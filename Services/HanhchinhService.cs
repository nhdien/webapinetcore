using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace WebAPINetCore.Services
{
    public interface IHanhchinhService
    {
        object SP_DM_TINH();
        object SP_DM_TINH_MA(string ma);
        object SP_DM_HUYEN_MA(string ma);
        object SP_DM_HUYEN_MATINH(string matinh);
        object SP_DM_PHUONGXA_MA(string ma);
        object SP_DM_PHUONGXA_MAHUYEN(string mahuyen);
        object SP_DM_PHUONGXA_MATINH(string matinh);
    }
    public class HanhchinhService : IHanhchinhService
    {
        private IConfiguration _configuration;

        public HanhchinhService(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }
             
        public object SP_DM_TINH()
        {
            object results = null;

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
                        var query = "SP_DM_TINH";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public object SP_DM_TINH_MA(string ma)
        {
            object results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma", value: ma, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_TINH_MA";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public object SP_DM_HUYEN_MA(string ma)
        {
            object results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma", value: ma, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HUYEN_MA";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public object SP_DM_HUYEN_MATINH(string matinh)
        {
            object results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma_tinh", value: matinh, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HUYEN_MATINH";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public object SP_DM_PHUONGXA_MA(string ma)
        {
            object results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma", value: ma, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_PHUONGXA_MA";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public object SP_DM_PHUONGXA_MAHUYEN(string mahuyen)
        {
            object results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma_huyen", value: mahuyen, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_PHUONGXA_MAHUYEN";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public object SP_DM_PHUONGXA_MATINH(string matinh)
        {
            object results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma_tinh", value: matinh, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_PHUONGXA_MATINH";

                        results = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }
    }
}
