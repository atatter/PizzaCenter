using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext() : base("DbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PizzaDbContext>());
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<AdditionalComponent> AdditionalComponents { get; set; }
        public DbSet<OrderedPizza> OrderedPizzas { get; set; }
        public DbSet<PizzaComponent> PizzaComponents { get; set; }
    }
}
