using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saleular.Models
{
    public class Gadget
    {
        [Key]
        [Required]
        public Int32 GadgetId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 1)]
        public String Type { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public String Model { get; set; }

        [Required]
        public String Capacity { get; set; }

        [Required]
        public String Carrier { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public String Condition { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public String ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }
    }
}