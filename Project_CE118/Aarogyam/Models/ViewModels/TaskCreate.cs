using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.ViewModels
{
    public class TaskCreate
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
        [Display(Name = "Select the Hospital")]
        public int HospitalId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Due")]
        public DateTime DateOfDue { get; set; }

    }
}
