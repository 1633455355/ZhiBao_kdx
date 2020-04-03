using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_factorytypelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Delete, HttpContext.Current))
            {
                deletepermission.Value = "true";
            }
            if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, HttpContext.Current))
            {
                updatepermission.Value = "true";
            }
        }
    }
}