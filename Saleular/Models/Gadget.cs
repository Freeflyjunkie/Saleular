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
        public Int32 GadgetID { get; set; }

        [StringLength(25, MinimumLength = 1)]
        public String Type { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public String Model { get; set; }
        
        public String Capacity { get; set; }

        public String Carrier { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public String Condition { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public String ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}