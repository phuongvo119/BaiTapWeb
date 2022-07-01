namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "IsShowOnHome", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "IsShowOnHome");
        }
    }
}
