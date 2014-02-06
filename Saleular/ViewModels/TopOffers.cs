using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Models;

namespace Saleular.ViewModels
{
    public class TopOffers
    {
        public IEnumerable<Phone> iPhone5Ss { get; set; }

        public IEnumerable<Phone> iPhone5Cs { get; set; }

        public IEnumerable<Phone> iPhone5s { get; set; }

        public IEnumerable<Phone> iPhone4Ss { get; set; }
    }
}