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
    public class CapbacService: ICapbacService
    {
        private IConfiguration _configuration;
        public CapbacService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<DMCAPBAC> SP_DM_CAPBAC()
        {
            IEnumerable<DMCAPBAC> results = null;

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
                        var query = "SP_DM_CAPBAC";

                        results = conn.Query<DMCAPBAC>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }


        public IEnumerable<DMCAPBAC> SP_DM_CAPBAC_TRANGTHAI(int trangthai)
        {
            IEnumerable<DMCAPBAC> results = null;

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
                        var query = "SP_DM_CAPBAC_TRANGTHAI";

                        results = conn.Query<DMCAPBAC>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public DMCAPBAC SP_DM_CAPBAC_ID(int id)
        {
            DMCAPBAC results = null;

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
                        var query = "SP_DM_CAPBAC_ID";

                        results = conn.QueryFirstOrDefault<DMCAPBAC>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return results;
            }
        }

        public int SP_DM_CAPBAC_CAPNHAT_TRANGTHAI(int id, int trangthai)
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
                        var query = "SP_DM_CAPBAC_CAPNHAT_TRANGTHAI";

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

        public int SP_DM_CAPBAC_INS(string prmdata)
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
                        var query = "SP_DM_CAPBAC_INS";

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

        public int SP_DM_CAPBAC_UPD(string prmdata)
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
                        var query = "SP_DM_CAPBAC_UPD";

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

        public int SP_DM_CAPBAC_DEL(int id)
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
                        var query = "SP_DM_CAPBAC_DEL";

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

    public interface ICapbacService
    {
        IEnumerable<DMCAPBAC> SP_DM_CAPBAC();
        IEnumerable<DMCAPBAC> SP_DM_CAPBAC_TRANGTHAI(int trangthai);
        DMCAPBAC SP_DM_CAPBAC_ID(int id);
        int SP_DM_CAPBAC_CAPNHAT_TRANGTHAI(int id, int trangthai);
        int SP_DM_CAPBAC_INS(string prmdata);
        int SP_DM_CAPBAC_UPD(string prmdata);
        int SP_DM_CAPBAC_DEL(int id);
    }
}
