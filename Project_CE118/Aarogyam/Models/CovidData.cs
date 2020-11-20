using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models
{
    public class CovidData
    {
        [Key]
        public int CovidDataId { get; set; }
        
        [Required]
        [Range(0, 1000000, ErrorMessage = "New Cases must be positive.")]
        [Display(Name = "New Cases")]
        public int NewCases { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Death Cases must be positive.")]
        [Display(Name = "Death Cases")]
        public int DeathCases { get; set; }
        
        [Required]
        [Display(Name = "Recovered Cases")]
        [Range(0, 1000000, ErrorMessage = "Recovered Cases must be positive.")]
        public int RecoveredCases { get; set; }

        [StringLength(100, ErrorMessage = "Discription should be less than 100 characters.")]
        [Display(Name="Description of the Data provided")]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
