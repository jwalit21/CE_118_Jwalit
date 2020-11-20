using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.ViewModels
{
    public class CitizenMadeCheckup: PatientCheckupData
    {
        [Required]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood group")]
        [Display(Name = "Blood group")]
        public string Bloodgroup { get; set; }

        [Required]
        [Display(Name = "Height of Person")]
        public decimal Height { get; set; }

        [Required]
        [Display(Name = "Weight of Person")]
        public float Weight { get; set; }
    }
}
