namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plugins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Style = c.String(),
                        Script = c.String(),
                        Html = c.String(),
                        Postion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ConfigSettings", "AppNameShort", c => c.String());
            AddColumn("dbo.ConfigSettings", "AppLogo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConfigSettings", "AppLogo");
            DropColumn("dbo.ConfigSettings", "AppNameShort");
            DropTable("dbo.Plugins");
        }
    }
}
