using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.DTO
{
   public  class Customer
    {
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
    }
}
