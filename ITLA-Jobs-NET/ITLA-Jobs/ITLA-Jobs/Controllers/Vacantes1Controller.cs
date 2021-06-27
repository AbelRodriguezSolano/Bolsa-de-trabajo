using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITLA_Jobs.Models;

namespace ITLA_Jobs.Controllers
{
    public class Vacantes1Controller : Controller
    {
        private BolsaTrabajoEntities db = new BolsaTrabajoEntities();

        // GET: Vacantes1
        public ActionResult Index()
        {
            var vacante = db.Vacante.Include(v => v.Categoria1);
            return View(vacante.ToList());
        }

        // GET: Vacantes1/Details/5
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

        // GET: Vacantes1/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "nombre");
            return View();
        }

        // POST: Vacantes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Company,Direccion_url,Logo,Posicion,Ubicacion,Descripcion,FechaRegistro,CorreoAplicar,Categoria,EmailUsuario")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Vacante.Add(vacante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "nombre", vacante.Categoria);
            return View(vacante);
        }

        // GET: Vacantes1/Edit/5
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
            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "nombre", vacante.Categoria);
            return View(vacante);
        }

        // POST: Vacantes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Company,Direccion_url,Logo,Posicion,Ubicacion,Descripcion,FechaRegistro,CorreoAplicar,Categoria,EmailUsuario")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "nombre", vacante.Categoria);
            return View(vacante);
        }

        // GET: Vacantes1/Delete/5
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

        // POST: Vacantes1/Delete/5
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
