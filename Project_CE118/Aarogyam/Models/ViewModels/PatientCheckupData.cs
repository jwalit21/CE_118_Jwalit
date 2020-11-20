using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.ViewModels
{
    public class PatientCheckupData
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Checkup data should be less than 200 characters.")]
        [Display(Name = "Health Check-up Data")]
        public string CheckupData { get; set; }
    }
}
