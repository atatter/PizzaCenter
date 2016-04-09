namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDb_CouponUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Coupons", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Coupons", "IsReusable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Coupons", "HasBeenUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "HasBeenUsed");
            DropColumn("dbo.Coupons", "IsReusable");
            DropColumn("dbo.Coupons", "EndDate");
            DropColumn("dbo.Coupons", "StartDate");
        }
    }
}
