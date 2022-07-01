namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Target", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Target");
        }
    }
}
