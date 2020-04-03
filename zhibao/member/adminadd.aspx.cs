using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_adminadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Admin, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        { 
            if (!Page.IsPostBack)
            {
                this.LoadRole();
                this.LoadProvince();
            }
        }
    }

    private void LoadRole()
    {
        role_ddl.Items.Add(new ListItem("", ""));
        AdminBLL ab = new AdminBLL();
        List<RoleModel> list=new List<RoleModel>();
        ab.GetRoleList(null, out list);
        if (list.Count > 0)
        {
            foreach(RoleModel model in list)
            {
                ListItem item = new ListItem();
                item.Value = model.RoleId.ToString();
                item.Text = model.RoleName;
                role_ddl.Items.Add(item);
            }
        }
    }
    private void LoadProvince()
    {
        province_ddl.Items.Add(new ListItem("", ""));
        List<ProvinceModel> list = Common.LoadProvince();
        if(list.Count>0)
        {
            foreach (ProvinceModel model in list)
            {
                ListItem item = new ListItem();
                item.Text = model.ProvinceName;
                item.Value = model.ProvinceId.ToString();
                province_ddl.Items.Add(item);
            }
        }
    }
}