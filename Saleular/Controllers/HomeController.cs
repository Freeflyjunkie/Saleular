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
        protected IGadgetRepository _gadget;       
        protected IMessenger _messenger;        
        protected const string UNKNOWN = "Unknown";

        public HomeController(IGadgetRepository gadget, IMessenger messenger)
        {
            _gadget = gadget;
            _messenger = messenger;
        }

        public ActionResult Index()
        {
            TopOffersViewModel offers = new TopOffersViewModel();
            offers.Gadgets = _gadget.GetTopOffersPaid("iPhone", "5S");
            return View(offers);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Questions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questions(string name, string email, string question)
        {
            string body = _messenger.ConstructMessage(name, email, question);
            _messenger.SendMessage(email, "Cash For My Phone", body);
            return View("QuestionSent");
        }

        public ActionResult Testimonials()
        {
            return View();
        }
    }
}