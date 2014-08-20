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
    [Authorize(Users = "etorres,rbitran")]
    public class PriceListRequestsController : Controller
    {
        private SaleularContext db = new SaleularContext();

        // GET: PriceListRequests
        public ActionResult Index()
        {
            return View(db.PriceListRequests.ToList());
        }

        // GET: PriceListRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListRequest priceListRequest = db.PriceListRequests.Find(id);
            if (priceListRequest == null)
            {
                return HttpNotFound();
            }
            return View(priceListRequest);
        }

        // GET: PriceListRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceListRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceListRequestId,BusinessName,Name,Email,Phone,Address,TaxId,BusinessAreaSelection")] PriceListRequest priceListRequest)
        {
            if (ModelState.IsValid)
            {
                db.PriceListRequests.Add(priceListRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priceListRequest);
        }

        // GET: PriceListRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListRequest priceListRequest = db.PriceListRequests.Find(id);
            if (priceListRequest == null)
            {
                return HttpNotFound();
            }
            return View(priceListRequest);
        }

        // POST: PriceListRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceListRequestId,BusinessName,Name,Email,Phone,Address,TaxId,BusinessAreaSelection")] PriceListRequest priceListRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceListRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priceListRequest);
        }

        // GET: PriceListRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListRequest priceListRequest = db.PriceListRequests.Find(id);
            if (priceListRequest == null)
            {
                return HttpNotFound();
            }
            return View(priceListRequest);
        }

        // POST: PriceListRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceListRequest priceListRequest = db.PriceListRequests.Find(id);
            db.PriceListRequests.Remove(priceListRequest);
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
