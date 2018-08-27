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
    public class ProduktyController : Controller
    {
        private ProduktyContext db = new ProduktyContext();

        // GET: Produkty
        public ActionResult Index(string wyszukiwanie)
        {
            var produkty = from c in db.Produkty
                           select c;

            if(!String.IsNullOrEmpty(wyszukiwanie))
            {
                produkty = produkty.Where(s => s.Nazwa.Contains(wyszukiwanie));
            }

            return View(produkty.ToList());
        }

       /* public ActionResult Index()
        {
            var produkty = db.Produkty.Include(p => p.Kategorie);
            return View(produkty.ToList());
        }*/

        // GET: Produkty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkty.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // GET: Produkty/Create
        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.Kategorie, "Id", "NazwaKategorii");
            return View();
        }

        // POST: Produkty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,KategoriaId,Cena,Opis")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkty.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaId = new SelectList(db.Kategorie, "Id", "NazwaKategorii", produkt.KategoriaId);
            return View(produkt);
        }

        // GET: Produkty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkty.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.Kategorie, "Id", "NazwaKategorii", produkt.KategoriaId);
            return View(produkt);
        }

        // POST: Produkty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,KategoriaId,Cena,Opis")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.Kategorie, "Id", "NazwaKategorii", produkt.KategoriaId);
            return View(produkt);
        }

        // GET: Produkty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkty.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Produkty.Find(id);
            db.Produkty.Remove(produkt);
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
