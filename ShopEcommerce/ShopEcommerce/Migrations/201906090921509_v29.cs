namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConfigSettings", "Instagram", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConfigSettings", "Instagram");
        }
    }
}
