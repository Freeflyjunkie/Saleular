using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Forms
{
    class PAFormFactory : IFormFactory
    {
        public IForm GetForms(string type)
        {
            switch (type)
            {
                case "mls":
                    return new MlsForm("Pennsylvania");

                case "weichert":
                    return new WeichertForm("Pennsylvania");

                default:
                    return new MlsForm("Pennsylvania");
            }
        }
    }
}