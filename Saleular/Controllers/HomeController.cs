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
        private IPhoneRepository _phone;
        public IPhoneRepository PhoneRepository
        {
            get
            {
                if (_phone == null)
                {
                    _phone = new PhoneRepository(new SaleularContext());
                }
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        private IPhoneSelectionManager _phoneSelectionManager;
        public IPhoneSelectionManager PhoneSelectionManager
        {
            get
            {
                if (_phoneSelectionManager == null)
                {
                    _phoneSelectionManager = new PhoneSelectionManager();
                }
                return _phoneSelectionManager;
            }
            set
            {
                _phoneSelectionManager = value;
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
            offers.iPhone5Ss = PhoneRepository.GetTopOffersPaid();
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
            string body = Messenger.ConstructMessage(unknown, unknown, unknown, unknown, email, question, PhoneSelectionManager);
            Messenger.SendMessage(email, "Cash For My Phone", body);
            return View("QuestionSent");
        }

        public ActionResult Testimonials()
        {
            return View();
        }
    }
}