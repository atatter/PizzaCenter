using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class TranslationsController : BaseController
    {
        private PizzaDbContext db = new PizzaDbContext();

        // GET: Translations
        public ActionResult Index()
        {
            var translations = db.Translations.Include(t => t.MultiLangString);
            return View(translations.ToList());
        }

        // GET: Translations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translation translation = db.Translations.Find(id);
            if (translation == null)
            {
                return HttpNotFound();
            }
            return View(translation);
        }

        // GET: Translations/Create
        public ActionResult Create()
        {
            ViewBag.MultiLangStringId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value");
            return View();
        }

        // POST: Translations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TranslationId,Value,MultiLangStringId,Culture")] Translation translation)
        {
            if (ModelState.IsValid)
            {
                db.Translations.Add(translation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MultiLangStringId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value", translation.MultiLangStringId);
            return View(translation);
        }

        // GET: Translations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translation translation = db.Translations.Find(id);
            if (translation == null)
            {
                return HttpNotFound();
            }
            ViewBag.MultiLangStringId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value", translation.MultiLangStringId);
            return View(translation);
        }

        // POST: Translations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TranslationId,Value,MultiLangStringId,Culture")] Translation translation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(translation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultiLangStringId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value", translation.MultiLangStringId);
            return View(translation);
        }

        // GET: Translations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translation translation = db.Translations.Find(id);
            if (translation == null)
            {
                return HttpNotFound();
            }
            return View(translation);
        }

        // POST: Translations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Translation translation = db.Translations.Find(id);
            db.Translations.Remove(translation);
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
