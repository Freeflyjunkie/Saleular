using Saleular.Interfaces;
using Saleular.Models;
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
            var mailMessage = new MailMessage
            {
                IsBodyHtml = false,
                From = new MailAddress("sales@saleular.com"),
                Subject = subject,
                Body = body
            };
            mailMessage.To.Add(new MailAddress("requests@saleular.com"));


            var smtpClient = new SmtpClient();
            //smtpClient.UseDefaultCredentials = false;
            //var credentials = new NetworkCredential("sales@saleular.com", "Zion21378");
            //smtpClient.Credentials = credentials;
            //smtpClient.Host = "smtpout.secureserver.net";
            smtpClient.Host = "relay-hosting.secureserver.net";
            smtpClient.Port = 25;
            smtpClient.Send(mailMessage);            
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

        public string ConstructMessage(SellPhoneRequest sellPhoneRequest)
        {
            var emailtext = new StringBuilder();
            emailtext.AppendLine("This is a 'Sell Phone Request' from Saleular.com");
            emailtext.AppendLine("Business Name: " + sellPhoneRequest.BusinessName);
            emailtext.AppendLine("Name: " + sellPhoneRequest.Name);
            emailtext.AppendLine("Email: " + sellPhoneRequest.Email);
            emailtext.AppendLine("Phone: " + sellPhoneRequest.Phone);
            emailtext.AppendLine("Address: " + sellPhoneRequest.Address);
            emailtext.AppendLine("Quantity: " + sellPhoneRequest.Quantity);
            emailtext.AppendLine("Model: " + sellPhoneRequest.Model);
            emailtext.AppendLine("Capacity: " + sellPhoneRequest.Capacity);
            emailtext.AppendLine("Carrier: " + sellPhoneRequest.Carrier);
            emailtext.AppendLine("Condition: " + sellPhoneRequest.Condition);
            return emailtext.ToString();
        }

        public string ConstructMessage(PriceListRequest priceListRequest)
        {
            var emailtext = new StringBuilder();
            emailtext.AppendLine("This is a 'Price List Request' from Saleular.com");
            emailtext.AppendLine("Business Name: " + priceListRequest.BusinessName);
            emailtext.AppendLine("Name: " + priceListRequest.Name);
            emailtext.AppendLine("Email: " + priceListRequest.Email);
            emailtext.AppendLine("Phone: " + priceListRequest.Phone);
            emailtext.AppendLine("Address: " + priceListRequest.Address);
            emailtext.AppendLine("Tax Id: " + priceListRequest.TaxId);
            emailtext.AppendLine("Business Area: " + priceListRequest.BusinessAreaSelection);
            return emailtext.ToString();
        }

        public string ConstructMessage(string email, string message)
        {
            var emailtext = new StringBuilder();
            emailtext.AppendLine("This is a 'Customer Email' from Saleular.com");
            emailtext.AppendLine("Email From: " + email);
            emailtext.AppendLine("Message :" + message);
            return emailtext.ToString();
        }
    }
}