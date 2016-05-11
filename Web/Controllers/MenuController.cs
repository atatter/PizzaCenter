using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;

namespace Web.Controllers
{
    public class MenuController : Controller
    {
        private IUOW _uow;

        public MenuController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Menu
        public ActionResult Index()
        {
            return View(_uow.Pizzas.All);
        }
    }
}