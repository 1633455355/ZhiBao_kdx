using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class AdminBLL
{

    private RoleDAL rd;
    private PermissionsDAL pd ;
    private AdminDAL ad ;
    private DealerBLL dd;
    private StoreBLL sd;
  
    public AdminBLL()
    {
         rd = new RoleDAL();
         pd = new PermissionsDAL();
         ad = new AdminDAL();
         dd = new DealerBLL();
         sd = new StoreBLL();
    }
    /// <summary>
    /// 添加角色信息
    /// </summary>
    /// <param name="oRModel"></param>
    /// <returns></returns>
    public string AddRole(RoleModel oRModel,out int RoleId)
    {
        string ret =Config.Fail;
        RoleId = 0;
        try
        {
            ret = rd.AddRole(oRModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0) {
                RoleId = Id;
                if (oRModel.Permissions != null) {
                    
                    foreach (PermissionsModel o in oRModel.Permissions) {
                        pd.AddPermissionRelation(RoleId, o.ModuleKey, o.PermissionsId, oRModel.CreatorId);
                    }
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AddRole()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新角色信息
    /// </summary>
    /// <param name="oRModel"></param>
    /// <returns></returns>
    public string SetRole(RoleModel oRModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = rd.SetRole(oRModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                if (oRModel.Permissions != null&&oRModel.Permissions.Count>0) {

                    pd.RemovePermissionRelation(oRModel.RoleId);
                    foreach (PermissionsModel o in oRModel.Permissions) {
                        pd.AddPermissionRelation(oRModel.RoleId, o.ModuleKey, o.PermissionsId, oRModel.CreatorId);
                    }
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.SetRole()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

        /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <returns></returns>
    public string RemoveRole(int RoleId)
    {
        string ret = Config.Fail;
        try
        {
            ret = rd.RemoveRole(RoleId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0) {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.RemoveRole()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 得到角色列表
    /// </summary>
    /// <param name="RoleId"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetRoleList(int? RoleId,out List<RoleModel> olist)
    {
        olist = null;
        string ret = Config.Fail;
        try
        {
            olist = rd.GetRoleList(RoleId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.GetRoleList()", ex);
            return Config.ExceptionMsg;
        }
    }

        /// <summary>
    /// 添加权限
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <param name="ModuleKey"></param>
    /// <param name="PermissionKey"></param>
    /// <returns></returns>
    public string AddPermissionRelation(int RoleId,int CreatorId, List<PermissionsModel> oPModel, out int AManagementId)
    {
        string ret = Config.Fail;
        AManagementId = 0;
        try
        {
            if (oPModel != null)
            {
                foreach (PermissionsModel o in oPModel)
                {
                    ret = pd.AddPermissionRelation(RoleId, o.ModuleKey, o.PermissionsId, CreatorId);
                }
                bool flag = Int32.TryParse(ret, out AManagementId);
                if (flag && AManagementId > 0)
                {
                    return Config.Success;
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AddPermissionRelation()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新权限
    /// </summary>
    /// <param name="RoleId"></param>
    /// <param name="CreatorId"></param>
    /// <param name="oPModel"></param>
    /// <param name="AManagementId"></param>
    /// <returns></returns>
    public string SetPermissonRelation(int RoleId,int CreatorId, List<PermissionsModel> oPModel)
    {
        string ret = Config.Fail;
        int AManagementId = 0;
        try
        {
            if (oPModel != null&&oPModel.Count>0)
            {
                pd.RemovePermissionRelation(RoleId);
                foreach (PermissionsModel o in oPModel)
                {
                    ret = pd.AddPermissionRelation(RoleId, o.ModuleKey, o.PermissionsId, CreatorId);
                }
                bool flag = Int32.TryParse(ret, out AManagementId);
                if (flag && AManagementId > 0)
                {
                    return Config.Success;
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.SetPermissonRelation()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 删除权限
    /// </summary>
    /// <param name="RoleId"></param>
    /// <returns></returns>
    public string RemovePermissionRelation(int RoleId)
    {
        string ret = Config.Fail;
        RoleId = 0;
        try
        {
            ret = pd.RemovePermissionRelation(RoleId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.RemovePermissionRelation()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
        /// <summary>
    /// 得到模块列表
    /// </summary>
    /// <param name="ModuleKey"></param>
    /// <returns></returns>
    public string GetModuleList(string ModuleKey,List<PermissionsModel> olist)
    {
        olist = null;
        string ret = Config.Fail;
        try
        {
            olist = pd.GetModuleList(ModuleKey);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.GetModuleList()", ex);
            return Config.ExceptionMsg;
        }
    }
        /// <summary>
    /// 得到权限列表
    /// </summary>
    /// <param name="PermissonKey"></param>
    /// <returns></returns>
    public string GetPermissonList(int? PermissonId,out List<PermissionsModel> olist)
    {
        olist = null;
        string ret = Config.Fail;
        try
        {
            olist = pd.GetPermissonList(PermissonId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.GetPermissonList()", ex);
            return Config.ExceptionMsg;
        }
    }

    /// <summary>
    /// 得到角色模块上的所有权限
    /// </summary>
    /// <param name="RoleKey"></param>
    /// <returns></returns>
    public string  GetRoleModulePermission(int RoleId,out List<PermissionsModel> olist )
    {
        olist = null;
        string ret = Config.Fail;
        try
        {
            olist = pd.GetRoleModulePermission(RoleId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.GetRoleModulePermission()", ex);
            return Config.ExceptionMsg;
        }
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string AddAdmin(AdminModel oAModel,out int AdminId)
    {
        string ret = Config.Fail;
        AdminId = 0;
        try
        {
            ret = ad.AddAdmin(oAModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                AdminId = Id;
                if (oAModel.Type==AdminType.Dealer&&oAModel.Dealer!=null)
                {
                    oAModel.Dealer.AdminId = AdminId;
                    dd.AddDealerInfo(oAModel.Dealer);
                }
                if (oAModel.Type == AdminType.Stores && oAModel.Store != null)
                {
                    oAModel.Store.AdminId = AdminId;
                    sd.AddStoreInfo(oAModel.Store);
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AddAdmin()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 更新用户密码
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string SetAdminPassword(AdminModel oAModel,string NewsPassword)
    {
        string ret = Config.Fail;
        try
        {
            AdminModel o = oAModel;
            //o.AdminPassword = MD5.SetMD5(oAModel.AdminPassword);
            ret = ad.SetAdminPassword(o, NewsPassword);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.SetAdminPassword()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新用户信息
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string SetAdmin(AdminModel oAModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = ad.SetAdmin(oAModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                if(oAModel.Dealer!=null)
                {
                    DealerBLL db = new DealerBLL();
                    db.SetDealerInfo(oAModel.Dealer);
                }
                if(oAModel.Store!=null)
                {
                    StoreBLL sb = new StoreBLL();
                    sb.SetStoreInfo(oAModel.Store);
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.SetAdmin()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="AdminName"></param>
    /// <param name="AdminPassword"></param>
    /// <returns></returns>
    public string RemoveAdmin(int AdminId,int status)
    {
        string ret = Config.Fail;
        try
        {
            ret = ad.RemoveAdmin(AdminId, status);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.RemoveAdmin()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 管理员登录
    /// </summary>
    /// <param name="Admin"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public bool AdminLogin(string AdminName, string AdminPassword, out AdminModel oAModel)
    {
        bool IsLogin = false;
        oAModel = null;
        try
        {
            oAModel = ad.AdminLogin(AdminName, AdminPassword);
            if (oAModel != null)
            {
                List<RoleModel> oRModel = rd.GetRoleList(oAModel.RoleId);
                if (oRModel != null && oRModel.Count>0)
                {
                    oAModel.Role = oRModel[0];
                }
                IsLogin = true;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AdminLogin()", ex);
        }
        return IsLogin;
    }
        /// <summary>
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetAdminList(int PageIndex, int PageNum, int? AdminId, string AdminName, AdminType? Type,int? RoleId,string ItemName,int? DealerId,out int Count, out List<AdminModel> olist)
    {
        olist = new List<AdminModel>();
        Count=0;
        string where = " 1=1";
        if (AdminId!=null) {
            where+= " and AdminInfo.AdminId=" + AdminId.Value;
        }
        if(!String.IsNullOrEmpty(AdminName)) {
            where+= " and AdminInfo.AdminName like '%" + AdminName + "%'";
        }
        if(Type!=null){
            where += " and AdminInfo.Type=" + (int)Type.Value;
            if (Type.Value == AdminType.Dealer){
                if (!String.IsNullOrEmpty(ItemName)) {
                    where += " and AdminInfo.AdminId in( select AdminId from DealerInfo where DealerCompanyName like '%" + ItemName + "%')";
                }
            }
            if(Type.Value==AdminType.Stores) {
                if (!String.IsNullOrEmpty(ItemName)) {
                    where += " and AdminInfo.AdminId in( select AdminId from StoreInfo where StoreName like '%" + ItemName + "%')";
                }
                if(DealerId!=null) {
                    where += " and AdminInfo.AdminId in( select AdminId from StoreInfo where DealerId=" + DealerId + ")";
                }
            }
        }
        if(RoleId!=null) {
            where += " and AdminInfo.RoleId=" + RoleId.Value;
        } 
        try
        {
            olist = ad.GetAdminList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch(Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.GetAdminList()", ex);
            return Config.ExceptionMsg;
        }
    }
    public string AddLoginInfo(string Ip)
    {
        string ret = Config.Fail;
        try
        {
            ret = ad.AddLoginInfo(Ip);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AddLoginInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    public string GetLoginInfo(string Ip)
    {
        string ret = Config.Fail;
        try
        {
            int Id = 0;
            bool flag = Int32.TryParse(ad.GetLoginInfo(Ip), out Id);
            if (flag && Id > 2)
            {
                ret= Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AddLoginInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
}

