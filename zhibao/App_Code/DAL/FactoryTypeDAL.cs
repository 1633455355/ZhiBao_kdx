using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// FactoryTypeDAL 的摘要说明
/// </summary>
public class FactoryTypeDAL
{
	public FactoryTypeDAL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 添加厂家类别
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string AddFactoryTypeInfo(string FactoryTypeName, string ProductSecondLevelNameDefalut,int CreatorId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _FactoryTypeName = new SqlParameter("@FactoryTypeName", FactoryTypeName);
        _FactoryTypeName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeName);

        SqlParameter _ProductSecondLevelNameDefalute = new SqlParameter("@ProductSecondLevelNameDefalut", ProductSecondLevelNameDefalut);
        _ProductSecondLevelNameDefalute.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelNameDefalute);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_FactoryTypeInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 更新厂家类别
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string SetFactoryTypeInfo(string FactoryTypeName,string ProductSecondLevelNameDefalut,int FactoryTypeId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", FactoryTypeId);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _FactoryTypeName = new SqlParameter("@FactoryTypeName", FactoryTypeName);
        _FactoryTypeName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeName);

        SqlParameter _ProductSecondLevelNameDefalute = new SqlParameter("@ProductSecondLevelNameDefalut", ProductSecondLevelNameDefalut);
        _ProductSecondLevelNameDefalute.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelNameDefalute);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_FactoryTypeInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 删除厂家类别
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string RemoveFactoryTypeInfo(int FactoryTypeId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", FactoryTypeId);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _FactoryTypeName = new SqlParameter("@FactoryTypeName", (Object)DBNull.Value);
        _FactoryTypeName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeName);

        SqlParameter _ProductSecondLevelNameDefalute = new SqlParameter("@ProductSecondLevelNameDefalut", (Object)DBNull.Value);
        _ProductSecondLevelNameDefalute.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelNameDefalute);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_FactoryTypeInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 得到厂家类别
    /// </summary>
    /// <param name="FactoryTypeId"></param>
    /// <returns></returns>
    public List<FactoryTypeModel> GetFactoryTypeInfo(int? FactoryTypeId)
    {
        List<FactoryTypeModel> olist = new List<FactoryTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_FactoryTypeInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "Select");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", FactoryTypeId == null ? (Object)DBNull.Value : FactoryTypeId.Value);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FactoryTypeId);


        SqlParameter _FactoryTypeName = new SqlParameter("@FactoryTypeName", (Object)DBNull.Value);
        _FactoryTypeName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FactoryTypeName);


        SqlParameter _ProductSecondLevelNameDefalute = new SqlParameter("@ProductSecondLevelNameDefalut", (Object)DBNull.Value);
        _ProductSecondLevelNameDefalute.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelNameDefalute);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_result);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    FactoryTypeModel oCModel = new FactoryTypeModel();

                    if (idr["FactoryTypeId"] != DBNull.Value) { oCModel.FactoryTypeId = (int)idr["FactoryTypeId"]; }
                    if (idr["FactoryTypeName"] != DBNull.Value) { oCModel.FactoryTypeName = (string)idr["FactoryTypeName"]; }
                    if (idr["ProductSecondLevelNameDefalut"] != DBNull.Value) { oCModel.ProductSecondLevelNameDefalut = (string)idr["ProductSecondLevelNameDefalut"]; }
                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    olist.Add(oCModel);
                }
            }
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
    /// <summary>
    /// 得到厂家类别未被使用过的
    /// </summary>
    /// <returns></returns>
    public List<FactoryTypeModel> GetFactoryTypeInfoByNotUsed()
    {
        List<FactoryTypeModel> olist = new List<FactoryTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_FactoryTypeInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "Select");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId",(Object)DBNull.Value);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FactoryTypeId);


        SqlParameter _FactoryTypeName = new SqlParameter("@FactoryTypeName", (Object)DBNull.Value);
        _FactoryTypeName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FactoryTypeName);

        SqlParameter _ProductSecondLevelNameDefalute = new SqlParameter("@ProductSecondLevelNameDefalut", (Object)DBNull.Value);
        _ProductSecondLevelNameDefalute.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelNameDefalute);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_result);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    FactoryTypeModel oCModel = new FactoryTypeModel();

                    if (idr["FactoryTypeId"] != DBNull.Value) { oCModel.FactoryTypeId = (int)idr["FactoryTypeId"]; }
                    if (idr["FactoryTypeName"] != DBNull.Value) { oCModel.FactoryTypeName = (string)idr["FactoryTypeName"]; }
                    if (idr["ProductSecondLevelNameDefalut"] != DBNull.Value) { oCModel.ProductSecondLevelNameDefalut = (string)idr["ProductSecondLevelNameDefalut"]; }
                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    olist.Add(oCModel);
                }
            }
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