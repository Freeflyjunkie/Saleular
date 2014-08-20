using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.Models;

namespace Saleular.Classes.Repositories
{
    public class PriceListRequestRepository : IPriceListRequestRepository
    {
        protected SaleularContext Context = new SaleularContext();

        public void SetContext(SaleularContext context)
        {
            Context = context;
        }

        public IEnumerable<PriceListRequest> GetRequests()
        {
            return Context.PriceListRequests.ToList();
        }

        public PriceListRequest GetRequestById(int requestId)
        {
            return Context.PriceListRequests.Find(requestId);
        }

        public void InsertRequest(PriceListRequest request)
        {
            Context.PriceListRequests.Add(request);
        }

        public void DeleteRequest(int requestId)
        {
            PriceListRequest request = Context.PriceListRequests.Find(requestId);
            Context.PriceListRequests.Remove(request);
        }

        public void UpdateRequest(PriceListRequest request)
        {
            Context.Entry(request).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}