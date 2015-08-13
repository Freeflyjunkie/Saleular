using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.Models;
using Saleular.ViewModels;

namespace Saleular.Interfaces
{
    public interface IMessenger
    {
        void SendMessage(string from, string subject, string body);
        string ConstructMessage(string name, string address, string city, string state, string zip, string userEmail, string additionalComments, SelectedGadgetViewModel selectedGadget);
        string ConstructMessage(string name, string userEmail, string additionalComments);        
        string ConstructMessage(SellPhoneRequest sellPhoneRequest);
        string ConstructMessage(PriceListRequest priceListRequest);
    }
}
