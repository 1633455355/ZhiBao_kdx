<%@ WebHandler Language="C#" Class="mechanic" %>

using System;
using System.Web;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;

public class mechanic : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    public void ProcessRequest(HttpContext context)
    {
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "Add":
                    this.mechanicAdd(context);
                    this.ResponseResult();
                    break;
                case "Set":
                    this.Setmechanic(context);
                    this.ResponseResult();
                    break;
                case "Del":
                    this.Delmechanic(context);
                    this.ResponseResult();
                    break;
                case "Search":
                    this.Search(context);
                    this.ResponseResult();
                    break;
                case "Get":
                    this.Get(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void mechanicAdd(HttpContext context)
    {
        AdminModel user=Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, HttpContext.Current))
        {
            string name = HttpUtility.UrlDecode(context.Request["Name"]);
            string intro = HttpUtility.UrlDecode(context.Request["Intro"]);
            string mobile = HttpUtility.UrlDecode(context.Request["Mobile"]);
            string email = HttpUtility.UrlDecode(context.Request["Email"]);
            
            string address = HttpUtility.UrlDecode(context.Request["Address"]);
            string type = HttpUtility.UrlDecode(context.Request["Type"]);
            try
            {
                UserBLL ub = new UserBLL();
                MechanicModel oMModel = new MechanicModel();
                oMModel.Name = name;
                oMModel.Introduction = intro;
                oMModel.Type = int.Parse(type);
                oMModel.Mobile = mobile;
                oMModel.Email = email;
                oMModel.Address = address;
                oMModel.StoreId = user.AdminId;
                int id=0;
                string t=ub.AddMechanic(oMModel, out id);
                if (t == "-1")
                {
                    errorCode = -1;
                }
                else
                {
                    errorCode = 0;
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("MechanicAdd", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void Setmechanic(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Update, HttpContext.Current))
        {
            string Id = HttpUtility.UrlDecode(context.Request["Id"]);
            string name = HttpUtility.UrlDecode(context.Request["Name"]);
            string intro = HttpUtility.UrlDecode(context.Request["Intro"]);
            string mobile = HttpUtility.UrlDecode(context.Request["Mobile"]);
            string email = HttpUtility.UrlDecode(context.Request["Email"]);

            string address = HttpUtility.UrlDecode(context.Request["Address"]);
            string type = HttpUtility.UrlDecode(context.Request["Type"]);
            try
            {
                UserBLL ub = new UserBLL();
                MechanicModel oMModel = new MechanicModel();
                oMModel.MechanicId = int.Parse(Id);
                oMModel.Name = name;
                oMModel.Introduction = intro;
                oMModel.Type = int.Parse(type);
                oMModel.Mobile = mobile;
                oMModel.Email = email;
                oMModel.Address = address;
               // oMModel.StoreId = user.AdminId;
                string t=ub.SetMechanic(oMModel);
                if(t=="-1")
                {
                    errorCode = -1;
                }
                else
                {
                     errorCode = 0;
                }
               
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("MechanicSet", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void Delmechanic(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Delete, HttpContext.Current))
        {
            string Id = HttpUtility.UrlDecode(context.Request["Id"]);
            try
            {
                UserBLL ub = new UserBLL();
                string t=ub.RemoveMechanic(int.Parse(Id));
                if(t=="-2")
                {
                    errorCode = -2;
                }
                else if(t=="-1")
                {
                    errorCode = -1;
                }
                else
                {
                    errorCode = 0;
                }
               
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("MechanicSet", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void Get(HttpContext context)
    {
        
        int total = 0;
        MechanicModel o = new MechanicModel();
        if (Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                  UserBLL ub = new UserBLL();
                string Id = context.Request["Id"];
                if (Id != null && !string.IsNullOrWhiteSpace(Id))
                {
                   string t= ub.GetMechanic(int.Parse(Id), out o);
                   if (t == "-1")
                   {
                       errorCode = -1;
                   }
                   else
                   {
                       errorCode = 0;
                   }
                }

                total = 1;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("Getmechanic", ex);
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
        sb.Append(JsonConvert.SerializeObject(o));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();

    }
    private void Search(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<MechanicModel> list = new List<MechanicModel>();
        if (Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                string dealer = context.Request["Dealer"];
                string store = context.Request["Store"];
                int dealerId = 0;
                if (dealer != null && !string.IsNullOrWhiteSpace(dealer))
                {
                    dealerId = Convert.ToInt32(dealer);
                }
                int storeid = 0;
                if (store != null && !string.IsNullOrWhiteSpace(store))
                {
                    storeid = Convert.ToInt32(store);
                }
                UserBLL ub = new UserBLL();
                if (user.Type == AdminType.Managers)
                {
                    ub.GetMechanicList(dealerId,storeid, out list);
                }
                 else if (user.Type == AdminType.Dealer)
                {
                    ub.GetMechanicList(user.AdminId,storeid, out list);
                }
                else if (user.Type == AdminType.Stores)
                {
                    ub.GetMechanicList(0,user.AdminId, out list);
                }
                if (list != null && list.Count > 0)
                {
                    total = list.Count;
                }
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("Searchmechanic", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"type\":\"");
        sb.Append(user.Type);

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