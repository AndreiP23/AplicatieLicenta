using LicentaNou2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Repositories
{
    public interface ILoginRepository
    {

    }
    public class LoginRepository
    {
        private static IDBConnection _dbCon;
        public LoginRepository(IDBConnection dBConnection)
        {
            _dbCon = dBConnection;
        }

        //public async Task<List<IDictionary<string,object>>> GetUsersCaNuMergeAltfel()
        //{
        //    var sqlQ = @"";
        //}
    }
}
