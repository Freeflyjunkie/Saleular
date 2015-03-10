using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.Models
{
    public class PriceListRequest
    {
        [Key]
        [Required]
        public Int32 PriceListRequestId { get; set; }
        public String BusinessName { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String TaxId { get; set; }
        public String BusinessAreaSelection { get; set; }
    }
}