<%@ WebHandler Language="C#" Class="Role" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Role : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private AdminBLL ab = new AdminBLL();
    public void ProcessRequest (HttpContext context) {
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "GetRoleList":
                    this.GetRoleList(context);
                    break;
                case "RoleAdd":
                    this.RoleAdd(context);
                    this.ResponseResult();
                    break;
                case "RoleUpdate":
                    this.RoleUpdate(context);
                    this.ResponseResult();
                    break;
                case "DeleteRole":
                    this.DeleteRole(context);
                    this.ResponseResult();
                    break;
                case "GetRole":
                    this.GetRole(context);
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void RoleUpdate(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        
        if (Common.CheckPermission(Common.Module_Role, Common.Permission_Update, context))
        {
            try
            {
                List<RoleModel> list=new List<RoleModel>();
                if (!string.IsNullOrWhiteSpace(context.Request["ID"]))
                {
                    ab.GetRoleList(Convert.ToInt32(context.Request["ID"]), out list);
                    RoleModel role = list[0];
                    List<PermissionsModel> plist = new List<PermissionsModel>();
                    //消息
                    string XXGL = context.Request["XXGL"];
                    string[] XXGLlist = XXGL.Split(',');
                    foreach (string str in XXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "XXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //资讯
                    string ZXGL = context.Request["ZXGL"];
                    string[] ZXGLlist = ZXGL.Split(',');
                    foreach (string str in ZXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "ZXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //促销
                    string CXHDGL = context.Request["CXHDGL"];
                    string[] CXHDGLlist = CXHDGL.Split(',');
                    foreach (string str in CXHDGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "CXHDGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //用户
                    string YHGL = context.Request["YHGL"];
                    string[] YHGLlist = YHGL.Split(',');
                    foreach (string str in YHGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "YHGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }


                    //反馈
                    string FKXXGL = context.Request["FKXXGL"];
                    string[] FKXXGLlist = FKXXGL.Split(',');
                    foreach (string str in FKXXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "FKXXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //角色
                    string QXGL = context.Request["QXGL"];
                    string[] QXGLlist = QXGL.Split(',');
                    foreach (string str in QXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "QXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //车型管理
                    string CXGL = context.Request["CXGL"];
                    string[] CXGLlist = CXGL.Split(',');
                    foreach (string str in CXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "CXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //产品管理
                    string CPDMGL = context.Request["CPDMGL"];
                    string[] CPDMGLlist = CPDMGL.Split(',');
                    foreach (string str in CPDMGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "CPDMGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }


                    //工厂产品类型管理
                    string GCCPLXGL = context.Request["GCCPLXGL"];
                    string[] GCCPLXGLlist = GCCPLXGL.Split(',');
                    foreach (string str in GCCPLXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "GCCPLXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }
                    
                    //报表管理
                    string TJBBGL = context.Request["TJBBGL"];
                    string[] TJBBGLlist = TJBBGL.Split(',');
                    foreach (string str in TJBBGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "TJBBGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //客户管理
                    string KHGL = context.Request["KHGL"];
                    string[] KHGLlist = KHGL.Split(',');
                    foreach (string str in KHGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "KHGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //产品类型管理
                    string CPLXGL = context.Request["CPLXGL"];
                    string[] CPLXGLlist = CPLXGL.Split(',');
                    foreach (string str in CPLXGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "CPLXGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    //产品认证管理
                    string CPRZGL = context.Request["CPRZGL"];
                    string[] CPRZGLlist = CPRZGL.Split(',');
                    foreach (string str in CPRZGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "CPRZGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }
                    //理赔管理
                    string LPGL = context.Request["LPGL"];
                    string[] LPGLlist = LPGL.Split(',');
                    foreach (string str in LPGLlist)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            PermissionsModel pmmodel = new PermissionsModel();
                            pmmodel.ModuleKey = "LPGL";
                            pmmodel.PermissionsId = Convert.ToInt32(str);
                            plist.Add(pmmodel);
                        }
                    }

                    role.Permissions = plist;
                    role.RoleName = context.Request["Title"];

                    if (ab.SetRole(role).Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("RoleUpdate",ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetRole(HttpContext context)
    {   
        List<RoleModel> list = new List<RoleModel>();
        if (Common.CheckPermission(Common.Module_Role, Common.Permission_View, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    ab.GetRoleList(Convert.ToInt32(context.Request["ID"]), out list);
                    errorCode = 0;
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("GetRole", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void DeleteRole(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Role, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    if (ab.RemoveRole(Convert.ToInt32(context.Request["ID"])).Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteRole", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetRoleList(HttpContext context)
    {
        List<RoleModel> list = new List<RoleModel>();
        if (Common.CheckPermission(Common.Module_Role, Common.Permission_View, context))
        {
            try
            {
                ab.GetRoleList(null, out list);
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetRoleList", ex);
            }
        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);
        
        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void RoleAdd(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Role, Common.Permission_Add, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);
            RoleModel rm = new RoleModel();
            List<PermissionsModel> plist = new List<PermissionsModel>();

            try
            {


                //消息
                string XXGL = context.Request["XXGL"];
                string[] XXGLlist = XXGL.Split(',');
                foreach (string str in XXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "XXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //资讯
                string ZXGL = context.Request["ZXGL"];
                string[] ZXGLlist = ZXGL.Split(',');
                foreach (string str in ZXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "ZXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //促销
                string CXHDGL = context.Request["CXHDGL"];
                string[] CXHDGLlist = CXHDGL.Split(',');
                foreach (string str in CXHDGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "CXHDGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //用户
                string YHGL = context.Request["YHGL"];
                string[] YHGLlist = YHGL.Split(',');
                foreach (string str in YHGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "YHGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }


                //反馈
                string FKXXGL = context.Request["FKXXGL"];
                string[] FKXXGLlist = FKXXGL.Split(',');
                foreach (string str in FKXXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "FKXXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //角色
                string QXGL = context.Request["QXGL"];
                string[] QXGLlist = QXGL.Split(',');
                foreach (string str in QXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "QXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //车型管理
                string CXGL = context.Request["CXGL"];
                string[] CXGLlist = CXGL.Split(',');
                foreach (string str in CXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "CXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //产品管理
                string CPDMGL = context.Request["CPDMGL"];
                string[] CPDMGLlist = CPDMGL.Split(',');
                foreach (string str in CPDMGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "CPDMGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //报表管理
                string TJBBGL = context.Request["TJBBGL"];
                string[] TJBBGLlist = TJBBGL.Split(',');
                foreach (string str in TJBBGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "TJBBGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //客户管理
                string KHGL = context.Request["KHGL"];
                string[] KHGLlist = KHGL.Split(',');
                foreach (string str in KHGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "KHGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //产品类型管理
                string CPLXGL = context.Request["CPLXGL"];
                string[] CPLXGLlist = CPLXGL.Split(',');
                foreach (string str in CPLXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "CPLXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }


                //工厂产品类型管理
                string GCCPLXGL = context.Request["GCCPLXGL"];
                string[] GCCPLXGLlist = GCCPLXGL.Split(',');
                foreach (string str in GCCPLXGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "GCCPLXGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }
                
                
                //产品认证管理
                string CPRZGL = context.Request["CPRZGL"];
                string[] CPRZGLlist = CPRZGL.Split(',');
                foreach (string str in CPRZGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "CPRZGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                //产品认证管理
                string LPGL = context.Request["LPGL"];
                string[] LPGLlist = LPGL.Split(',');
                foreach (string str in LPGLlist)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        PermissionsModel pmmodel = new PermissionsModel();
                        pmmodel.ModuleKey = "LPGL";
                        pmmodel.PermissionsId = Convert.ToInt32(str);
                        plist.Add(pmmodel);
                    }
                }

                rm.Permissions = plist;
                rm.CreatorId = user.AdminId;
                rm.RoleName = context.Request["Title"];
                int id = 0;
                ab.AddRole(rm, out id);
                if (id > 0)
                {
                    errorCode = 0;
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("RoleAdd", ex);
            }
        }
        else
        {
            errorCode = -10; 
        }
    }
    private void ResponseResult()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);
        sb.Append("\",\"returnmsg\":\"");
        sb.Append(returnMsg);
        sb.Append("\"}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}