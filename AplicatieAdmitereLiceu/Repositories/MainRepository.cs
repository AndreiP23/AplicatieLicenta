using LicentaNou2.Models;
using LicentaNou2.Util;
using System.Data.SQLite;
using static LicentaNou2.FrmMain;

namespace LicentaNou2.Repositories
{
    public interface IMainRepository
    {
        Task<List<Profil>> GetProfile();
        Task<List<ModelRezLiceu>> PopulareDGVTopLicee(int an);
        Task<List<GeneralInfo>> StatLiceeByANAndProfil(int an, string profil);
        Task<int> StatLiceeByANAndProfilInt(int an, string profil);
        Task<List<ModelRezLiceu>> Search(string context, int anSelectat);
        Task<ChartModel> FillChart(int anSelectat);
    }
    public class MainRepository : IMainRepository
    {
        private static IDBConnection _dbCon;
        public MainRepository(IDBConnection dBConnection)
        {
            _dbCon = dBConnection;
        }
        public async Task<List<Profil>> GetProfile()
        {
            string sqlQ = @"select distinct p as Nume from RezultateLicee";
            List<Profil> result = await _dbCon.ExecuteQueryWithPram<Profil>(sqlQ);

            return result;
        }
        public async Task<List<ModelRezLiceu>> PopulareDGVTopLicee(int an)
        {
            string sqlQ = @"select I, NLT,LP, SP,UM,UMA  from RezultateLicee where AN between @ANFrom and @ANTo order by I";
            SQLiteParameter sqlQParam = new SQLiteParameter("@ANFrom", an);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@ANTo", an + 1);

            var result = _dbCon.ExecuteQueryWithPram<ModelRezLiceu>(sqlQ, sqlQParam, sqlQParam2);

            return await result;
        }
        public async Task<List<GeneralInfo>> StatLiceeByANAndProfil(int an, string profil)
        {
            string sqlQ = @"select count(*) as NrLicee,max(um) as MedieMax,min(um) as MedieMin,avg(um) - avg(uma) as AvgDif, avg(NLO) as MedieLocuri  from RezultateLicee where p = @profil and AN BETWEEN @ANFrom and @ANTo";
            SQLiteParameter sqlQParam = new SQLiteParameter("@ANFrom", an);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@ANTo", an + 1);
            SQLiteParameter sqlQParam3 = new SQLiteParameter("@profil", profil);

            var result = _dbCon.ExecuteQueryWithPram<GeneralInfo>(sqlQ, sqlQParam, sqlQParam2, sqlQParam3);

            return await result;
        }

        public async Task<int> StatLiceeByANAndProfilInt(int an, string profil)
        {
            string sqlQ = @"select count(*) as NrLicee from RezultateLicee where AN BETWEEN @ANFrom and @ANTo";
            SQLiteParameter sqlQParam = new SQLiteParameter("@ANFrom", an);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@ANTo", an + 1);
            SQLiteParameter sqlQParam3 = new SQLiteParameter("@profil", profil);

            var result = _dbCon.ExecuteScalarInt(sqlQ, sqlQParam, sqlQParam2, sqlQParam3);

            return result;
        }
        public async Task<List<ModelRezLiceu>> Search(string context, int anSelectat)
        {
            string sqlQ = @"select I, NLT,LP, SP,UM,UMA  from RezultateLicee where strftime('%Y',AN) >= @ANFrom and strftime('%Y',AN) < @ANTo and (UM like @value or SP like @value or NLT like @value or I like @value) order by I";
            SQLiteParameter sqlQParam = new SQLiteParameter("@ANFrom", $"{anSelectat}");
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@ANTo", $"{anSelectat+1}");
            SQLiteParameter sqlQParam3 = new SQLiteParameter("@value", "%" + context + "%");

            var result = _dbCon.ExecuteQueryWithPram<ModelRezLiceu>(sqlQ, sqlQParam, sqlQParam2, sqlQParam3);

            return await result;
        }
        public async Task<ChartModel> FillChart(int anSelectat)
        {
            SQLiteParameter sqlQParam = new SQLiteParameter("@ANFrom", anSelectat);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@ANTo", anSelectat + 1);
            var sqlQ = @"SELECT COUNT(CASE WHEN um > 9 AND um <= 10 THEN 1 END) AS CategoriaA,
                       COUNT(CASE WHEN um > 8 AND um <= 9 THEN 1 END) AS CategoriaB,
	                   COUNT(CASE WHEN um > 7 AND um <= 8 THEN 1 END) AS CategoriaC,
	                   COUNT(CASE WHEN um > 6 AND um <= 7 THEN 1 END) AS CategoriaD,
	                   COUNT(CASE WHEN um <= 6 THEN 1 END) AS CategoriaF
                       FROM RezultateLicee
                       where an BETWEEN @ANFrom and @ANTo";

            var result = await _dbCon.ExecuteQuerySingle<ChartModel>(sqlQ, sqlQParam, sqlQParam2);

            return result;
        }
    }
}
