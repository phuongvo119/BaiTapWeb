namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Prefix = c.String(),
                        Continuous = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeyDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyType = c.String(),
                        KeyYear = c.Int(nullable: false),
                        KeyMonth = c.Int(nullable: false),
                        KeyValue = c.Int(nullable: false),
                        KeyDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KeyDatas");
            DropTable("dbo.CodeTables");
        }
    }
}
