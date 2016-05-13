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
using Web.Helpers;

namespace Web.Areas.Admin.Controllers
{
    public class PizzasController : Controller
    {
        private IUOW _uow;

        public PizzasController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Pizzas
        public ActionResult Index()
        {
            var vm = _uow.Pizzas.All;

            return View(vm);
        }

        // GET: Admin/Pizzas/Create
        public ActionResult Create()
        {
            var vm = new PizzaViewModels
            {
                //Components = new SelectList(_uow.Components.All, nameof(Component.ComponentId), nameof(Component.ComponentName)),
                Components = _uow.Components.All,
                PriceTypes = new SelectList(_uow.PriceTypes.All, nameof(PriceType.PriceTypeId), nameof(PriceType.PriceTypeName))
            };
            
            return View(vm);
        }

        // POST: Admin/Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaViewModels vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.Pizza == null) vm.Pizza = new Pizza();

                vm.Pizza.PizzaName = new MultiLangString(vm.PizzaName, CultureHelper.GetCurrentNeutralUICulture(), vm.PizzaName, "");
                _uow.Pizzas.Add(vm.Pizza);
                _uow.Commit();
                return RedirectToAction("Index");
            }


            return View(vm);
        }

        // GET: Admin/Pizzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = _uow.Pizzas.GetById(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            var vm = new PizzaViewModels()
            {
                Pizza = pizza,
                PizzaName = pizza.PizzaName.Translate()
            };
            return View(vm);
        }

        // POST: Admin/Pizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PizzaViewModels vm)
        {
            if (ModelState.IsValid)
            {
                vm.Pizza.PizzaName = _uow.MultiLangStrings.GetById(vm.Pizza.PizzaNameId);
                vm.Pizza.PizzaName.SetTranslation(vm.PizzaName, CultureHelper.GetCurrentNeutralUICulture(), "");
                _uow.Pizzas.Update(vm.Pizza);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Admin/Pizzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = _uow.Pizzas.GetById(id);
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
            Pizza pizza = _uow.Pizzas.GetById(id);
            _uow.Pizzas.Delete(pizza);
            _uow.Commit();
            return RedirectToAction("Index");
        }
    }
}
