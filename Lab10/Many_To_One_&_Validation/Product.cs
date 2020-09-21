using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Many_To_One_Validation.Models
{
    public class Product
    {
        [Key]
        public int ID { set; get; }
        
        [Required]
        [StringLength(100,ErrorMessage ="Product name can not greater than 100 characters.")]
        public string Name { set; get; }
        
        [Required]
        [Range(0,10000)]
        public float Price { set; get; }
        
        [ExpiryDate()]
        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        public DateTime expiryDate { set; get; }

        public int StoreID { get; set; }
        public Store Store { get; set; }
    }
}
