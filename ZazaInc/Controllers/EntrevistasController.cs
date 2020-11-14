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
    public class EntrevistasController : Controller
    {
        private DBZazaIncEntities1 db = new DBZazaIncEntities1();

        // GET: Entrevistas
        public ActionResult Index()
        {
            var entrevistas = db.Entrevistas.Include(e => e.Solicitante).Include(e => e.Usuario);
            return View(entrevistas.ToList());
        }

        // GET: Entrevistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrevista entrevista = db.Entrevistas.Find(id);
            if (entrevista == null)
            {
                return HttpNotFound();
            }
            return View(entrevista);
        }

        // GET: Entrevistas/Create
        public ActionResult Create()
        {
            ViewBag.Id_solicitante = new SelectList(db.Solicitantes, "id_Solicitante", "nombre_Solicitante");
            ViewBag.Id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Entrevistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Entrevista,Id_usuario,Id_solicitante,notas")] Entrevista entrevista)
        {
            if (ModelState.IsValid)
            {
                db.Entrevistas.Add(entrevista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_solicitante = new SelectList(db.Solicitantes, "id_Solicitante", "nombre_Solicitante", entrevista.Id_solicitante);
            ViewBag.Id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", entrevista.Id_usuario);
            return View(entrevista);
        }

        // GET: Entrevistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrevista entrevista = db.Entrevistas.Find(id);
            if (entrevista == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_solicitante = new SelectList(db.Solicitantes, "id_Solicitante", "nombre_Solicitante", entrevista.Id_solicitante);
            ViewBag.Id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", entrevista.Id_usuario);
            return View(entrevista);
        }

        // POST: Entrevistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Entrevista,Id_usuario,Id_solicitante,notas")] Entrevista entrevista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrevista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_solicitante = new SelectList(db.Solicitantes, "id_Solicitante", "nombre_Solicitante", entrevista.Id_solicitante);
            ViewBag.Id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", entrevista.Id_usuario);
            return View(entrevista);
        }

        // GET: Entrevistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrevista entrevista = db.Entrevistas.Find(id);
            if (entrevista == null)
            {
                return HttpNotFound();
            }
            return View(entrevista);
        }

        // POST: Entrevistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrevista entrevista = db.Entrevistas.Find(id);
            db.Entrevistas.Remove(entrevista);
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
