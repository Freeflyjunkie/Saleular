﻿using System;
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
    [Authorize(Users = "etorres,rbitran")]
    public class GadgetManagementController : Controller
    {
        private SaleularContext db = new SaleularContext();

        // GET: /GadgetManagement/
        public ActionResult Index()
        {
            return View(db.Gadgets.ToList());
        }

        // GET: /GadgetManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gadget gadget = db.Gadgets.Find(id);
            if (gadget == null)
            {
                return HttpNotFound();
            }
            return View(gadget);
        }

        // GET: /GadgetManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GadgetManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GadgetID,Type,Model,Capacity,Carrier,Condition,ImageUrl,Price")] Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                db.Gadgets.Add(gadget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gadget);
        }

        // GET: /GadgetManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gadget gadget = db.Gadgets.Find(id);
            if (gadget == null)
            {
                return HttpNotFound();
            }
            return View(gadget);
        }

        // POST: /GadgetManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GadgetID,Type,Model,Capacity,Carrier,Condition,ImageUrl,Price")] Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gadget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gadget);
        }

        // GET: /GadgetManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gadget gadget = db.Gadgets.Find(id);
            if (gadget == null)
            {
                return HttpNotFound();
            }
            return View(gadget);
        }

        // POST: /GadgetManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gadget gadget = db.Gadgets.Find(id);
            db.Gadgets.Remove(gadget);
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