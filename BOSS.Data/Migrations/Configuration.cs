namespace BOSS.Data.Migrations
{
    using BOSS.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BOSS.Data.BossDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BOSS.Data.BossDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BossDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BossDbContext()));


            var user = new ApplicationUser()
            {
                UserName = "trangpham",
                Email = "trangphamutc01@gmail.com",
                EmailConfirmed = true,
               
            };
            manager.Create(user, "123456$");
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });

            }
            var admin = manager.FindByEmail("trangphamutc01@gmail.com");
            manager.AddToRole(admin.Id, "Admin");
            manager.AddToRole(admin.Id, "User");
        }
    }
}
