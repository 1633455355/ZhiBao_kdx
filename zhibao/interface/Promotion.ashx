<%@ WebHandler Language="C#" Class="Promotion" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Promotion : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private PromotionBLL pb = new PromotionBLL();
    
    public void ProcessRequest (HttpContext context) {
        
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "PromotionAdd":
                    this.PromotionAdd(context);
                    this.ResponseResult();
                    break;
                case "GetPromotionList":
                    this.GetPromotionList(context);
                    this.ResponseResult();
                    break;
                case "DeletePromotion":
                    this.DeletePromotion(context);
                    this.ResponseResult();
                    break;
                case "GetPromotion":
                    this.GetPromotion(context);
                    this.ResponseResult();
                    break;
                case "PromotionUpdate":
                    this.PromotionUpdate(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void DeletePromotion(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    if (pb.RemovePromotionInfo(Convert.ToInt32(context.Request["ID"])).Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeletePromotion", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void PromotionUpdate(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_Update, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["ID"]) && !string.IsNullOrWhiteSpace(context.Request["Title"]) && !string.IsNullOrWhiteSpace(context.Request["Content"]) && !string.IsNullOrWhiteSpace(context.Request["Dealer"]))
            {
                string id = context.Request["ID"];
                List<PromotionModel> list = new List<PromotionModel>();
                int total = 0;
                try
                {
                    pb.GetPromotionList(1, 1, Convert.ToInt16(id), null, null, null, out total, out list);
                    if (list.Count == 1)
                    {
                        PromotionModel model = list[0];

                        string title = HttpUtility.UrlDecode(context.Request["Title"]);
                        string content = HttpUtility.UrlDecode(context.Request["Content"]);
                        string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);
                        string[] dealerlist = dealer.Split(',');
                        List<int> newlist = new List<int>();
                        foreach (string idstr in dealerlist)
                        {
                            if (!string.IsNullOrWhiteSpace(idstr))
                            {
                                newlist.Add(Convert.ToInt32(idstr));
                            }
                        }
                        model.Title = title;
                        model.Content = content;
                        model.DealerIdList = newlist;
                        model.UpLastor = user.AdminId;
                        if (pb.SetPromotionInfo(model).Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("PromotionUpdate", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetPromotion(HttpContext context)
    {
        List<PromotionModel> list = new List<PromotionModel>();
        int total = 0;
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_View, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    pb.GetPromotionList(1, 1, Convert.ToInt32(context.Request["ID"]), null, null, null, out total, out list);
                    errorCode = 0;
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("GetPromotion", ex);
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

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();

    }
    private void GetPromotionList(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<PromotionModel> list = new List<PromotionModel>();
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_View, context))
        {
            if (!string.IsNullOrEmpty(context.Request["Page"]))
            {
                try
                {

                    if (user.Type==AdminType.Dealer)
                    {
                        pb.GetPromotionList(int.Parse(context.Request["Page"]) + 1, int.Parse(context.Request["Item"]), null, null, user.AdminId, null, out total, out list); 
                    }
                    else if (user.Type == AdminType.Stores)
                    {
                        pb.GetPromotionList(int.Parse(context.Request["Page"]) + 1, int.Parse(context.Request["Item"]), null, null, null, user.AdminId, out total, out list);
                    }
                    else
                    {
                        pb.GetPromotionList(int.Parse(context.Request["Page"]) + 1, int.Parse(context.Request["Item"]), null, null, null, null, out total, out list);
                    }
                    errorCode = 0;
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("GetPromotionList", ex); 
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

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":[");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("]}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void PromotionAdd(HttpContext context)
    {
        AdminModel user=Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_Update, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Title"]) && !string.IsNullOrWhiteSpace(context.Request["Content"]) && !string.IsNullOrWhiteSpace(context.Request["Dealer"]))
            {
                string title = HttpUtility.UrlDecode(context.Request["Title"]);
                string content = HttpUtility.UrlDecode(context.Request["Content"]);
                string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);
                string[] dealerlist = dealer.Split(',');
                List<int> list = new List<int>();
                foreach (string idstr in dealerlist)
                {
                    if (!string.IsNullOrWhiteSpace(idstr))
                    {
                        list.Add(Convert.ToInt32(idstr));
                    }
                }

                PromotionModel pm = new PromotionModel();
                pm.Title = title;
                pm.Content = content;
                pm.DealerIdList = list;
                pm.CreatorId = user.AdminId;
                int id = 0;
                try
                {
                    pb.AddPromotionInfo(pm, out id);
                    if (id > 0)
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("PromotionAdd",ex);
                }
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