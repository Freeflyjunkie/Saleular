using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.ViewModels
{
    public abstract class SelectedGadgetViewModel
    {
        public SelectedGadgetViewModel()
        {           
            Capacities = new List<String>();
            SelectedCapacity = "Select Capacity...";
            Conditions = new List<String>();
            SelectedCondition = "Select Condition...";            
        }

        public IEnumerable<String> Capacities { get; set; }     
        public String SelectedCapacity { get; set; }
        public IEnumerable<String> Conditions { get; set; }
        public String SelectedCondition { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}