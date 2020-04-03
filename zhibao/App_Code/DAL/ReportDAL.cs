using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// ReportDAL 的摘要说明
/// </summary>
public class ReportDAL
{
    /// <summary>
    /// 得到厂家报表
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public DataSet GetAdminReportInfo(int firsttype,int secondtype,int dealer,int store, DateTime start,DateTime end,int AdminId)
    {
        DataSet ds = new DataSet();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
       
        SqlCommand sqlcommand = new SqlCommand("sp_Admin_Total", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.CommandTimeout = 0;
        sqlcommand.Parameters.AddWithValue("@firsttype", firsttype);
        sqlcommand.Parameters.AddWithValue("@secondtype", secondtype);
        sqlcommand.Parameters.AddWithValue("@dealer", dealer);
        sqlcommand.Parameters.AddWithValue("@store", store);
        sqlcommand.Parameters.AddWithValue("@starTime",start);
        sqlcommand.Parameters.AddWithValue("@endTime",end);
        sqlcommand.Parameters.AddWithValue("@AdminId", AdminId);
        SqlDataAdapter sda = new SqlDataAdapter(sqlcommand);
        try
        {
            sda.Fill(ds);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }
        return ds;

    }
   /// <summary>
   /// 得到经销商报表
   /// </summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   /// <returns></returns>
    public DataSet GetDealerReportInfo(DateTime start, DateTime end,int DealerId)
    {
        DataSet dt = new DataSet();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

        SqlCommand sqlcommand = new SqlCommand("sp_Dealer_Total", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Parameters.AddWithValue("@starTime", start);
        sqlcommand.Parameters.AddWithValue("@endTime", end);
        sqlcommand.Parameters.AddWithValue("@_dealerId", DealerId);
        SqlDataAdapter sda = new SqlDataAdapter(sqlcommand);
        try
        {
            sda.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }
        return dt;

    }
    /// <summary>
    /// 得到加盟店报表信息
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public DataSet GetStoreReportInfo(DateTime start, DateTime end,int StoreId)
    {
        DataSet dt = new DataSet();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

        SqlCommand sqlcommand = new SqlCommand("sp_Store_Total", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;
        sqlcommand.Parameters.AddWithValue("@starTime", start);
        sqlcommand.Parameters.AddWithValue("@endTime", end);
        sqlcommand.Parameters.AddWithValue("@_storeId", StoreId);
        SqlDataAdapter sda = new SqlDataAdapter(sqlcommand);
        try
        {
            sda.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }
        return dt;

    }
}