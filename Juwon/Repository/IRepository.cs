﻿using Dapper;
//using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Juwon.Repository
{
    public interface IRepository
    {
        #region BE USED WHEN EXECUTE A STORED PROCEDURE
        Task<T> ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null);
        Task<T> ExecuteReturnFirsOrDefault<T>(string procedureName, DynamicParameters param = null);
        Task<IList<T>> ExecuteReturnList<T>(string procedureName, DynamicParameters param = null);
        Task<DataTable> ExecuteReturnDataTable(string procedureName, DynamicParameters param = null);
        #endregion

        #region BE USED WHEN EXECUTE A QUERY
        Task<T> GetReturnScalar<T>(string sql, DynamicParameters param = null);
        Task<T> GetReturnFirstOrDefault<T>(string sql, DynamicParameters param = null);
        Task<IList<T>> GetReturnList<T>(string sql, DynamicParameters param = null);
        Task<DataTable> GetReturnDataTable(string sql, DynamicParameters param = null);
        #endregion

        #region BULK Operation
        Task<int> BulkInsertBySql<T>(string sql, List<T> obj);
        #endregion
    }
}
