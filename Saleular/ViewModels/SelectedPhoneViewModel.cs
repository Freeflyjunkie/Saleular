using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.ViewModels
{
    public class SelectedPhoneViewModel : SelectedGadgetViewModel
    {

        public SelectedPhoneViewModel()
        {
            SelectedTypeAndModel = "Select Model...";
            Models = new List<String>();
            SelectedModel = "";
            Carriers = new List<String>();
            SelectedCarrier = "Select Carrier...";              
        }

        public String SelectedTypeAndModel { get; set; }
        public IEnumerable<String> Models { get; set; }
        public String SelectedModel { get; set; }
        public IEnumerable<String> Carriers { get; set; }
        public String SelectedCarrier { get; set; } 
    }
}