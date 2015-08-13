using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.DAL;
using Saleular.Models;

namespace Saleular.Interfaces
{
    public interface ISellPhoneRequestRepository
    {
        void SetContext(SaleularContext context);
        IEnumerable<SellPhoneRequest> GetRequests();
        SellPhoneRequest GetRequestById(int requestId);
        void InsertRequest(SellPhoneRequest request);
        void DeleteRequest(int requestId);
        void UpdateRequest(SellPhoneRequest request);
        void Save();
    }
}
