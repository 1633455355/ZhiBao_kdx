using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_producttypeupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Common.CheckPermission(Common.Module_Product_Type, Common.Permission_Update, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.GetProductType();
            }
        }   
    }

    
    private void GetProductType()
    {

        FactoryTypeBLL ptb = new FactoryTypeBLL();
        List<FactoryTypeModel> listfac = new List<FactoryTypeModel>();
        ptb.GetFactoryTypeInfo(null, out listfac);

        foreach (FactoryTypeModel model in listfac)
        {
            ListItem item = new ListItem();
            item.Value = model.FactoryTypeId.ToString();
            item.Text = model.FactoryTypeName;
            typefac_ddl.Items.Add(item);
        }


        int id = Convert.ToInt32(Request.QueryString["id"]);
        ProductBLL pb = new ProductBLL();
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        pb.GetProductSecondLevelInfo(null, out list);
        foreach(ProductTypeModel model in list)
        {
            if (model.S_ProductTypeId == id)
            {
                typeone_lb.Text = model.F_ProductTypeName;
                name_txt.Text = model.S_ProductTypeName;

                typefac_ddl.SelectedValue = model.FactoryTypeId.ToString();

                break;
            }
        }
    }
}