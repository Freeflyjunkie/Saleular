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

namespace Saleular.Controllers
{
    public class PhoneController : Controller
    {
        private SaleularContext db = new SaleularContext();

        public ActionResult SelectModel()
        {
            return View("SelectModel");
        }

        public ActionResult SelectCarrier()
        {
            return View("SelectCarrier");
        }

        public ActionResult SelectCapacity()
        {
            return View("SelectCapacity");
        }

        public ActionResult SelectCondition()
        {
            return View("SelectCondition");
        }

        public ActionResult Offer()
        {
            return View("Offer");
        }

        public ActionResult Ship()
        {
            return View("Ship");
        }

        public ActionResult Paid()
        {
            return View("Paid");
        }               

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
