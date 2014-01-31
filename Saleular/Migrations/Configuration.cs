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
                // iPhone 5S 64 GB Factory
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="64 GB", 
                            Condition="Flawless", 
                            Price = 455.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 430.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="64 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },         
     
                // iPhone 5S 32 GB Factory
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="32 GB", 
                            Condition="Flawless", 
                            Price = 420.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="32 GB", 
                            Condition="Good",
                            Price = 395.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="32 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 
        
                // iPhone 5S 16 GB Factory
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 390.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 365.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 64 GB Other
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="64 GB", 
                            Condition="Flawless", 
                            Price = 430.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 405.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="64 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 32 GB Other
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="32 GB", 
                            Condition="Flawless", 
                            Price = 400.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="32 GB", 
                            Condition="Good",
                            Price = 375.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="32 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 16 GB Other
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 370.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 345.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Other", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 64 GB Verizon
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="64 GB", 
                            Condition="Flawless", 
                            Price = 455.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 430.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="64 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 32 GB Verizon
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="32 GB", 
                            Condition="Flawless", 
                            Price = 420.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="32 GB", 
                            Condition="Good",
                            Price = 395.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="32 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 16 GB Verizon
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 390.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 365.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Verizon", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 64 GB TMobile
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="64 GB", 
                            Condition="Flawless", 
                            Price = 450.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 425.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="64 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 32 GB TMobile
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="32 GB", 
                            Condition="Flawless", 
                            Price = 420.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="32 GB", 
                            Condition="Good",
                            Price = 395.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="32 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 16 GB TMobile
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 390.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 365.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "TMobile", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 64 GB Sprint
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="64 GB", 
                            Condition="Flawless", 
                            Price = 430.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 405.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="64 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 32 GB Sprint
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="32 GB", 
                            Condition="Flawless", 
                            Price = 400.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="32 GB", 
                            Condition="Good",
                            Price = 375.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="32 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 16 GB Sprint
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 370.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 345.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Sprint", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 64 GB ATT
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="64 GB", 
                            Condition="Flawless", 
                            Price = 450.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 425.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="64 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }, 

                // iPhone 5S 32 GB ATT
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="32 GB", 
                            Condition="Flawless", 
                            Price = 420.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="32 GB", 
                            Condition="Good",
                            Price = 395.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="32 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

                // iPhone 5S 16 GB ATT
                new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="16 GB", 
                            Condition="Flawless", 
                            Price = 390.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="16 GB", 
                            Condition="Good",
                            Price = 365.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "ATT", 
                            Capacity="16 GB", 
                            Condition="Bad", 
                            Price = 165.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },


              
            };
            phones.ForEach(s => context.Phones.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();
        }
    }
}
