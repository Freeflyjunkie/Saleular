using Saleular.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.Models;

namespace Saleular.Interfaces
{
    public interface IPriceListRequestRepository
    {
        void SetContext(SaleularContext context);
        IEnumerable<PriceListRequest> GetRequests();
        PriceListRequest GetRequestById(int requestId);
        void InsertRequest(PriceListRequest request);
        void DeleteRequest(int requestId);
        void UpdateRequest(PriceListRequest request);              
        void Save();
    }
}

