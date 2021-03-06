﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Saleular.Classes.Factories;
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
        protected ISellPhoneRequestRepository SellPhoneRequestRepository;
        protected IOfferBuilder OfferBuilder;
        //protected IMessenger Messenger;

        public PhoneController(IStorage storage, 
            IRequestRepository request, 
            IPriceListRequestRepository priceListRequestRepository, 
            ISellPhoneRequestRepository sellPhoneRequestRepository,
            IOfferBuilder offerBuilder)
        {
            Storage = storage;
            RequestRespository = request;
            PriceListRequestRepository = priceListRequestRepository;
            SellPhoneRequestRepository = sellPhoneRequestRepository;
            OfferBuilder = offerBuilder;
        }

        public ActionResult BrowseSelection()
        {
            return View();
        }

        public ActionResult PriceList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PriceList(string businessName, string name, string email, string phone, string address, string taxId,
            string businessAreaHidden)
        {            
            var priceListRequest = new PriceListRequest
            {
                BusinessName = businessName,                
                Name = name,
                Email = email,
                Phone = phone,
                Address = address,
                TaxId = taxId,
                BusinessAreaSelection = businessAreaHidden,
                CreatedDate = DateTime.Now
            };
            PriceListRequestRepository.InsertRequest(priceListRequest);
            PriceListRequestRepository.Save();                       

            var factory = new MessageFactory();
            var messenger = factory.CreateMessenger(MessageFactory.MessengerType.Email);
            var emailBody = messenger.ConstructMessage(priceListRequest);
            messenger.SendMessage("", "Price List Request", emailBody);            

            return View("PriceListSent", priceListRequest);
        }

        public async Task<ActionResult> SellPhone()
        {
            var gadgetViewModel = await OfferBuilder.InitializeSelectedGadgetViewModelAsync();
            gadgetViewModel.SelectedType = "iPhone";
            gadgetViewModel = await OfferBuilder.SelectionChangedAsync(gadgetViewModel);
            Storage.Save("SelectedGadgetViewModel", gadgetViewModel);
            return View(gadgetViewModel);
        }

        [HttpPost]
        public ActionResult SellPhone(string businessName, string name, string email, string phone, string address, 
            string quantity, string modelHidden, string capacityHidden, string carrierHidden, string conditionHidden)
        {
           var sellphoneRequest = new SellPhoneRequest
            {
                BusinessName = businessName,
                Name = name,
                Email = email,
                Phone = phone,
                Address = address,                
                Quantity = quantity,
                Model = modelHidden,
                Capacity = capacityHidden,
                Carrier = carrierHidden,
                Condition = conditionHidden,                
                CreatedDate = DateTime.Now
            };
            SellPhoneRequestRepository.InsertRequest(sellphoneRequest);
            SellPhoneRequestRepository.Save();

             var factory = new MessageFactory();
            var messenger = factory.CreateMessenger(MessageFactory.MessengerType.Email);
            var emailBody = messenger.ConstructMessage(sellphoneRequest);
            messenger.SendMessage("", "Sell Phone Request", emailBody);

            return View("SellPhoneSent", sellphoneRequest);
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
                City = city,
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
