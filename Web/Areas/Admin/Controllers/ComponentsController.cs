using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Helpers;

namespace Web.Areas.Admin.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly IUOW _uow;

        public ComponentsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Components
        public ActionResult Index()
        {
            var vm = _uow.Components.All;
            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Components/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponentsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Component == null) vm.Component = new Component();

                vm.Component.ComponentName = new MultiLangString(vm.ComponentName, CultureHelper.GetCurrentNeutralUICulture(), vm.ComponentName, "");
                _uow.Components.Add(vm.Component);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Admin/Components/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = _uow.Components.GetById(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            var vm = new ComponentsCreateEditViewModel
            {
                Component = component,
                ComponentName = component.ComponentName.Translate()
            };
            return View(vm);
        }

        // POST: Admin/Components/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComponentsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Component.ComponentName = _uow.MultiLangStrings.GetById(vm.Component.ComponentNameId);
                vm.Component.ComponentName.SetTranslation(vm.ComponentName, CultureHelper.GetCurrentNeutralUICulture(), "");
                _uow.Components.Update(vm.Component);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = _uow.Components.GetById(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Admin/Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Components.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }
    }
}