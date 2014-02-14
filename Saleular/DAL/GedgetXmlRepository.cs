using Saleular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.DAL
{
    public class GedgetXmlRepository : IGadgetRepository
    {
        public IEnumerable<Models.Gadget> GetGadgets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Gadget> GetTopOffersPaid(string type, string model)
        {
            throw new NotImplementedException();
        }

        public Models.Gadget GetGadgetByID(int gadgetID)
        {
            throw new NotImplementedException();
        }

        public void InsertGadget(Models.Gadget gadget)
        {
            throw new NotImplementedException();
        }

        public void DeleteGadget(int gadgetID)
        {
            throw new NotImplementedException();
        }

        public void UpdateGadget(Models.Gadget gadget)
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