using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Web.Areas.Admin.ViewModels;
using System.Net;
using Domain;
using Web.Controllers;
using Web.Helpers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PizzaSizesController : BaseController
    {

        private readonly IUOW _uow;        

        public PizzaSizesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/PizzaSizes
        public ActionResult Index()
        {
            return View(_uow.PizzaSizes.All);
        }

        // GET: Admin/PizzaSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaSizesVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.PizzaSize == null) vm.PizzaSize = new PizzaSize();

                vm.PizzaSize.PizzaSizeName = new MultiLangString(vm.PizzaSizeName, CultureHelper.GetCurrentNeutralUICulture(), vm.PizzaSizeName, "");               
                _uow.PizzaSizes.Add(vm.PizzaSize);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/PizzaSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaSize pizzaSize = _uow.PizzaSizes.GetById(id);
            if (pizzaSize == null)
            {
                return HttpNotFound();
            }
            var vm = new PizzaSizesVM
            {
                PizzaSize = pizzaSize,
                PizzaSizeName = pizzaSize.PizzaSizeName.Translate()
            };
            return View(vm);
        }

        // POST: Admin/PizzaSizes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PizzaSizesVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.PizzaSize.PizzaSizeName = _uow.MultiLangStrings.GetById(vm.PizzaSize.PizzaSizeNameId);
                vm.PizzaSize.PizzaSizeName.SetTranslation(vm.PizzaSizeName, CultureHelper.GetCurrentNeutralUICulture(), "");
                _uow.PizzaSizes.Update(vm.PizzaSize);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/PizzaSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaSize pizzaSize = _uow.PizzaSizes.GetById(id);
            if (pizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(pizzaSize);
        }

        // POST: Admin/PizzaSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.PizzaSizes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }
    }
}