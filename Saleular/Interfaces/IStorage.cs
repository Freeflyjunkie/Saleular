using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    public interface IStorage
    {
        void Save(string key, object value);        
        object Retrieve(string key);
    }
}
