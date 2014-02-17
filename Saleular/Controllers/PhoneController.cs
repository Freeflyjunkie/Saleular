using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Saleular.Models;
using Saleular.DAL;
using Saleular.ViewModels;
using Saleular.Classes;
using Saleular.Interfaces;

namespace Saleular.Controllers
{
    public class PhoneController : Controller
    {
        protected IStorage Storage;        
        protected IGadgetRepository Gadget;        
        protected IOfferBuilder OfferBuilder;
        protected IMessenger Messenger;

        public PhoneController(IStorage storage, IGadgetRepository gadget, IOfferBuilder offerBuilder, IMessenger messenger)
        {
            Storage = storage;
            Gadget = gadget;
            OfferBuilder = offerBuilder;
            Messenger = messenger;
            
            //var factory = new MessageFactory();
            //Messenger = factory.CreateMessenger(MessageFactory.MessengerType.Email);
        }

        public ActionResult Offer()
        {            
            var gadgetViewModel = OfferBuilder.InitializeSelectedGadgetViewModel();
            return View(gadgetViewModel);
        }      

        [HttpPost]
        public JsonResult GetSelectedGadgetViewModel(SelectedGadgetViewModel selectedGadget)
        {
            selectedGadget = OfferBuilder.SelectionChanged(selectedGadget);
            Storage.Save("SelectedGadgetViewModel", selectedGadget);
            return Json(selectedGadget, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Ship()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Ship(string name, string address, string city, string state, string zip, string email, string comments)
        {           
            var selectedGadget = (SelectedGadgetViewModel)Storage.Retrieve("SelectedGadgetViewModel");            
            var body = Messenger.ConstructMessage(name, address, city, state, zip, email, comments, selectedGadget);            
            Messenger.SendMessage(email, "Cash For My Phone", body);
            return RedirectToAction("ShipSent");            
        }

        public ActionResult ShipSent()
        {
            return View();
        }
    }
}
