using LicentaNou2.Models;
using LicentaNou2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicentaNou2.FrmMain;

namespace LicentaNou2.Repositories
{
    public interface IMLAdmissionRepository
    {
        Task<List<MLAdmissionModel>> GetDateForTraining();
    }
    public class MLAdmissionRepository : IMLAdmissionRepository
    {
        private static IDBConnection _dbCon;
        public MLAdmissionRepository(IDBConnection dBConnection)
        {
            _dbCon = dBConnection;

        }
        public async Task<List<MLAdmissionModel>> GetDateForTraining()
        {
            string sqlQ = @"select medie_admitere as MedieAdmitere, locuri, ultima_medie as UltimaMedie, medie_an_precedent as MedieAnPrecedent,
                    candidat, profil,liceu , judet, judet_liceu as JudetLiceu, clasa_profil as ClasaProfil, medie_2021 as Medie2021 from ProcesareDateElevi";
            List<MLAdmissionModel> result = await _dbCon.ExecuteQueryWithPram<MLAdmissionModel>(sqlQ);

            return result;
        }
    }
}
