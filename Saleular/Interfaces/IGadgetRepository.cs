using Saleular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    public interface IGadgetRepository : IDisposable
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetTopOffersPaid();
        Gadget GetGadgetByID(int gadgetID);
        void InsertGadget(Gadget gadget);
        void DeleteGadget(int gadgetID);
        void UpdateGadget(Gadget gadget);
        IEnumerable<string> GetTypesAndModels();
        IEnumerable<string> GetDistinctModels(string type);
        IEnumerable<string> GetDistinctCarriers(string model);
        IEnumerable<string> GetDistinctCapacities(string model);
        IEnumerable<string> GetConditions();
        decimal GetPrice(string model, string carrier, string capacity, string condition);
        void Save();
    }
}
