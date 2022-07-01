namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductViewers",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductViewers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductViewers", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductViewers", new[] { "UserId" });
            DropIndex("dbo.ProductViewers", new[] { "ProductId" });
            DropTable("dbo.ProductViewers");
        }
    }
}
