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
    public class PriceTypesController : BaseController
    {

        private readonly IUOW _uow;

        public PriceTypesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/PriceTypes
        public ActionResult Index()
        {
            var vm = _uow.PriceTypes.All;
            return View(vm);
        }

        // GET: Admin/PriceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PriceTypesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.PriceType == null) vm.PriceType = new PriceType();

                vm.PriceType.PriceTypeName = new MultiLangString(vm.PriceTypeName, CultureHelper.GetCurrentNeutralUICulture(), vm.PriceTypeName, "");
                _uow.PriceTypes.Add(vm.PriceType);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/PriceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = _uow.PriceTypes.GetById(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }
            var vm = new PriceTypesCreateEditViewModel
            {
                PriceType = priceType,
                PriceTypeName = priceType.PriceTypeName.Translate()
            };
            return View(vm);
        }

        // POST: Admin/PriceTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PriceTypesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PriceType.PriceTypeName = _uow.MultiLangStrings.GetById(vm.PriceType.PriceTypeNameId);
                vm.PriceType.PriceTypeName.SetTranslation(vm.PriceTypeName, CultureHelper.GetCurrentNeutralUICulture(), "");
                _uow.PriceTypes.Update(vm.PriceType);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Admin/PriceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = _uow.PriceTypes.GetById(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }

            return View(priceType);
        }

        // POST: Admin/PriceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.PriceTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }
    }
}