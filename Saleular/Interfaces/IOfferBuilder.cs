using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    public interface IOfferBuilder
    {
        SelectedGadgetViewModel InitializeSelectedGadgetViewModel();
        Task<SelectedGadgetViewModel> InitializeSelectedGadgetViewModelAsync();
        SelectedGadgetViewModel SelectionChanged(SelectedGadgetViewModel selections);
        Task<SelectedGadgetViewModel> SelectionChangedAsync(SelectedGadgetViewModel selections);    
    }
}
