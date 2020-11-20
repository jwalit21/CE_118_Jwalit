using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.IRepositories
{
    public interface IAdvisoryRepository
    {
        Advisory Add(Advisory advisory);
        Advisory GetAdvisory(int AdvisoryID);
        IEnumerable<Advisory> GetAllAdvisorys();
        Advisory Update(Advisory advisoryChanges);
        Advisory Delete(int AdvisoryID);
    }
}
