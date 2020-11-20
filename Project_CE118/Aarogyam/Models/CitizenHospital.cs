using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models
{
    public class CitizenHospital
    {
        public int CitizenId { get; set; }
        //public int HospitalId { get; set; }
        public ApplicationUser Hospital { get; set; }
    }
}
