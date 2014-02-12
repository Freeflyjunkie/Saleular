using Saleular.Classes;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saleular.Controllers
{
    public class HomeController : Controller
    {
        //SaleularContext db = new SaleularContext();
        IPhoneRepository iphone = new PhoneRepository(new SaleularContext());

        public ActionResult Index()
        {
            TopOffersViewModel offers = new TopOffersViewModel();
            offers.iPhone5Ss = iphone.GetTopOffersPaid();                           
            return View(offers);
        }

        public ActionResult About()
        {            
            return View();
        }

        public ActionResult Questions()
        {            
            return View("Questions");
        }

        [HttpPost]
        public ActionResult Questions(string name, string email, string question)
        {
            IMessenger messenger = new EmailMessenger();
            string unknown = "Unknown";
            string body = messenger.ConstructMessage(unknown, unknown, unknown, unknown, email, question);
            messenger.SendMessage(email, "Cash For My Phone", body);
            return View("QuestionSent");
        }

        public ActionResult Testimonials()
        {            
            return View("Testimonials");
        }
    }
}