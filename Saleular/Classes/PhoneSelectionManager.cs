using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class PhoneSelectionManager
    {

        public static SelectedPhoneViewModel InitializeSelection()
        {
            SelectedPhoneViewModel selectedIPhone = new SelectedPhoneViewModel();
            IPhoneLoader loader = new PhoneSQLLoader();            
            selectedIPhone.Models = loader.LoadModels("iPhone");
            HttpContext.Current.Session["SelectedPhoneViewModel"] = selectedIPhone;
            return selectedIPhone;
        }

        public static SelectedPhoneViewModel SelectionChanged(string model, string carrier, string capacity, string condition)
        {
            // Get Selection
            IPhoneLoader loader = new PhoneSQLLoader();
            SelectedPhoneViewModel selectedIPhone = (SelectedPhoneViewModel)HttpContext.Current.Session["SelectedPhoneViewModel"];
            if (selectedIPhone == null)
            {
                selectedIPhone = new SelectedPhoneViewModel();
            }

            selectedIPhone.SelectedModel = model;
            selectedIPhone.SelectedTypeAndModel = "iPhone " + model;
            if (!selectedIPhone.SelectedModel.Contains("Select"))
            {
                selectedIPhone.Conditions = loader.LoadConditions();
            }

            selectedIPhone.SelectedCarrier = carrier;
            selectedIPhone.SelectedCapacity = capacity;
            selectedIPhone.SelectedCondition = condition;

            // Reload String Lists            
            selectedIPhone.Carriers = loader.LoadCarriers(model);
            selectedIPhone.Capacities = loader.LoadCapacities(model);


            if (!selectedIPhone.Carriers.Contains(selectedIPhone.SelectedCarrier))
            {
                selectedIPhone.SelectedCarrier = "Select Carrier...";
            }

            if (!selectedIPhone.Capacities.Contains(selectedIPhone.SelectedCapacity))
            {
                selectedIPhone.SelectedCapacity = "Select Capacity...";
            }            

            selectedIPhone.Price = loader.LoadPrice(selectedIPhone.SelectedModel,
                                                    selectedIPhone.SelectedCarrier,
                                                    selectedIPhone.SelectedCapacity,
                                                    selectedIPhone.SelectedCondition);

            HttpContext.Current.Session["SelectedPhoneViewModel"] = selectedIPhone;
            return selectedIPhone;
        }      
    }
}