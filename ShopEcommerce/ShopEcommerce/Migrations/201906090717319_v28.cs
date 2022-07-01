namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v28 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfigSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AppName = c.String(),
                        Title = c.String(),
                        PhoneNumber = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Facebook = c.String(),
                        Zalo = c.String(),
                        Youtube = c.String(),
                        Policy = c.String(),
                        Service = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConfigSettings");
        }
    }
}
