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
        protected IStorage _storage;        
        protected IGadgetRepository _gadget;        
        protected IOfferBuilder _offerBuilder;
        protected IMessenger _messenger;

        public PhoneController(IStorage storage, IGadgetRepository gadget, IOfferBuilder offerBuilder, IMessenger messenger)
        {
            _storage = storage;
            _gadget = gadget;
            _offerBuilder = offerBuilder;
            _messenger = messenger;
        }

        public ActionResult Offer()
        {
            SelectedGadgetViewModel gadgetViewModel = _offerBuilder.InitializeSelectedGadgetViewModel();
            return View(gadgetViewModel);
        }      

        [HttpPost]
        public JsonResult GetSelectedGadgetViewModel(SelectedGadgetViewModel selectedGadget)
        {
            selectedGadget = _offerBuilder.SelectionChanged(selectedGadget);
            _storage.Save("SelectedGadgetViewModel", selectedGadget);
            return Json(selectedGadget, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Ship()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Ship(string name, string address, string city, string state, string zip, string email, string comments)
        {                        
            SelectedGadgetViewModel selectedGadget = (SelectedGadgetViewModel)_storage.Retrieve("SelectedGadgetViewModel");
            string body = _messenger.ConstructMessage(name, address, city, state, zip, email, comments, selectedGadget);
            _messenger.SendMessage(email, "Cash For My Phone", body);
            return RedirectToAction("ShipSent");            
        }

        public ActionResult ShipSent()
        {
            return View();
        }
    }
}
