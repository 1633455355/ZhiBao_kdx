using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        companyname_lb.Text = Config.CompanyName;
        if(!Page.IsPostBack)
        {
            if(!string.IsNullOrWhiteSpace(Request.QueryString["a"]) && !string.IsNullOrWhiteSpace(Request.QueryString["b"]))
            {
                username_txt.Text = DES.Decrypt(Request.QueryString["a"].ToString());
                pwd_txt.Text =  DES.Decrypt(Request.QueryString["b"].ToString());
                this.SignIn();
            }
        }
    }
    private void SignIn()
    {
        string username = username_txt.Text.Trim();
        string pwd = pwd_txt.Text.Trim();

        AdminBLL ab = new AdminBLL();
        AdminModel model = new AdminModel();
        ab.AdminLogin(username, pwd, out model);
        if (model == null || model.AdminId == 0)
        {
            username_err.Text = "用户名或者密码不正确";
            pwd_err.Text = "用户名或者密码不正确";
            usernamediv.CssClass = "block clearfix has-error";
            pwddiv.CssClass = "block clearfix has-error";
        }
        else if (model.Status == false)
        {
            username_err.Text = "账户已经被禁止登陆";
            pwd_err.Text = "账户已经被禁止登陆";
            usernamediv.CssClass = "block clearfix has-error";
            pwddiv.CssClass = "block clearfix has-error";
        }
        else
        {
            Common.ClearSessinAdminInfro(HttpContext.Current);
            //保存cookie
            if (remember_cb.Checked)
            {
                FormsAuthentication.SetAuthCookie(model.AdminId.ToString(), true);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.AdminId.ToString(), false);
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["ReturnUrl"]))
            {
                Response.Redirect(Request.QueryString["ReturnUrl"]);
            }
            else
            {
                Response.Redirect("member/home.aspx");
            }
        }
    }
    protected void login_btn_Click(object sender, EventArgs e)
    {
        this.SignIn();
    }
}