using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.Classes;
using Saleular.Classes.Factories;

namespace Saleular.Interfaces.Factories
{
    interface IMessageFactory
    {
        IMessenger CreateMessenger(MessageFactory.MessengerType messengerType);
    }
}
