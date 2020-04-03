using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class F_productlist : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadTypeOne();
            }
        }
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Delete, HttpContext.Current))
        {
            deletepermission.Value = "true";
        }
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, HttpContext.Current))
        {
            updatepermission.Value = "true";
        }
    }
    private void LoadTypeOne()
    {
        FactoryTypeBLL ftb = new FactoryTypeBLL();
        List<FactoryTypeModel> olist = new List<FactoryTypeModel>();
        ftb.GetFactoryTypeInfo(null, out olist);
        if (olist != null && olist.Count > 0)
        {
            typeone_ddl.DataValueField = "FactoryTypeId";
            typeone_ddl.DataTextField = "FactoryTypeName";
            typeone_ddl.DataSource = olist;
            typeone_ddl.DataBind();
        }
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        typeone_ddl.Items.Insert(0, emptyitem);
    }
 

}