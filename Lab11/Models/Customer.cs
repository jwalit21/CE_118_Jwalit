using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Order_Authentication_Application.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "Name should be less than 100 characters.")]
        public string Name { set; get; }

        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        [Phone]
        public string Mobile { set; get; }

        public IList<Order> Orders { get; set; }
    }
}
