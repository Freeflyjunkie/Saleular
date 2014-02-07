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
        public ActionResult Offer()
        {
            SelectediPhone selectedIPhone = PhoneSelectionManager.InitializeSelection();
            return View(selectedIPhone);
        }
       
        public ActionResult ChangeSelection(string model, string carrier, string capacity, string condition){
            SelectediPhone selectedIPhone = PhoneSelectionManager.SelectionChanged(model, carrier, capacity, condition);
            return View("Offer",selectedIPhone);
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
            return View("ShipLabelRequestSent");
        }
    }
}
