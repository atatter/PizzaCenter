using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DAL.Interfaces;
using Domain;
using Domain.Identity;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoicesController : BaseController
    {
        private readonly IUOW _uow;

        public InvoicesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Invoices
        public ActionResult Index()
        {
            var vm = _uow.Invoices.All;
            return View(vm);
        }

        // GET: Admin/Invoices/Create
        public ActionResult Create()
        {
            var vm = new InvoicesCreateEditViewModel
            {
                Coupons = new SelectList(_uow.Coupons.All, nameof(Coupon.CouponId), nameof(Coupon.Code)),
                PaymentMethods = new SelectList(_uow.PaymentMethods.All, nameof(PaymentMethod.PaymentMethodId), nameof(PaymentMethod.PaymentMethodName)),
                UserInts = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName))
            };
            return View(vm);
        }

        // POST: Admin/Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoicesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Invoice == null) vm.Invoice = new Invoice();
                vm.Invoice.CouponId = vm.CouponId;
                vm.Invoice.UserIntId = vm.UserIntId;
                vm.Invoice.PaymentMethodId = vm.PaymentMethodId;
                vm.Invoice.CustomersPhone = vm.PhoneNr;
                vm.Invoice.CreationTime = vm.Date;
                vm.Invoice.SumBeforeCoupon = vm.SUM;
                vm.Invoice.SumAfterCoupon = vm.SUM;

                _uow.Invoices.Add(vm.Invoice);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            vm.Coupons = new SelectList(_uow.Coupons.All, nameof(Coupon.CouponId), nameof(Coupon.Code), vm.CouponId);
            vm.PaymentMethods = new SelectList(_uow.PaymentMethods.All, nameof(PaymentMethod.PaymentMethodId), nameof(PaymentMethod.PaymentMethodName), vm.PaymentMethodId);
            vm.UserInts = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName), vm.UserIntId);

            return View(vm);
        }

        // GET: Admin/Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = _uow.Invoices.GetById(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            var vm = new InvoicesCreateEditViewModel()
            {
                Invoice = invoice,
                Date = invoice.CreationTime,
                PhoneNr = invoice.CustomersPhone,
                PaymentMethodId = invoice.PaymentMethodId,
                CouponId = invoice.CouponId,
                UserIntId = invoice.UserIntId,
                SUM = invoice.SumAfterCoupon,
                Coupons = new SelectList(_uow.Coupons.All, nameof(Coupon.CouponId), nameof(Coupon.Code), invoice.CouponId),
                PaymentMethods = new SelectList(_uow.PaymentMethods.All, nameof(PaymentMethod.PaymentMethodId), nameof(PaymentMethod.PaymentMethodName)),
                UserInts = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName), invoice.UserIntId)
            };

            return View(vm);
        }

        // POST: Admin/Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoicesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Invoices.Update(new Invoice()
                {
                    CouponId = vm.CouponId,
                    CreationTime = vm.Date,
                    CustomersPhone = vm.PhoneNr,
                    InvoiceId = vm.Invoice.InvoiceId,
                    PaymentMethodId = vm.PaymentMethodId,
                    UserIntId = vm.UserIntId,
                    //MUUTA!!!!!!!!!!!
                    SumAfterCoupon = vm.SUM
                });
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }


            return View(vm);
        }

        // GET: Admin/Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // POST: Admin/Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}