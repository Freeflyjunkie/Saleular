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
        Task<IEnumerable<Gadget>> GetTopOffersPaid(string type, string model);
        Gadget GetGadgetById(int gadgetId);
        void InsertGadget(Gadget gadget);
        void DeleteGadget(int gadgetId);
        void UpdateGadget(Gadget gadget);
        IEnumerable<string> GetDistinctTypes();
        IEnumerable<string> GetDistinctModels(string type);
        IEnumerable<string> GetDistinctCarriers(string model);
        IEnumerable<string> GetDistinctCapacities(string model);
        IEnumerable<string> GetDistinctConditions(string type);
        decimal GetPrice(string model, string carrier, string capacity, string condition);
        void Save();
    }
}
