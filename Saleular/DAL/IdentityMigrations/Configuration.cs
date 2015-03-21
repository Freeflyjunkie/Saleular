using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Saleular.Models;

namespace Saleular.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityContext>
    {        
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\IdentityMigrations";
            //add-migration -ConfigurationTypeName Saleular.DAL.IdentityMigrations.Configuration "migration4"
            //update-database -ConfigurationTypeName Saleular.DAL.IdentityMigrations.Configuration
        }

        protected override void Seed(IdentityContext context)
        {
            //  This method will be called after migrating to the latest version.            
            var hasher = new PasswordHasher();            
            context.Roles.Add(new IdentityRole {Name = "Administrator"});
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "rbitran",
                    Email = "saleular1@gmail.com",
                    PasswordHash = hasher.HashPassword("roybitran123"),
                    SecurityStamp = hasher.HashPassword("123456789"),
                },
                new ApplicationUser
                {
                    UserName = "etorres",                    
                    Email = "erictorres56@gmail.com",
                    PasswordHash = hasher.HashPassword("charna64"),
                    SecurityStamp = hasher.HashPassword("987654321"),
                });             
        }
    }
}
