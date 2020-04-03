using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_feedbacklist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Feedback, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        if (Common.CheckPermission(Common.Module_Feedback, Common.Permission_Delete, HttpContext.Current))
        {
            deletepermission.Value = "true";
        }
    }
}