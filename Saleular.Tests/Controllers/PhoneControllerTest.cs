using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saleular;
using Saleular.Controllers;
using Moq;
using Saleular.DAL;
using System.Data.Entity;
using Saleular.Models;
using Saleular.Interfaces;
using Saleular.ViewModels;

namespace Saleular.Tests.Controllers
{
    [TestClass]
    public class PhoneControllerTest
    {
        protected Mock<IStorage> _storage;
        protected Mock<IGadgetRepository> _gadgets;        
        protected Mock<IOfferBuilder> _offerBuilder;
        protected Mock<IMessenger> _messenger;        

        public PhoneControllerTest()
        {

            _storage = new Mock<IStorage>();
            _storage.Setup(s => s.Save(It.IsAny<string>(), It.IsAny<string>()));
            _storage.Setup(s => s.Retrieve(It.IsAny<string>())).Returns(new SelectedGadgetViewModel());

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

            _offerBuilder = new Mock<IOfferBuilder>();
            _offerBuilder.Setup(o => o.InitializeSelectedGadgetViewModel()).Returns(new SelectedGadgetViewModel());
            _offerBuilder.Setup(o => o.SelectionChanged(new SelectedGadgetViewModel())).Returns(new SelectedGadgetViewModel());

            _messenger = new Mock<IMessenger>();
            _messenger.Setup(m => m.ConstructMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("Question Message Body");
            _messenger.Setup(m => m.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

         [TestMethod]
        public void Offer()
        {
            PhoneController phone = new PhoneController(_storage.Object, _gadgets.Object, _offerBuilder.Object, _messenger.Object);
            ActionResult result = phone.Offer();
            Assert.IsNotNull(result);
        }

         [TestMethod]
         public void GetSelectedPhoneViewModel()
        {
            PhoneController phone = new PhoneController(_storage.Object, _gadgets.Object, _offerBuilder.Object, _messenger.Object);
            SelectedGadgetViewModel selectedGadget = new SelectedGadgetViewModel();
            selectedGadget.SelectedType = "iPhone";
            ActionResult result = phone.GetSelectedGadgetViewModel(selectedGadget);
            Assert.IsNotNull(result);
        }

         [TestMethod]
         public void Ship()
        {
            PhoneController phone = new PhoneController(_storage.Object, _gadgets.Object, _offerBuilder.Object, _messenger.Object);
            ActionResult result = phone.Ship();
            Assert.IsNotNull(result);
        }        

         [TestMethod]
         public void ShippingLabelRequest()
        {
            PhoneController phone = new PhoneController(_storage.Object, _gadgets.Object, _offerBuilder.Object, _messenger.Object);
            ActionResult result = phone.Ship("Eric Torres", "32 Briar Court", "Hamburg", "New Jersey", "07419", "erictorres56@gmail.com", "My Comments");
            Assert.IsNotNull(result);
        }

        [TestMethod]
         public void ShipSent()
         {
             PhoneController phone = new PhoneController(_storage.Object, _gadgets.Object, _offerBuilder.Object, _messenger.Object);
             ActionResult result = phone.ShipSent();
             Assert.IsNotNull(result);
         }  
    }
}
