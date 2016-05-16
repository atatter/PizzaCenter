using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using DAL;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Helpers;
using WebGrease.Css.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PizzasController : BaseController
    {
        private IUOW _uow;

        public PizzasController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Pizzas
        public ActionResult Index()
        {
            var vm = new PizzaIndexViewModel()
            {
                Pizzas = _uow.Pizzas.All,
                ThePizzaSizes = _uow.PizzaSizes.All,
                ThePriceTypes = _uow.PriceTypes.All,
                ThePrices = _uow.Prices.All
            };

            return View(vm);
        }

        // GET: Admin/Pizzas/Create
        public ActionResult Create()
        {
            var vm = new PizzaViewModels
            {
                ComponentSelectList = new MultiSelectList(_uow.Components.All, nameof(Component.ComponentId), nameof(Component.ComponentName)),
                PizzaSizesList = _uow.PizzaSizes.All,
                PriceTypesList = _uow.PriceTypes.All
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
                if (vm.ComponentSelectListId != null)
                {
                    //Olemas ComponentSelectListId valitud komponentidega
                    foreach (var compId in vm.ComponentSelectListId)
                    {
                        _uow.ComponentInPizzas.Add(new ComponentInPizza(vm.Pizza.PizzaId, compId));
                    }
                }
                vm.Pizza.PizzaName = new MultiLangString(vm.PizzaName, CultureHelper.GetCurrentNeutralUICulture(), vm.PizzaName, "");
                _uow.Pizzas.Add(vm.Pizza);
                _uow.Commit();
                if(vm.ThePrice != null) { 
                    for (int i = 0; i < vm.ThePrice.Length; i++)
                    {
                        if(vm.ThePrice[i] != null) { 
                            _uow.Prices.Add(new Price()
                            {
                                Value = vm.ThePrice[i].Value,
                                PizzaSizeId = vm.ThePizzaSizeId[i],
                                PriceTypeId = vm.ThePriceTypeId[i] ?? default(int),
                                PizzaId = vm.Pizza.PizzaId
                            });
                        }
                    }
                }
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.ComponentSelectList = new MultiSelectList(_uow.Components.All, nameof(Component.ComponentId), nameof(Component.ComponentName));
            vm.PizzaSizesList = _uow.PizzaSizes.All;
            vm.PriceTypesList = _uow.PriceTypes.All;
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
            var selected = pizza.ComponentInPizzas.Select(x => x.ComponentId);

            //Kõik hinnad mis on seotud selle pizzaga
            var prices = _uow.Prices.All.Where(x => x.PizzaId == id).ToArray();

            //Kõik võimalikud hinnad sellele pizzale
            List<double?> thePrices = new List<double?>();
            foreach (var size in _uow.PizzaSizes.All)
            {
                var y = 0;
                foreach (var pricetype in _uow.PriceTypes.All)
                {
                    var query = prices.Where(x => x.PizzaSizeId == size.PizzaSizeId && x.PriceTypeId == pricetype.PriceTypeId).ToList();
                    if (query.Any())
                    {
                        thePrices.Add(query.FirstOrDefault().Value);
                    }
                    else
                    {
                        thePrices.Add(null);
                    }
                    y++;
                }
            }

            var vm = new PizzaViewModels()
            {
                Pizza = pizza,
                PizzaName = pizza.PizzaName.Translate(),
                PizzaSizesList = _uow.PizzaSizes.All,
                PriceTypesList = _uow.PriceTypes.All,
                ComponentSelectListId = selected.ToArray(),
                ComponentSelectList = new MultiSelectList(_uow.Components.All, nameof(Component.ComponentId), nameof(Component.ComponentName)),
                ThePrice = thePrices.ToArray()
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
                _uow.ComponentInPizzas.All.Where(x => x.PizzaId == vm.Pizza.PizzaId).ForEach(x => _uow.ComponentInPizzas.Delete(x));
                if (vm.ComponentSelectListId != null)
                {
                    //Olemas ComponentSelectListId valitud komponentidega
                    foreach (var compId in vm.ComponentSelectListId)
                    {
                        _uow.ComponentInPizzas.Add(new ComponentInPizza(vm.Pizza.PizzaId, compId));
                    }
                }
                vm.Pizza.PizzaName = _uow.MultiLangStrings.GetById(vm.Pizza.PizzaNameId);
                vm.Pizza.PizzaName.SetTranslation(vm.PizzaName, CultureHelper.GetCurrentNeutralUICulture(), "");
                _uow.Pizzas.Update(vm.Pizza);
                _uow.Commit();


                _uow.Prices.All.Where(x => x.PizzaId == vm.Pizza.PizzaId).ForEach(x => _uow.Prices.Delete(x));
                for (int i = 0; i < vm.ThePrice.Length; i++)
                {
                    if (vm.ThePrice[i] != null)
                    {
                        _uow.Prices.Add(new Price()
                        {
                            Value = vm.ThePrice[i].Value,
                            PizzaSizeId = vm.ThePizzaSizeId[i],
                            PriceTypeId = vm.ThePriceTypeId[i] ?? default(int),
                            PizzaId = vm.Pizza.PizzaId
                        });
                    }
                }
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
