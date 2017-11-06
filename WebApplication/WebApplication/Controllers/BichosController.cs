using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models.Contexto;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BichosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Bichos
        public ActionResult Index()
        {
            return View(db.Bichoes.ToList());
        }

        // GET: Bichos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicho bicho = db.Bichoes.Find(id);
            if (bicho == null)
            {
                return HttpNotFound();
            }
            return View(bicho);
        }

        // GET: Bichos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bichos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BichoID,Nome,Descricao,Forca")] Bicho bicho)
        {
            if (ModelState.IsValid)
            {
                db.Bichoes.Add(bicho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bicho);
        }

        // GET: Bichos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicho bicho = db.Bichoes.Find(id);
            if (bicho == null)
            {
                return HttpNotFound();
            }
            return View(bicho);
        }

        // POST: Bichos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BichoID,Nome,Descricao,Forca")] Bicho bicho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bicho);
        }

        // GET: Bichos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicho bicho = db.Bichoes.Find(id);
            if (bicho == null)
            {
                return HttpNotFound();
            }
            return View(bicho);
        }

        // POST: Bichos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicho bicho = db.Bichoes.Find(id);
            db.Bichoes.Remove(bicho);
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
