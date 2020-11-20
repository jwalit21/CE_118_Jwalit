using Aarogyam.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.IRepositories
{
    public interface IHospitalRepositoy
    {
        IEnumerable<CitizenHospital> GetCitizens();
        ApplicationUser GetHospital(int HospitalID);
        IEnumerable<ApplicationUser> GetAllHospitals();
        ApplicationUser Update(RegisterHospital registerHospital);
        ApplicationUser Delete(int HospitalID);
        ApplicationUser GetMaxHospital();
    }
}
