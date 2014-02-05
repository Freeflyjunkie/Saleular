using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.Models;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class PhoneSQLLoader : IPhoneLoader
    {
        public IEnumerable<string> LoadTypesAndModels()
        {
            using (SaleularContext db = new SaleularContext())
            {
                return new List<string>();
            }
        }

        public IEnumerable<string> LoadModels(string type)
        {
            using (SaleularContext db = new SaleularContext())
            {
                return db.Phones
                         .Where(p => p.Type == type)
                         .Select(p => p.Model).Distinct().ToList();
            }
        }

        public IEnumerable<string> LoadCarriers(string model)
        {
            using (SaleularContext db = new SaleularContext())
            {
                return db.Phones
                       .Where(p => p.Model == model)
                       .Select(c => c.Carrier).Distinct().ToList();
            }
        }

        public IEnumerable<string> LoadCapacities(string model)
        {
            using (SaleularContext db = new SaleularContext())
            {
                return db.Phones
                    .Where(p => p.Model == model)
                    .Select(c => c.Capacity).Distinct().ToList();
            }
        }

        public IEnumerable<string> LoadConditions()
        {
            return new List<string> { "Flawless", "Good", "Bad" };
        }

        public decimal LoadPrice(string model, string carrier, string capacity, string condition)
        {
            using (SaleularContext db = new SaleularContext())
            {
                return db.Phones
                    .Where(p => p.Model == model
                        && p.Carrier == carrier
                        && p.Capacity == capacity
                        && p.Condition == condition)
                    .Select(c => c.Price).SingleOrDefault();
            }
        }
    }
}