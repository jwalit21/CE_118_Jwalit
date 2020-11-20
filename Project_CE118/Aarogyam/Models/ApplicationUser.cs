using Aarogyam.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task = Aarogyam.Models.Task;

namespace Aarogyam.Models
{
    public class ApplicationUser:IdentityUser
    {
        //common fields
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Mobile { get; set; }

        //Fields for end user or citizens
        public bool IsCitizen { get; set; }
        public int CitizenId { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bloodgroup { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public string CheckupData { get; set; }
        public string hid { get; set; }

        //Fields for Hospitals
        public bool IsHospital { get; set; }
        public int HospitalId { get; set; }
        public string OwnerName { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Telephone { get; set; }
        public decimal MaxBeds { get; set; }
        public ICollection<CitizenHospital> citizenHospitals { get; set; }
        public ICollection<Task> tasks { get; set; }
        public ICollection <Patient> patients { get; set; }

        //Fields for Administrator
        public bool IsGoverment { get; set; }

    }
}
