using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// CityDAL 的摘要说明
/// </summary>
public class CityDAL
{
    /// <summary>
    /// 得到城市
    /// </summary>
    /// <param name="ProvinceId"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<CityModel> GetCity(int? ProvinceId, out int Count)
    {
        List<CityModel> olist = new List<CityModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Province_City_Car", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetCity");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _ItemId = new SqlParameter("@ItemId", ProvinceId == null ? (Object)DBNull.Value : ProvinceId.Value);
        _ItemId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ItemId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.Int);
        _result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_result);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    CityModel oCModel = new CityModel();
                    oCModel.CityId = (int)idr["CityId"];
                    if (idr["CityName"] != DBNull.Value) { oCModel.CityName = (string)idr["CityName"]; }
                    if (idr["ProvinceId"] != DBNull.Value) { oCModel.ProvinceId = (int)idr["ProvinceId"]; }
                    olist.Add(oCModel);
                }
            }
            Count = int.Parse(_result.Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }
        return olist;
    }
}