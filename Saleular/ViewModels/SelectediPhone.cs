using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.ViewModels
{
    public class SelectediPhone
    {

        public SelectediPhone()
        {
            Models = new List<String>();
            SelectedModel = "Select Model...";
            Carriers = new List<String>();
            SelectedCarrier = "Select Carrier...";
            Capacities = new List<String>();
            SelectedCapacity = "Select Capacity...";
            Conditions = new List<String>();
            SelectedCondition = "Select Condition...";            
        }

        public IEnumerable<String> Models { get; set; }

        public String SelectedModel { get; set; }

        public IEnumerable<String> Carriers { get; set; }

        public String SelectedCarrier { get; set; }

        public IEnumerable<String> Capacities { get; set; }

        public String SelectedCapacity { get; set; }

        public IEnumerable<String> Conditions { get; set; }

        public String SelectedCondition { get; set; }

    }
}