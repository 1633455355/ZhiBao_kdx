<%@ WebHandler Language="C#" Class="Message" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

public class Message : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private MessageBLL mb = new MessageBLL();
    public void ProcessRequest (HttpContext context) {
        
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "SendMEssage":
                    this.SendMEssage(context);
                    this.ResponseResult();
                    break;
                case "GetMessage":
                    this.GetMessage(context);
                    this.ResponseResult();
                    break;
                case "DeleteMessage":
                    this.DeleteMessage(context);
                    this.ResponseResult();
                    break;
                case "SetRead":
                    this.SetRead(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void SendMEssage(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        
        string type = HttpUtility.UrlDecode(context.Request["Type"]);
        string dealer = HttpUtility.UrlDecode(context.Request["Dealer"]);
        string store = HttpUtility.UrlDecode(context.Request["Store"]);
        string title = HttpUtility.UrlDecode(context.Request["Title"]);
        string content = HttpUtility.UrlDecode(context.Request["Content"]);

        if (Common.CheckPermission(Common.Module_Message, Common.Permission_Add, context))
        {
            try
            {

                if (type.Equals("all"))
                {
                    MessageModel model = new MessageModel();
                    model.Title = title;
                    model.Content = content;
                    model.From = user.AdminId;
                    int id = 0;
                    mb.AddAllDealerMessageInfo(model, out id);
                    mb.AddAllStoreMessageInfo(model, out id);
                    errorCode = 0;
                }
                else if (type.Equals("dealer"))
                {
                    MessageModel model = new MessageModel();
                    model.Title = title;
                    model.Content = content;
                    model.From = user.AdminId;
                    int id = 0;
                    mb.AddAllDealerMessageInfo(model, out id);
                    errorCode = 0;
                }
                else if (type.Equals("store"))
                {
                    MessageModel model = new MessageModel();
                    model.Title = title;
                    model.Content = content;
                    model.From = user.AdminId;
                    int id = 0;
                    mb.AddAllStoreMessageInfo(model, out id);
                    errorCode = 0;
                }
                else if (type.Equals("self"))
                {
                    string[] dealerlst = dealer.Split(',');
                    foreach (string str in dealerlst)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            MessageModel model = new MessageModel();
                            model.Title = title;
                            model.Content = content;
                            model.From = user.AdminId;
                            int id = 0;
                            model.To = Convert.ToInt32(str);
                            mb.AddMessageInfo(model, out id);
                        }
                    }

                    string[] storelst = store.Split(',');
                    foreach (string str in storelst)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            MessageModel model = new MessageModel();
                            model.Title = title;
                            model.Content = content;
                            model.From = user.AdminId;
                            int id = 0;
                            model.To = Convert.ToInt32(str);
                            mb.AddMessageInfo(model, out id);
                        }
                    }
                    errorCode = 0;
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("SendMEssage", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void SetRead(HttpContext context)
    {
        string id = context.Request["ID"];
        mb.SetIsReadMessageInfo(Convert.ToInt32(id), true);
        int count=0;
        List<MessageModel> list=new List<MessageModel>();
        int noread=0;
        try
        {
            mb.GetMessageList(1, 1, Convert.ToInt32(id), null, null, null, null, out count, out noread, out list);
            errorCode = 0;
        }
        catch(Exception ex)
        {
            WriteLog.WriteExceptionLog("SetRead", ex);
        }
        
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(count);


        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End(); 
        
    }
    private void DeleteMessage(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Message, 3, context))
        {
            try
            {
                string idstr = context.Request["ID"];
                string[] idlst = idstr.Split(',');
                foreach (string id in idlst)
                {
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        mb.RemoveMessageInfo(Convert.ToInt32(id));
                    }
                }
                errorCode = 0;
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("DeleteMessage", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetMessage(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int notread = 0;
        int total = 0;
        List<MessageModel> list = new List<MessageModel>();
        if (Common.CheckPermission(Common.Module_Message, 4, context))
        {
            try
            {
                mb.GetMessageList(int.Parse(context.Request["Page"]), int.Parse(context.Request["Item"]), null, null, null, null, user.AdminId, out total, out notread, out list);
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetMessage", ex);
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

        sb.Append("\",\"notread\":\"");
        sb.Append(notread);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End(); 
    }
    public bool IsReusable {
        get {
            return false;
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

}