using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saleular;
using Saleular.Controllers;
using Saleular.Interfaces;
using Saleular.Classes;
using Saleular.DAL;
using Moq;
using Saleular.Models;

namespace Saleular.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public IPhoneRepository MockPhoneRepository;

        [TestMethod]
        public void Index()
        {
            Mock<IPhoneRepository> phone = new Mock<IPhoneRepository>();
            phone.Setup(p => p.GetTopOffersPaid()).Returns(() => new Phone[] 
            { 
                 new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity = "64 GB", 
                            Condition = "Flawless", 
                            Price = 455.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Phone { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 430.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }
            });

            this.MockPhoneRepository = phone.Object;
            var result = MockPhoneRepository.GetTopOffersPaid();

            //HomeController home = new HomeController(phone.Object);
            //ActionResult result = home.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
       
    }
}
