using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZazaInc.Models;

namespace ZazaInc.Controllers
{
    public class VacacionesController : Controller
    {
        private DBZazaIncEntities1 db = new DBZazaIncEntities1();

        // GET: Vacaciones
        public ActionResult Index()
        {
            var vacaciones = db.Vacaciones.Include(v => v.Empleado).Include(v => v.Usuario);
            return View(vacaciones.ToList());
        }

        // GET: Vacaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // GET: Vacaciones/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado");
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Vacaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vacaciones,fecha_inicio,fecha_final,id_usuario,id_empleado")] Vacacione vacacione)
        {
            if (ModelState.IsValid)
            {
                db.Vacaciones.Add(vacacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado", vacacione.id_empleado);
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", vacacione.id_usuario);
            return View(vacacione);
        }

        // GET: Vacaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado", vacacione.id_empleado);
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", vacacione.id_usuario);
            return View(vacacione);
        }

        // POST: Vacaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vacaciones,fecha_inicio,fecha_final,id_usuario,id_empleado")] Vacacione vacacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado", vacacione.id_empleado);
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", vacacione.id_usuario);
            return View(vacacione);
        }

        // GET: Vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacacione vacacione = db.Vacaciones.Find(id);
            db.Vacaciones.Remove(vacacione);
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
