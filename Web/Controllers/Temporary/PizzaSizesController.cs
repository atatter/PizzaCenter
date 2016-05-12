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

namespace Web.Controllers.Temporary
{
    public class PizzaSizesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: PizzaSizes
        public ActionResult Index()
        {
            return View(db.PizzaSizes.ToList());
        }

        // GET: PizzaSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaSize pizzaSize = db.PizzaSizes.Find(id);
            if (pizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(pizzaSize);
        }

        // GET: PizzaSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PizzaSizeId,Size,Diameter")] PizzaSize pizzaSize)
        {
            if (ModelState.IsValid)
            {
                db.PizzaSizes.Add(pizzaSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizzaSize);
        }

        // GET: PizzaSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaSize pizzaSize = db.PizzaSizes.Find(id);
            if (pizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(pizzaSize);
        }

        // POST: PizzaSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PizzaSizeId,Size,Diameter")] PizzaSize pizzaSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizzaSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizzaSize);
        }

        // GET: PizzaSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaSize pizzaSize = db.PizzaSizes.Find(id);
            if (pizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(pizzaSize);
        }

        // POST: PizzaSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaSize pizzaSize = db.PizzaSizes.Find(id);
            db.PizzaSizes.Remove(pizzaSize);
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
