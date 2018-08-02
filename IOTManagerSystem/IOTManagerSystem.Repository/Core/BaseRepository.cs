using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IOTManagerSystem.Repository.Core
{
    public class BaseRepository
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["IOTMANAGERSYSTEM"].ConnectionString;

        public BaseRepository()
        { }

        //SELECT
        public IEnumerable<T> Query<T>(string strSQL, CommandType command, dynamic param = null)
        {

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    return SqlMapper.Query<T>(connection, strSQL, param: param, commandType: command);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return default(IEnumerable<T>);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        //INTSERT,UPDATE,DELETE
        public bool Execute<T>(string strSQL, CommandType command, DynamicParameters param = null, DynamicParameters outParam = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    int kq = connection.Execute(strSQL,
                                param,
                                commandType: command
                            );
                    return kq > 0;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        //FUNCTION
        public dynamic ResultFunction(string stringFunction)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    dynamic result = connection.Query<dynamic>(stringFunction);
                    return result[0].result;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }

        }

        public DynamicParameters CreateOutputParameters()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("result", string.Empty, DbType.String, ParameterDirection.InputOutput, 255);

            return param;
        }

        public void CombineParameters(ref DynamicParameters param, DynamicParameters outParam = null)
        {
            if (outParam != null)
            {
                if (param != null)
                {
                    param = new DynamicParameters(param);
                    ((DynamicParameters)param).AddDynamicParams(outParam);
                }
                else param = outParam;
            }
        }
    }
}
