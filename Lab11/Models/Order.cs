using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Order_Authentication_Application.Models
{
    public class Order
    {
        [Key]
        public int OrderID { set; get; }

        [ExpiryDate()]
        [DataType(DataType.Date)]
        [Display(Name = "Order Place Date")]
        public DateTime OrderDate { set; get; }

        public int ProductID { get; set; }
        public Product product { get; set; }

        public int CustomerID { get; set; }
        public Customer customer { get; set; }

    }
}
