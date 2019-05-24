using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ReparacionesWeb.Models;

namespace ReparacionesWeb.Controllers
{
    public class ReparacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reparacions
        public ActionResult Index()
        {
            var reparacions = db.Reparacions.Include(r => r.Cliente);
            return View(reparacions.OrderByDescending(f => f.ReparacionID).ToList());
        }

        // GET: Reparacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparacion reparacion = db.Reparacions.Find(id);
            if (reparacion == null)
            {
                return HttpNotFound();
            }
            return View(reparacion);
        }

        // GET: Reparacions/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "ApeNombre");
            return View();
        }

        // POST: Reparacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReparacionID,DetalleEquipo,FechaRecepcion,Diagnostico,Observaciones,CostoReparacion,EstadoReparacion,FechaPago,ClienteID")] Reparacion reparacion)
        {
            if (ModelState.IsValid)
            {
                db.Reparacions.Add(reparacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "ApeNombre", reparacion.ClienteID);
            return View(reparacion);
        }

        // GET: Reparacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparacion reparacion = db.Reparacions.Find(id);
            if (reparacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "ApeNombre", reparacion.ClienteID);
            return View(reparacion);
        }

        // POST: Reparacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReparacionID,DetalleEquipo,FechaRecepcion,Diagnostico,Observaciones,CostoReparacion,EstadoReparacion,FechaPago,ClienteID")] Reparacion reparacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "ApeNombre", reparacion.ClienteID);
            return View(reparacion);
        }

        // GET: Reparacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparacion reparacion = db.Reparacions.Find(id);
            if (reparacion == null)
            {
                return HttpNotFound();
            }
            return View(reparacion);
        }

        // POST: Reparacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparacion reparacion = db.Reparacions.Find(id);
            db.Reparacions.Remove(reparacion);
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
