using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.ViewModels
{
    public class SelectediPhone
    {

        public SelectediPhone()
        {
            SelectedTypeAndModel = "Select Model...";
            Models = new List<String>();
            SelectedModel = "";
            Carriers = new List<String>();
            SelectedCarrier = "Select Carrier...";
            Capacities = new List<String>();
            SelectedCapacity = "Select Capacity...";
            Conditions = new List<String>();
            SelectedCondition = "Select Condition...";            
        }

        public String SelectedTypeAndModel { get; set; }

        public IEnumerable<String> Models { get; set; }

        public String SelectedModel { get; set; }

        public IEnumerable<String> Carriers { get; set; }

        public String SelectedCarrier { get; set; }

        public IEnumerable<String> Capacities { get; set; }

        public String SelectedCapacity { get; set; }

        public IEnumerable<String> Conditions { get; set; }

        public String SelectedCondition { get; set; }

        [DataType(DataType.Currency)]        
        public decimal Price { get; set; }

    }
}