namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationRoleMenus",
                c => new
                    {
                        ApplicationRole_Id = c.String(nullable: false, maxLength: 128),
                        Menu_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationRole_Id, t.Menu_Id })
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.Menu_Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationRoleMenus", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.ApplicationRoleMenus", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.ApplicationRoleMenus", new[] { "Menu_Id" });
            DropIndex("dbo.ApplicationRoleMenus", new[] { "ApplicationRole_Id" });
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.ApplicationRoleMenus");
        }
    }
}
