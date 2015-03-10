using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saleular.Models
{
    public class Request
    {
        [Key]
        [Required]
        public Int32 RequestId { get; set; }
        [Required]
        public Int32 GadgetId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Zip { get; set; }
        public String State { get; set; }
        public String Email { get; set; }
        public String Comment { get; set; }
        public virtual Gadget Gadget { get; set; }
    }
}