namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "ParentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ProductCategories", "ParentId");
            AddForeignKey("dbo.ProductCategories", "ParentId", "dbo.ProductCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ParentId", "dbo.ProductCategories");
            DropIndex("dbo.ProductCategories", new[] { "ParentId" });
            DropColumn("dbo.ProductCategories", "ParentId");
        }
    }
}
