using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_EFCore.Models
{
    public class Student
    {
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public float cpi { set; get; }
        public string email { set; get; }
        public string mobile { set; get; }
    }
}
