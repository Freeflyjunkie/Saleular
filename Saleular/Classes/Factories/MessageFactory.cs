using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Interfaces;
using Saleular.Classes;
using Saleular.Interfaces.Factories;

namespace Saleular.Classes.Factories
{
    public class MessageFactory: IMessageFactory
    {
        public enum MessengerType
        {
            Sms,
            Email
        }

        public IMessenger CreateMessenger(MessengerType messengerType)
        {
            switch (messengerType)
            {
                case MessengerType.Sms:
                    return new SmsMessenger();

                case MessengerType.Email:
                    return new EmailMessenger();

                default:
                    return new EmailMessenger();
            }
        }
    }
}