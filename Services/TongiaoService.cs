using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPINetCore.Entities;

namespace WebAPINetCore.Services
{
    public interface ITongiaoService
    {
        IEnumerable<DMTONGIAO> SP_DM_TONGIAO();
        IEnumerable<DMTONGIAO> SP_DM_TONGIAO_TRANGTHAI(int trangthai);
        DMTONGIAO SP_DM_TONGIAO_MA(string ma);
        int SP_DM_TONGIAO_CAPNHAT_TRANGTHAI(string ma, int trangthai);
        int SP_DM_TONGIAO_INS(string prmdata);
        int SP_DM_TONGIAO_UPD(string prmdata);
        int SP_DM_TONGIAO_DEL(string ma);
    }
    public class TongiaoService : ITongiaoService
    {
        private IConfiguration _configuration;
        public TongiaoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DMTONGIAO> SP_DM_TONGIAO()
        {
            IEnumerable<DMTONGIAO> results = null;

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
                        var query = "SP_DM_TONGIAO";

                        results = conn.Query<DMTONGIAO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
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
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public IEnumerable<DMTONGIAO> SP_DM_TONGIAO_TRANGTHAI(int trangthai)
        {
            IEnumerable<DMTONGIAO> results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
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
                        var query = "SP_DM_TONGIAO_TRANGTHAI";

                        results = conn.Query<DMTONGIAO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
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
        /// <param name="ma"></param>
        /// <returns></returns>
        public DMTONGIAO SP_DM_TONGIAO_MA(string ma)
        {
            DMTONGIAO results = null;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("results", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    dyParam.Add("pma", value: ma, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_TONGIAO_MA";

                        results = conn.QueryFirstOrDefault<DMTONGIAO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
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
        /// <param name="ma"></param>
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public int SP_DM_TONGIAO_CAPNHAT_TRANGTHAI(string ma, int trangthai)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIDatabase")))
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
                        var query = "SP_DM_TONGIAO_CAPNHAT_TRANGTHAI";

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmdata"></param>
        /// <returns></returns>
        public int SP_DM_TONGIAO_INS(string prmdata)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
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
                        var query = "SP_DM_TONGIAO_INS";

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmdata"></param>
        /// <returns></returns>
        public int SP_DM_TONGIAO_UPD(string prmdata)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
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
                        var query = "SP_DM_TONGIAO_UPD";

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public int SP_DM_TONGIAO_DEL(string ma)
        {
            int results = 0;

            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("WebAPIAuthDatabase")))
            {
                try
                {
                    var dyParam = new OracleDynamicParameters();

                    dyParam.Add("pma", value: ma, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_DM_TONGIAO_DEL";

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
