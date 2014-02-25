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
using System.Threading.Tasks;

namespace Saleular.Tests.Controllers
{
    [TestClass]
    public class PhoneControllerTest
    {
        protected Mock<IStorage> Storage;
        protected Mock<IGadgetRepository> Gadgets;
        protected Mock<IOfferBuilder> OfferBuilder;
        protected Mock<IMessenger> Messenger;

        public PhoneControllerTest()
        {

            Storage = new Mock<IStorage>();
            Storage.Setup(s => s.Save(It.IsAny<string>(), It.IsAny<string>()));
            Storage.Setup(s => s.Retrieve(It.IsAny<string>())).Returns(new SelectedGadgetViewModel());

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

            OfferBuilder = new Mock<IOfferBuilder>();
            OfferBuilder.Setup(o => o.InitializeSelectedGadgetViewModel()).Returns(new SelectedGadgetViewModel());
            OfferBuilder.Setup(o => o.SelectionChanged(new SelectedGadgetViewModel())).Returns(new SelectedGadgetViewModel());

            Messenger = new Mock<IMessenger>();
            Messenger.Setup(m => m.ConstructMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("Question Message Body");
            Messenger.Setup(m => m.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [TestMethod]
        public void Offer()
        {
            PhoneController phone = new PhoneController(Storage.Object, Gadgets.Object, OfferBuilder.Object, Messenger.Object);
            ActionResult result = phone.Offer();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSelectedPhoneViewModel()
        {
            PhoneController phone = new PhoneController(Storage.Object, Gadgets.Object, OfferBuilder.Object, Messenger.Object);
            SelectedGadgetViewModel selectedGadget = new SelectedGadgetViewModel();
            selectedGadget.SelectedType = "iPhone";
            ActionResult result = phone.GetSelectedGadgetViewModel(selectedGadget);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Ship()
        {
            PhoneController phone = new PhoneController(Storage.Object, Gadgets.Object, OfferBuilder.Object, Messenger.Object);
            ActionResult result = phone.Ship();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShippingLabelRequest()
        {
            PhoneController phone = new PhoneController(Storage.Object, Gadgets.Object, OfferBuilder.Object, Messenger.Object);
            ActionResult result = phone.Ship("Eric Torres", "32 Briar Court", "Hamburg", "New Jersey", "07419", "erictorres56@gmail.com", "My Comments");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShipSent()
        {
            PhoneController phone = new PhoneController(Storage.Object, Gadgets.Object, OfferBuilder.Object, Messenger.Object);
            ActionResult result = phone.ShipSent();
            Assert.IsNotNull(result);
        }
    }
}
