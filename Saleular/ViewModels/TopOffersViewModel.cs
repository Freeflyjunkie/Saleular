﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Models;

namespace Saleular.ViewModels
{
    public class TopOffersViewModel
    {
        public IEnumerable<Gadget> Gadgets { get; set; }        
    }
}