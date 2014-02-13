using Saleular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    public interface IPhoneRepository : IDisposable
    {
        IEnumerable<Phone> GetPhones();
        IEnumerable<Phone> GetTopOffersPaid();
        Phone GetPhoneByID(int studentId);
        void InsertPhone(Phone student);
        void DeletePhone(int studentID);
        void UpdatePhone(Phone student);
        void Save();
        IEnumerable<string> GetTypesAndModels();
        IEnumerable<string> GetDistinctModels(string type);
        IEnumerable<string> GetDistinctCarriers(string model);
        IEnumerable<string> GetDistinctCapacities(string model);
        IEnumerable<string> GetConditions();
        decimal GetPrice(string model, string carrier, string capacity, string condition);
    }
}
