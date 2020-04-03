<%@ WebHandler Language="C#" Class="GetUserHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text;

public class GetUserHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write(GetUserList(context));
    }
    public string GetUserList(HttpContext context)
    {
        string mobile = context.Request["mobile"];
        string li = context.Request["Licence"];
        List<UserModel> olist=null;
        int count=0;
        if(String.IsNullOrWhiteSpace(mobile))
        {
            mobile = null;
        }
        if(String.IsNullOrWhiteSpace(li))
        {
            li = null;
        }
        UserBLL user = new UserBLL();
        string ret = user.GetUserList(1, 10000000, null, li, null, mobile, out count, out olist);
        JavaScriptSerializer json = json = new JavaScriptSerializer();
        StringBuilder html = new StringBuilder();
        if(olist!=null && olist.Count>0)
        {
                html.Append(" <h3></h3>");
                html.Append("  <table cellpadding='0' cellspacing='0'>");
                html.Append("  <tr><th>编号</th><th>车主姓名</th><th>贴膜门店</th><th>贴膜类型</th><th>贴膜时间</th><th>质保截止日期</th> </tr>");
                foreach (UserModel mode in olist)
                {
                    html.Append("<tr>");
                    html.Append("   <td>"+mode.UserId+"</td>");
                    html.Append("   <td>" + mode.UserName + "</td>");
                    html.Append("   <td>" + mode.StoreName + "</td>");
                    html.Append("   <td>" + mode.F_ProductTypeName+"--"+mode.S_ProductTypeName + "</td>");
                    html.Append("   <td>" +mode.CreateTime.ToString("yyy-MM-dd") + "</td>");
                    
                    if(!String.IsNullOrWhiteSpace(mode.ZBYear)) {
                        int year=0;
                        bool flag=Int32.TryParse(mode.ZBYear,out year);
                        if(flag) { html.Append("   <td>" + mode.CreateTime.AddYears(year).ToString("yyyy-MM-dd") + "</td>"); }
                        else {  html.Append("   <td></td>");  }
                    }
                    else {  html.Append("   <td></td>"); }
                     html.Append("<tr>");
                }
                html.Append("  </table>");
        }
        else
        {
            html.Append(" <h3>目前还没有查询到你的质保信息哦！</h3>");
            html.Append("  <table>");
            html.Append("  <tr><th>编号</th><th>车主姓名</th><th>贴膜门店</th><th>贴膜类型</th><th>贴膜时间</th><th>质保截止日期</th> </tr>");
            html.Append("  </table>");
        }
        return html.ToString();
      
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}