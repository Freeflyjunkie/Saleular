using Saleular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    interface IPhoneLoader
    {
        IEnumerable<String> LoadTypesAndModels();

        IEnumerable<String> LoadModels(string type);

        IEnumerable<String> LoadCarriers(string model);

        IEnumerable<String> LoadCapacities(string model);

        IEnumerable<String> LoadConditions();

        decimal LoadPrice(string model, string carrier, string capacity, string condition);
    }
}
