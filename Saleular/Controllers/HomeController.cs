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
        SaleularContext db = new SaleularContext();

        public ActionResult Index()
        {
            OffersPaid offers = new OffersPaid();            
            offers.iPhone5Ss  = db.Phones.Where(phone => phone.Type == "iPhone" && phone.Model == "5S").OrderBy(phone => phone.PhoneID).Take(5);
            //offers.iPhone5Cs = db.Phones.Where(phone => phone.Type == "iPhone" && phone.Model == "5C");
            //offers.iPhone5s = db.Phones.Where(phone => phone.Type == "iPhone" && phone.Model == "5");
            //offers.iPhone4Ss = db.Phones.Where(phone => phone.Type == "iPhone" && phone.Model == "4S");         
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
            //messenger.SendMessage(email, "Cash For My Phone", body);
            return View("QuestionSent");
        }

        public ActionResult Testimonials()
        {            
            return View("Testimonials");
        }
    }
}