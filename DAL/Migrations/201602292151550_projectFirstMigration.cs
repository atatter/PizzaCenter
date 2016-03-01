namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalComponents",
                c => new
                    {
                        AdditionalComponentId = c.Int(nullable: false, identity: true),
                        OrderedPizzaId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionalComponentId)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.OrderedPizzas", t => t.OrderedPizzaId, cascadeDelete: true)
                .Index(t => t.OrderedPizzaId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ComponentId);
            
            CreateTable(
                "dbo.PizzaComponents",
                c => new
                    {
                        PizzaComponentId = c.Int(nullable: false, identity: true),
                        PizzaId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaComponentId)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaId);
            
            CreateTable(
                "dbo.OrderedPizzas",
                c => new
                    {
                        OrderedPizzaId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderedPizzaId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PizzaId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaComponents", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.OrderedPizzas", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.OrderedPizzas", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.AdditionalComponents", "OrderedPizzaId", "dbo.OrderedPizzas");
            DropForeignKey("dbo.PizzaComponents", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.AdditionalComponents", "ComponentId", "dbo.Components");
            DropIndex("dbo.OrderedPizzas", new[] { "PizzaId" });
            DropIndex("dbo.OrderedPizzas", new[] { "OrderId" });
            DropIndex("dbo.PizzaComponents", new[] { "ComponentId" });
            DropIndex("dbo.PizzaComponents", new[] { "PizzaId" });
            DropIndex("dbo.AdditionalComponents", new[] { "ComponentId" });
            DropIndex("dbo.AdditionalComponents", new[] { "OrderedPizzaId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderedPizzas");
            DropTable("dbo.Pizzas");
            DropTable("dbo.PizzaComponents");
            DropTable("dbo.Components");
            DropTable("dbo.AdditionalComponents");
        }
    }
}
