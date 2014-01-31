using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saleular.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Saleular About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Questions()
        {
            ViewBag.Message = "Your questions page.";

            return View("Questions");
        }

        public ActionResult Testimonials()
        {
            ViewBag.Message = "Your testimonials page.";

            return View("Testimonials");
        }
    }
}