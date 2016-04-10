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
    public class MultiLangStringsController : BaseController
    {
        private PizzaDbContext db = new PizzaDbContext();

        // GET: MultiLangStrings
        public ActionResult Index()
        {
            return View(db.MultiLangStrings.ToList());
        }

        // GET: MultiLangStrings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiLangString multiLangString = db.MultiLangStrings.Find(id);
            if (multiLangString == null)
            {
                return HttpNotFound();
            }
            return View(multiLangString);
        }

        // GET: MultiLangStrings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultiLangStrings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MultiLangStringId,Value,Owner")] MultiLangString multiLangString)
        {
            if (ModelState.IsValid)
            {
                db.MultiLangStrings.Add(multiLangString);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multiLangString);
        }

        // GET: MultiLangStrings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiLangString multiLangString = db.MultiLangStrings.Find(id);
            if (multiLangString == null)
            {
                return HttpNotFound();
            }
            return View(multiLangString);
        }

        // POST: MultiLangStrings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MultiLangStringId,Value,Owner")] MultiLangString multiLangString)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiLangString).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multiLangString);
        }

        // GET: MultiLangStrings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiLangString multiLangString = db.MultiLangStrings.Find(id);
            if (multiLangString == null)
            {
                return HttpNotFound();
            }
            return View(multiLangString);
        }

        // POST: MultiLangStrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultiLangString multiLangString = db.MultiLangStrings.Find(id);
            db.MultiLangStrings.Remove(multiLangString);
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
