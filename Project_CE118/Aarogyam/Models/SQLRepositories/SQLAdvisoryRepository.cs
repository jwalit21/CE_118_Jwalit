using Aarogyam.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.SQLRepositories
{
    public class SQLAdvisoryRepository : IAdvisoryRepository
    {
        private readonly AppDbContext context;

        public SQLAdvisoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        Advisory IAdvisoryRepository.Add(Advisory advisory)
        {
            context.Advisories.Add(advisory);
            context.SaveChanges();
            return advisory;
        }

        Advisory IAdvisoryRepository.Delete(int AdvisoryID)
        {
            Advisory advisory = context.Advisories.Find(AdvisoryID);
            if (advisory != null)
            {
                context.Advisories.Remove(advisory);
                context.SaveChanges();
            }
            return advisory;
        }

        Advisory IAdvisoryRepository.GetAdvisory(int AdvisoryID)
        {
            return context.Advisories.FirstOrDefault(m => m.AdvisoryId == AdvisoryID);
        }

        IEnumerable<Advisory> IAdvisoryRepository.GetAllAdvisorys()
        {
            return context.Advisories;
        }

        Advisory IAdvisoryRepository.Update(Advisory advisoryChanges)
        {
            var advisory = context.Advisories.Attach(advisoryChanges);
            advisory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return advisoryChanges;
        }
    }
}
