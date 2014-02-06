using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

            SmtpClient smtpClient = new SmtpClient("smtp.secureserver.net");
            smtpClient.Host = "relay-hosting.secureserver.net";
            smtpClient.Send(message);
        }

        public string ConstructMessage(string address, string city, string state, string zip, string useremail, string additionalcomments)
        {
            StringBuilder emailtext = new StringBuilder();

            emailtext.AppendLine("This is a 'Sell My IPhone Request' from Saleular.com");
            emailtext.AppendLine("The Email Address is:");
            emailtext.AppendLine(useremail);
            emailtext.AppendLine("");
            emailtext.AppendLine("The Address Information is:");
            emailtext.AppendLine(address);
            emailtext.AppendLine(city);
            emailtext.AppendLine(state);
            emailtext.AppendLine(zip);
            emailtext.AppendLine("");
            if (additionalcomments != string.Empty)
            {
                emailtext.AppendLine("User Additional Comments:");
                emailtext.AppendLine(additionalcomments);
                emailtext.AppendLine("");
            }
            emailtext.AppendLine("This user would like to ship you the following iPhones:");
            SelectediPhone phone = (SelectediPhone)HttpContext.Current.Session["SelectedIPhone"];
            if (phone != null)
            {
                emailtext.AppendLine(phone.SelectedModel);
                emailtext.AppendLine(phone.SelectedCarrier);
                emailtext.AppendLine(phone.SelectedCapacity);
                emailtext.AppendLine(phone.SelectedCondition);
                emailtext.AppendLine(phone.Price.ToString());
                emailtext.AppendLine("");
            }

            return emailtext.ToString();
        }
    }
}