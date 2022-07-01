namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsHot", c => c.Boolean());
            AddColumn("dbo.Products", "IsFeatured", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsFeatured");
            DropColumn("dbo.Products", "IsHot");
        }
    }
}
