using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Saleular.Models;
using Saleular.DAL;
using Saleular.ViewModels;
using Saleular.Classes;
using Saleular.Interfaces;

namespace Saleular.Controllers
{
    [AllowAnonymous]
    public class PhoneController : Controller
    {
        protected IStorage Storage;        
        //protected IGadgetRepository GadgetRepository;
        protected IRequestRepository RequestRespository;
        protected IPriceListRequestRepository PriceListRequestRepository;
        protected IOfferBuilder OfferBuilder;
        //protected IMessenger Messenger;

        public PhoneController(IStorage storage, IRequestRepository request, IPriceListRequestRepository priceListRequest, IOfferBuilder offerBuilder)
        {
            Storage = storage;            
            RequestRespository = request;
            PriceListRequestRepository = priceListRequest;
            OfferBuilder = offerBuilder;            
        }
        
        public ActionResult PriceList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PriceList(string businessName, string name, string email, string phone, string address, string taxId, string businessAreaSelection)
        {
            //var factory = new MessageFactory();
            //var messenger = factory.CreateMessenger(MessageFactory.MessengerType.Email);
            //var emailBody = messenger.ConstructMessage(businessName, name, email, phone, address, taxId, businessAreaSelection);
            //messenger.SendMessage("", "Price List Request", emailBody);

            //var selectedGadget = (SelectedGadgetViewModel)Storage.Retrieve("SelectedGadgetViewModel");
            var priceListRequest = new PriceListRequest
            {
                BusinessName = businessName,
                Name = name,
                Email = email,
                Phone = phone,
                Address = address,
                TaxId = taxId,
                BusinessAreaSelection = businessAreaSelection
            };
            PriceListRequestRepository.InsertRequest(priceListRequest);
            PriceListRequestRepository.Save();
            return View("PriceListSent");
        }

        public async Task<ActionResult> Offer()
        {            
            var gadgetViewModel = await OfferBuilder.InitializeSelectedGadgetViewModelAsync();
            return View(gadgetViewModel);
        }      

        [HttpPost]
        public async Task<JsonResult> GetSelectedGadgetViewModel(SelectedGadgetViewModel selectedGadget)
        {
            selectedGadget = await OfferBuilder.SelectionChangedAsync(selectedGadget);
            Storage.Save("SelectedGadgetViewModel", selectedGadget);
            return Json(selectedGadget, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Ship()
        {
            var selectedGadgetViewModel = (SelectedGadgetViewModel)Storage.Retrieve("SelectedGadgetViewModel");
            return View(selectedGadgetViewModel);
        }

        [HttpPost]
        public ActionResult Ship(int id, string name, string address, string city, string state, string zip, string email, string comments)
        {           
            var selectedGadget = (SelectedGadgetViewModel)Storage.Retrieve("SelectedGadgetViewModel");
            var request = new Request
            {
                GadgetId = id,
                Name = name,
                Address = address,
                City =city,
                State = state,
                Zip = zip,
                Email = email,
                Comment = comments
            };
            RequestRespository.InsertRequest(request);
            RequestRespository.Save();
            //var body = Messenger.ConstructMessage(name, address, city, state, zip, email, comments, selectedGadget);            
            //Messenger.SendMessage(email, "Cash For My Phone", body);            
            return RedirectToAction("ShipSent");            
        }

        public ActionResult ShipSent()
        {
            return View();
        }
    }
}
