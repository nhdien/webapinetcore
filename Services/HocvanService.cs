using Microsoft.Extensions.Configuration;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPINetCore.Entities;
using System.Data;
using Dapper;

namespace WebAPINetCore.Services
{
    public interface IHocvanService
    {
        IEnumerable<DMHOCVAN> SP_DM_HOCVAN();
        IEnumerable<DMHOCVAN> SP_DM_HOCVAN_TRANGTHAI(int trangthai);
        DMHOCVAN SP_DM_HOCVAN_ID(int id);
        int SP_DM_HOCVAN_CAPNHAT_TRANGTHAI(int id, int trangthai);
        int SP_DM_HOCVAN_INS(string prmdata);
        int SP_DM_HOCVAN_UPD(string prmdata);
        int SP_DM_HOCVAN_DEL(int id);
    }

    public class HocvanService : IHocvanService
    {
        private IConfiguration _configuration;
        public HocvanService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<DMHOCVAN> SP_DM_HOCVAN()
        {
            IEnumerable<DMHOCVAN> results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
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
                        var query = "SP_DM_HOCVAN";

                        results = conn.Query<DMHOCVAN>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }


        public IEnumerable<DMHOCVAN> SP_DM_HOCVAN_TRANGTHAI(int trangthai)
        {
            IEnumerable<DMHOCVAN> results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    dyParam.Add("ptrangthai", value: trangthai, dbType: OracleMappingType.Int16, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HOCVAN_TRANGTHAI";

                        results = conn.Query<DMHOCVAN>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public DMHOCVAN SP_DM_HOCVAN_ID(int id)
        {
            DMHOCVAN results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    dyParam.Add("pid", value: id, dbType: OracleMappingType.Int16, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HOCVAN_ID";

                        results = conn.QueryFirstOrDefault<DMHOCVAN>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public int SP_DM_HOCVAN_CAPNHAT_TRANGTHAI(int id, int trangthai)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pid", value: id, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
                    dyParam.Add("ptrangthai", value: trangthai, dbType: OracleMappingType.Int16, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HOCVAN_CAPNHAT_TRANGTHAI";

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

        public int SP_DM_HOCVAN_INS(string prmdata)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("prmdata", value: prmdata, dbType: OracleMappingType.Clob, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HOCVAN_INS";

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

        public int SP_DM_HOCVAN_UPD(string prmdata)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("prmdata", value: prmdata, dbType: OracleMappingType.Clob, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HOCVAN_UPD";

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

        public int SP_DM_HOCVAN_DEL(int id)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pid", value: id, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_HOCVAN_DEL";

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
