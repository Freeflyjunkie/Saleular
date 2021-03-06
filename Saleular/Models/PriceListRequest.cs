﻿using System;
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
        [Required]
        public String BusinessName { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }
        public String Address { get; set; }
        public String TaxId { get; set; }
        public String BusinessAreaSelection { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}