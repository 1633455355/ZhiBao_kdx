using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_adminlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Admin, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadRole();
                this.LoadDealer();
            }
        }
    }
    private void LoadDealer()
    {
        int total = 0;
        List<DealerModel> list = Common.GetDealerList(out total);
        dealer_ddl.Items.Add(new ListItem("", ""));
        if (list.Count > 0)
        {
            foreach (DealerModel model in list)
            {
                ListItem item = new ListItem();
                item.Text = model.DealerCompanyName;
                item.Value = model.AdminId.ToString();
                dealer_ddl.Items.Add(item);
            }
        }
    }

    private void LoadRole()
    {
        role_ddl.Items.Add(new ListItem("", ""));
        List<RoleModel> list = Common.GetRoleList();
        if (list.Count > 0)
        {
            foreach (RoleModel model in list)
            {
                ListItem item = new ListItem();
                item.Value = model.RoleId.ToString();
                item.Text = model.RoleName;
                role_ddl.Items.Add(item);
            }
        }
    }
}