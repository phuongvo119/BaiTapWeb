namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(maxLength: 100),
                        CommonName = c.String(maxLength: 100),
                        FormalName = c.String(maxLength: 100),
                        CountryType = c.String(maxLength: 100),
                        CountrySubType = c.String(maxLength: 100),
                        Sovereignty = c.String(maxLength: 100),
                        Capital = c.String(maxLength: 100),
                        CurrencyCode = c.String(maxLength: 100),
                        CurrencyName = c.String(maxLength: 100),
                        TelephoneCode = c.String(maxLength: 100),
                        CountryCode3 = c.String(maxLength: 100),
                        CountryNumber = c.String(maxLength: 100),
                        InternetCountryCode = c.String(maxLength: 100),
                        SortOrder = c.Int(),
                        IsPublished = c.Boolean(),
                        Flags = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Type = c.String(maxLength: 50),
                        LatiLongTude = c.String(maxLength: 50),
                        ProvinceId = c.Int(nullable: false),
                        SortOrder = c.Int(),
                        IsPublished = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Type = c.String(maxLength: 20),
                        TelephoneCode = c.Int(),
                        ZipCode = c.String(maxLength: 20),
                        CountryId = c.Int(nullable: false),
                        CountryCode = c.String(),
                        SortOrder = c.Int(),
                        IsPublished = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        LatiLongTude = c.String(maxLength: 50),
                        DistrictId = c.Int(nullable: false),
                        SortOrder = c.Int(),
                        IsPublished = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wards", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Provinces", "CountryId", "dbo.Countries");
            DropIndex("dbo.Wards", new[] { "DistrictId" });
            DropIndex("dbo.Provinces", new[] { "CountryId" });
            DropIndex("dbo.Districts", new[] { "ProvinceId" });
            DropTable("dbo.Wards");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.Countries");
        }
    }
}
