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
using System.Threading.Tasks;
using System.Threading;

namespace Saleular.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        protected Mock<IGadgetRepository> Gadgets;
        protected Mock<IMessenger> Messenger;

        public HomeControllerTest()
        {
            Gadgets = new Mock<IGadgetRepository>();
            IEnumerable<Gadget> fakeGadgets = new List<Gadget>
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
            };
            Gadgets.Setup(g => g.GetTopOffersPaidAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(fakeGadgets));           

            Messenger = new Mock<IMessenger>();
            Messenger.Setup(m => m.ConstructMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("Question Message Body");
            Messenger.Setup(m => m.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [TestMethod]
        public async Task Index()
        {
            HomeController home = new HomeController(Gadgets.Object, Messenger.Object);
            ActionResult result = (ActionResult)await home.Index(new CancellationToken());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {            
            // Arrange
            HomeController home = new HomeController(Gadgets.Object, Messenger.Object);

            // Act
            ViewResult result = home.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Questions()
        {
            HomeController home = new HomeController(Gadgets.Object, Messenger.Object);

            // Act
            ViewResult result = home.Questions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Questions_Submit()
        {
            HomeController home = new HomeController(Gadgets.Object, Messenger.Object);

            // Act
            ViewResult result = home.Questions("Eric Torres", "erictorres56@gmail.com", "I have a question") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testimonials()
        {
            HomeController home = new HomeController(Gadgets.Object, Messenger.Object);

            // Act
            ViewResult result = home.Questions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
