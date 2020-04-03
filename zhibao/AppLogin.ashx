<%@ WebHandler Language="C#" Class="AppLogin" %>

using System;
using System.Web;

public class AppLogin : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        context.Response.Write(SignIn(context));
    }
    private string SignIn(HttpContext context)
    {
        string Code = "{}";
        string userName = context.Request["userName"];
        string userPassword = context.Request["userPassword"];
        if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(userPassword))
        {
            Code = "{\"Status\":-1,\"Text\":\"用户名或密码不能为空\",\"Id\":0}";
        }
        else
        {
            try
            {
                AdminBLL ab = new AdminBLL();
                AdminModel model = new AdminModel();
                ab.AdminLogin(DES.DESDeCode(userName, "11111111"), DES.DESDeCode(userPassword, "11111111"), out model);
                if (model == null || model.AdminId == 0)
                {
                    Code = "{\"Status\":-2,\"Text\":\"用户名或者密码不正确\",\"Id\":0}";
                }
                else if (model.Status == false)
                {
                    Code = "{\"Status\":-3,\"Text\":\"账户已经被禁止登陆\",\"Id\":0}";
                }
                else
                {
                    Code = "{\"Status\":0,\"Text\":\"登陆成功\",\"Id\":" + model.AdminId + "}";
                }
            }
            catch(Exception ex)
            {
                Code = "{\"Status\":-4,\"Text\":\"" + ex .Message+ "\",\"Id\":0}";
            }
        }
        return Code;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}