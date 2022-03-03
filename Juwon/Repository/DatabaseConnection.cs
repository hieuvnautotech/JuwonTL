using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Juwon.Repository
{
    public static class DatabaseConnection
    {

        /*
         <add name="_DbContext" connectionString="data source=118.69.61.10;initial catalog=Juwon;persist security info=True;user id=sa;password=Onconc848682@#!;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
         */

        /**
         * Connection String Set up
         */

        //// AUTONSI-JUWON NAT
        //public static readonly string CONNECTIONSTRING = @"data source=192.168.5.47;initial catalog=Juwon;persist security info=True;user id=sa;password=P@ssw0rd$#;MultipleActiveResultSets=True;";
        public static readonly string CONNECTIONSTRING = @"data source=.;initial catalog=Juwon;persist security info=True;user id=sa;password=P@ssw0rd$#;MultipleActiveResultSets=True;";
        //public static readonly string CONNECTIONSTRING = @"data source=118.69.61.10;initial catalog=Juwon;persist security info=True;user id=sa;password=Onconc848682@#!;MultipleActiveResultSets=True;";

        //// AUTONSI-JUWON LOCAL
        //public static readonly string CONNECTIONSTRING = @"data source=localhost;initial catalog=Juwon;persist security info=True;user id=sa;password=Onconc848682@#!;MultipleActiveResultSets=True;";

        public static async Task<T> ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
