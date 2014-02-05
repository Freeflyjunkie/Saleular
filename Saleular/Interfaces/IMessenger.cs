using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    interface IMessenger
    {
        public void SendMessage(string from, string subject, string body);

        public string ConstructMessage(string address, string city, string state, string zip, string useremail, string additionalcomments);
    }
}
