namespace ShopEcommerce.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ShopEcommerce.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopEcommerce.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopEcommerce.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var roleStore = new RoleStore<ApplicationRole>(context);
            var roleManager = new RoleManager<ApplicationRole>(roleStore);


            var userStore = new ApplicationUserStore(context);
            var userManager = new ApplicationUserManager(userStore);

            if (!context.Roles.Any(r => r.Name == "Admin")) {
                var role = new ApplicationRole { Name = "Admin" };
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Mod")) {
                var role = new ApplicationRole { Name = "Mod" };
                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com")) {
                var user = new ApplicationUser {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FullName = "Admin",
                    Gender = "Nam",
                    BirthDate = DateTime.Parse("1990/01/01"),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    EmailConfirmed = true,
                    PhoneNumber = "0987654321",
                    PhoneNumberConfirmed = true
                };

                userManager.Create(user, "&&**123456SE");
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
