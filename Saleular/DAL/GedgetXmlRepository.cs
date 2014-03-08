using Saleular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Saleular.Models;

namespace Saleular.DAL
{
    public class GedgetXmlRepository : IGadgetRepository
    {
        public void SetContext(SaleularContext context)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Gadget>> GetTopOffersPaidAsync(string type, string model, int take)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Gadget>> GetTopOffersPaidRandomAsync(int take)
        {
            throw new NotImplementedException();
        }

        public Models.Gadget GetGadgetById(int gadgetId)
        {
            throw new NotImplementedException();
        }

        public void InsertGadget(Gadget gadget)
        {
            throw new NotImplementedException();
        }

        public void DeleteGadget(int gadgetId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGadget(Gadget gadget)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDistinctTypes()
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<string> GetDistinctModels(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDistinctCarriers(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDistinctCapacities(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDistinctConditions(string type)
        {
            throw new NotImplementedException();
        }

        public decimal GetPrice(string model, string carrier, string capacity, string condition)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}