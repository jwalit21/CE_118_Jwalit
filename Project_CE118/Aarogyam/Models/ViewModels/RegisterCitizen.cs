using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aarogyam.Models.ViewModels
{
    public class RegisterCitizen
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name should be less than 30 characters.")]
        [Display(Name = "Citizen Name")]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email (Username)")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; } 

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile number")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name="Please select the Hospital for your further reference")]
        public int Hospital_id_select { get; set; }

        [Required]
        [Display(Name = "Select Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address should be less than 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "City name should be less than 20 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "State name should be less than 20 characters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^(A|B|AB|O)[+-]$",ErrorMessage ="Invalid blood group")]
        [Display(Name = "Blood group")]
        public string Bloodgroup { get; set; }

        [Required]
        [Display(Name = "Height of Person")]
        public decimal Height { get; set; }

        [Required]
        [Display(Name = "Weight of Person")]
        public float Weight { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Checkup data should be less than 200 characters.")]
        [Display(Name = "Health Check-up Data")]
        public string CheckupData { get; set; }
    }
}
