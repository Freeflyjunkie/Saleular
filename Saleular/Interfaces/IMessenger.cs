using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    public interface IMessenger
    {
        void SendMessage(string from, string subject, string body);

        string ConstructMessage(string address, string city, string state, string zip, string useremail, string additionalcomments, IPhoneSelectionManager phoneSelectionManager);
    }
}
