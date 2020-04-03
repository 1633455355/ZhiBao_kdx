<%@ WebHandler Language="C#" Class="BJG_User_APIHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class BJG_User_APIHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        GetUserList(context);
    }
    public void GetUserList(HttpContext context)
    {
        string mobile = context.Request["mobile"];
        string li = context.Request["Licence"];
       // string userid = context.Request["userid"];
       // int? uid=null;
        string jsonhtml = "{}";
        List<UserModel> olist = null;
        int count = 0;
        if (String.IsNullOrWhiteSpace(mobile))
        {
            mobile = null;
        }
        if (String.IsNullOrWhiteSpace(li))
        {
            li = null;
        }
       //if(String.IsNullOrWhiteSpace(userid))
       // {
       //     uid = null;
       // }
       // else
       // {
       //     uid = int.Parse(userid);
       // }
       
        UserBLL user = new UserBLL();
        if (!string.IsNullOrWhiteSpace(mobile) || !string.IsNullOrWhiteSpace(li) )
        {
            string ret = user.GetUserList(1, 10000000, null, li, null, mobile, out count, out olist);
        }
        JavaScriptSerializer json = json = new JavaScriptSerializer();

        string callback = context.Request["callback"];
        if(!String.IsNullOrWhiteSpace(callback))
        {
            jsonhtml = callback + "(" + json.Serialize(olist) + ")";
        }
        else
        {
            jsonhtml =json.Serialize(olist);
        }
        if (jsonhtml=="null")
        {
            jsonhtml = "{}";
        }
        context.Response.Write(jsonhtml);
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}