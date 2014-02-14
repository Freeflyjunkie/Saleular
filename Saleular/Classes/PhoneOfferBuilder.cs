using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class PhoneOfferBuilder : IOfferBuilder
    {
        protected IGadgetRepository _gadgets;

        public PhoneOfferBuilder(IGadgetRepository gadgets)
        {
            _gadgets = gadgets;
        }

        public SelectedGadgetViewModel InitializeSelectedGadgetViewModel()
        {
            SelectedPhoneViewModel selectedPhoneViewModel = new SelectedPhoneViewModel();
            selectedPhoneViewModel.Models = _gadgets.GetDistinctModels("iPhone");

            return selectedPhoneViewModel;
        }

        public SelectedGadgetViewModel SelectionChanged(SelectedGadgetViewModel selections)
        {            
            SelectedPhoneViewModel selectedPhoneViewModel = (SelectedPhoneViewModel)selections;

            if (selectedPhoneViewModel != null)
            {                                
                if (!selectedPhoneViewModel.SelectedModel.Contains("Select"))
                {
                    selectedPhoneViewModel.Conditions = _gadgets.GetConditions();
                }                

                // Reload String Lists            
                selectedPhoneViewModel.Carriers = _gadgets.GetDistinctCarriers(selectedPhoneViewModel.SelectedModel);
                selectedPhoneViewModel.Capacities = _gadgets.GetDistinctCapacities(selectedPhoneViewModel.SelectedModel);


                if (!selectedPhoneViewModel.Carriers.Contains(selectedPhoneViewModel.SelectedCarrier))
                {
                    selectedPhoneViewModel.SelectedCarrier = "Select Carrier...";
                }

                if (!selectedPhoneViewModel.Capacities.Contains(selectedPhoneViewModel.SelectedCapacity))
                {
                    selectedPhoneViewModel.SelectedCapacity = "Select Capacity...";
                }

                selectedPhoneViewModel.Price = _gadgets.GetPrice(selectedPhoneViewModel.SelectedModel,
                                                        selectedPhoneViewModel.SelectedCarrier,
                                                        selectedPhoneViewModel.SelectedCapacity,
                                                        selectedPhoneViewModel.SelectedCondition);                
            }
            
            return selectedPhoneViewModel;
        }
    }
}