namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionOrders", "Name", c => c.String());
            AddColumn("dbo.ProductionOrders", "PhoneNumber", c => c.String());
            AddColumn("dbo.ProductionOrders", "Email", c => c.String());
            AddColumn("dbo.ProductionOrders", "Note", c => c.String());
            AddColumn("dbo.ProductionOrders", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionOrders", "Address");
            DropColumn("dbo.ProductionOrders", "Note");
            DropColumn("dbo.ProductionOrders", "Email");
            DropColumn("dbo.ProductionOrders", "PhoneNumber");
            DropColumn("dbo.ProductionOrders", "Name");
        }
    }
}
