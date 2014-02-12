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

namespace Saleular.Tests.Controllers
{
    [TestClass]
    public class PhoneControllerTest
    {
        [TestMethod]
        public void Index()
        {            
            ////ViewResult result = controller.Offer() as ViewResult;
            //Mock<SaleularContext> phone = new Mock<SaleularContext>();
            //phone.Setup(r => r.Phones.ToList()).Returns(() => new Phone[] 
            //{ 
            //    new Phone { Type = "iPhone", Model = "A", Carrier = "B" },
            //    new Phone { Type = "iPhone", Model = "B", Carrier = "C" }
            //});


            //PhoneController controller = new PhoneController();            

         
            //Assert.IsNotNull(phone);
        }
    }
}
