using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Saleular.Classes.Factories;
using Saleular.Interfaces;
using Saleular.Models;
using Saleular.DAL;
using Saleular.ViewModels;

namespace Saleular.Controllers
{
    public class RequestController : Controller
    {
        private readonly SaleularContext db = new SaleularContext();
        protected IStorage Storage;
        protected IPriceListRequestRepository PriceListRequestRepository;

        public RequestController(IStorage storage, IPriceListRequestRepository request)
        {
            Storage = storage;
            PriceListRequestRepository = request;
        }

        public ActionResult Gadgets()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Gadgets(string businessName, string name, string email, string phone, string address, string taxId, string businessAreaSelection)
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
            return View();
        }

        // GET: /Request/
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Gadget);
            return View(requests.ToList());
        }

        // GET: /Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: /Request/Create
        public ActionResult Create()
        {
            ViewBag.GadgetId = new SelectList(db.Gadgets, "GadgetId", "GadgetId");
            return View();
        }

        // POST: /Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,GadgetId,Name,Address,City,Zip,State,Email,Comment")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GadgetId = new SelectList(db.Gadgets, "GadgetId", "Type", request.GadgetId);
            return View(request);
        }

        // GET: /Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.GadgetId = new SelectList(db.Gadgets, "GadgetId", "Type", request.GadgetId);
            return View(request);
        }

        // POST: /Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,GadgetId,Name,Address,City,Zip,State,Email,Comment")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GadgetId = new SelectList(db.Gadgets, "GadgetId", "Type", request.GadgetId);
            return View(request);
        }

        // GET: /Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: /Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
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
