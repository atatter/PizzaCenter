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
    //[Authorize(Roles = "Admin")]
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
                UserInts = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName)),
                Components = new SelectList(_uow.Components.All.Where(x => x.IsTopping == true), nameof(Component.ComponentId), nameof(Component.ComponentName)),
                Pizzas = new SelectList(_uow.Pizzas.All, nameof(Pizza.PizzaId), nameof(Pizza.PizzaName)),
                Sizes = new SelectList(_uow.PizzaSizes.All, nameof(PizzaSize.PizzaSizeId), nameof(PizzaSize.PizzaSizeName))
            };
            return View(vm);
        }

        // POST: Admin/Invoices/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoicesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Orders == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                if (vm.Invoice == null) vm.Invoice = new Invoice();
                var managedOrders = new List<ManagedOrder>();

                foreach (var order in vm.Orders.Where(x => x.Deleted == false && x.Pizzas != null))
                {
                    managedOrders.Add(new ManagedOrder() {People = order.People, ThePizzas = order.Pizzas.Where(x => x.Deleted == false).ToList()});
                }
                var doneOrders = new List<Order>();
                foreach (var order in managedOrders)
                {
                    var doneOrder = new Order() { NrOfPeople = order.People };
                    var doneOrderPizzas = new List<PizzaInOrder>();
                    foreach (var pizza in order.ThePizzas)
                    {
                        var pizzainorder = new PizzaInOrder() {PizzaId = pizza.PizzaId};
                        var compsinpizza = new List<ToppingInPizzaOrder>();
                        if(pizza.ComponentIds != null) {
                            foreach (var component in pizza.ComponentIds.ToList())
                            {
                                var compinpizza = new ToppingInPizzaOrder() {ComponentId = component, PizzaInOrder = pizzainorder};
                                compsinpizza.Add(compinpizza);
                            }
                        }
                        pizzainorder.ToppingsInPizzaOrder = compsinpizza;
                        doneOrderPizzas.Add(pizzainorder);

                    }

                    doneOrder.PizzaInOrders = doneOrderPizzas;
                    doneOrders.Add(doneOrder);
                }

                vm.Invoice.Orders = doneOrders;
                vm.Invoice.CouponId = vm.CouponId;
                vm.Invoice.UserIntId = vm.UserIntId;
                vm.Invoice.PaymentMethodId = vm.PaymentMethodId;
                vm.Invoice.CustomersPhone = vm.PhoneNr;
                vm.Invoice.CreationTime = DateTime.Now;
                vm.Invoice.SumBeforeCoupon = 1;
                vm.Invoice.SumAfterCoupon = 1;

                _uow.Invoices.Add(vm.Invoice);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            vm.Coupons = new SelectList(_uow.Coupons.All, nameof(Coupon.CouponId), nameof(Coupon.Code), vm.CouponId);
            vm.PaymentMethods = new SelectList(_uow.PaymentMethods.All, nameof(PaymentMethod.PaymentMethodId), nameof(PaymentMethod.PaymentMethodName), vm.PaymentMethodId);
            vm.UserInts = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName), vm.UserIntId);
            vm.Components = new SelectList(_uow.Components.All.Where(x => x.IsTopping == true),
                nameof(Component.ComponentId), nameof(Component.ComponentName));
            vm.Pizzas = new SelectList(_uow.Pizzas.All, nameof(Pizza.PizzaId), nameof(Pizza.PizzaName));
            vm.Sizes = new SelectList(_uow.PizzaSizes.All, nameof(PizzaSize.PizzaSizeId),
                nameof(PizzaSize.PizzaSizeName));

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