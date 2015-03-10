using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }        

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public int GadgetId { get; set; }

        public virtual Gadget Gadget { get; set; }        
    }
}