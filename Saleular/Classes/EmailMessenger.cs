using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Saleular.Classes
{
    public class EmailMessenger : IMessenger
    {

        public EmailMessenger()
        {

        }

        public void SendMessage(string from, string subject, string body)
        {
            //var message = new MailMessage();
            //message.From = new MailAddress("sales@saleular.com");
            //message.To.Add(new MailAddress("roy@saleular.com"));
            //message.Subject = subject;
            //message.Body = body;

            //var smtpClient = new SmtpClient("smtpout.secureserver.net");
            //smtpClient.Host = "relay-hosting.secureserver.net";            
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential("sales@saleular.com", "Zion21378");
            //smtpClient.EnableSsl = true;
            //smtpClient.Port = 25;
            //smtpClient.Send(message);
        }

        public string ConstructMessage(string name, string address, string city, string state, string zip,
            string userEmail, string additionalComments, SelectedGadgetViewModel selectedGadget)
        {
            var emailtext = new StringBuilder();

            emailtext.AppendLine("This is a 'Sell My IPhone Request' from Saleular.com");
            emailtext.AppendLine(name);
            emailtext.AppendLine("The Email Address is:");
            emailtext.AppendLine(userEmail);
            emailtext.AppendLine("");
            emailtext.AppendLine("The Address Information is:");
            emailtext.AppendLine(address);
            emailtext.AppendLine(city);
            emailtext.AppendLine(state);
            emailtext.AppendLine(zip);
            emailtext.AppendLine("");
            if (additionalComments != string.Empty)
            {
                emailtext.AppendLine("User Additional Comments:");
                emailtext.AppendLine(additionalComments);
                emailtext.AppendLine("");
            }
            emailtext.AppendLine("This user would like to ship you the following iPhones:");
                        
            if (selectedGadget != null)
            {
                emailtext.AppendLine(selectedGadget.SelectedModel);
                emailtext.AppendLine(selectedGadget.SelectedCarrier);
                emailtext.AppendLine(selectedGadget.SelectedCapacity);
                emailtext.AppendLine(selectedGadget.SelectedCondition);
                emailtext.AppendLine(selectedGadget.Price.ToString());
                emailtext.AppendLine("");
            }

            return emailtext.ToString();
        }

        public string ConstructMessage(string name, string userEmail, string question)
        {
            var emailtext = new StringBuilder();
            emailtext.AppendLine("This is a 'Sell My IPhone Request' from Saleular.com");
            emailtext.AppendLine(name);
            emailtext.AppendLine("The Email Address is:");
            emailtext.AppendLine(userEmail);            
            emailtext.AppendLine("");
            emailtext.AppendLine("User Question:");
            emailtext.AppendLine(question);            
            return emailtext.ToString();
        }
        
        public string ConstructMessage(string businessName, string name, string email, string phone, string address, string taxId, string businessAreaSelection)
        {
            var emailtext = new StringBuilder();
            emailtext.AppendLine("This is a 'Price List Request' from Saleular.com");
            emailtext.AppendLine("Business Name: " + businessName);
            emailtext.AppendLine("Name: " + name);
            emailtext.AppendLine("Email: " + email);
            emailtext.AppendLine("Phone: " + phone);
            emailtext.AppendLine("Address: " + address);
            emailtext.AppendLine("Tax Id: " + taxId);
            emailtext.AppendLine("Business Area: " + businessAreaSelection);
            return emailtext.ToString();
        }
    }
}