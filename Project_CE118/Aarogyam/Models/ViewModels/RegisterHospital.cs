using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aarogyam.Models.ViewModels
{
    public class RegisterHospital
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name should be less than 30 characters.")]
        [Display(Name = "Hospital Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name should be less than 30 characters.")]
        [Display(Name = "Hospital Owner(Director) Name")]
        public string OwnerName { get; set; }

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
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone number")]
        public string Telephone { get; set; }


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
        [Range(0,1000,ErrorMessage = "Beds amount must lies in between 0-1000.")]
        [Display(Name = "Maximum amount of Beds")]
        public int MaxBeds { get; set; }

    }
}