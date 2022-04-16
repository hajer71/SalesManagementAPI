using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.DTO
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public float Price { get; set; }

        public string Description { get; set; }
    }
}
