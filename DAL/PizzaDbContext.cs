using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL
{
    public class PizzaDbContext : DbContext, IDbContext
    {
        public PizzaDbContext() : base("DbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PizzaDbContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PizzaDbContext,Migrations.Configuration>());



#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<AdditionalProduct> AdditionalProducts { get; set; }
        public DbSet<AdditionalProductInOrder> AdditionalProductInOrders { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentAsTopping> ComponentAsToppings { get; set; }
        public DbSet<ComponentInPizza> ComponentInPizzas { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaInOrder> PizzaInOrders { get; set; }
        public DbSet<PizzaPriceBySize> PizzaPriceBySizes { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<ToppingInPizzaOrder> ToppingInPizzaOrders { get; set; }

        public System.Data.Entity.DbSet<Domain.MultiLangString> MultiLangStrings { get; set; }
    }
}
