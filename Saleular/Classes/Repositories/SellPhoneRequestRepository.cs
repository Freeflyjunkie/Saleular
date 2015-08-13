using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.Models;

namespace Saleular.Classes.Repositories
{
    public class SellPhoneRequestRepository : ISellPhoneRequestRepository
    {
        protected SaleularContext Context = new SaleularContext();

        public void SetContext(SaleularContext context)
        {
            Context = context;
        }

        public IEnumerable<SellPhoneRequest> GetRequests()
        {
            return Context.SellPhoneRequests.ToList();
        }

        public SellPhoneRequest GetRequestById(int requestId)
        {
            return Context.SellPhoneRequests.Find(requestId);
        }

        public void InsertRequest(SellPhoneRequest request)
        {
            Context.SellPhoneRequests.Add(request);
        }

        public void DeleteRequest(int requestId)
        {
            SellPhoneRequest request = Context.SellPhoneRequests.Find(requestId);
            Context.SellPhoneRequests.Remove(request);
        }

        public void UpdateRequest(SellPhoneRequest request)
        {
            Context.Entry(request).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}