namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plugins", "OrderNo", c => c.Int(nullable: false));
            AddColumn("dbo.Plugins", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Plugins", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Plugins", "Show", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Plugins", "UserId");
            AddForeignKey("dbo.Plugins", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plugins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Plugins", new[] { "UserId" });
            DropColumn("dbo.Plugins", "Show");
            DropColumn("dbo.Plugins", "UserId");
            DropColumn("dbo.Plugins", "AddedDate");
            DropColumn("dbo.Plugins", "OrderNo");
        }
    }
}
