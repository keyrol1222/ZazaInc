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
    public class TerminarsController : Controller
    {
        private DBZazaIncEntities2 db = new DBZazaIncEntities2();

        // GET: Terminars
        public ActionResult Index()
        {
            var terminars = db.Terminars.Include(t => t.Empleado).Include(t => t.Usuario);
            return View(terminars.ToList());
        }

        // GET: Terminars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminar terminar = db.Terminars.Find(id);
            if (terminar == null)
            {
                return HttpNotFound();
            }
            return View(terminar);
        }

        // GET: Terminars/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado");
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Terminars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Terminar,id_usuario,id_empleado,razon")] Terminar terminar)
        {
            if (ModelState.IsValid)
            {
                db.Terminars.Add(terminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado", terminar.id_empleado);
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", terminar.id_usuario);
            return View(terminar);
        }

        // GET: Terminars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminar terminar = db.Terminars.Find(id);
            if (terminar == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado", terminar.id_empleado);
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", terminar.id_usuario);
            return View(terminar);
        }

        // POST: Terminars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Terminar,id_usuario,id_empleado,razon")] Terminar terminar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleadoes, "id_empleado", "nombre_empleado", terminar.id_empleado);
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", terminar.id_usuario);
            return View(terminar);
        }

        // GET: Terminars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminar terminar = db.Terminars.Find(id);
            if (terminar == null)
            {
                return HttpNotFound();
            }
            return View(terminar);
        }

        // POST: Terminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terminar terminar = db.Terminars.Find(id);
            db.Terminars.Remove(terminar);
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
