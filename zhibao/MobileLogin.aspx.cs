using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MobileLogin : System.Web.UI.Page
{
    public string style="";
    public string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request["type"]!=null)
        {
          //  style = "<style>body {zoom:1;}</style>";
            type = Request["type"].ToString();
        }
    }
    protected void login_btn_Click(object sender, EventArgs e)
    {
        this.SignIn();
    }
    public void alert(Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "alterMsg", "<script>alert('" + msg + "')</script>)");
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
            this.alert(this.Page, "用户名或者密码不正确");
        }
        else if (model.Status == false)
        {
            this.alert(this.Page, "账户已经被禁止登陆");
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
                if (!String.IsNullOrWhiteSpace(type))
                {
                    Response.Redirect("Mobile/mobileadduser.aspx?type=" + type);
                }
                else
                {
                    Response.Redirect("Mobile/mobileadduser.aspx");
                }
            }
        }
    }
}