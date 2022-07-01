namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Menus", new[] { "RoleId" });
            DropColumn("dbo.Menus", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "RoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Menus", "RoleId");
            AddForeignKey("dbo.Menus", "RoleId", "dbo.AspNetRoles", "Id");
        }
    }
}
