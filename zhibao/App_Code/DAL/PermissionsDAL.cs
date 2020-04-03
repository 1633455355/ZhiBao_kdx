using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class PermissionsDAL
{
    /// <summary>
    /// 添加权限
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <param name="ModuleKey"></param>
    /// <param name="PermissionKey"></param>
    /// <returns></returns>
    public string AddPermissionRelation(int RoleId, string ModuleKey, int PermissionId, int CreatorId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _RoleId = new SqlParameter("@RoleId", RoleId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleId);



        SqlParameter _ModuleKey = new SqlParameter("@ModuleKey", ModuleKey);
        _ModuleKey.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ModuleKey);


        SqlParameter _PermissionsId = new SqlParameter("@PermissionsId", PermissionId);
        _PermissionsId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PermissionsId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_Permissions", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 删除角色权限
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <returns></returns>
    public string RemovePermissionRelation(int RoleId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _RoleId = new SqlParameter("@RoleId", RoleId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleId);



        SqlParameter _ModuleKey = new SqlParameter("@ModuleKey", (Object)DBNull.Value);
        _ModuleKey.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ModuleKey);


        SqlParameter _PermissionsId = new SqlParameter("@PermissionsId", (Object)DBNull.Value);
        _PermissionsId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PermissionsId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_Permissions", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 得到模块列表
    /// </summary>
    /// <param name="ModuleKey"></param>
    /// <returns></returns>
    public List<PermissionsModel> GetModuleList(string ModuleKey)
    {
        List<PermissionsModel> oLMPModel = new List<PermissionsModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Permissions", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetM");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _RoleId = new SqlParameter("@RoleId", (Object)DBNull.Value);
        _RoleId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_RoleId);

        SqlParameter _ModuleKey = new SqlParameter("@ModuleKey", ModuleKey == null ? (Object)DBNull.Value : ModuleKey);
        _ModuleKey.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ModuleKey);


        SqlParameter _PermissionsId = new SqlParameter("@PermissionsId", (Object)DBNull.Value);
        _PermissionsId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PermissionsId);

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
                while (idr.Read())
                {
                    PermissionsModel oMPModel = new PermissionsModel();
                    oMPModel.ModuleKey = (string)idr["ModuleKey"];
                    oMPModel.ModuleLink = (string)idr["ModuleLink"];
                    oMPModel.CreateTime = (DateTime)idr["CreateTime"];
                    oLMPModel.Add(oMPModel);
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
        return oLMPModel;
    }

    /// <summary>
    /// 得到权限列表
    /// </summary>
    /// <param name="PermissonKey"></param>
    /// <returns></returns>
    public List<PermissionsModel> GetPermissonList(int? PermissonId)
    {
        List<PermissionsModel> oLMPModel = new List<PermissionsModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Permissions", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetP");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _RoleId = new SqlParameter("@RoleId", (Object)DBNull.Value);
        _RoleId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_RoleId);

        SqlParameter _ModuleKey = new SqlParameter("@ModuleKey",(Object)DBNull.Value);
        _ModuleKey.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ModuleKey);


        SqlParameter _PermissionsId = new SqlParameter("@PermissionsId", PermissonId == null ? (Object)DBNull.Value : PermissonId.Value);
        _PermissionsId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PermissionsId);

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
                while (idr.Read())
                {
                    PermissionsModel oMPModel = new PermissionsModel();
                    oMPModel.PermissionsId = (int)idr["PermissionsId"];
                    oMPModel.PermissionsName = (string)idr["PermissionsName"];
                    oMPModel.CreateTime = (DateTime)idr["CreateTime"];
                    oLMPModel.Add(oMPModel);
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
        return oLMPModel;
    }
    /// <summary>
    /// 得到角色模块上的所有权限
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <returns></returns>
    public List<PermissionsModel> GetRoleModulePermission(int RoleId)
    {
        List<PermissionsModel> oLMPModel = new List<PermissionsModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Permissions", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetA");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _RoleId = new SqlParameter("@RoleId", RoleId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_RoleId);

        SqlParameter _ModuleKey = new SqlParameter("@ModuleKey", (Object)DBNull.Value);
        _ModuleKey.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ModuleKey);


        SqlParameter _PermissionsId = new SqlParameter("@PermissionsId", (Object)DBNull.Value);
        _PermissionsId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PermissionsId);

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
                while (idr.Read())
                {
                    PermissionsModel oMPModel = new PermissionsModel();
                    oMPModel.PermissionsId = (int)idr["PermissionsId"];
                    oMPModel.PermissionsName = (string)idr["PermissionsName"];
                    oMPModel.ModuleKey = (string)idr["ModuleKey"];
                    oMPModel.ModuleName = (string)idr["ModuleName"];
                    oMPModel.ModuleLink =  (idr["ModuleLink"]!=null && !string.IsNullOrWhiteSpace(idr["ModuleLink"].ToString()))?(string)idr["ModuleLink"]:string.Empty;
                    oMPModel.CreateTime = (DateTime)idr["CreateTime"];
                    oMPModel.CreatorId = (int)idr["CreatorId"];
                    oLMPModel.Add(oMPModel);
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
        return oLMPModel;
    }


      
}
