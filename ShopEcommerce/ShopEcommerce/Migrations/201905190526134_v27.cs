namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionOrders", "PONumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionOrders", "PONumber");
        }
    }
}
