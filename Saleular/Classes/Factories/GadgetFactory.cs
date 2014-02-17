using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.DAL;
using Saleular.Interfaces.Factories;

namespace Saleular.Classes.Factories
{
    public class GadgetFactory : IGadgetFactory
    {
        public enum GadgetType
        {
            Database,
            Xml
        }

        public Interfaces.IGadgetRepository CreateGadgetRepository(GadgetType gadgetType)
        {
            switch (gadgetType)
            {
                case GadgetType.Database:
                    return new GadgetRepository();

                case GadgetType.Xml:
                    return new GedgetXmlRepository();

                default:
                    return new GadgetRepository();
            }
        }
    }
}