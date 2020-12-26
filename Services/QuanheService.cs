using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Threading.Tasks;
using WebAPINetCore.Entities;
using System.Data;
using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;

namespace WebAPINetCore.Services
{
    public interface IQuanheService
    {
        IEnumerable<DMQUANHE> SP_DM_QUANHE();
        IEnumerable<DMQUANHE> SP_DM_QUANHE_TRANGTHAI(int trangthai);
        DMQUANHE SP_DM_QUANHE_ID(int id);
        int SP_DM_QUANHE_CAPNHAT_TRANGTHAI(int id, int trangthai);
        int SP_DM_QUANHE_INS(string prmdata);
        int SP_DM_QUANHE_UPD(string prmdata);
        int SP_DM_QUANHE_DEL(int id);
    }
    public class QuanheService: IQuanheService
    {
        private IConfiguration _configuration;
        public QuanheService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<DMQUANHE> SP_DM_QUANHE()
        {
            IEnumerable<DMQUANHE> results = null;

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
                        var query = "SP_DM_QUANHE";

                        results = conn.Query<DMQUANHE>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }


        public IEnumerable<DMQUANHE> SP_DM_QUANHE_TRANGTHAI(int trangthai)
        {
            IEnumerable<DMQUANHE> results = null;

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
                        var query = "SP_DM_QUANHE_TRANGTHAI";

                        results = conn.Query<DMQUANHE>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public DMQUANHE SP_DM_QUANHE_ID(int id)
        {
            DMQUANHE results = null;

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
                        var query = "SP_DM_QUANHE_ID";

                        results = conn.QueryFirstOrDefault<DMQUANHE>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public int SP_DM_QUANHE_CAPNHAT_TRANGTHAI(int id, int trangthai)
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
                        var query = "SP_DM_QUANHE_CAPNHAT_TRANGTHAI";

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

        public int SP_DM_QUANHE_INS(string prmdata)
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
                        var query = "SP_DM_QUANHE_INS";

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

        public int SP_DM_QUANHE_UPD(string prmdata)
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
                        var query = "SP_DM_QUANHE_UPD";

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

        public int SP_DM_QUANHE_DEL(int id)
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
                        var query = "SP_DM_QUANHE_DEL";

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
