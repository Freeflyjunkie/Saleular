using Saleular.Interfaces;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class PhoneSelectionManager : IPhoneSelectionManager
    {
        private SelectedPhoneViewModel _selectedPhoneViewModel;

        public SelectedPhoneViewModel GetSelectedPhoneViewModel()
        {
            if (HttpContext.Current.Session["SelectedPhoneViewModel"] == null)
            {
                _selectedPhoneViewModel = new SelectedPhoneViewModel();
                HttpContext.Current.Session["SelectedPhoneViewModel"] = _selectedPhoneViewModel;

            }
            return (SelectedPhoneViewModel)HttpContext.Current.Session["SelectedPhoneViewModel"];
        }
        public void SetSelectedPhoneViewModel(SelectedPhoneViewModel selectedPhoneViewModel)
        {
            _selectedPhoneViewModel = selectedPhoneViewModel;
            HttpContext.Current.Session["SelectedPhoneViewModel"] = selectedPhoneViewModel;
        }

        public SelectedPhoneViewModel InitializeSelectedPhoneViewModel()
        {
            _selectedPhoneViewModel = new SelectedPhoneViewModel();

            IPhoneLoader loader = new PhoneSQLLoader();
            _selectedPhoneViewModel.Models = loader.LoadModels("iPhone");

            SetSelectedPhoneViewModel(_selectedPhoneViewModel);

            return _selectedPhoneViewModel;
        }

        public SelectedPhoneViewModel SelectionChanged(string model, string carrier, string capacity, string condition)
        {
            // Get Selection
            IPhoneLoader loader = new PhoneSQLLoader();

            GetSelectedPhoneViewModel();

            _selectedPhoneViewModel.SelectedModel = model;
            _selectedPhoneViewModel.SelectedTypeAndModel = "iPhone " + model;
            if (!_selectedPhoneViewModel.SelectedModel.Contains("Select"))
            {
                _selectedPhoneViewModel.Conditions = loader.LoadConditions();
            }

            _selectedPhoneViewModel.SelectedCarrier = carrier;
            _selectedPhoneViewModel.SelectedCapacity = capacity;
            _selectedPhoneViewModel.SelectedCondition = condition;

            // Reload String Lists            
            _selectedPhoneViewModel.Carriers = loader.LoadCarriers(model);
            _selectedPhoneViewModel.Capacities = loader.LoadCapacities(model);


            if (!_selectedPhoneViewModel.Carriers.Contains(_selectedPhoneViewModel.SelectedCarrier))
            {
                _selectedPhoneViewModel.SelectedCarrier = "Select Carrier...";
            }

            if (!_selectedPhoneViewModel.Capacities.Contains(_selectedPhoneViewModel.SelectedCapacity))
            {
                _selectedPhoneViewModel.SelectedCapacity = "Select Capacity...";
            }

            _selectedPhoneViewModel.Price = loader.LoadPrice(_selectedPhoneViewModel.SelectedModel,
                                                    _selectedPhoneViewModel.SelectedCarrier,
                                                    _selectedPhoneViewModel.SelectedCapacity,
                                                    _selectedPhoneViewModel.SelectedCondition);

            SetSelectedPhoneViewModel(_selectedPhoneViewModel);

            return _selectedPhoneViewModel;
        }
    }
}