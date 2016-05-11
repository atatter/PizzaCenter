using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;

namespace Web.Areas.Admin.Controllers
{
    public class PizzasController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        private IUOW _uow;

        public PizzasController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Pizzas
        public ActionResult Index()
        {
            var pizzas = db.Pizzas.Include(p => p.PizzaDescription);

            return View(_uow.Pizzas.All);
        }

        // GET: Admin/Pizzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // GET: Admin/Pizzas/Create
        public ActionResult Create()
        {
            var vm = new PizzaViewModels();

            //ViewBag.PizzaDescriptionId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value");
            //ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "PaymentMethodId","Name");
            return View(vm);
        }

        // POST: Admin/Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaViewModels pizzaViewModels)
        {
            if (ModelState.IsValid)
            {
                _uow.MultiLangStrings.Add(pizzaViewModels.MultiLangString);
                _uow.Commit();
                pizzaViewModels.Pizza.PizzaDescriptionId = pizzaViewModels.MultiLangString.MultiLangStringId;
                _uow.Pizzas.Add(pizzaViewModels.Pizza);
                _uow.Commit();
                return RedirectToAction("Index");
            }


            return View(pizzaViewModels);
        }

        // GET: Admin/Pizzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            ViewBag.PizzaDescriptionId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value", pizza.PizzaDescriptionId);
            return View(pizza);
        }

        // POST: Admin/Pizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PizzaId,Name,PizzaDescriptionId")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PizzaDescriptionId = new SelectList(db.MultiLangStrings, "MultiLangStringId", "Value", pizza.PizzaDescriptionId);
            return View(pizza);
        }

        // GET: Admin/Pizzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Admin/Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            db.Pizzas.Remove(pizza);
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
