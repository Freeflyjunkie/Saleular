using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Forms
{
    interface IFormFactory
    {
        IForm GetForms(string type);
    }
}
