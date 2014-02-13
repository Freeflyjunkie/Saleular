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

        public IEnumerable<string> GetTypesAndModels()
        {
            return context.Phones.Select(p => p.Type);
        }

        public IEnumerable<string> GetDistinctModels(string type)
        {
            return context.Phones
                         .Where(p => p.Type == type)
                         .Select(p => p.Model).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctCarriers(string model)
        {
            return context.Phones
                       .Where(p => p.Model == model)
                       .Select(c => c.Carrier).Distinct().ToList();
        }

        public IEnumerable<string> GetDistinctCapacities(string model)
        {
            return context.Phones
                    .Where(p => p.Model == model)
                    .Select(c => c.Capacity).Distinct().ToList();
        }

        public IEnumerable<string> GetConditions()
        {
            return context.Phones
                    .Select(p => p.Condition).Distinct().ToList();
        }

        public decimal GetPrice(string model, string carrier, string capacity, string condition)
        {
            return context.Phones
                    .Where(p => p.Model == model
                        && p.Carrier == carrier
                        && p.Capacity == capacity
                        && p.Condition == condition)
                    .Select(c => c.Price).SingleOrDefault();
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