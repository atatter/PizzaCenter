using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;

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
            return View(_uow.Components.All);
        }

        public ActionResult Create()
        {
            var vm = new ComponentsViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponentsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.MultiLangStrings.Add(vm.MultiLangString);
                _uow.Commit();
                Component component = new Component();
                component.NimetusId = vm.MultiLangString.MultiLangStringId;
                _uow.Components.Add(component);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

    }
}