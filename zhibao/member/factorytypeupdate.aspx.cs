using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class factorytypeupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.GetFactoryType();
            }
        }   
    }

    private void GetFactoryType()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        FactoryTypeBLL ftb = new FactoryTypeBLL();
        List<FactoryTypeModel> list = new List<FactoryTypeModel>();
        ftb.GetFactoryTypeInfo(id, out list);
        if (list.Count>0)
        {
            FactoryTypeModel model = (FactoryTypeModel)list[0];
            name_txt.Text = model.FactoryTypeName;
            namep_txt.Text = model.ProductSecondLevelNameDefalut;
        }
    }
}