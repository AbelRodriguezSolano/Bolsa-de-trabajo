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
using System.IO;

namespace ITLA_Jobs.Controllers
{
    public class VacantesController : Controller
    {
        private BolsaTrabajoEntities db = new BolsaTrabajoEntities();

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
                if (vacante.LogoFile!=null)
                {
                    string nombreLogo = Path.GetFileNameWithoutExtension(vacante.LogoFile.FileName);
                    string extension = Path.GetExtension(vacante.LogoFile.FileName);
                    nombreLogo = nombreLogo + DateTime.Now.ToString("yymmssfff") + extension;
                    vacante.Logo = nombreLogo;
                    nombreLogo = Path.Combine(Server.MapPath("~/Logos/"), nombreLogo);
                    vacante.LogoFile.SaveAs(nombreLogo);
                }
                
            } 
            catch (Exception)
            {

            }
            finally 
            {
                if (ModelState.IsValid)
                {
                    vacante.FechaRegistro = DateTime.Today;
                    vacante.EmailUsuario = User.Identity.GetUserName();
                    db.Vacante.Add(vacante);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", vacante);  

            //HttpPostedFileBase http = Request.Files[0];
            //WebImage imagen = new WebImage(http.InputStream);

            //vacante.Logo = imagen.GetBytes();
        }

        // GET: Vacantes/Edit/5
        [Authorize]
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
        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Company,Direccion_url,Logo,Posicion,Ubicacion,Descripcion,FechaRegistro,CorreoAplicar,Categoria,EmailUsuario")] Vacante vacante, HttpPostedFileBase LogoFile)
        {
            try
            {
                if (LogoFile != null)
                {
                    string nombreLogo = Path.GetFileNameWithoutExtension(LogoFile.FileName);
                    string extension = Path.GetExtension(LogoFile.FileName);
                    nombreLogo = nombreLogo + DateTime.Now.ToString("yymmssfff") + extension;
                    vacante.Logo = nombreLogo;
                    vacante.LogoFile = LogoFile;
                    nombreLogo = Path.Combine(Server.MapPath("~/Logos/"), nombreLogo);
                    vacante.LogoFile.SaveAs(nombreLogo);
                }
                
            }
            catch (Exception)
            {

            }
            finally
            {
                if (ModelState.IsValid)
                {
                    vacante.FechaRegistro = DateTime.Today;
                    vacante.EmailUsuario = User.Identity.GetUserName();
                    db.Entry(vacante).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
                
            return RedirectToAction("MisVacantes", vacante);
        }

        // GET: Vacantes/Delete/5
        [Authorize]
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
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacante vacante = db.Vacante.Find(id);
            db.Vacante.Remove(vacante);
            db.SaveChanges();
            return RedirectToAction("MisVacantes");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult MisVacantes()
        {
            return View(from datos in db.Vacante.ToList() where datos.EmailUsuario == User.Identity.GetUserName() select datos);
        }
    }
}
