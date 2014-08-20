using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.ViewModels;

namespace Saleular.Interfaces
{
    public interface IMessenger
    {
        void SendMessage(string from, string subject, string body);
        string ConstructMessage(string name, string address, string city, string state, string zip, string userEmail, string additionalComments, SelectedGadgetViewModel selectedGadget);
        string ConstructMessage(string name, string userEmail, string additionalComments);
        string ConstructMessage(string businessName, string name, string email, string phone, string address, string taxId, string businessAreaSelection);
    }
}
