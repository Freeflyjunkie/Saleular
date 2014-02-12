using Saleular.Interfaces;
using Saleular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Saleular.DAL
{
    public class PhoneRepository : IPhoneRepository, IDisposable
    {
        private SaleularContext context;

        public PhoneRepository(SaleularContext context)
        {
            this.context = context;
        }

        public IEnumerable<Phone> GetPhones()
        {
            return context.Phones.ToList();
        }

        public IEnumerable<Phone> GetTopOffersPaid()
        {
            return context.Phones
                .Where(phone => phone.Type == "iPhone" && phone.Model == "5S")
                .OrderBy(phone => phone.PhoneID).Take(5);
        }

        public Phone GetPhoneByID(int id)
        {
            return context.Phones.Find(id);
        }

        public void InsertPhone(Phone phone)
        {
            context.Phones.Add(phone);
        }

        public void DeletePhone(int phoneID)
        {
            Phone phone = context.Phones.Find(phoneID);
            context.Phones.Remove(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            context.Entry(phone).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}