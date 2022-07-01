namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v18 : DbMigration
    {
        public override void Up()
        {
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
        
        public override void Down()
        {
            DropTable("dbo.RequestProducts");
        }
    }
}
