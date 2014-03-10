using Saleular.DAL;
using Saleular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Saleular.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Saleular.Classes.Repositories
{
    public class GadgetRepository : IGadgetRepository
    {
        protected SaleularContext Context = new SaleularContext();

        public void SetContext(SaleularContext context)
        {
            Context = context;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            return Context.Gadgets.ToList();
        }

        public async Task<IEnumerable<Gadget>> GetTopOffersPaidAsync(string type, string model, int take)
        {
            // select random
            return await Context.Gadgets
                .Where(g => g.Type == type && g.Model == model)                
                .OrderBy(g => Guid.NewGuid()).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<Gadget>> GetTopOffersPaidRandomAsync(int take)
        {
            return await Context.Gadgets
                .Where(g => !g.Model.Contains("3G"))
                .OrderBy(g => Guid.NewGuid()).Take(take).ToListAsync();
        }

        public Gadget GetGadgetById(int gadgetId)
        {
            return Context.Gadgets.Find(gadgetId);
        }
     
        public void InsertGadget(Gadget gadget)
        {
            Context.Gadgets.Add(gadget);
        }

        public void DeleteGadget(int gadgetId)
        {
            Gadget gadget = Context.Gadgets.Find(gadgetId);
            Context.Gadgets.Remove(gadget);
        }

        public void UpdateGadget(Gadget gadget)
        {
            Context.Entry(gadget).State = EntityState.Modified;
        }

        public IEnumerable<string> GetDistinctTypes()
        {
            return Context.Gadgets                          
                          .Select(p => p.Type).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctModels(string type)
        {
            return Context.Gadgets
                          .Where(p => p.Type == type)
                          .Select(p => p.Model).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctCarriers(string model)
        {
            return Context.Gadgets
                       .Where(p => p.Model == model)
                       .Select(c => c.Carrier).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctCapacities(string model)
        {
            return Context.Gadgets
                   .Where(p => p.Model == model)
                   .Select(c => c.Capacity).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctConditions(string type)
        {
            return Context.Gadgets
                    .Where(g => g.Type == type)
                    .Select(p => p.Condition).Distinct().ToList();
        }

        public decimal GetPrice(string model, string carrier, string capacity, string condition)
        {
            return Context.Gadgets
                    .Where(p => p.Model == model
                        && p.Carrier == carrier
                        && p.Capacity == capacity
                        && p.Condition == condition)
                    .Select(c => c.Price).SingleOrDefault();
        }

        public Gadget GetGadget(string type, string model, string carrier, string capacity, string condition)
        {
            return Context.Gadgets.SingleOrDefault(g => g.Type == type
                                                        && g.Model == model
                                                        && g.Carrier == carrier
                                                        && g.Capacity == capacity
                                                        && g.Condition == condition);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }
        
    }
}