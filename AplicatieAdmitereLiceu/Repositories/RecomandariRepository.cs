using LicentaNou2.Util;
using LicentaNou2.Views;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Repositories
{
    public interface IRecomandariRepository
    {
        Task<List<string>> PopulateLicee();
        Task<List<string>> PopulateProfile();
        Task<List<string>> PopulateLimba();
    }
    public class RecomandariRepository: IRecomandariRepository
    {
        private static IDBConnection _dbCon;
        public RecomandariRepository(IDBConnection dBConnection)
        {
            _dbCon = dBConnection;
        }
        public async Task<List<string>> PopulateLicee()
        {
            string sqlQ = @"select distinct I from RezultateLicee";
            var result = await _dbCon.ExecuteQueryV2<string>(sqlQ);
            return  result;
        }
        public async Task<List<string>> PopulateProfile()
        {
            string sqlQ = @"select distinct SP from RezultateLicee";

            var result = _dbCon.ExecuteQueryV2<string>(sqlQ);
            return await result;
        }
        public async Task<List<string>> PopulateLimba()
        {
            string sqlQ = @"select distinct CASE WHEN LB = '-' THEN 'Limba romana' ELSE LB END  from RezultateLicee";

            var result = _dbCon.ExecuteQueryV2<string>(sqlQ);
            return await result;
        }
    }
}
