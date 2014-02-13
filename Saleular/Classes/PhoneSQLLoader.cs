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
        IPhoneRepository _phoneRepository = new PhoneRepository(new SaleularContext());

        public IEnumerable<string> LoadTypesAndModels()
        {
            return _phoneRepository.GetTypesAndModels();
        }

        public IEnumerable<string> LoadModels(string type)
        {
            return _phoneRepository.GetDistinctModels(type);
        }

        public IEnumerable<string> LoadCarriers(string model)
        {
            return _phoneRepository.GetDistinctCarriers(model);
        }

        public IEnumerable<string> LoadCapacities(string model)
        {
            return _phoneRepository.GetDistinctCapacities(model);
        }

        public IEnumerable<string> LoadConditions()
        {
            return _phoneRepository.GetConditions();
        }

        public decimal LoadPrice(string model, string carrier, string capacity, string condition)
        {
            return _phoneRepository.GetPrice(model, carrier, capacity, condition);
        }
    }
}