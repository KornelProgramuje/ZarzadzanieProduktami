using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieProduktami.DAL;
using ZarzadzanieProduktami.Models;

namespace ZarzadzanieProduktami.Controllers
{
    public class KategorieController : Controller
    {
        private ProduktyContext db = new ProduktyContext();

        // GET: Kategorie
        public ActionResult Index()
        {
            return View(db.Kategorie.ToList());
        }

        // GET: Kategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorie.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // GET: Kategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaKategorii")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Kategorie.Add(kategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoria);
        }

        // GET: Kategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorie.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // POST: Kategorie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaKategorii")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoria);
        }

        // GET: Kategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorie.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // POST: Kategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoria kategoria = db.Kategorie.Find(id);
            db.Kategorie.Remove(kategoria);
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
