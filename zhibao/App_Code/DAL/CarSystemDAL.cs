using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// CarSystemDAL 的摘要说明
/// </summary>
public class CarSystemDAL
{  
    /// <summary>
    ///得到车系信息
    /// </summary>
    /// <param name="CarBrandCode"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<CarSystemModel> GetCarSystem(int? CarBrandCode, out int Count)
    {
        List<CarSystemModel> olist = new List<CarSystemModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Province_City_Car", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetSystem");
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
                    CarSystemModel oCModel = new CarSystemModel();
                    if (idr["CarSystemCode"] != DBNull.Value) { oCModel.CarSystemCode = (int)idr["CarSystemCode"]; }
                    if (idr["CarSystemName"] != DBNull.Value) { oCModel.CarSystemName = (string)idr["CarSystemName"]; }
                    if (idr["CarBrandCode"] != DBNull.Value) { oCModel.CarBrandCode = (int)idr["CarBrandCode"]; }
                    if (idr["SY"] != DBNull.Value) { oCModel.SY = (string)idr["SY"]; }
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
