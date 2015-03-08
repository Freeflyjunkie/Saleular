using System.Threading.Tasks;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading;

namespace Saleular.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        protected IGadgetRepository Gadget;
        protected IMessenger Messenger;
        private readonly TopOffersViewModel _topOffersViewModel = new TopOffersViewModel();

        public HomeController(IGadgetRepository gadget, IMessenger messenger)
        {
            Gadget = gadget;
            Messenger = messenger;
            _topOffersViewModel = new TopOffersViewModel();
            //Func<int, int> square = (x) => x * x;
        }

        [AsyncTimeout(30000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "Timeout")]
        public async Task<ActionResult> Index(CancellationToken ctk)
        {
            _topOffersViewModel.TopGadgetsOffers = await Gadget.GetTopOffersPaidRandomAsync(5);
            return View(_topOffersViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult CompanyInfo()
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

        async Task GetTopOffersAsync(string type, string model, int take)
        {
            // A second operation started on this context before a previous asynchronous operation completed. 
            // Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context. 
            // Any instance members are not guaranteed to be thread safe.
            // Cannot send 2 asynchronous on the same context at the same time...
            //Gadget.SetContext(new SaleularContext());            
            var topIPhones = await Gadget.GetTopOffersPaidAsync(type, model, take);
            _topOffersViewModel.TopGadgetsOffers = _topOffersViewModel.TopGadgetsOffers.Concat(topIPhones);
        }
    }
}