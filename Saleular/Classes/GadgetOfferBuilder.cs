using System.Threading.Tasks;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.Models;
using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Classes
{
    public class GadgetOfferBuilder : IOfferBuilder
    {
        protected IGadgetRepository Gadgets;

        public GadgetOfferBuilder(IGadgetRepository gadgets)
        {
            Gadgets = gadgets;
        }

        public SelectedGadgetViewModel InitializeSelectedGadgetViewModel()
        {
            var gadgetViewModel = new SelectedGadgetViewModel();
            gadgetViewModel.Types = Gadgets.GetDistinctTypes();

            return gadgetViewModel;
        }

        public async Task<SelectedGadgetViewModel> InitializeSelectedGadgetViewModelAsync()
        {
            var gadgetViewModel = new SelectedGadgetViewModel();
            gadgetViewModel.Types = await Gadgets.GetDistinctTypesAsync();

            return gadgetViewModel;
        }

        public SelectedGadgetViewModel SelectionChanged(SelectedGadgetViewModel selections)
        {            
            if (selections != null)
            {                
                // Reload List<String>             
                selections.Models = Gadgets.GetDistinctModels(selections.SelectedType);                
                selections.Carriers = Gadgets.GetDistinctCarriers(selections.SelectedModel);
                selections.Capacities = Gadgets.GetDistinctCapacities(selections.SelectedModel);
                selections.Conditions = Gadgets.GetDistinctConditions(selections.SelectedType);
               
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


                Gadget gadget = Gadgets.GetGadget(selections.SelectedType, 
                    selections.SelectedModel, selections.SelectedCarrier,
                    selections.SelectedCapacity, selections.SelectedCondition);

                if (gadget != null)
                {
                    selections.GadgetId = gadget.GadgetId;
                    selections.Price = gadget.Price;
                }              
            }

            return selections;
        }

        public async Task<SelectedGadgetViewModel> SelectionChangedAsync(SelectedGadgetViewModel selections)
        {
            if (selections != null)
            {                
                var modelsTask = GetDistinctModelsAsync(selections);
                var carriersTask = GetDistinctCarriersAsync(selections);
                var capacitiesTask = GetDistinctCapacitiesAsync(selections);
                var conditionsTask = GetDistinctConditionsAsync(selections);

                await Task.WhenAll(modelsTask, carriersTask, capacitiesTask, conditionsTask);

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
                    selections.SelectedCondition = "Select Condition...";
                }


                var gadget = await Gadgets.GetGadgetAsync(selections.SelectedType,
                                                                selections.SelectedModel, 
                                                                selections.SelectedCarrier,
                                                                selections.SelectedCapacity, 
                                                                selections.SelectedCondition);

                if (gadget != null)
                {
                    selections.GadgetId = gadget.GadgetId;
                    selections.Price = gadget.Price;
                }                
            }

            return selections;
        }
        
        private async Task GetDistinctModelsAsync(SelectedGadgetViewModel vwModel)
        {
            Gadgets.SetContext(new SaleularContext());            
            vwModel.Models = await Gadgets.GetDistinctModelsAsync(vwModel.SelectedType);
        }

        private async Task GetDistinctCarriersAsync(SelectedGadgetViewModel vwModel)
        {
            Gadgets.SetContext(new SaleularContext());            
            vwModel.Carriers = await Gadgets.GetDistinctCarriersAsync(vwModel.SelectedModel);
        }

        private async Task GetDistinctCapacitiesAsync(SelectedGadgetViewModel vwModel)
        {
            Gadgets.SetContext(new SaleularContext());            
            vwModel.Capacities = await Gadgets.GetDistinctCapacitiesAsync(vwModel.SelectedModel);
        }

        private async Task GetDistinctConditionsAsync(SelectedGadgetViewModel vwModel)
        {
            Gadgets.SetContext(new SaleularContext());            
            vwModel.Conditions = await Gadgets.GetDistinctConditionsAsync(vwModel.SelectedType);
        }       
    }
}