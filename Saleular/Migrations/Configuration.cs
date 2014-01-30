namespace Saleular.Migrations
{
    using Saleular.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Saleular.DAL.SaleularContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Saleular.DAL.SaleularContext context)
        {
            //  This method will be called after migrating to the latest version.

            var phones = new List<Phone>
            {
                new Phone { Type = "iPhone",   
                            Model = "3G", 
                            Carrier = "Factory", 
                            Capacity="8 GB", 
                            Condition="Bad", 
                            Price = 5.00M,
                            ImageUrl="http://im1.shopmania.org/files/p/t/120/apple-iphone-3g-8gb~1377120.jpg" },

               new Phone { Type = "iPhone",   
                            Model = "3G", 
                            Carrier = "Factory", 
                            Capacity="8 GB", 
                            Condition="Good",
                            Price = 20.00M,
                            ImageUrl="http://im1.shopmania.org/files/p/t/120/apple-iphone-3g-8gb~1377120.jpg" },

               new Phone { Type = "iPhone",   
                            Model = "3G", 
                            Carrier = "Factory", 
                            Capacity="8 GB", 
                            Condition="Flawless", 
                            Price = 30.00M,
                            ImageUrl="http://im1.shopmania.org/files/p/t/120/apple-iphone-3g-8gb~1377120.jpg" },

               new Phone { Type = "iPhone",   
                            Model = "3G", 
                            Carrier = "Factory", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 5.00M,
                            ImageUrl="http://im1.shopmania.org/files/p/t/120/apple-iphone-3g-8gb~1377120.jpg" },

               new Phone { Type = "iPhone",   
                            Model = "3G", 
                            Carrier = "Factory", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 23.00M,
                            ImageUrl="http://im1.shopmania.org/files/p/t/120/apple-iphone-3g-8gb~1377120.jpg" },

               new Phone { Type = "iPhone",   
                            Model = "3G", 
                            Carrier = "Factory", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 35.00M,
                            ImageUrl="http://im1.shopmania.org/files/p/t/120/apple-iphone-3g-8gb~1377120.jpg" },
            };
            phones.ForEach(s => context.Phones.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();
        }
    }
}
