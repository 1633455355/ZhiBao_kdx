using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_productupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Product, Common.Permission_Update, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadTypeOne();
                this.LoadData();
            }
        }
    }
    private void LoadData()
    {
        int count=0;
        string code=Request.QueryString["code"];
        if(!string.IsNullOrWhiteSpace(code))
        {
            ProductBLL pb = new ProductBLL();
            List<ProductModel> list=new List<ProductModel>();
            pb.GetProductInfoList(1, 1, null, null, code, null, null, null,null,null,null, out count, out list);
            if(list.Count==1)
            {
                ProductModel model=list[0];
                typeone_ddl.SelectedValue = model.ProductFirstLevelId.ToString();
                this.LoadTypeTwo();
                typetwo_ddl.SelectedValue = model.ProductSecondLevelId.ToString();
                code_txt.Text = model.ProductCode;
                memo_txt.Text = model.ProductDes;

                if (model.Status == 0)
                {

                }
                else
                {
                    typeone_ddl.Enabled = false;
                    typeone_ddl.CssClass = "form-control";
                    typetwo_ddl.Enabled = false;
                    typetwo_ddl.CssClass = "form-control";
                    code_txt.Enabled = false;
                    code_txt.CssClass = "col-xs-10 col-sm-5";
                }
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
            ListItem item = new ListItem();
            item.Value = model.F_ProductTypeId.ToString();
            item.Text = model.F_ProductTypeName;
            typeone_ddl.Items.Add(item);
        }
    }

    private void LoadTypeTwo()
    {
        List<ProductTypeModel> list = Common.GetProductTypeTwoList(Convert.ToInt32(typeone_ddl.SelectedValue));
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        typetwo_ddl.Items.Add(emptyitem);

        foreach (ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.S_ProductTypeId.ToString();
            item.Text = model.S_ProductTypeName;
            typetwo_ddl.Items.Add(item);
        }
    }
      
}