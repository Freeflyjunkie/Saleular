using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.Models
{
    public class CustomerOrder
    {
        [Key]
        [Required]
        public int CustomerOrderId { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int OrderId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Order Order { get; set; }
    }
}