using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models
{
    public class RequestPatient
    {
        [Key]
        public int Id { get; set; }

        public int citizenId { get; set; }

        public int hospitalId { get; set; }

    }
}
