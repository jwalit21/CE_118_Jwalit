using Aarogyam.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.IRepositories
{
    public interface ICitizenRepository
    {
        ApplicationUser GetCitizen(int CitizenID);
        IEnumerable<ApplicationUser> GetAllCitizens();
        ApplicationUser Update(ApplicationUser usr);
        Task<int> Delete(int CitizenID);
        ApplicationUser GetMaxCitizen();
    }
}
