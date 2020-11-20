using Aarogyam.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.SQLRepositories
{
    public class SQLCovidDataRepository:ICovidDataRepository
    {
        private readonly AppDbContext context;
        public SQLCovidDataRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CovidData Add(CovidData covidData)
        {
            context.CovidDatas.Add(covidData);
            context.SaveChanges();
            return covidData;
        }

        public IEnumerable<CovidData> GetAllCovidDatas()
        {
            return context.CovidDatas;
        }

        public CovidData GetCovidData(int CovidDataID)
        {
            return context.CovidDatas.FirstOrDefault(m => m.CovidDataId == CovidDataID);
        }

        public CovidData Update(CovidData covidDataChanges)
        {
            var data = context.CovidDatas.Attach(covidDataChanges);
            data.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return covidDataChanges;
        }
    }
}
