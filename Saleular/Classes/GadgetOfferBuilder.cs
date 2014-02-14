using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class GadgetOfferBuilder : IOfferBuilder
    {
        protected IGadgetRepository _gadgets;

        public GadgetOfferBuilder(IGadgetRepository gadgets)
        {
            _gadgets = gadgets;
        }

        public SelectedGadgetViewModel InitializeSelectedGadgetViewModel()
        {
            SelectedGadgetViewModel gadgetViewModel = new SelectedGadgetViewModel();
            gadgetViewModel.Types = _gadgets.GetDistinctTypes();

            return gadgetViewModel;
        }

        public SelectedGadgetViewModel SelectionChanged(SelectedGadgetViewModel selections)
        {            
            if (selections != null)
            {                
                // Reload List<String>             
                selections.Models = _gadgets.GetDistinctModels(selections.SelectedType);                
                selections.Carriers = _gadgets.GetDistinctCarriers(selections.SelectedModel);
                selections.Capacities = _gadgets.GetDistinctCapacities(selections.SelectedModel);
                selections.Conditions = _gadgets.GetDistinctConditions(selections.SelectedType);

                if (!selections.Models.Contains(selections.SelectedModel))
                {
                    selections.SelectedCarrier = "Select Model...";
                }

                if (!selections.Carriers.Contains(selections.SelectedCarrier))
                {
                    selections.SelectedCarrier = "Select Carrier...";
                }

                if (!selections.Capacities.Contains(selections.SelectedCapacity))
                {
                    selections.SelectedCapacity = "Select Capacity...";
                }

                if (!selections.Conditions.Contains(selections.SelectedCondition))
                {
                    selections.SelectedCapacity = "Select Condition...";
                }

                selections.Price = _gadgets.GetPrice(selections.SelectedModel,
                                                        selections.SelectedCarrier,
                                                        selections.SelectedCapacity,
                                                        selections.SelectedCondition);
            }

            return selections;
        }
    }
}