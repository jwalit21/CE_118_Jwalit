using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        public string role { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email (Username)")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
