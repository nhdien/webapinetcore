using Microsoft.Extensions.Configuration;
using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using WebAPINetCore.Entities;
using System.Collections.Generic;

namespace WebAPINetCore.Services
{
    public interface IDantocService
    {
        IEnumerable<DMDANTOC> SP_DM_DANTOC();
        IEnumerable<DMDANTOC> SP_DM_DANTOC_TRANGTHAI(int TRANGTHAI);
        int SP_DM_DANTOC_CAPNHAT_TRANGTHAI(string ma, int trangthai);
    }

    public class DantocService : IDantocService
    {
        private IConfiguration _configuration;
        

        public DantocService(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DMDANTOC> SP_DM_DANTOC()
        {
            IEnumerable<DMDANTOC> results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_DANTOC";

                        results = conn.Query<DMDANTOC>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TRANGTHAI">0: Không sử dụng, 1: Đang sử dụng</param>
        /// <returns></returns>
        public IEnumerable<DMDANTOC> SP_DM_DANTOC_TRANGTHAI(int TRANGTHAI)
        {
            IEnumerable<DMDANTOC> results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    dyParam.Add("ptrangthai", value: TRANGTHAI, dbType: OracleMappingType.Int16, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_DANTOC_TRANGTHAI";

                        results = conn.Query<DMDANTOC>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public int SP_DM_DANTOC_CAPNHAT_TRANGTHAI(string ma, int trangthai)
        {
            int results = 0;
            
            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try 
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma", value: ma, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("ptrangthai", value: trangthai, dbType: OracleMappingType.Int16, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_DANTOC_CAPNHAT_TRANGTHAI";

                        results = conn.Execute(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return results;
        }
    }
}
