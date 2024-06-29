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
    public interface IDetaliiRecomandareRepository
    {
        Task<List<int>> LoadPrimaZonaIntSup(double notaR, double notaM, double medie);
        Task<List<int>> LoadPrimaZonaIntrari();
        Task<List<DataPrepModel>> GetDataZona2(string liceu, string profil, string limba);
        Task<double> GetAvgAnualLimbaSiProfil(string liceu, string profil, string an);
        Task<List<LiceuViewModel>> GetLiceeAprpDeMedie(string liceu, string profil, double valInf, double valSup);
        Task<List<Diff>> GetLiceeProfil(string profil,int categ);
        Task<double> GetSpecificUMA(string liceu, string limba, string profil);
    }
    public class DetaliiRecomandareRepository : IDetaliiRecomandareRepository
    {
        private static IDBConnection _dbCon;
        public DetaliiRecomandareRepository(IDBConnection dBConnection)
        {
            _dbCon = dBConnection;
        }

        public async Task<List<int>> LoadPrimaZonaIntSup(double notaR, double notaM, double medie)
        {
            string sqlQ = @"SELECT COUNT(N) AS IntariSuperioare, AN
                            FROM RezultateCandidati
                            WHERE
                              CASE
                                WHEN MEV > @mev THEN 1  ";
            if (notaR > 0)
            {
                sqlQ += @"WHEN MEV = @mev AND NRO > @nro THEN 1 ";
            }
            if (notaM > 0)
            {
                sqlQ += @"WHEN MEV = @mev AND NMATE > @nmate THEN 1 ";
            }
            sqlQ += @" ELSE 0
                       END = 1
                       GROUP BY AN";
            SQLiteParameter sqlQParam = new SQLiteParameter("@mev", medie);
            SQLiteParameter sqlQParam1 = new SQLiteParameter("@nro", notaR);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@nmate", notaM);

            var result = _dbCon.ExecuteQueryV2<int>(sqlQ, sqlQParam, sqlQParam1, sqlQParam2);
            return await result;
        }
        public async Task<List<int>> LoadPrimaZonaIntrari()
        {
            string sqlQ = @"SELECT COUNT(N), AN AS Intrari
                            FROM RezultateCandidati
                            GROUP BY AN";
            var result = _dbCon.ExecuteQueryV2<int>(sqlQ);
            return await result;
        }
        public async Task<double> GetAvgAnualLimbaSiProfil(string limba, string profil, string an)
        {
            string sqlQ = @"select avg(uma) from RezultateLicee where lp = @limba and sp = @sp and an = @an";
            SQLiteParameter sqlQParam = new SQLiteParameter("@limba", limba);
            SQLiteParameter sqlQParam1 = new SQLiteParameter("@sp", profil);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@an", an);
            var result = await _dbCon.ExecuteQueryV2<double>(sqlQ, sqlQParam, sqlQParam1, sqlQParam2);
            return result.FirstOrDefault();
        }
        public async Task<List<LiceuViewModel>> GetLiceeAprpDeMedie(string limba, string profil, double valInf, double valSup)
        {
            string sqlQ;
            if (!string.IsNullOrEmpty(profil))
            {
                sqlQ = @"select distinct I as Nume, NLT as NumarLocuri ,UMA as Media, sp as Specializare from RezultateLicee where uma BETWEEN @valInf and @valSup and lp = @limba and sp = @profil";
            }
            else
            {
                sqlQ = @"select distinct I as Nume, NLT as NumarLocuri ,UMA as Media, sp as Specializare from RezultateLicee where uma BETWEEN @valInf and @valSup and lp = @limba";
            }
            SQLiteParameter sqlQParam = new SQLiteParameter("@limba", limba);
            SQLiteParameter sqlQParam1 = new SQLiteParameter("@profil", profil);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@valInf", valInf);
            SQLiteParameter sqlQParam3 = new SQLiteParameter("@valSup", valSup);
            var result = _dbCon.ExecuteQueryWithPram<LiceuViewModel>(sqlQ, sqlQParam, sqlQParam1, sqlQParam2, sqlQParam3);
            return await result;
        }
        public async Task<List<Diff>> GetLiceeProfil( string profil, int categ)
        {
            string sqlQ;

            if (!string.IsNullOrEmpty(profil) && categ == -1)
                sqlQ = @"SELECT uma-um as VALUE FROM RezultateLicee WHERE sp = @profil";
            else if (categ >= 0 && string.IsNullOrEmpty(profil))
            {
                sqlQ = @"WITH FilteredResults AS (
                                    SELECT
                                        um - uma as um,
                                        CASE
                                            WHEN 1 =  0 AND um > 9 AND um <= 10 THEN 'A'
                                            WHEN 1 =  1 AND um > 8 AND um <= 9 THEN 'B'
                                            WHEN 1 =  2 AND um > 7 AND um <= 8 THEN 'C'
                                            WHEN 1 =  3 AND um > 6 AND um <= 7 THEN 'D'
                                            WHEN 1 =  4 AND um <= 6 THEN 'F'
                                            ELSE NULL
                                        END AS Category
                                    FROM RezultateLicee
                                )
                                SELECT
                                    um AS value
                                FROM FilteredResults
                                WHERE Category IS NOT NULL";
            }
            else
            {
                sqlQ = @"WITH FilteredResults AS (
                                    SELECT
                                        um - uma as um,
                                        CASE
                                            WHEN 1 =  0 AND um > 9 AND um <= 10 THEN 'A'
                                            WHEN 1 =  1 AND um > 8 AND um <= 9 THEN 'B'
                                            WHEN 1 =  2 AND um > 7 AND um <= 8 THEN 'C'
                                            WHEN 1 =  3 AND um > 6 AND um <= 7 THEN 'D'
                                            WHEN 1 =  4 AND um <= 6 THEN 'F'
                                            ELSE NULL
                                        END AS Category
                                    FROM RezultateLicee
                                    WHERE sp = @profil
                                )
                                SELECT
                                    um AS value
                                FROM FilteredResults
                                WHERE Category IS NOT NULL";
            }
            SQLiteParameter sqlQParam1 = new SQLiteParameter("@profil", profil);
            var result = _dbCon.ExecuteQueryWithPram<Diff>(sqlQ, sqlQParam1);
            return await result;
        }
        public async Task<double> GetSpecificUMA( string liceu, string limba, string profil)
        {
            string sqlQ;
            if (!string.IsNullOrEmpty(profil)) 
                sqlQ = @"select uma as value from RezultateLicee WHERE I = @liceu and sp = @profil and lb = @limba order by an desc";
            else
            {
                sqlQ = @"select uma as value from RezultateLicee WHERE I = @liceu and lb = @limba order by an desc, uma asc";
            }
            SQLiteParameter sqlQParam1 = new SQLiteParameter("@liceu", liceu);
            SQLiteParameter sqlQParam = new SQLiteParameter("@limba", limba == "Limba romana" ? "-": limba);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@profil", profil);
            var result = _dbCon.ExecuteScalarDouble(sqlQ, sqlQParam1, sqlQParam, sqlQParam2);
            return result;
        }
        public async Task<List<DataPrepModel>> GetDataZona2(string liceu, string profil, string limba)
        {
            string sqlQ = @"SELECT
                            AN,
                            UM,
                            UMA,
                            NLT
                        FROM
                            RezultateLicee
                        WHERE ";
            var conditions = string.Empty;

            if (!string.IsNullOrEmpty(liceu))
            {
                conditions += @"I = @liceu and ";
            }
            if (!string.IsNullOrEmpty(profil))
            {
                conditions += @"sp = @sp and ";
            }
            if (!string.IsNullOrEmpty(limba))
            {
                conditions += @"lp = @lb and ";
            }
            sqlQ += conditions.Substring(0, conditions.Length - 4) + @"GROUP BY
                                        AN
                                    ORDER BY
                                        AN";
            SQLiteParameter sqlQParam = new SQLiteParameter("@liceu", liceu);
            SQLiteParameter sqlQParam1 = new SQLiteParameter("@sp", profil);
            SQLiteParameter sqlQParam2 = new SQLiteParameter("@lb", limba);

            var result = _dbCon.ExecuteQueryWithPram<DataPrepModel>(sqlQ, sqlQParam, sqlQParam1, sqlQParam2);
            return await result;
        }
    }
}
