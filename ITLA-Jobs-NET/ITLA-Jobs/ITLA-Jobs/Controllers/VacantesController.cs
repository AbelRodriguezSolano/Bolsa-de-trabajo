using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using ITLA_Jobs.Models;

namespace ITLA_Jobs.Controllers
{
    public class VacantesController : Controller
    {
        private BolsaTrabajoEntities db = new BolsaTrabajoEntities();

        public List<Categoria> listadoCategorias()
        {
            return db.Categoria.ToList();
        }

        // GET: Vacantes
        public ActionResult Index()
        {
            return View(db.Vacante.ToList());
        }

        // GET: Vacantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // GET: Vacantes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Vacante vacante)
        {
            try
            {
                HttpPostedFileBase http = Request.Files[0];
                WebImage imagen = new WebImage(http.InputStream);

                vacante.Logo = imagen.GetBytes();
            } 
            catch (Exception)
            {

            }
            finally
            {
                if (ModelState.IsValid)
                {
                    vacante.EmailUsuario = User.Identity.GetUserName();
                    db.Vacante.Add(vacante);
                    db.SaveChanges();
                }
            }
                    return RedirectToAction("Index", vacante);  
        }

        // GET: Vacantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Company,Direccion_url,Logo,Posicion,Ubicacion,Descripcion,FechaRegistro,CorreoAplicar,Categoria,Estado,EmailUsuario")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacante);
        }

        // GET: Vacantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // POST: Vacantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacante vacante = db.Vacante.Find(id);
            db.Vacante.Remove(vacante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
