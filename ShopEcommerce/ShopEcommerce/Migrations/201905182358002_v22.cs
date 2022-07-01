namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitorCounters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Online = c.Int(nullable: false),
                        Today = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitorCounters");
        }
    }
}
