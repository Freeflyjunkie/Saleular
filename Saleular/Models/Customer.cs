using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Saleular.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }        
        
        [Required]
        public int AddressId { get; set; }
        
        [Required]        
        [StringLength(25, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 1)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        
        public virtual Address Address { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}