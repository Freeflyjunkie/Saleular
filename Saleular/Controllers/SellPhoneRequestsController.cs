using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Saleular.DAL;
using Saleular.Models;

namespace Saleular.Controllers
{
    public class SellPhoneRequestsController : Controller
    {
        private SaleularContext db = new SaleularContext();

        // GET: SellPhoneRequests
        public ActionResult Index()
        {
            return View(db.SellPhoneRequests.ToList());
        }

        // GET: SellPhoneRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellPhoneRequest sellPhoneRequest = db.SellPhoneRequests.Find(id);
            if (sellPhoneRequest == null)
            {
                return HttpNotFound();
            }
            return View(sellPhoneRequest);
        }

        // GET: SellPhoneRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellPhoneRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceListRequestId,BusinessName,Name,Email,Phone,Address,TaxId,Quantity,Model,Carrier,Capacity,Condition,CreatedDate")] SellPhoneRequest sellPhoneRequest)
        {
            if (ModelState.IsValid)
            {
                db.SellPhoneRequests.Add(sellPhoneRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellPhoneRequest);
        }

        // GET: SellPhoneRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellPhoneRequest sellPhoneRequest = db.SellPhoneRequests.Find(id);
            if (sellPhoneRequest == null)
            {
                return HttpNotFound();
            }
            return View(sellPhoneRequest);
        }

        // POST: SellPhoneRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceListRequestId,BusinessName,Name,Email,Phone,Address,TaxId,Quantity,Model,Carrier,Capacity,Condition,CreatedDate")] SellPhoneRequest sellPhoneRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellPhoneRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellPhoneRequest);
        }

        // GET: SellPhoneRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellPhoneRequest sellPhoneRequest = db.SellPhoneRequests.Find(id);
            if (sellPhoneRequest == null)
            {
                return HttpNotFound();
            }
            return View(sellPhoneRequest);
        }

        // POST: SellPhoneRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellPhoneRequest sellPhoneRequest = db.SellPhoneRequests.Find(id);
            db.SellPhoneRequests.Remove(sellPhoneRequest);
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
