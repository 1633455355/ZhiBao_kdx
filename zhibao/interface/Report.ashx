<%@ WebHandler Language="C#" Class="Report" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Report : IHttpHandler, IRequiresSessionState
{
    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private ReportBLL rb = new ReportBLL();

    public void ProcessRequest (HttpContext context) {
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "GetReport":
                    this.GetReport(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void GetReport(HttpContext context)
    {
        int FirstType = 0;
        int SecondType = 0;
        int Dealer = 0;
        int Store = 0;
        DateTime start=DateTime.Now.AddYears(-100);
        DateTime end=DateTime.Now;
        if (!string.IsNullOrWhiteSpace(context.Request["FirstType"]))
        {
            FirstType = int.Parse(context.Request["FirstType"]);
        }
        if (!string.IsNullOrWhiteSpace(context.Request["SecondType"]))
        {
            SecondType = int.Parse(context.Request["SecondType"]);
        }
        if (!string.IsNullOrWhiteSpace(context.Request["Dealer"]))
        {
            Dealer = int.Parse(context.Request["Dealer"]);
        }
        if (!string.IsNullOrWhiteSpace(context.Request["Store"]))
        {
            Store = int.Parse(context.Request["Store"]);
        }
        if(!string.IsNullOrWhiteSpace(context.Request["Start"]))
        {
            start = Convert.ToDateTime(context.Request["Start"]);
        }
        if (!string.IsNullOrWhiteSpace(context.Request["End"]))
        {
            end = Convert.ToDateTime(context.Request["End"]);
        }
        AdminModel user=Common.GetLoginAdmin(context);
        System.Data.DataSet ds = null;
        try
        {
            rb.GetReport(FirstType,SecondType,Dealer,Store,start,end, user.Type, user.AdminId, out ds);
            errorCode = 0;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("GetReport",ex);
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"type\":\"");
        sb.Append(user.Type);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(ds.Tables[0]));
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
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}