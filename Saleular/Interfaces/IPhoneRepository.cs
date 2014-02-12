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
    }
}
