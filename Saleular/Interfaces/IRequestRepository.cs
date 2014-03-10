using Saleular.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.Models;

namespace Saleular.Interfaces
{
    public interface IRequestRepository
    {
        void SetContext(SaleularContext context);
        IEnumerable<Request> GetRequests();
        Request GetRequestById(int requestId);
        void InsertRequest(Request request);
        void DeleteRequest(int requestId);
        void UpdateRequest(Request request);              
        void Save();
    }
}
