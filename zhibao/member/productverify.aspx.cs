using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_productverify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Product_Verify, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
            if(user!=null && user.Type==AdminType.Dealer)
            {
                Panel1.Visible = false;
            }

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

        foreach (ProductTypeModel model in list)
        {
            if (!model.F_ProductTypeName.Equals("安全膜"))
            {
                ListItem item = new ListItem();
                item.Value = model.F_ProductTypeId.ToString();
                item.Text = model.F_ProductTypeName;
                typeone_ddl.Items.Add(item);
            }
        }
    }
    private void LoadTypeTwo()
    {
        typetwo_ddl.Items.Clear();
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        typetwo_ddl.Items.Add(emptyitem);
    }
    protected void typeone_ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTypeTwo();
        ProductBLL pb = new ProductBLL();
        if (!string.IsNullOrWhiteSpace(typeone_ddl.SelectedValue))
        {
            List<ProductTypeModel> list=new List<ProductTypeModel>();
            pb.GetProductSecondLevelInfo(Convert.ToInt32(typeone_ddl.SelectedValue), out list);

            foreach (ProductTypeModel model in list)
            {
                ListItem item = new ListItem();
                item.Value = model.S_ProductTypeId.ToString();
                item.Text = model.S_ProductTypeName;
                typetwo_ddl.Items.Add(item);
            }
        }
    }
}