using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Interfaces;

namespace Saleular.Classes
{
    public class SQLStorage : IStorage
    {
        public void Save(string key, object value)
        {
            throw new NotImplementedException();
        }

        public object Retrieve(string key)
        {
            throw new NotImplementedException();
        }
    }
}