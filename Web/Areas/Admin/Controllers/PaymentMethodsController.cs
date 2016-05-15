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
    public class PaymentMethodsController : BaseController
    {

        private readonly IUOW _uow;

        public PaymentMethodsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/PaymentMethods
        public ActionResult Index()
        {
            var vm = _uow.PaymentMethods.All;
            return View(vm);
        }

        // GET: Admin/PaymentMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentMethodsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.PaymentMethod == null) vm.PaymentMethod = new PaymentMethod();

                vm.PaymentMethod.PaymentMethodName = new MultiLangString(vm.PaymentMethodName, CultureHelper.GetCurrentNeutralUICulture(), vm.PaymentMethodName, "");
                _uow.PaymentMethods.Add(vm.PaymentMethod);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/PaymentMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = _uow.PaymentMethods.GetById(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            var vm = new PaymentMethodsCreateEditViewModel()
            {
                PaymentMethod = paymentMethod,
                PaymentMethodName = paymentMethod.PaymentMethodName.Translate()
            };
            return View(vm);
        }

        // POST: Admin/PaymentMethods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaymentMethodsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PaymentMethod.PaymentMethodName = _uow.MultiLangStrings.GetById(vm.PaymentMethod.PaymentMethodNameId);
                vm.PaymentMethod.PaymentMethodName.SetTranslation(vm.PaymentMethodName, CultureHelper.GetCurrentNeutralUICulture(), "");
                _uow.PaymentMethods.Update(vm.PaymentMethod);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/PaymentMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = _uow.PaymentMethods.GetById(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.PaymentMethods.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }
    }
}