using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Order_Authentication_Application.Models
{
    public class ExpiryDateAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;
            var curr_date = DateTime.Now;
            if (order.OrderDate == null)
                return new ValidationResult("Order Date is required.");
            if (order.OrderDate > curr_date)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date before today is not allowed");
        }
    }
}
