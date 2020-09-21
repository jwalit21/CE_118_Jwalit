using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Many_To_One_Validation.Models
{
    public class Store
    {
        [Key]
        public int StoreID { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "Store Name should be less than 100 characters.")]
        public string StoreName { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "Owner Name should be less than 100 characters.")]
        public string OwnerName { set; get; }

        [Required]
        [StringLength(50,ErrorMessage ="Area should be less than 50 characters.")]
        public string area { set; get; }

        [Required]
        [StringLength(50,ErrorMessage = "City should be less than 50 Characters.")]
        public string city { set; get; }

        [Required]
        [EmailAddress]
        public string email { set; get; }

        [Required]
        [Phone]
        public string mobile { set; get; }

        public IList<Product> Products { get; set; }
    }
}
