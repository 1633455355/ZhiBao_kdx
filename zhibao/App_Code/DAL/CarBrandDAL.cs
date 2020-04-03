using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// CarBrandDAL 的摘要说明
/// </summary>
public class CarBrandDAL
{ 
    /// <summary>
    /// 得到车子品牌信息
    /// </summary>
    /// <param name="CarBrandCode"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<CarBrandModel> GetCarBrand(int? CarBrandCode, out int Count)
    {
        List<CarBrandModel> olist = new List<CarBrandModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Province_City_Car", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetBrand");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _ItemId = new SqlParameter("@ItemId", CarBrandCode == null ? (Object)DBNull.Value : CarBrandCode.Value);
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
                    CarBrandModel oCModel = new CarBrandModel();
                    if (idr["CarBrandCode"] != DBNull.Value) { oCModel.CarBrandCode = (int)idr["CarBrandCode"]; }
                    if (idr["CarBrandName"] != DBNull.Value) { oCModel.CarBrandName = (string)idr["CarBrandName"]; }
                    if (idr["Firstletter"] != DBNull.Value) { oCModel.Firstletter = (string)idr["Firstletter"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
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