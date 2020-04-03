using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class AdminDAL
{
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string AddAdmin(AdminModel oAModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _AdminName = new SqlParameter("@AdminName", oAModel.AdminName == null ? (Object)DBNull.Value : oAModel.AdminName);
        _AdminName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminName);

        SqlParameter _AdminPassword = new SqlParameter("@AdminPassword", oAModel.AdminPassword == null ? (Object)DBNull.Value : MD5.SetMD5(oAModel.AdminPassword));
        _AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminPassword);

        SqlParameter _News_AdminPassword = new SqlParameter("@News_AdminPassword", (Object)DBNull.Value);
        _News_AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_News_AdminPassword);

        SqlParameter _Type = new SqlParameter("@Type",oAModel.Type);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _RoleId = new SqlParameter("@RoleId", oAModel.RoleId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oAModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_AdminInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 更新用户密码
    /// </summary>
    /// <param name="oAModel"></param>
    /// <param name="NewsPassword"></param>
    /// <returns></returns>
    public string SetAdminPassword(AdminModel oAModel,string NewsPassword)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _AdminName = new SqlParameter("@AdminName", oAModel.AdminName == null ? (Object)DBNull.Value : oAModel.AdminName);
        _AdminName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminName);

        SqlParameter _AdminPassword = new SqlParameter("@AdminPassword", oAModel.AdminPassword == null ? (Object)DBNull.Value : oAModel.AdminPassword);
        _AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminPassword);

        SqlParameter _News_AdminPassword = new SqlParameter("@News_AdminPassword", NewsPassword == null ? (Object)DBNull.Value :  MD5.SetMD5(NewsPassword));
        _News_AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_News_AdminPassword);

        SqlParameter _Type = new SqlParameter("@Type", (Object)DBNull.Value);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _RoleId = new SqlParameter("@RoleId", oAModel.RoleId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oAModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_AdminInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 更新用户数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <param name="NewsPassword"></param>
    /// <returns></returns>
    public string SetAdmin(AdminModel oAModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "UpPassword");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _AdminName = new SqlParameter("@AdminName", oAModel.AdminName == null ? (Object)DBNull.Value : oAModel.AdminName);
        _AdminName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminName);

        SqlParameter _AdminPassword = new SqlParameter("@AdminPassword", oAModel.AdminPassword == null ? (Object)DBNull.Value : oAModel.AdminPassword);
        _AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminPassword);

        SqlParameter _News_AdminPassword = new SqlParameter("@News_AdminPassword",(Object)DBNull.Value);
        _News_AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_News_AdminPassword);

        SqlParameter _Type = new SqlParameter("@Type", (Object)DBNull.Value);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _RoleId = new SqlParameter("@RoleId", oAModel.RoleId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oAModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_AdminInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="oAModel"></param>
    /// <param name="NewsPassword"></param>
    /// <returns></returns>
    public string RemoveAdmin(int AdminId, int status)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _AdminName = new SqlParameter("@AdminName", (Object)DBNull.Value);
        _AdminName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminName);

        SqlParameter _AdminPassword = new SqlParameter("@AdminPassword", (Object)DBNull.Value);
        _AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminPassword);

        SqlParameter _News_AdminPassword = new SqlParameter("@News_AdminPassword", (Object)DBNull.Value);
        _News_AdminPassword.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_News_AdminPassword);

        SqlParameter _Type = new SqlParameter("@Type", status);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _RoleId = new SqlParameter("@RoleId", AdminId);
        _RoleId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_RoleId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_AdminInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 登陆
    /// </summary>
    /// <param name="AdminName"></param>
    /// <param name="AdminPassword"></param>
    /// <returns></returns>
    public AdminModel AdminLogin(string AdminName, string AdminPassword)
    {
        AdminModel oAModel = null;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_AdminInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

          
        SqlParameter _op = new SqlParameter("@op", "Login");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);


        SqlParameter _AdminName = new SqlParameter("@AdminName", AdminName == null ? (Object)DBNull.Value : AdminName);
        _AdminName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AdminName);

        SqlParameter _AdminPassword = new SqlParameter("@AdminPassword", AdminPassword == null ? (Object)DBNull.Value : MD5.SetMD5(AdminPassword));
        _AdminPassword.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AdminPassword);

        SqlParameter _News_AdminPassword = new SqlParameter("@News_AdminPassword", (Object)DBNull.Value);
        _News_AdminPassword.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_News_AdminPassword);

        SqlParameter _Type = new SqlParameter("@Type", (Object)DBNull.Value);
        _Type.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Type);

        SqlParameter _RoleId = new SqlParameter("@RoleId", (Object)DBNull.Value);
        _RoleId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_RoleId);

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
                    oAModel = new AdminModel();
                    oAModel.AdminId = (int)idr["AdminId"];
                    oAModel.AdminName = (string)idr["AdminName"];
                    oAModel.AdminPassword = (string)idr["AdminPassword"];
                    oAModel.Type = (AdminType)idr["Type"];
                    oAModel.Status = (bool)idr["Status"];
                    oAModel.CreateTime = (DateTime)idr["CreateTime"];
                    oAModel.CreatorId = (int)idr["CreatorId"];
                    oAModel.RoleId = (int)idr["RoleId"];
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
        return oAModel;
    }
    /// <summary>
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<AdminModel> GetAdminList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<AdminModel> olist = new List<AdminModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_AdminList", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _PageIndex = new SqlParameter("@PageIndex", PageIndex);
        _PageIndex.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PageIndex);

        SqlParameter _PageNum = new SqlParameter("@PageNum", PageNum);
        _PageNum.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PageNum);

        SqlParameter _where = new SqlParameter("@where", where);
        _where.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_where);

        SqlParameter _Count = new SqlParameter("@Count", SqlDbType.Int);
        _Count.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_Count);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                DealerDAL dd=new DealerDAL();
                StoreDAL sd=new StoreDAL();
                PermissionsDAL pDal = new PermissionsDAL();
                while (idr.Read())
                {
                    AdminModel oCModel = new AdminModel();
                    if (idr["AdminId"] != DBNull.Value) { oCModel.AdminId = (int)idr["AdminId"]; }
                    if (idr["AdminName"] != DBNull.Value) { oCModel.AdminName = (string)idr["AdminName"]; }
                    if (idr["AdminPassword"] != DBNull.Value) { oCModel.AdminPassword = (string)idr["AdminPassword"]; }
                    if (idr["Type"] != DBNull.Value) { oCModel.Type = (AdminType)idr["Type"]; }
                    if (idr["RoleId"] != DBNull.Value) { oCModel.RoleId = (int)idr["RoleId"]; }
                    if (idr["Status"] != DBNull.Value) { oCModel.Status = (bool)idr["Status"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }

                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    int Totoal=0;
                    List<DealerModel> dModel = dd.GetDealerModelList(1,1,"DealerInfo.AdminId="+oCModel.AdminId,out Totoal);
                    if(dModel!=null &dModel.Count>0)
                    {
                        oCModel.Dealer=dModel[0];
                    }
                    List<StoreModel> oSMoel = sd.GetStoreModelList(1, 1, "StoreInfo.AdminId=" + oCModel.AdminId, out Totoal);
                    if(oSMoel!=null&oSMoel.Count>0)
                    {
                        oCModel.Store=oSMoel[0];
                    }
                    RoleModel role = new RoleModel();
                    if (idr["RoleId"] != DBNull.Value) { role.RoleId = (int)idr["RoleId"]; }
                    if (idr["RoleId"] != DBNull.Value) { role.RoleName = (string)idr["RoleName"]; }
                    if (idr["RoleId"] != DBNull.Value)
                    {
                        role.Permissions = pDal.GetRoleModulePermission(role.RoleId);
                    }
                    oCModel.Role = role;
                    olist.Add(oCModel);
                }
            }
            Count = int.Parse(_Count.Value.ToString());
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

    public string AddLoginInfo(string Ip)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Ip = new SqlParameter("@Ip", Ip);
        _Ip.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Ip);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_LoginInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    public string GetLoginInfo(string Ip)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Get");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Ip = new SqlParameter("@Ip", Ip);
        _Ip.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Ip);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_LoginInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
}

