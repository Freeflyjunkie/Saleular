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
        public void SendMessage(string from, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress("iphone@saleular.com"));
            message.Subject = subject;
            message.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtpout.secureserver.net");
            smtpClient.Host = "relay-hosting.secureserver.net";            
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("iphone@saleular.com", "Roybitran123");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 25;
            smtpClient.Send(message);
        }

        public string ConstructMessage(string name, string address, string city, string state, string zip,
            string userEmail, string additionalComments, SelectedGadgetViewModel selectedGadget)
        {
            StringBuilder emailtext = new StringBuilder();

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
            StringBuilder emailtext = new StringBuilder();

            emailtext.AppendLine("This is a 'Sell My IPhone Request' from Saleular.com");
            emailtext.AppendLine(name);
            emailtext.AppendLine("The Email Address is:");
            emailtext.AppendLine(userEmail);            
            emailtext.AppendLine("");
            emailtext.AppendLine("User Question:");
            emailtext.AppendLine(question);            
            return emailtext.ToString();
        }
    }
}