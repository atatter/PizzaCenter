using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    public class CouponsController : BaseController
    {
        private readonly IUOW _uow;

        public CouponsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Coupons
        public ActionResult Index()
        {
            var vm = _uow.Coupons.All;
            return View(vm);
        }

        // GET: Admin/Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Coupons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CouponsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Coupon == null) vm.Coupon = new Coupon();
                _uow.Coupons.Add(vm.Coupon);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Coupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = _uow.Coupons.GetById(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            var vm = new CouponsCreateEditViewModel()
            {
                Coupon =  coupon
            };

            return View(vm);
        }

        // POST: Admin/Coupons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CouponsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Coupons.Update(vm.Coupon);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Coupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = _uow.Coupons.GetById(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Admin/Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Coupons.Delete(id);
            _uow.Commit();
            return RedirectToAction(nameof(Index));
        }

    }
}