using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.ViewModels
{
    public class RequestPatientView: RequestPatient
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

    }
}
