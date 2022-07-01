namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        OrderNo = c.Int(nullable: false),
                        IsPublish = c.Boolean(),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vendors", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Vendors", new[] { "ModifiedBy" });
            DropIndex("dbo.Vendors", new[] { "CreatedBy" });
            DropTable("dbo.Vendors");
        }
    }
}
