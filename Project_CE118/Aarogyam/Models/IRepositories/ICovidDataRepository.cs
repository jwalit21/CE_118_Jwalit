using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.IRepositories
{
    public interface ICovidDataRepository
    {
        CovidData Add(CovidData covidData);
        CovidData GetCovidData(int CovidDataID);
        IEnumerable<CovidData> GetAllCovidDatas();
        CovidData Update(CovidData covidDataChanges);
    }
}
