<%@ WebHandler Language="C#" Class="News" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;

public class News : IHttpHandler, IRequiresSessionState
{


    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private NewsBLL nb = new NewsBLL();
    public void ProcessRequest(HttpContext context)
    {

        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "NewsAdd":
                    this.NewsAdd(context);
                    this.ResponseResult();
                    break;
                case "GetNewsList":
                    this.GetNewsList(context);
                    this.ResponseResult();
                    break;
                case "DeleteNews":
                    this.DeleteNews(context);
                    this.ResponseResult();
                    break;
                case "GetNews":
                    this.GetNews(context);
                    this.ResponseResult();
                    break;
                case "NewsUpdate":
                    this.NewsUpdate(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void NewsUpdate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_News, Common.Permission_Update, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Title"]) && !string.IsNullOrWhiteSpace(context.Request["Content"]) && !string.IsNullOrWhiteSpace(context.Request["ID"]))
            {
                string title = HttpUtility.UrlDecode(context.Request["Title"]);
                string content = HttpUtility.UrlDecode(context.Request["Content"]);
                string id = HttpUtility.UrlDecode(context.Request["ID"]);

                List<NewsModel> list = new List<NewsModel>();
                int total = 0;
                if (!string.IsNullOrEmpty(context.Request["ID"]))
                {
                    try
                    {
                        nb.GetNewsList(1, 1, Convert.ToInt32(context.Request["ID"]), null, out total, out list);
                        if (list.Count > 0)
                        {
                            NewsModel model = list[0];
                            model.Title = title;
                            model.Content = content;
                            if (nb.SetNewsInfo(model).Equals(Config.Success))
                            {
                                errorCode = 0;
                            }
                        }   
                    }
                    catch(Exception ex)
                    {
                        WriteLog.WriteExceptionLog("NewsUpdate",ex);
                    }
                }
            }
        }
        else
        {
            errorCode = -10; 
        }
    }
    private void GetNews(HttpContext context)
    {
        List<NewsModel> list = new List<NewsModel>();
        int total = 0;
        if (Common.CheckPermission(Common.Module_News, Common.Permission_View, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    nb.GetNewsList(1, 1, Convert.ToInt32(context.Request["ID"]), null, out total, out list);
                    errorCode = 0;
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("GetNews",ex);
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
    private void DeleteNews(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_News, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    if (nb.RemoveNewsInfo(Convert.ToInt32(context.Request["ID"])).Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteNews",ex);
                }
                
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetNewsList(HttpContext context)
    {
        int total = 0;
        List<NewsModel> list = new List<NewsModel>();
        if (Common.CheckPermission(Common.Module_News, Common.Permission_View, context))
        {
            if (!string.IsNullOrEmpty(context.Request["Page"]))
            {
                try
                {
                    NewsBLL nb = new NewsBLL();
                    nb.GetNewsList(int.Parse(context.Request["Page"]) + 1, int.Parse(context.Request["Item"]), null, null, out total, out list);
                    errorCode = 0;
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("GetNewsList", ex); 
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
    private void NewsAdd(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_News, Common.Permission_Add, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Title"]) && !string.IsNullOrWhiteSpace(context.Request["Content"]))
            {
                string title = HttpUtility.UrlDecode(context.Request["Title"]);
                string content = HttpUtility.UrlDecode(context.Request["Content"]);

                NewsBLL nb = new NewsBLL();
                NewsModel model = new NewsModel();
                model.Title = title;
                model.Content = content;
                model.CreatorId = user.AdminId;
                int id = 0;
                try
                {
                    nb.AddNewsInfo(model, out id);
                    if (id > 0)
                    {
                        errorCode = 0;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("NewsAdd", ex);
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