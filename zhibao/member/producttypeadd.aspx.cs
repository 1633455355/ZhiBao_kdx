using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_producttypeadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Product_Type, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else {

            ProductBLL pb = new ProductBLL();
            List<ProductTypeModel> list = Common.GetProductTypeOneList();
            foreach (ProductTypeModel model in list)
            {
                ListItem item = new ListItem();
                item.Value = model.F_ProductTypeId.ToString();
                item.Text = model.F_ProductTypeName;
                typeone_ddl.Items.Add(item);
            }

            FactoryTypeBLL ptb = new FactoryTypeBLL();
            List<FactoryTypeModel> listfac=new List<FactoryTypeModel>();
            ptb.GetFactoryTypeInfo(null, out listfac);

            foreach (FactoryTypeModel model in listfac)
            {
                ListItem item = new ListItem();
                item.Value = model.FactoryTypeId.ToString();
                item.Text = model.FactoryTypeName;
                typefac_ddl.Items.Add(item);
            }

        }
    }
}