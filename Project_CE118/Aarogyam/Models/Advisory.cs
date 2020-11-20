using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models
{
    public class Advisory
    {
        [Key]
        public int AdvisoryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title should be less than 50 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Discription should be less than 100 characters.")]
        public string Description { get; set; }
    }
}
