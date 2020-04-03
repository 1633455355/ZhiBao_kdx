<%@ WebHandler Language="C#" Class="Admin" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Admin : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private AdminBLL ab = new AdminBLL();
    private OperLogBLL olb = new OperLogBLL();
    
    public void ProcessRequest (HttpContext context) {

        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "DeleteAdmin":
                    this.DeleteAdmin(context);
                    this.ResponseResult();
                    break;
                case "StoreList":
                    this.StoreList(context);
                    this.ResponseResult();
                    break;
                case "GetCityByProvince":
                    this.GetCityByProvince(context);
                    this.ResponseResult();
                    break;
                case "AdminAdd":
                    this.AdminAdd(context);
                    this.ResponseResult();
                    break;
                case "GetDealerList":
                    this.GetDealerList(context);
                    break;
                case "PwdRet":
                    this.PwdRet(context);
                    this.ResponseResult();
                    break;
                case "AdminUpdate":
                    this.AdminUpdate(context);
                    this.ResponseResult();
                    break;
                case "SearchAdmin":
                    this.SearchAdmin(context);
                    break;
                case "PasswordChange":
                    this.PasswordChange(context);
                    this.ResponseResult();
                    break;
                case "ProfileUpdate":
                    this.ProfileUpdate(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void DeleteAdmin(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Admin, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    if (ab.RemoveAdmin(Convert.ToInt32(context.Request["ID"]),0).Equals(Config.Success))
                    {
                        errorCode = 0;
                        AdminModel user = Common.GetLoginAdmin(context);
                        olb.AddOperLog(user.AdminId, "删除用户", "用户ＩＤ："+context.Request["ID"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteAdmin", ex);
                }

            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void StoreList(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<AdminModel> list = new List<AdminModel>();

        int page = int.Parse(context.Request["Page"]) + 1;
        int item = int.Parse(context.Request["Item"]);

        if (user.Type==AdminType.Dealer)
        {
            try
            {
                ab.GetAdminList(page, item, null, null, AdminType.Stores, null, null, user.AdminId, out total, out list);
                olb.AddOperLog(user.AdminId, "获取门店列表", "");
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("StoreList", ex);
            }
            
        }

        errorCode = 0;

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void ProfileUpdate(HttpContext context)
    {
        string name = HttpUtility.UrlDecode(context.Request["Name"]);
        string contact = HttpUtility.UrlDecode(context.Request["Contact"]);
        string position = HttpUtility.UrlDecode(context.Request["Position"]);
        string phone = HttpUtility.UrlDecode(context.Request["Phone"]);
        string mobile = HttpUtility.UrlDecode(context.Request["Mobile"]);
        string fax = HttpUtility.UrlDecode(context.Request["Fax"]);
        string province = HttpUtility.UrlDecode(context.Request["Province"]);
        string city = HttpUtility.UrlDecode(context.Request["City"]);
        string address = HttpUtility.UrlDecode(context.Request["Address"]);
        string zip = HttpUtility.UrlDecode(context.Request["Zip"]);
        string email = HttpUtility.UrlDecode(context.Request["Email"]);

        AdminModel am = Common.GetLoginAdmin(context);
        if (am != null)
        {
            if (am.Type == AdminType.Dealer)
            {
                am.Dealer.DealerCompanyName = !string.IsNullOrWhiteSpace(name) ? name : string.Empty;
                am.Dealer.Contacts = !string.IsNullOrWhiteSpace(contact) ? contact : string.Empty;
                am.Dealer.Position = !string.IsNullOrWhiteSpace(position) ? position : string.Empty;
                am.Dealer.Phone = !string.IsNullOrWhiteSpace(phone) ? phone : string.Empty;
                am.Dealer.Mobile = !string.IsNullOrWhiteSpace(mobile) ? mobile : string.Empty;
                am.Dealer.Fax = !string.IsNullOrWhiteSpace(fax) ? fax : string.Empty;
                am.Dealer.ProvinceId = !string.IsNullOrWhiteSpace(province) ? Convert.ToInt32(province) : 0;
                am.Dealer.CityId = !string.IsNullOrWhiteSpace(city) ? Convert.ToInt32(city) : 0;
                am.Dealer.Address = !string.IsNullOrWhiteSpace(address) ? address : string.Empty;
                am.Dealer.Zip = !string.IsNullOrWhiteSpace(zip) ? zip : string.Empty;
                am.Dealer.Email = !string.IsNullOrWhiteSpace(email) ? email : string.Empty;
            }
            else if (am.Type == AdminType.Stores)
            {
                am.Store.StoreName = !string.IsNullOrWhiteSpace(name) ? name : string.Empty;
                am.Store.Contacts = !string.IsNullOrWhiteSpace(contact) ? contact : string.Empty;
                am.Store.Position = !string.IsNullOrWhiteSpace(position) ? position : string.Empty;
                am.Store.Phone = !string.IsNullOrWhiteSpace(phone) ? phone : string.Empty;
                am.Store.Mobile = !string.IsNullOrWhiteSpace(mobile) ? mobile : string.Empty;
                am.Store.Fax = !string.IsNullOrWhiteSpace(fax) ? fax : string.Empty;
                am.Store.ProvinceId = string.IsNullOrWhiteSpace(province) ? 0 : Convert.ToInt32(province);
                am.Store.CityId = string.IsNullOrWhiteSpace(city) ? 0 : Convert.ToInt32(city);
                am.Store.Address = !string.IsNullOrWhiteSpace(address) ? address : string.Empty;
                am.Store.Zip = !string.IsNullOrWhiteSpace(zip) ? zip : string.Empty;
                am.Store.Email = !string.IsNullOrWhiteSpace(email) ? email : string.Empty;
            }

            try
            {
                if (ab.SetAdmin(am).Equals(Config.Success))
                {
                    errorCode = 0;
                    Common.ClearSessinAdminInfro(context);

                    olb.AddOperLog(am.AdminId, "更新用户信息", "");
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("ProfileUpdate",ex);
            }
            
        } 
    }
    private void PasswordChange(HttpContext context)
    {
         if(!string.IsNullOrWhiteSpace(context.Request["Old"]) && !string.IsNullOrWhiteSpace(context.Request["New"]) && !string.IsNullOrWhiteSpace(context.Request["Con"]))
         {
             string oldpwd = HttpUtility.UrlDecode(context.Request["Old"]);
             string newpwd = HttpUtility.UrlDecode(context.Request["New"]);
             string compwd = HttpUtility.UrlDecode(context.Request["Con"]);

             AdminModel model = Common.GetLoginAdmin(context);
             if(model!=null)
             {
                 if (MD5.SetMD5(oldpwd).Equals(model.AdminPassword))
                 {
                     //model.AdminPassword = oldpwd;
                     try
                     {
                         string result = ab.SetAdminPassword(model, newpwd);
                         if (result.Equals(Config.Success))
                         {
                             errorCode = 0;
                             Common.ClearSessinAdminInfro(context);
                             olb.AddOperLog(model.AdminId, "修改密码", "");
                         }
                         else if (result.Equals("-2"))
                         {
                             errorCode = -2;
                         }
                     }
                     catch (Exception ex)
                     {
                         WriteLog.WriteExceptionLog("PasswordChange", ex);
                     }
                 }
                 else
                 {
                     errorCode = -2;
                 }
                 
             }
         }
    }
    private void SearchAdmin(HttpContext context)
    {
        int total = 0;
        List<AdminModel> list = new List<AdminModel>();
        
        if (Common.CheckPermission(Common.Module_Admin, Common.Permission_View, context))
        {
            int page = int.Parse(context.Request["Page"]) + 1;
            int item = int.Parse(context.Request["Item"]);

            string username = HttpUtility.UrlDecode(context.Request["Username"]);
            string relastion = HttpUtility.UrlDecode(context.Request["Relastion"]);
            string role = HttpUtility.UrlDecode(context.Request["Role"]);
            string name = HttpUtility.UrlDecode(context.Request["Name"]);
            string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);

            int? roleId = null;
            if (!string.IsNullOrWhiteSpace(role))
            {
                roleId = int.Parse(role);
            }

            int? dealerid = null;
            if (!string.IsNullOrWhiteSpace(dealer))
            {
                dealerid = int.Parse(dealer);
            }
            try
            {
                if (relastion.Equals("admin"))
                {
                    ab.GetAdminList(page, item, null, username, AdminType.Managers, roleId, null, null, out total, out list);
                }
                else if (relastion.Equals("dealer"))
                {
                    ab.GetAdminList(page, item, null, username, AdminType.Dealer, roleId, name, null, out total, out list);
                }
                else if (relastion.Equals("store"))
                {
                    ab.GetAdminList(page, item, null, username, AdminType.Stores, roleId, name, dealerid, out total, out list);
                }

                errorCode = 0;

                AdminModel user = Common.GetLoginAdmin(context);
                olb.AddOperLog(user.AdminId, "搜索用户", "");
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("SearchAdmin",ex);
            }
        }
        else
        {
            errorCode = -10; 
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
        
        
    }
    private void AdminUpdate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Admin, Common.Permission_Add, context))
        {
            string id = HttpUtility.UrlDecode(context.Request["ID"]);

            string role = HttpUtility.UrlDecode(context.Request["Role"]);
            string name = HttpUtility.UrlDecode(context.Request["Name"]);
            string contact = HttpUtility.UrlDecode(context.Request["Contact"]);
            string position = HttpUtility.UrlDecode(context.Request["Position"]);
            string phone = HttpUtility.UrlDecode(context.Request["Phone"]);
            string mobile = HttpUtility.UrlDecode(context.Request["Mobile"]);
            string fax = HttpUtility.UrlDecode(context.Request["Fax"]);
            string province = HttpUtility.UrlDecode(context.Request["Province"]);
            string city = HttpUtility.UrlDecode(context.Request["City"]);
            if (city == "null")
            {
                city = ""; 
            }
            string address = HttpUtility.UrlDecode(context.Request["Address"]);
            string zip = HttpUtility.UrlDecode(context.Request["Zip"]);
            string email = HttpUtility.UrlDecode(context.Request["Email"]);
            string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);

            List<AdminModel> list = new List<AdminModel>();
            int count = 0;
            try 
            { 
                ab.GetAdminList(1, 1, Convert.ToInt32(id), null, null, null, null, null, out count, out list);
                if (list.Count > 0)
                {
                    AdminModel am = list[0];
                    am.RoleId = Convert.ToInt32(role);
                    if (am.Type == AdminType.Managers)
                    {

                    }
                    else if (am.Type == AdminType.Dealer)
                    {
                        am.Dealer.DealerCompanyName = !string.IsNullOrWhiteSpace(name) ? name : string.Empty;
                        am.Dealer.Contacts = !string.IsNullOrWhiteSpace(contact) ? contact : string.Empty;
                        am.Dealer.Position = !string.IsNullOrWhiteSpace(position) ? position : string.Empty;
                        am.Dealer.Phone = !string.IsNullOrWhiteSpace(phone) ? phone : string.Empty;
                        am.Dealer.Mobile = !string.IsNullOrWhiteSpace(mobile) ? mobile : string.Empty;
                        am.Dealer.Fax = !string.IsNullOrWhiteSpace(fax) ? fax : string.Empty;
                        am.Dealer.ProvinceId = !string.IsNullOrWhiteSpace(province) ? Convert.ToInt32(province) : 0;
                        am.Dealer.CityId = !string.IsNullOrWhiteSpace(city) ? Convert.ToInt32(city) : 0;
                        am.Dealer.Address = !string.IsNullOrWhiteSpace(address) ? address : string.Empty;
                        am.Dealer.Zip = !string.IsNullOrWhiteSpace(zip) ? zip : string.Empty;
                        am.Dealer.Email = !string.IsNullOrWhiteSpace(email) ? email : string.Empty;
                    }
                    else if (am.Type == AdminType.Stores)
                    {
                        am.Store.StoreName = !string.IsNullOrWhiteSpace(name) ? name : string.Empty;
                        am.Store.Contacts = !string.IsNullOrWhiteSpace(contact) ? contact : string.Empty;
                        am.Store.Position = !string.IsNullOrWhiteSpace(position) ? position : string.Empty;
                        am.Store.Phone = !string.IsNullOrWhiteSpace(phone) ? phone : string.Empty;
                        am.Store.Mobile = !string.IsNullOrWhiteSpace(mobile) ? mobile : string.Empty;
                        am.Store.Fax = !string.IsNullOrWhiteSpace(fax) ? fax : string.Empty;
                        am.Store.ProvinceId = !string.IsNullOrWhiteSpace(province) ? Convert.ToInt32(province) : 0;
                        am.Store.CityId = !string.IsNullOrWhiteSpace(city) ? Convert.ToInt32(city) : 0;
                        am.Store.Address = !string.IsNullOrWhiteSpace(address) ? address : string.Empty;
                        am.Store.Zip = !string.IsNullOrWhiteSpace(zip) ? zip : string.Empty;
                        am.Store.Email = !string.IsNullOrWhiteSpace(email) ? email : string.Empty;
                        am.Store.DealerId = !string.IsNullOrWhiteSpace(dealer) ?  Convert.ToInt32(dealer):0;
                    }

                    if (ab.SetAdmin(am).Equals(Config.Success))
                    {
                        errorCode = 0;

                        AdminModel user = Common.GetLoginAdmin(context);
                        olb.AddOperLog(user.AdminId, "更新用户", "用户ＩＤ：" + context.Request["ID"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("AdminUpdate",ex);
            }
        }
        else
        {
            errorCode = -10; 
        }
    }
    private void PwdRet(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Admin, Common.Permission_Update, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["ID"]))
            {
                string id = HttpUtility.UrlDecode(context.Request["id"]);
                List<AdminModel> list = new List<AdminModel>();
                int count = 0;
                try
                {
                    ab.GetAdminList(1, 1, Convert.ToInt32(id), null, null, null, null, null, out count, out list);
                    if (list.Count > 0)
                    {
                        AdminModel model = list[0];
                        if (ab.SetAdminPassword(model, "111111").Equals(Config.Success))
                        {
                            errorCode = 0;

                            AdminModel user = Common.GetLoginAdmin(context);
                            olb.AddOperLog(user.AdminId, "密码重置", "用户ＩＤ：" + context.Request["ID"].ToString());
                        }
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("PwdRet",ex);
                }
            }
        }
        else
        {
            errorCode = -10; 
        }
    }
    private void GetDealerList(HttpContext contex)
    {
        int total = 0;
        List<DealerModel> list = new List<DealerModel>();
        try
        {
            list = Common.GetDealerList(out total);
            errorCode = 0;

            AdminModel user = Common.GetLoginAdmin(contex);
            olb.AddOperLog(user.AdminId, "获取经销商列表", "");
        }
        catch(Exception ex)
        {
            WriteLog.WriteExceptionLog("GetDealerList", ex);
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void AdminAdd(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Admin, Common.Permission_Add, context))
        {
            string username = HttpUtility.UrlDecode(context.Request["Username"]);
            string pawwsord = HttpUtility.UrlDecode(context.Request["Password"]);
            string relastion = HttpUtility.UrlDecode(context.Request["Relastion"]);
            string role = HttpUtility.UrlDecode(context.Request["Role"]);
            string name = HttpUtility.UrlDecode(context.Request["Name"]);
            string contact = HttpUtility.UrlDecode(context.Request["Contact"]);
            string position = HttpUtility.UrlDecode(context.Request["Position"]);
            string phone = HttpUtility.UrlDecode(context.Request["Phone"]);
            string mobile = HttpUtility.UrlDecode(context.Request["Mobile"]);
            string fax = HttpUtility.UrlDecode(context.Request["Fax"]);
            string province = HttpUtility.UrlDecode(context.Request["Province"]);
            string city = HttpUtility.UrlDecode(context.Request["City"]);
            string address = HttpUtility.UrlDecode(context.Request["Address"]);
            string zip = HttpUtility.UrlDecode(context.Request["Zip"]);
            string email = HttpUtility.UrlDecode(context.Request["Email"]);
            string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);

            AdminModel am = new AdminModel();
            am.AdminName = username;
            am.AdminPassword = pawwsord;
            if (relastion.Equals("admin"))
            {
                am.Type = AdminType.Managers;
            }
            else if (relastion.Equals("dealer"))
            {
                am.Type = AdminType.Dealer;
                DealerModel dm = new DealerModel();
                dm.DealerCompanyName = name;
                dm.Contacts = contact;
                dm.Position = position;
                dm.Phone = phone;
                dm.Mobile = mobile;
                dm.Fax = fax;
                dm.ProvinceId = (province != "null" && !string.IsNullOrWhiteSpace(province)) ? Convert.ToInt32(province) : 0;
                dm.CityId = (city != "null" && !string.IsNullOrWhiteSpace(city)) ? Convert.ToInt32(city) : 0;
                dm.Address = address;
                dm.Zip = zip;
                dm.Email = email;
                am.Dealer = dm;
            }
            else if (relastion.Equals("store"))
            {
                am.Type = AdminType.Stores;
                StoreModel sm = new StoreModel();
                sm.StoreName = name;
                sm.Contacts = contact;
                sm.Position = position;
                sm.Phone = phone;
                sm.Mobile = mobile;
                sm.Fax = fax;
                sm.ProvinceId = (province != "null" && !string.IsNullOrWhiteSpace(province)) ? Convert.ToInt32(province) : 0;
                sm.CityId = (city != "null" && !string.IsNullOrWhiteSpace(city)) ? Convert.ToInt32(city) : 0;
                sm.Address = address;
                sm.Zip = zip;
                sm.Email = email;
                sm.DealerId = (dealer != "null" && !string.IsNullOrWhiteSpace(dealer)) ? Convert.ToInt32(dealer) : 0;
                am.Store = sm;
            }

            am.RoleId = Convert.ToInt32(role);
            am.CreatorId = user.AdminId;
            int aid = 0;
            try 
            {
                ab.AddAdmin(am, out aid);
                if (aid > 0)
                {
                    errorCode = 0;

                    olb.AddOperLog(user.AdminId, "新增用户", "用户ＩＤ" + aid);
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("AdminAdd",ex);
            }
        }
        else
        {
            errorCode = -10; 
        }
    }
    private void GetCityByProvince(HttpContext context)
    {
        int total=0;
        List<CityModel> list=new List<CityModel>();
        if(!string.IsNullOrWhiteSpace(context.Request["ProvinceID"]))
        {
            Province_City_CarBLL pcc = new Province_City_CarBLL();
            try
            {
                pcc.GetCityList(Convert.ToInt32(context.Request["ProvinceID"]), out total, out list);
                errorCode = 0;
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("GetCityByProvince", ex);
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
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