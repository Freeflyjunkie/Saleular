using Saleular.DAL;
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
        void SetContext(SaleularContext context);
        IEnumerable<Gadget> GetGadgets();       
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
        Gadget GetGadget(string type, string model, string carrier, string capacity, string condition);
        Task<IEnumerable<Gadget>> GetTopOffersPaidAsync(string type, string model, int take);
        Task<IEnumerable<Gadget>> GetTopOffersPaidRandomAsync(int take);
        Task<IEnumerable<string>> GetDistinctModelsAsync(string type);
        Task<IEnumerable<string>> GetDistinctCarriersAsync(string model);
        Task<IEnumerable<string>> GetDistinctCapacitiesAsync(string model);
        Task<IEnumerable<string>> GetDistinctConditionsAsync(string type);
        void Save();
    }
}
