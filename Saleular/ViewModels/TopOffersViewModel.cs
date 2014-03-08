using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Models;

namespace Saleular.ViewModels
{
    public class TopOffersViewModel
    {
        public TopOffersViewModel()
        {
            TopGadgetsOffers = new List<Gadget>();
        }
        public IEnumerable<Gadget> TopGadgetsOffers { get; set; }        
    }
}