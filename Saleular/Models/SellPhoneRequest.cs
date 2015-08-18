using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace Saleular.Models
{
    public class SellPhoneRequest
    {
        [Key]
        [Required]
        public Int32 SellPhoneRequestId { get; set; }
        [Required]
        public String BusinessName { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }
        public String Address { get; set; }        
        public String Quantity { get; set; }
        public String Model { get; set; }
        public String Carrier { get; set; }
        public String Capacity { get; set; }
        public String Condition { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}