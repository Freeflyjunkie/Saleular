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
        //public IPhoneRepository MockPhoneRepository;

        [TestMethod]
        public void Index()
        {
            //Mock<IPhoneRepository> phone = new Mock<IPhoneRepository>();
            //phone.Setup(p => p.GetTopOffersPaid()).Returns(() => new Phone[] 
            //{ 
            //     new Phone { Type = "iPhone",   
            //                Model = "5S", 
            //                Carrier = "Factory", 
            //                Capacity = "64 GB", 
            //                Condition = "Flawless", 
            //                Price = 455.00M,
            //                ImageUrl="/Images/iPhones/iPhone5S" },

            //   new Phone { Type = "iPhone",   
            //                Model = "5S", 
            //                Carrier = "Factory", 
            //                Capacity="64 GB", 
            //                Condition="Good",
            //                Price = 430.00M,
            //                ImageUrl="/Images/iPhones/iPhone5S" }
            //});

            //HomeController home = new HomeController { PhoneRepository = phone.Object };

            ////HomeController home = new HomeController();
            //ActionResult result = home.Index();
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Questions()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Questions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Questions_Submit()
        {
            //Mock<IMessenger> messenger = new Mock<IMessenger>();
            //messenger.Setup(m => m.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            //Mock<IPhoneSelectionManager> phoneSelectionManager = new Mock<IPhoneSelectionManager>();
            //phoneSelectionManager.Setup(p => p.GetSelectedPhoneViewModel()).Returns(new ViewModels.SelectedPhoneViewModel());

            //// Arrange
            //HomeController controller = new HomeController { 
            //    Messenger = messenger.Object, 
            //    PhoneSelectionManager = phoneSelectionManager.Object };

            //// Act
            //ViewResult result = controller.Questions("Eric Torres", "erictorres56@gmail.com", "I have a question") as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testimonials()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Questions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
