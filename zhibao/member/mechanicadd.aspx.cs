using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_mechanicadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_User, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
      
    }
}