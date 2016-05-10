using System;
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
        void RefreshAllEntities();

        //UOW Methods, that dont fit into specific repo

        //get repository for type
        T GetRepository<T>() where T : class;

        // standard autocreated repos, since we do not have any special methods in interfaces
        IEFRepository<ContactType> ContactTypes { get; }
        IEFRepository<MultiLangString> MultiLangStrings { get; }
        IEFRepository<Translation> Translations { get; }


        IPersonRepository Persons { get; }
        IContactRepository Contacts { get; }
        IArticleRepository Articles { get; }

        IEFRepository<AdditionalProduct> AdditionalProducts { get; }
        IEFRepository<AdditionalProductInOrder> AdditionalProductInOrders { get; }
        IEFRepository<Component> Components { get; }
        IEFRepository<ComponentAsTopping> ComponentAsToppings { get; }
        IEFRepository<ComponentInPizza> ComponentInPizzas { get; }
        IEFRepository<Coupon> Coupons { get; }
        IEFRepository<Invoice> Invoices { get; }
        IEFRepository<Order> Orders { get; }
        IEFRepository<PaymentMethod> PaymentMethods { get; }
        IEFRepository<Pizza> Pizzas { get; }
        IEFRepository<PizzaInOrder> PizzaInOrders { get; }
        IEFRepository<PizzaPriceBySize> PizzaPriceBySizes { get; }
        IEFRepository<PizzaSize> PizzaSizes { get; }
        IEFRepository<Price> Prices { get; }
        IEFRepository<PriceType> PriceTypes { get; }
        IEFRepository<Topping> Toppings { get; }
        IEFRepository<ToppingInPizzaOrder> ToppingInPizzaOrders { get; }


        // Identity, PK - string
        //IUserRepository Users { get; }
        //IUserRoleRepository UserRoles { get; }
        //IRoleRepository Roles { get; }
        //IUserClaimRepository UserClaims { get; }
        //IUserLoginRepository UserLogins { get; }

        // Identity, PK - int
        IUserIntRepository UsersInt { get; }
        IUserRoleIntRepository UserRolesInt { get; }
        IRoleIntRepository RolesInt { get; }
        IUserClaimIntRepository UserClaimsInt { get; }
        IUserLoginIntRepository UserLoginsInt { get; }
    }
}