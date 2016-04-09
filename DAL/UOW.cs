using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL
{
    public class UOW : IUOW, IDisposable
    {
        private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext)
        {

            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext)DbContext).SaveChanges();
        }


        //standard repos
        //public IEFRepository<Contact> Contacts => GetStandardRepo<Contact>();
        //public IEFRepository<ContactType> ContactTypes => GetStandardRepo<ContactType>();
        public IEFRepository<AdditionalProduct> AdditionalProducts => GetStandardRepo<AdditionalProduct>();
        public IEFRepository<AdditionalProductInOrder> AdditionalProductInOrders => GetStandardRepo<AdditionalProductInOrder>();
        public IEFRepository<Component> Components => GetStandardRepo<Component>();
        public IEFRepository<ComponentAsTopping> ComponentAsToppings => GetStandardRepo<ComponentAsTopping>();
        public IEFRepository<ComponentInPizza> ComponentInPizzas => GetStandardRepo<ComponentInPizza>();
        public IEFRepository<Coupon> Coupons => GetStandardRepo<Coupon>();
        public IEFRepository<Invoice> Invoices => GetStandardRepo<Invoice>();
        public IEFRepository<Order> Orders => GetStandardRepo<Order>();
        public IEFRepository<PaymentMethod> PaymentMethods => GetStandardRepo<PaymentMethod>();
        public IEFRepository<Person> Persons => GetStandardRepo<Person>();
        public IEFRepository<Pizza> Pizzas => GetStandardRepo<Pizza>();
        public IEFRepository<PizzaInOrder> PizzaInOrders => GetStandardRepo<PizzaInOrder>();
        public IEFRepository<PizzaPriceBySize> PizzaPriceBySizes => GetStandardRepo<PizzaPriceBySize>();
        public IEFRepository<PizzaSize> PizzaSizes => GetStandardRepo<PizzaSize>();
        public IEFRepository<Price> Prices => GetStandardRepo<Price>();
        public IEFRepository<PriceType> PriceTypes => GetStandardRepo<PriceType>();
        public IEFRepository<Topping> Toppings => GetStandardRepo<Topping>();
        public IEFRepository<ToppingInPizzaOrder> ToppingInPizzaOrders => GetStandardRepo<ToppingInPizzaOrder>();
        
        
        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories
        //public IPersonRepository Persons => GetRepo<IPersonRepository>();

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        // try to find repository for type T
        public T GetRepository<T>() where T : class
        {
            var res = GetRepo<T>() ?? GetStandardRepo<T>() as T;
            if (res == null)
            {
                throw new NotImplementedException("No repository for type, " + typeof(T).FullName);
            }
            return res;
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        #endregion

    }
}
