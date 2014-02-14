using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Interfaces;

namespace Saleular.Classes
{
    public class SessionStorage : IStorage
    {
        public void Save(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }        

        public object Retrieve(string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}