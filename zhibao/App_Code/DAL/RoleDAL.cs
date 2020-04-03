using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class RoleDAL
{
    /// <summary>
    /// 添加角色信息
    /// </summary>
    /// <param name="oRModel"></param>
    /// <returns></returns>
    public string AddRole(RoleModel oRModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _RoleKey = new SqlParameter("@RoleId", (Object)DBNull.Value);
        _RoleKey.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleKey);

        SqlParameter _RoleName = new SqlParameter("@RoleName", oRModel.RoleName == null ? (Object)DBNull.Value : oRModel.RoleName);
        _RoleName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleName);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oRModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_RoleInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 更新角色信息
    /// </summary>
    /// <param name="oRModel"></param>
    /// <returns></returns>
    public string SetRole(RoleModel oRModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _RoleKey = new SqlParameter("@RoleId", oRModel.RoleId);
        _RoleKey.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleKey);

        SqlParameter _RoleName = new SqlParameter("@RoleName", oRModel.RoleName == null ? (Object)DBNull.Value : oRModel.RoleName);
        _RoleName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleName);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oRModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_RoleInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <returns></returns>
    public string RemoveRole(int RoleKey)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _RoleKey = new SqlParameter("@RoleId", RoleKey);
        _RoleKey.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleKey);

        SqlParameter _RoleName = new SqlParameter("@RoleName",(Object)DBNull.Value);
        _RoleName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleName);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId",(Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_RoleInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    ///得到角色列表
    /// </summary>
    /// <returns></returns>
    public List<RoleModel> GetRoleList(int? RoleId)
    {
        List<RoleModel> oLRModel = new List<RoleModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_RoleInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "Get");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _RoleId = new SqlParameter("@RoleId",RoleId==null?(Object)DBNull.Value:RoleId.Value);
        _RoleId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_RoleId);

        SqlParameter _RoleName = new SqlParameter("@RoleName", (Object)DBNull.Value);
        _RoleName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_RoleName);



        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CreatorId);

         
        SqlParameter result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(result);

        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                PermissionsDAL pDal=new PermissionsDAL();
                while (idr.Read())
                {
                    RoleModel oRoleModel = new RoleModel();
                    oRoleModel.RoleId = (int)idr["RoleId"];
                    oRoleModel.RoleName = (string)idr["RoleName"];
                    oRoleModel.CreatorId = (int)idr["CreatorId"];
                    if (idr["AdminName"] != DBNull.Value) { oRoleModel.Creator = (string)idr["AdminName"]; };
                    oRoleModel.CreateTime = (DateTime)idr["CreateTime"];
                    oRoleModel.Permissions =pDal.GetRoleModulePermission(oRoleModel.RoleId);
                    oLRModel.Add(oRoleModel);
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
        return oLRModel;
    }
}

