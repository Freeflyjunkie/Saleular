using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleular.Classes.Factories;

namespace Saleular.Interfaces.Factories
{
    interface IGadgetFactory
    {
        IGadgetRepository CreateGadgetRepository(GadgetFactory.GadgetType gadgetType);
    }
}
