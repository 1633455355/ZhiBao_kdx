using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// SqlActuator 的摘要说明
/// </summary>
public class SqlActuator
{
    public static int ExecuteNonQuery(string sql, string ConnectionString)
    {
        int retV = 0;
        SqlConnection sqlconnection = new SqlConnection(ConnectionString);
        SqlCommand sqlcommand = new SqlCommand(sql, sqlconnection);
        sqlcommand.CommandType = CommandType.Text;
        try
        {
            sqlconnection.Open();
            retV = sqlcommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlconnection.Close();
        }
        return retV;
    }

    /// <summary>
    /// 有条件查询
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static int ExecuteNonQuery(string sql, List<SqlParameter> listSqlParameter, string ConnectionString)
    {
        int retV = 0;
        SqlConnection sqlconnection = new SqlConnection(ConnectionString);
        SqlCommand sqlcommand = new SqlCommand(sql, sqlconnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;
        if (listSqlParameter != null)
        {
            foreach (SqlParameter obj in listSqlParameter)
            {
                sqlcommand.Parameters.Add(obj);
            }
        }
        try
        {
            sqlconnection.Open();
            retV = sqlcommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlconnection.Close();
        }
        return retV;
    }

    /// <summary>
    /// 有条件查询,返回ID
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static string ExecuteScalar(string sql, List<SqlParameter> listSqlParameter, string ConnectionString)
    {
        string retV = "";
        SqlConnection sqlconnection = new SqlConnection(ConnectionString);
        SqlCommand sqlcommand = new SqlCommand(sql, sqlconnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;
        if (listSqlParameter != null)
        {
            foreach (SqlParameter obj in listSqlParameter)
            {
                sqlcommand.Parameters.Add(obj);
            }
        }
        try
        {
            sqlconnection.Open();
            object o = sqlcommand.ExecuteScalar();
            if (o != null)
            {
                retV = o.ToString();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlconnection.Close();
        }
        return retV;
    }
}