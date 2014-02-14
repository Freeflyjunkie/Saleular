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
        private IGadgetRepository _gadget;
        public IGadgetRepository GadgetRepository
        {
            get
            {
                if (_gadget == null)
                {
                    _gadget = new GadgetRepository(new SaleularContext());
                }
                return _gadget;
            }
            set
            {
                _gadget = value;
            }
        }       

        private IMessenger _messenger;
        public IMessenger Messenger
        {
            get
            {
                if (_messenger == null)
                {
                    _messenger = new EmailMessenger();
                }
                return _messenger;
            }
            set
            {
                _messenger = value;
            }
        }

        public ActionResult Index()
        {
            TopOffersViewModel offers = new TopOffersViewModel();
            offers.Gadgets = GadgetRepository.GetTopOffersPaid();
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
            string unknown = "Unknown";
            string body = Messenger.ConstructMessage(unknown, unknown, unknown, unknown, email, question);
            Messenger.SendMessage(email, "Cash For My Phone", body);
            return View("QuestionSent");
        }

        public ActionResult Testimonials()
        {
            return View();
        }
    }
}