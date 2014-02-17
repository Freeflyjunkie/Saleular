using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Forms
{
    class NJFormFactory : IFormFactory
    {
        public IForm GetForms(string type)
        {
            switch (type)
            {
                case "mls":
                    return new MlsForm("New Jersey");

                case "weichert":
                    return new WeichertForm("New Jersey");

                default:
                       return new MlsForm("New Jersey");
            }
        }
    }
}