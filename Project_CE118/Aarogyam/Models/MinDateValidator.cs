using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models
{
    public class MinDateValidator: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && ((DateTime)value > DateTime.Now) && ((DateTime)value < DateTime.Now.AddMonths(2));
        }
    }
}
