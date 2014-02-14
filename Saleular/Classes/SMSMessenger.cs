using Saleular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.ViewModels;

namespace Saleular.Classes
{
    public class SMSMessenger : IMessenger
    {
        public void SendMessage(string from, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public string ConstructMessage(string name, string address, string city, string state, string zip, string userEmail, string additionalComments, SelectedGadgetViewModel selectedGadget)
        {
            throw new NotImplementedException();
        }

        public string ConstructMessage(string name, string userEmail, string additionalComments)
        {
            throw new NotImplementedException();
        }
    }
}