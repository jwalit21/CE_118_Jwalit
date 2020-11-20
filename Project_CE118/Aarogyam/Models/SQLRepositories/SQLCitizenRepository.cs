using Aarogyam.Models.IRepositories;
using Aarogyam.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.SQLRepositories
{
    public class SQLCitizenRepository : ICitizenRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public SQLCitizenRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        async Task<int> ICitizenRepository.Delete(int CitizenID)
        {
            await userManager.DeleteAsync(userManager.Users.Where(user => user.CitizenId == CitizenID).FirstOrDefault());
            return 1;
        }

        IEnumerable<ApplicationUser> ICitizenRepository.GetAllCitizens()
        {
            var users = userManager.Users;
            users = users.Where(user => user.IsCitizen == true);
            return users;
        }

        ApplicationUser ICitizenRepository.GetCitizen(int CitizenID)
        {
            return userManager.Users.Where(user => user.CitizenId == CitizenID).FirstOrDefault();
        }

        ApplicationUser ICitizenRepository.GetMaxCitizen()
        {
            var users = userManager.Users;
            users = users.Where(user => user.IsCitizen == true);
            var max_citizen_id = users.Max(u => u.CitizenId);
            var user_max = users.Where(user => user.CitizenId == max_citizen_id).FirstOrDefault();
            return user_max;
        }

        ApplicationUser ICitizenRepository.Update(ApplicationUser usr)
        {
            var task = context.Users.Attach(usr);
            task.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            
            return usr;
        }
    }
}
