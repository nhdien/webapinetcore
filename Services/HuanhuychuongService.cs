using Dapper;
using Dapper.Oracle;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using WebAPINetCore.Entities;

namespace WebAPINetCore.Services
{
    public class HuanhuychuongService: IHuanhuychuongService
    {
        private IConfiguration _configuration;
        public HuanhuychuongService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<DMHUANHUYCHUONG> SP_DM_HUANHUYCHUONG()
        {
            IEnumerable<DMHUANHUYCHUONG> results = null;

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
                        var query = "SP_DM_HUANHUYCHUONG";

                        results = conn.Query<DMHUANHUYCHUONG>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }


        public IEnumerable<DMHUANHUYCHUONG> SP_DM_HUANHUYCHUONG_TRANGTHAI(int trangthai)
        {
            IEnumerable<DMHUANHUYCHUONG> results = null;

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
                        var query = "SP_DM_HUANHUYCHUONG_TRANGTHAI";

                        results = conn.Query<DMHUANHUYCHUONG>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public DMHUANHUYCHUONG SP_DM_HUANHUYCHUONG_ID(int id)
        {
            DMHUANHUYCHUONG results = null;

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
                        var query = "SP_DM_HUANHUYCHUONG_ID";

                        results = conn.QueryFirstOrDefault<DMHUANHUYCHUONG>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public int SP_DM_HUANHUYCHUONG_CAPNHAT_TRANGTHAI(int id, int trangthai)
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
                        var query = "SP_DM_HUANHUYCHUONG_CAPNHAT_TRANGTHAI";

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

        public int SP_DM_HUANHUYCHUONG_INS(string prmdata)
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
                        var query = "SP_DM_HUANHUYCHUONG_INS";

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

        public int SP_DM_HUANHUYCHUONG_UPD(string prmdata)
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
                        var query = "SP_DM_HUANHUYCHUONG_UPD";

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

        public int SP_DM_HUANHUYCHUONG_DEL(int id)
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
                        var query = "SP_DM_HUANHUYCHUONG_DEL";

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

    public interface IHuanhuychuongService
    {
        IEnumerable<DMHUANHUYCHUONG> SP_DM_HUANHUYCHUONG();
        IEnumerable<DMHUANHUYCHUONG> SP_DM_HUANHUYCHUONG_TRANGTHAI(int trangthai);
        DMHUANHUYCHUONG SP_DM_HUANHUYCHUONG_ID(int id);
        int SP_DM_HUANHUYCHUONG_CAPNHAT_TRANGTHAI(int id, int trangthai);
        int SP_DM_HUANHUYCHUONG_INS(string prmdata);
        int SP_DM_HUANHUYCHUONG_UPD(string prmdata);
        int SP_DM_HUANHUYCHUONG_DEL(int id);
    }
}
