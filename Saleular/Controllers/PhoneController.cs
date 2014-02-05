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
            selectedIPhone.SelectedModel = model;
            selectedIPhone.SelectedTypeAndModel = "iPhone " + model;            

            using (SaleularContext db = new SaleularContext())
            {
                selectedIPhone.Carriers = db.Phones
                    .Where(p => p.Model == model)
                    .Select(c => c.Carrier).Distinct().ToList();
            }

            if(!selectedIPhone.Carriers.Contains(selectedIPhone.SelectedCarrier))
            {
                selectedIPhone.SelectedCarrier = "Select Carrier...";
            }

            Session["SelectIPhone"] = selectedIPhone;

            return View("Offer", selectedIPhone);
        }

        public ActionResult SelectCarrier(string carrier)
        {
            SelectediPhone selectedIPhone = (SelectediPhone)Session["SelectIPhone"];
            
            if (selectedIPhone.SelectedCarrier.Contains("Select"))
            {
                selectedIPhone.SelectedCarrier = carrier;
            }

            using (SaleularContext db = new SaleularContext())
            {                
                selectedIPhone.Capacities = db.Phones
                    .Where(p => p.Model == selectedIPhone.SelectedModel && p.Carrier == selectedIPhone.SelectedCarrier)
                    .Select(c => c.Capacity).Distinct().ToList();
            }

            if (!selectedIPhone.Capacities.Contains(selectedIPhone.SelectedCapacity))
            {
                selectedIPhone.SelectedCapacity = "Select Capacity...";
            }

            Session["SelectIPhone"] = selectedIPhone;

            return View("Offer", selectedIPhone);
        }

        public ActionResult SelectCapacity(string capacity)
        {
            SelectediPhone selectedIPhone = (SelectediPhone)Session["SelectIPhone"];
            selectedIPhone.SelectedCapacity = capacity;

            using (SaleularContext db = new SaleularContext())
            {
                selectedIPhone.Conditions = db.Phones
                    .Where(p => p.Model == selectedIPhone.SelectedModel && p.Carrier == selectedIPhone.SelectedCarrier && p.Capacity == selectedIPhone.SelectedCapacity)
                    .Select(c => c.Condition).Distinct().ToList();
            }

            Session["SelectIPhone"] = selectedIPhone;

            return View("Offer", selectedIPhone);
        }

        public ActionResult SelectCondition(string condition)
        {
            SelectediPhone selectedIPhone = (SelectediPhone)Session["SelectIPhone"];
            selectedIPhone.SelectedCondition = condition;

            using (SaleularContext db = new SaleularContext())
            {
                selectedIPhone.Price = db.Phones
                    .Where(p => p.Model == selectedIPhone.SelectedModel 
                        && p.Carrier == selectedIPhone.SelectedCarrier 
                        && p.Capacity == selectedIPhone.SelectedCapacity
                        && p.Condition == selectedIPhone.SelectedCondition)
                    .Select(c => c.Price).SingleOrDefault();
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
