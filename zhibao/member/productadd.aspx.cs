using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_productadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Product, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if(!Page.IsPostBack)
            {
                this.LoadTypeOne();
                this.LoadTypeTwo();
            }
        }
    }
    private void LoadTypeOne()
    {
        List<ProductTypeModel> list = Common.GetProductTypeOneList();
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        typeone_ddl.Items.Add(emptyitem);

        foreach(ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.F_ProductTypeId.ToString();
            item.Text = model.F_ProductTypeName;
            typeone_ddl.Items.Add(item);
        }
    }
    private void LoadTypeTwo()
    {
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        typetwo_ddl.Items.Add(emptyitem);
    }
}