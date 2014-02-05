using Saleular.Interfaces;
using Saleular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class PhoneXMLLoader : IPhoneLoader
    {

        public IEnumerable<string> LoadTypesAndModels()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> LoadModels(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> LoadCarriers(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> LoadCapacities(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> LoadConditions()
        {
            throw new NotImplementedException();
        }

        public decimal LoadPrice(string model, string carrier, string capacity, string condition)
        {
            throw new NotImplementedException();
        }
    }
}