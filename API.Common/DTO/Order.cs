using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.DTO
{
    public class Order
    {
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }

        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }

        [Required]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Total Quantity")]
        public int TotalQuantity { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
