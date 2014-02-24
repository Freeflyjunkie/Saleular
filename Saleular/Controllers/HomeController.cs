using System.Threading.Tasks;
using Saleular.Classes;
using Saleular.DAL;
using Saleular.Forms;
using Saleular.Interfaces;
using Saleular.Models;
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
        protected IGadgetRepository Gadget;       
        protected IMessenger Messenger;
        private readonly TopOffersViewModel _offers = new TopOffersViewModel();

        public HomeController(IGadgetRepository gadget, IMessenger messenger)
        {
            Gadget = gadget;
            Messenger = messenger;
            _offers = new TopOffersViewModel();
        }

        public ActionResult Index()
        {
            //IFormFactory factory = new PAFormFactory();
            //var formlist = factory.GetForms("mls");
            //List<string> forms = formlist.GetForms();

            _offers.Gadgets = Gadget.GetTopOffersPaid("iPhone", "5S");
            //var task = Task.Factory.StartNew(PerformGetTopOffersViewModel);            
            return View(_offers);
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
            var body = Messenger.ConstructMessage(name, email, question);
            Messenger.SendMessage(email, "Cash For My Phone", body);
            return View("QuestionSent");
        }

        public ActionResult Testimonials()
        {
            return View();
        }

        private void PerformGetTopOffersViewModel()
        {
            _offers.Gadgets = Gadget.GetTopOffersPaid("iPhone", "5S");            
        }
    }
}