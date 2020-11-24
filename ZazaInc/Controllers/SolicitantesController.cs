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
    public class SolicitantesController : Controller
    {
        private DBZazaIncEntities2 db = new DBZazaIncEntities2();

        // GET: Solicitantes
        public ActionResult Index()
        {
            return View(db.Solicitantes.ToList());
        }
        public ActionResult VistaS()
        {
            return View(db.Solicitantes.ToList());
        }
        // GET: Solicitantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitantes.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Solicitante,nombre_Solicitante,apellido_Solicitante,cedula_Solicitante,correo_Solicitante")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Solicitantes.Add(solicitante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solicitante);
        }

        // GET: Solicitantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitantes.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Solicitante,nombre_Solicitante,apellido_Solicitante,cedula_Solicitante,correo_Solicitante")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitantes.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitante solicitante = db.Solicitantes.Find(id);
            db.Solicitantes.Remove(solicitante);
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
