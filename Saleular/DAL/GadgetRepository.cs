using Saleular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Models;
using System.Data.Entity;

namespace Saleular.DAL
{
    public class GadgetRepository : IGadgetRepository
    {
        protected SaleularContext _context = new SaleularContext();

        public IEnumerable<Gadget> GetGadgets()
        {
            return _context.Gadgets.ToList();
        }

        public IEnumerable<Gadget> GetTopOffersPaid()
        {
            return _context.Gadgets
                .Where(g => g.Type == "iPhone" && g.Model == "5S")
                .OrderBy(g => g.GadgetID).Take(5);
        }

        public Gadget GetGadgetByID(int gadgetID)
        {
            return _context.Gadgets.Find(gadgetID);
        }

        public void InsertGadget(Gadget gadget)
        {
            _context.Gadgets.Add(gadget);
        }

        public void DeleteGadget(int gadgetID)
        {
            Gadget gadget = _context.Gadgets.Find(gadgetID);
            _context.Gadgets.Remove(gadget);
        }

        public void UpdateGadget(Gadget gadget)
        {
            _context.Entry(gadget).State = EntityState.Modified;
        }

        public IEnumerable<string> GetTypesAndModels()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDistinctModels(string type)
        {
            return _context.Gadgets
                          .Where(p => p.Type == type)
                          .Select(p => p.Model).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctCarriers(string model)
        {
            return _context.Gadgets
                       .Where(p => p.Model == model)
                       .Select(c => c.Carrier).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctCapacities(string model)
        {
            return _context.Gadgets
                   .Where(p => p.Model == model)
                   .Select(c => c.Capacity).Distinct().ToList();
        }

        public IEnumerable<string> GetConditions()
        {
            return _context.Gadgets
                    .Select(p => p.Condition).Distinct().ToList();
        }

        public decimal GetPrice(string model, string carrier, string capacity, string condition)
        {
            return _context.Gadgets
                    .Where(p => p.Model == model
                        && p.Carrier == carrier
                        && p.Capacity == capacity
                        && p.Condition == condition)
                    .Select(c => c.Price).SingleOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

    }
}