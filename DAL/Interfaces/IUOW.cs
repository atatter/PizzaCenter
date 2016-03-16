﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IUOW
    {
        //save pending changes to the data store
        void Commit();

        //get repository for type
        //T GetRepository<T>() where T : class;

        //Standard repos, autogenerated
        IEFRepository<Pizza> Pizzas { get; }
        IEFRepository<PizzaComponent> PizzaComponents { get; }
        IEFRepository<AdditionalComponent> AdditionalComponents { get; }
        IEFRepository<Component> Components { get; }
        IEFRepository<Order> Orders { get; } 
        IEFRepository<OrderedPizza> OrderedPizzas { get; } 

        //Customs repos, manually implemented


    }
}
