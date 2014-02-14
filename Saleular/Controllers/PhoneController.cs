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
        private IOfferBuilder _offerBuilder;
        public IOfferBuilder PhoneOfferBuilder
        {
            get
            {
                if (_offerBuilder == null)
                {
                    _offerBuilder = new PhoneOfferBuilder(new GadgetRepository());
                }
                return _offerBuilder;
            }
            set
            {
                _offerBuilder = value;
            }
        }

        public ActionResult Offer()
        {
            SelectedPhoneViewModel selectedIPhone = (SelectedPhoneViewModel)PhoneOfferBuilder.InitializeSelectedGadgetViewModel();
            return View(selectedIPhone);
        }      

        [HttpPost]
        public JsonResult GetSelectedPhoneViewModel(string model, string carrier, string capacity, string condition)
        {
            SelectedPhoneViewModel selection = new SelectedPhoneViewModel();
            selection.SelectedModel = model;
            selection.SelectedCarrier = carrier;
            selection.SelectedCapacity = capacity;
            selection.SelectedCondition = condition;

            selection = (SelectedPhoneViewModel)PhoneOfferBuilder.SelectionChanged(selection);
            return Json(selection, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ship()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Ship(string name, string address, string city, string state, string zip, string email, string comments)
        {            
            IMessenger messenger = new EmailMessenger();
            string body = messenger.ConstructMessage(address, city, state, zip, email, comments);
            messenger.SendMessage(email, "Cash For My Phone", body);
            return RedirectToAction("ShipSent");            
        }

        public ActionResult ShipSent()
        {
            return View();
        }
    }
}
