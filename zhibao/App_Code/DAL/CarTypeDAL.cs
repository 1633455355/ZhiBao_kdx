using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// CarTypeDAL 的摘要说明
/// </summary>
public class CarTypeDAL
{
    /// <summary>
    ///   得到车型
    /// </summary>
    /// <param name="CarSystemCode"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<CarTypeModel> GetCarType(int? CarSystemCode, out int Count)
    {
        List<CarTypeModel> olist = new List<CarTypeModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Province_City_Car", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetType");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _ItemId = new SqlParameter("@ItemId", CarSystemCode == null ? (Object)DBNull.Value : CarSystemCode.Value);
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
                    CarTypeModel oCModel = new CarTypeModel();
                    if (idr["CarTypeCode"] != DBNull.Value) { oCModel.CarTypeCode = (int)idr["CarTypeCode"]; }
                    if (idr["CarTypeName"] != DBNull.Value) { oCModel.CarTypeName = (string)idr["CarTypeName"]; }
                    if (idr["CarSystemCode"] != DBNull.Value) { oCModel.CarSystemCode = (int)idr["CarSystemCode"]; }
                    if (idr["TY"] != DBNull.Value) { oCModel.TY = (string)idr["TY"]; }
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