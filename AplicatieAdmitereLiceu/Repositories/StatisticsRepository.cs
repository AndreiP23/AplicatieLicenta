using LicentaNou2.Models;
using LicentaNou2.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicentaNou2.FrmMain;

namespace LicentaNou2.Repositories
{
    public interface IStatisticsRepository
    {
        Task<List<ProfilCandidat>> GetAvgProfil(string liceu);
        Task<List<RepartScoli>> GetRepartScoli(string liceu);
        Task<List<string>> GetAdresaLiceu(string liceu);
        Task<List<LiceuStatModel>> GetLicee();
    }
    public class StatisticsRepository: IStatisticsRepository
    {
        private static IDBConnection _dbCon;
        public StatisticsRepository(IDBConnection dBConnection)
        {
            _dbCon = dBConnection;
        }
        public async Task<List<ProfilCandidat>> GetAvgProfil(string liceu)
        {
            string sqlQ = @"SELECT 
                              ROUND(AVG(mabs), 2) AS MABS,
                              ROUND(AVG(madm), 2) AS MADM,
                              ROUND(AVG(mev), 2) AS MEV,
                              ROUND(AVG(nmate), 2) AS NMATE,
                              ROUND(AVG(nro), 2) AS NRO 
                            FROM 
                              RezultateCandidati 
                            WHERE 
                              UPPER(TRIM(H)) LIKE @liceu";
            SQLiteParameter sqlQParam = new SQLiteParameter("@liceu", '%' + liceu + '%'  );

            var result = await _dbCon.ExecuteQueryWithPram<ProfilCandidat>(sqlQ, sqlQParam);
            return result;
        }
        public async Task<List<RepartScoli>> GetRepartScoli(string liceu)
        {
            string sqlQ = @"SELECT
                            SUM(CASE WHEN s LIKE '%Şcoala%' THEN 1 ELSE 0 END) AS scoala_count,
                            SUM(CASE WHEN s LIKE '%Liceu%' THEN 1 ELSE 0 END) AS liceu_count,
                            SUM(CASE WHEN s LIKE '%Colegiu%' THEN 1 ELSE 0 END) AS colegiu_count
                            FROM RezultateCandidati
                            WHERE UPPER(TRIM(H)) LIKE @liceu";
            SQLiteParameter sqlQParam = new SQLiteParameter("@liceu", '%' + liceu + '%');

            var result = await _dbCon.ExecuteQueryWithPram<RepartScoli>(sqlQ, sqlQParam);
            return result;
        }
        public async Task<List<string>> GetAdresaLiceu(string liceu)
        {
            string sqlQ = @"select A from Licee WHERE L like @liceu";
            SQLiteParameter sqlQParam = new SQLiteParameter("@liceu", '%' + liceu + '%');

            var result = await _dbCon.ExecuteQueryV2<string>(sqlQ, sqlQParam);
            return result;
        }
        public async Task<List<LiceuStatModel>> GetLicee()
        {
            string sqlQ = @"select distinct L as Liceu, F as Id from Licee";

            var result = await _dbCon.ExecuteQueryWithPram<LiceuStatModel>(sqlQ);
            return result;
        }
    }
}
