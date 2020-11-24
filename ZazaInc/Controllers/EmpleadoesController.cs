using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZazaInc.Models;

namespace ZazaInc.Controllers
{
    public class EmpleadoesController : Controller
    {
        private DBZazaIncEntities2 db = new DBZazaIncEntities2();

        // GET: Empleadoes
        public ActionResult Index()
        {
            return View(db.Empleadoes.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_empleado,nombre_empleado,apellido_empleado,posicion_empleado,cedula_empleado,correo_usuario,pago_empleado,horario_empleado,departamento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                 
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_empleado,nombre_empleado,apellido_empleado,posicion_empleado,cedula_empleado,correo_usuario,pago_empleado,horario_empleado,departamento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }
        public void ExportCSV_Employee()
        {
            var sb = new StringBuilder();
            // You can write sql query according your need  
            string qry = ("Select * from Empleado");
            IEnumerable<Empleado> query = db.Database.SqlQuery<Empleado>(qry);
            var list = query.ToList();

            sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", "id", "nombre", "apellido", "posicion", "cedula", "correo", "pago", "horario", "departamento", Environment.NewLine);
            foreach (var item in list)
            {
                sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", item.id_empleado, item.nombre_empleado, item.apellido_empleado, item.posicion_empleado, item.cedula_empleado, item.correo_usuario, item.pago_empleado,item.horario_empleado,item.departamento, Environment.NewLine);
            }
            //Get Current Response  
            var response = System.Web.HttpContext.Current.Response;
            response.BufferOutput = true;
            response.Clear();
            response.ClearHeaders();
            response.ContentEncoding = Encoding.Unicode;
            response.AddHeader("content-disposition", "attachment;filename=Employee.CSV ");
            response.ContentType = "text/plain";
            response.Write(sb.ToString());
            response.End();
        }



        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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
