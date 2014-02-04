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

namespace Saleular.Controllers
{
    public class PhoneController : Controller
    {
        public ActionResult Offer()
        {
            SelectediPhone selectedIPhone = new SelectediPhone();

            using (SaleularContext db = new SaleularContext())
            {
                selectedIPhone.Models = db.Phones.Select(p => p.Model).Distinct().ToList();
            }
            Session["SelectIPhone"] = selectedIPhone;
            return View(selectedIPhone);
        }

        public ActionResult SelectModel(string model)
        {
            SelectediPhone selectedIPhone = (SelectediPhone)Session["SelectIPhone"];
            selectedIPhone.SelectedModel = "iPhone " + model;

            using (SaleularContext db = new SaleularContext())
            {
                selectedIPhone.Carriers = db.Phones
                    .Where(p => p.Model == model)
                    .Select(c => c.Carrier).Distinct().ToList();
            }
            Session["SelectIPhone"] = selectedIPhone;

            return View("Offer", selectedIPhone);
        }

        public ActionResult SelectCarrier(string carrier)
        {
            SelectediPhone selectedIPhone = (SelectediPhone)Session["SelectIPhone"];
            selectedIPhone.SelectedCarrier = carrier;

            using (SaleularContext db = new SaleularContext())
            {
                selectedIPhone.Capacities = db.Phones
                    .Where(p => p.Model == selectedIPhone.SelectedModel && p.Carrier == selectedIPhone.SelectedCarrier)
                    .Select(c => c.Capacity).Distinct().ToList();
            }
            Session["SelectIPhone"] = selectedIPhone;

            return View("Offer", selectedIPhone);
        }

        public ActionResult Ship()
        {
            return View("Ship");
        }

        public ActionResult Paid()
        {
            return View("Paid");
        }

    }
}
