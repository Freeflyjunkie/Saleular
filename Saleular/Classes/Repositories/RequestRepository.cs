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
    public class RequestRepository : IRequestRepository
    {
        protected SaleularContext Context = new SaleularContext();

        public void SetContext(SaleularContext context)
        {
            Context = context;
        }

        public IEnumerable<Request> GetRequests()
        {
            return Context.Requests.ToList();
        }

        public Request GetRequestById(int requestId)
        {
            return Context.Requests.Find(requestId);
        }

        public void InsertRequest(Request request)
        {
            Context.Requests.Add(request);
        }

        public void DeleteRequest(int requestId)
        {
            Request request = Context.Requests.Find(requestId);
            Context.Requests.Remove(request);
        }

        public void UpdateRequest(Request request)
        {
            Context.Entry(request).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}