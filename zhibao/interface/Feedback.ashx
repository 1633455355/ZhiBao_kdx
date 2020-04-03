<%@ WebHandler Language="C#" Class="Feedback" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Feedback : IHttpHandler, IRequiresSessionState
{
    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private FeedBackBLL fbb = new FeedBackBLL();
    public void ProcessRequest(HttpContext context)
    {

        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "FeedbackAdd":
                    this.FeedbackAdd(context);
                    this.ResponseResult();
                    break;
                case "GetFeedbackList":
                    this.GetFeedbackList(context);
                    this.ResponseResult();
                    break;
                case "DeleteFeedback":
                    this.DeleteFeedback(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void DeleteFeedback(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Feedback, Common.Permission_Delete, HttpContext.Current))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    if (fbb.RemoveFeedBackInfo(Convert.ToInt32(context.Request["ID"])).Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteFeedback", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetFeedbackList(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<FeedBackModel> list = new List<FeedBackModel>();
        if (Common.CheckPermission(Common.Module_Feedback, Common.Permission_View, HttpContext.Current))
        {
            if (!string.IsNullOrEmpty(context.Request["Page"]))
            {
                try
                {
                    if (user.Type == AdminType.Managers)
                    {
                        fbb.GetFeedBackList(int.Parse(context.Request["Page"]) + 1, int.Parse(context.Request["Item"]), null, null, null, null, null, out total, out list);
                    }
                    else
                    {
                        fbb.GetFeedBackList(int.Parse(context.Request["Page"]) + 1, int.Parse(context.Request["Item"]), null, null, null, user.AdminId, true, out total, out list);
                    }
                    errorCode = 0;
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("GetFeedbackList", ex); 
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
    private void FeedbackAdd(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Feedback, Common.Permission_Add, HttpContext.Current))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Title"]) && !string.IsNullOrWhiteSpace(context.Request["Content"]))
            {
                string title = HttpUtility.UrlDecode(context.Request["Title"]);
                string contact = HttpUtility.UrlDecode(context.Request["Contact"]);
                string mobile = HttpUtility.UrlDecode(context.Request["Mobile"]);
                string email = HttpUtility.UrlDecode(context.Request["Email"]);
                string content = HttpUtility.UrlDecode(context.Request["Content"]);
                string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);
                
                FeedBackModel model = new FeedBackModel();
                model.Title = title;
                model.Content = content;
                model.Name = contact;
                model.Mobile = mobile;
                model.Email = email;
                model.CreatorId = user.AdminId;

                if (dealer.Equals("true"))
                {
                    model.IsdisplayDealer = true;
                }
                else
                {
                    model.IsdisplayDealer = false;
                }
                
                int id = 0;
                try
                {
                    fbb.AddFeedBackInfo(model, out id);
                    if (id > 0)
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("FeedbackAdd",ex);
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