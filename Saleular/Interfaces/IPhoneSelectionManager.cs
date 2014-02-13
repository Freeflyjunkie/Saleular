using Saleular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saleular.Interfaces
{
    public interface IPhoneSelectionManager
    {
        SelectedPhoneViewModel GetSelectedPhoneViewModel();
        void SetSelectedPhoneViewModel(SelectedPhoneViewModel selectedPhoneViewModel);       
        SelectedPhoneViewModel InitializeSelectedPhoneViewModel();        
        SelectedPhoneViewModel SelectionChanged(string model, string carrier, string capacity, string condition);        
    }
}
