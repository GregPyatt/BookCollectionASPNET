using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookCollectionASPNET.Models;

namespace BookCollectionASPNET.Controllers
{
    public class ScannedBooksController : Controller
    {
        private BookCollectionEntities db = new BookCollectionEntities();

        // GET: ScannedBooks
        public ActionResult Index()
        {
            return View(db.ScannedBooks.ToList());
        }

        // GET: ScannedBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScannedBook scannedBook = db.ScannedBooks.Find(id);
            if (scannedBook == null)
            {
                return HttpNotFound();
            }
            return View(scannedBook);
        }

        // GET: ScannedBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScannedBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,Authors,Categories,PublishedDate,Publisher,Pages,ISBN,IsRead,ReadingPeriods,Comments,Summary,CoverPath,IsAudioBook,OKToDonate")] ScannedBook scannedBook)
        {
            if (ModelState.IsValid)
            {
                db.ScannedBooks.Add(scannedBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scannedBook);
        }

        // GET: ScannedBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScannedBook scannedBook = db.ScannedBooks.Find(id);
            if (scannedBook == null)
            {
                return HttpNotFound();
            }
            return View(scannedBook);
        }

        // POST: ScannedBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,Authors,Categories,PublishedDate,Publisher,Pages,ISBN,IsRead,ReadingPeriods,Comments,Summary,CoverPath,IsAudioBook,OKToDonate")] ScannedBook scannedBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scannedBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scannedBook);
        }

        // GET: ScannedBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScannedBook scannedBook = db.ScannedBooks.Find(id);
            if (scannedBook == null)
            {
                return HttpNotFound();
            }
            return View(scannedBook);
        }

        // POST: ScannedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScannedBook scannedBook = db.ScannedBooks.Find(id);
            db.ScannedBooks.Remove(scannedBook);
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
