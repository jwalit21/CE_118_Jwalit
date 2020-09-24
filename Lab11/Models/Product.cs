using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Order_Authentication_Application.Models
{
    public class Product
    {
        [Key]
        public int ProductID { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "Product name can not greater than 100 characters.")]
        public string Name { set; get; }

        [Required]
        [Range(0, 10000)]
        public float Price { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "Product Details can not greater than 100 characters.")]
        public string Details { set; get; }

        public IList<Order> Orders { get; set; }
    }
}
