using System.Threading.Tasks;
using Ninject.Infrastructure.Language;
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
using System.Threading;

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

        [AsyncTimeout(5000)]
        [HandleError(ExceptionType=typeof(TimeoutException), View="Timeout")]
        public async Task<ActionResult> Index(CancellationToken ctk)
        {
            //IFormFactory factory = new PAFormFactory();
            //var formlist = factory.GetForms("mls");
            //List<string> forms = formlist.GetForms();    
            //_offers.Gadgets = Gadget.GetTopOffersPaid("iPhone", "5S");                        

            _offers.Gadgets = await GetTopOffersAsync();            
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

        private async Task<IEnumerable<Gadget>> GetTopOffersAsync()
        {
            return await Gadget.GetTopOffersPaidAsync("iPhone", "5S");
        }
    }
}