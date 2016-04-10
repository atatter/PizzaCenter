namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalProductInOrders",
                c => new
                    {
                        AdditionalProductInOrderId = c.Int(nullable: false, identity: true),
                        AdditionalProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionalProductInOrderId)
                .ForeignKey("dbo.AdditionalProducts", t => t.AdditionalProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.AdditionalProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.AdditionalProducts",
                c => new
                    {
                        AdditionalProductId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdditionalProductId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        PriceTypeId = c.Int(nullable: false),
                        PizzaPriceBySizeId = c.Int(nullable: false),
                        ToppingId = c.Int(nullable: false),
                        AdditionalProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriceId)
                .ForeignKey("dbo.AdditionalProducts", t => t.AdditionalProductId, cascadeDelete: true)
                .ForeignKey("dbo.PizzaPriceBySizes", t => t.PizzaPriceBySizeId, cascadeDelete: true)
                .ForeignKey("dbo.PriceTypes", t => t.PriceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Toppings", t => t.ToppingId, cascadeDelete: true)
                .Index(t => t.PriceTypeId)
                .Index(t => t.PizzaPriceBySizeId)
                .Index(t => t.ToppingId)
                .Index(t => t.AdditionalProductId);
            
            CreateTable(
                "dbo.PizzaPriceBySizes",
                c => new
                    {
                        PizzaPriceBySizeId = c.Int(nullable: false, identity: true),
                        PizzaSizeId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaPriceBySizeId)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .ForeignKey("dbo.PizzaSizes", t => t.PizzaSizeId, cascadeDelete: true)
                .Index(t => t.PizzaSizeId)
                .Index(t => t.PizzaId);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ContactTypeNameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaId)
                .ForeignKey("dbo.MultiLangStrings", t => t.ContactTypeNameId, cascadeDelete: true)
                .Index(t => t.ContactTypeNameId);
            
            CreateTable(
                "dbo.ComponentInPizzas",
                c => new
                    {
                        ComponentInPizzaId = c.Int(nullable: false, identity: true),
                        PizzaId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComponentInPizzaId)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentId = c.Int(nullable: false, identity: true),
                        Nimetus = c.String(),
                    })
                .PrimaryKey(t => t.ComponentId);
            
            CreateTable(
                "dbo.ComponentAsToppings",
                c => new
                    {
                        ComponentAsToppingId = c.Int(nullable: false, identity: true),
                        ToppingId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComponentAsToppingId)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Toppings", t => t.ToppingId, cascadeDelete: true)
                .Index(t => t.ToppingId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Toppings",
                c => new
                    {
                        ToppingId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ToppingId);
            
            CreateTable(
                "dbo.ToppingInPizzaOrders",
                c => new
                    {
                        ToppingInPizzaOrderId = c.Int(nullable: false, identity: true),
                        ToppingId = c.Int(nullable: false),
                        PizzaInOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToppingInPizzaOrderId)
                .ForeignKey("dbo.PizzaInOrders", t => t.PizzaInOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Toppings", t => t.ToppingId, cascadeDelete: true)
                .Index(t => t.ToppingId)
                .Index(t => t.PizzaInOrderId);
            
            CreateTable(
                "dbo.PizzaInOrders",
                c => new
                    {
                        PizzaInOrderId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaInOrderId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PizzaId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        NrOfPeople = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        CreationTime = c.DateTime(nullable: false),
                        SumWOCoupon = c.Int(),
                        Sum = c.Int(),
                        CustomersName = c.String(),
                        Delivered = c.Boolean(nullable: false),
                        CouponId = c.Int(),
                        PaymentMethodId = c.Int(nullable: false),
                        PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Coupons", t => t.CouponId)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.CouponId)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsReusable = c.Boolean(nullable: false),
                        HasBeenUsed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CouponId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.MultiLangStrings",
                c => new
                    {
                        MultiLangStringId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Owner = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        TranslationId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MultiLangStringId = c.Int(nullable: false),
                        Culture = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.TranslationId)
                .ForeignKey("dbo.MultiLangStrings", t => t.MultiLangStringId, cascadeDelete: true)
                .Index(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.PizzaSizes",
                c => new
                    {
                        PizzaSizeId = c.Int(nullable: false, identity: true),
                        Suurus = c.String(),
                        Diameeter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaSizeId);
            
            CreateTable(
                "dbo.PriceTypes",
                c => new
                    {
                        PriceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PriceTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ToppingId", "dbo.Toppings");
            DropForeignKey("dbo.Prices", "PriceTypeId", "dbo.PriceTypes");
            DropForeignKey("dbo.Prices", "PizzaPriceBySizeId", "dbo.PizzaPriceBySizes");
            DropForeignKey("dbo.PizzaPriceBySizes", "PizzaSizeId", "dbo.PizzaSizes");
            DropForeignKey("dbo.PizzaPriceBySizes", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Pizzas", "ContactTypeNameId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Translations", "MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.ComponentInPizzas", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.ToppingInPizzaOrders", "ToppingId", "dbo.Toppings");
            DropForeignKey("dbo.ToppingInPizzaOrders", "PizzaInOrderId", "dbo.PizzaInOrders");
            DropForeignKey("dbo.PizzaInOrders", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.PizzaInOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "PersonId", "dbo.People");
            DropForeignKey("dbo.Invoices", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CouponId", "dbo.Coupons");
            DropForeignKey("dbo.AdditionalProductInOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ComponentAsToppings", "ToppingId", "dbo.Toppings");
            DropForeignKey("dbo.ComponentAsToppings", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.ComponentInPizzas", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Prices", "AdditionalProductId", "dbo.AdditionalProducts");
            DropForeignKey("dbo.AdditionalProductInOrders", "AdditionalProductId", "dbo.AdditionalProducts");
            DropIndex("dbo.Translations", new[] { "MultiLangStringId" });
            DropIndex("dbo.Invoices", new[] { "PersonId" });
            DropIndex("dbo.Invoices", new[] { "PaymentMethodId" });
            DropIndex("dbo.Invoices", new[] { "CouponId" });
            DropIndex("dbo.Orders", new[] { "InvoiceId" });
            DropIndex("dbo.PizzaInOrders", new[] { "PizzaId" });
            DropIndex("dbo.PizzaInOrders", new[] { "OrderId" });
            DropIndex("dbo.ToppingInPizzaOrders", new[] { "PizzaInOrderId" });
            DropIndex("dbo.ToppingInPizzaOrders", new[] { "ToppingId" });
            DropIndex("dbo.ComponentAsToppings", new[] { "ComponentId" });
            DropIndex("dbo.ComponentAsToppings", new[] { "ToppingId" });
            DropIndex("dbo.ComponentInPizzas", new[] { "ComponentId" });
            DropIndex("dbo.ComponentInPizzas", new[] { "PizzaId" });
            DropIndex("dbo.Pizzas", new[] { "ContactTypeNameId" });
            DropIndex("dbo.PizzaPriceBySizes", new[] { "PizzaId" });
            DropIndex("dbo.PizzaPriceBySizes", new[] { "PizzaSizeId" });
            DropIndex("dbo.Prices", new[] { "AdditionalProductId" });
            DropIndex("dbo.Prices", new[] { "ToppingId" });
            DropIndex("dbo.Prices", new[] { "PizzaPriceBySizeId" });
            DropIndex("dbo.Prices", new[] { "PriceTypeId" });
            DropIndex("dbo.AdditionalProductInOrders", new[] { "OrderId" });
            DropIndex("dbo.AdditionalProductInOrders", new[] { "AdditionalProductId" });
            DropTable("dbo.PriceTypes");
            DropTable("dbo.PizzaSizes");
            DropTable("dbo.Translations");
            DropTable("dbo.MultiLangStrings");
            DropTable("dbo.People");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Coupons");
            DropTable("dbo.Invoices");
            DropTable("dbo.Orders");
            DropTable("dbo.PizzaInOrders");
            DropTable("dbo.ToppingInPizzaOrders");
            DropTable("dbo.Toppings");
            DropTable("dbo.ComponentAsToppings");
            DropTable("dbo.Components");
            DropTable("dbo.ComponentInPizzas");
            DropTable("dbo.Pizzas");
            DropTable("dbo.PizzaPriceBySizes");
            DropTable("dbo.Prices");
            DropTable("dbo.AdditionalProducts");
            DropTable("dbo.AdditionalProductInOrders");
        }
    }
}
