namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RequestProducts");
            DropTable("dbo.Subscriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestProducts",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductName = c.String(),
                        Email = c.String(),
                        Notification = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
