namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BannerCategories", "IsPublish", c => c.Boolean());
            AddColumn("dbo.Banners", "IsPublish", c => c.Boolean());
            AddColumn("dbo.ProductCategories", "IsPublish", c => c.Boolean());
            AddColumn("dbo.Products", "IsPublish", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsPublish");
            DropColumn("dbo.ProductCategories", "IsPublish");
            DropColumn("dbo.Banners", "IsPublish");
            DropColumn("dbo.BannerCategories", "IsPublish");
        }
    }
}
