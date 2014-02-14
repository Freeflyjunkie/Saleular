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
        protected Mock<IGadgetRepository> _gadgets;
        protected Mock<IMessenger> _messenger;

        public HomeControllerTest()
        {
            _gadgets = new Mock<IGadgetRepository>();
            _gadgets.Setup(g => g.GetTopOffersPaid(It.IsAny<string>(), It.IsAny<string>())).Returns(() => new Gadget[] 
            { 
                 new Gadget { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity = "64 GB", 
                            Condition = "Flawless", 
                            Price = 455.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" },

               new Gadget { Type = "iPhone",   
                            Model = "5S", 
                            Carrier = "Factory", 
                            Capacity="64 GB", 
                            Condition="Good",
                            Price = 430.00M,
                            ImageUrl="/Images/iPhones/iPhone5S" }
            });

            _messenger = new Mock<IMessenger>();
            _messenger.Setup(m => m.ConstructMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("Question Message Body");
            _messenger.Setup(m => m.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [TestMethod]
        public void Index()
        {
            HomeController home = new HomeController(_gadgets.Object, _messenger.Object);
            ActionResult result = home.Index();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {            
            // Arrange
            HomeController home = new HomeController(_gadgets.Object, _messenger.Object);

            // Act
            ViewResult result = home.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Questions()
        {
            HomeController home = new HomeController(_gadgets.Object, _messenger.Object);

            // Act
            ViewResult result = home.Questions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Questions_Submit()
        {
            HomeController home = new HomeController(_gadgets.Object, _messenger.Object);

            // Act
            ViewResult result = home.Questions("Eric Torres", "erictorres56@gmail.com", "I have a question") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testimonials()
        {
            HomeController home = new HomeController(_gadgets.Object, _messenger.Object);

            // Act
            ViewResult result = home.Questions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
