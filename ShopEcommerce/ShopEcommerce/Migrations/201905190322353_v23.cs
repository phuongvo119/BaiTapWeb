namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v23 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductProductCategories", newName: "ProductCategoryProducts");
            DropPrimaryKey("dbo.ProductCategoryProducts");
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Thumail = c.String(),
                        ProductId = c.Guid(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ProductionOrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductionOrders", t => t.ProductionOrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductionOrderId);
            
            CreateTable(
                "dbo.ProductionOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            AddPrimaryKey("dbo.ProductCategoryProducts", new[] { "ProductCategory_Id", "Product_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionOrders", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartItems", "ProductionOrderId", "dbo.ProductionOrders");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductionOrders", new[] { "CreatedBy" });
            DropIndex("dbo.CartItems", new[] { "ProductionOrderId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropPrimaryKey("dbo.ProductCategoryProducts");
            DropTable("dbo.ProductionOrders");
            DropTable("dbo.CartItems");
            AddPrimaryKey("dbo.ProductCategoryProducts", new[] { "Product_Id", "ProductCategory_Id" });
            RenameTable(name: "dbo.ProductCategoryProducts", newName: "ProductProductCategories");
        }
    }
}
