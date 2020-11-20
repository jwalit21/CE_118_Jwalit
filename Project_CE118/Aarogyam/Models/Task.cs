using Aarogyam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title should be less than 50 characters.")]
        [Display(Name = "Title of the Task")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "Description should be less than 100 characters.")]
        [Display(Name = "Description of the Task")]
        [Required]
        public string Description { get; set; }

        [Required]
        [MinDateValidator(ErrorMessage = "Date of Issue must be from today to next months")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Issue")]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [MinDateValidator(ErrorMessage ="Date of Due must be from today to next months")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Due")]
        public DateTime DateOfDue { get; set; }

        [Required]
        public bool Finished { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Finished")]
        public DateTime DateOfFinished { get; set; }
        //public int HospitalId { get; set; }
        
        public ApplicationUser Hospital { get; set; }

    }
}
