namespace ShopEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Module = c.String(),
                        ObjectType = c.String(),
                        ObjectId = c.String(),
                        ObjectCode = c.String(),
                        ObjectName = c.String(),
                        Action = c.String(),
                        Notes = c.String(),
                        OldVal = c.String(),
                        NewVal = c.String(),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Photo = c.String(),
                        FullName = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LoginSessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginTime = c.DateTime(nullable: false),
                        LogoffTime = c.DateTime(),
                        HostName = c.String(),
                        IPAddress = c.String(),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.BannerCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        OrderNo = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Link = c.String(),
                        Image = c.String(),
                        OrderNo = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        BannerCategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BannerCategories", t => t.BannerCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.BannerCategoryId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Controller = c.String(),
                        ActionName = c.String(),
                        IsGroupHeader = c.Boolean(nullable: false),
                        ModuleName = c.String(),
                        Link = c.String(),
                        OrderNo = c.Int(nullable: false),
                        GroupOrder = c.Int(nullable: false),
                        CssClass = c.String(),
                        ParentId = c.Int(),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.ParentId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        OrderNo = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SKU = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Manufacturer = c.String(),
                        Warranty = c.String(),
                        Description = c.String(),
                        Color = c.String(),
                        Delivery = c.String(),
                        Quantity = c.Int(nullable: false),
                        Size = c.String(),
                        DetailOverview = c.String(),
                        OrderNo = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(),
                        SeName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Link = c.String(),
                        FileName = c.String(),
                        OrderNo = c.Int(nullable: false),
                        Alt = c.String(),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        Content = c.String(),
                        OrderNo = c.Int(nullable: false),
                        AllowDelete = c.Boolean(nullable: false),
                        IsPublish = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.ProductProductCategories",
                c => new
                    {
                        Product_Id = c.Guid(nullable: false),
                        ProductCategory_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductCategory_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.ProductTagProducts",
                c => new
                    {
                        ProductTag_Id = c.Guid(nullable: false),
                        Product_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductTag_Id, t.Product_Id })
                .ForeignKey("dbo.ProductTags", t => t.ProductTag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.ProductTag_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Topics", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductCategories", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductCategories", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductTagProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductTagProducts", "ProductTag_Id", "dbo.ProductTags");
            DropForeignKey("dbo.ProductImages", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductImages", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductProductCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductProductCategories", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Menus", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("dbo.BannerCategories", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BannerCategories", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Banners", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Banners", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Banners", "BannerCategoryId", "dbo.BannerCategories");
            DropForeignKey("dbo.ActivityLogs", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LoginSessions", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ProductTagProducts", new[] { "Product_Id" });
            DropIndex("dbo.ProductTagProducts", new[] { "ProductTag_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.Topics", new[] { "ModifiedBy" });
            DropIndex("dbo.Topics", new[] { "CreatedBy" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ModifiedBy" });
            DropIndex("dbo.ProductImages", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "ModifiedBy" });
            DropIndex("dbo.Products", new[] { "CreatedBy" });
            DropIndex("dbo.ProductCategories", new[] { "ModifiedBy" });
            DropIndex("dbo.ProductCategories", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Menus", new[] { "RoleId" });
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropIndex("dbo.Banners", new[] { "BannerCategoryId" });
            DropIndex("dbo.Banners", new[] { "ModifiedBy" });
            DropIndex("dbo.Banners", new[] { "CreatedBy" });
            DropIndex("dbo.BannerCategories", new[] { "ModifiedBy" });
            DropIndex("dbo.BannerCategories", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.LoginSessions", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ActivityLogs", new[] { "CreatedBy" });
            DropTable("dbo.ProductTagProducts");
            DropTable("dbo.ProductProductCategories");
            DropTable("dbo.Topics");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Menus");
            DropTable("dbo.Banners");
            DropTable("dbo.BannerCategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.LoginSessions");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ActivityLogs");
        }
    }
}
