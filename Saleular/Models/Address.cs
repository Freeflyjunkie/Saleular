using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Address1 { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 1)]
        public string State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Zip { get; set; }
    }
}