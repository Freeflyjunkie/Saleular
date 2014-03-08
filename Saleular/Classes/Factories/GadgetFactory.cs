using Saleular.Classes.Repositories;
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
                    return new GadgetXmlRepository();

                default:
                    return new GadgetRepository();
            }
        }
    }
}