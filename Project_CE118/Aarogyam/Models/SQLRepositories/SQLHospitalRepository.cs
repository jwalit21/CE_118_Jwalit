using Aarogyam.Models.IRepositories;
using Aarogyam.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.SQLRepositories
{
    public class SQLHospitalRepository:IHospitalRepositoy
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public SQLHospitalRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        IEnumerable<CitizenHospital> IHospitalRepositoy.GetCitizens()
        {
            return context.CitizenHospitals;
        }

        ApplicationUser IHospitalRepositoy.Delete(int HospitalID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ApplicationUser> IHospitalRepositoy.GetAllHospitals()
        {
            var users = userManager.Users;
            users = users.Where(user => user.IsHospital == true);
            return users;
        }

        ApplicationUser IHospitalRepositoy.GetHospital(int HospitalID)
        {
            throw new NotImplementedException();
        }

        ApplicationUser IHospitalRepositoy.GetMaxHospital()
        {
            var users = userManager.Users;
            users = users.Where(user => user.IsHospital == true);
            var max_hopital_id = users.Max(u => u.HospitalId);
            var user = users.Where(user => user.HospitalId == max_hopital_id).First();
            return user;
        }

        ApplicationUser IHospitalRepositoy.Update(RegisterHospital registerHospital)
        {
            throw new NotImplementedException();
        }
    }
}
