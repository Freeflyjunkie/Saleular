using Microsoft.AspNet.Identity;
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
        }

        protected override void Seed(IdentityContext context)
        {
            //  This method will be called after migrating to the latest version.
            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "rbitran",
                    PasswordHash = hasher.HashPassword("roybitran123")
                },
                new ApplicationUser
                {
                    UserName = "etorres",
                    PasswordHash = hasher.HashPassword("charna64")
                }); 
        }
    }
}
