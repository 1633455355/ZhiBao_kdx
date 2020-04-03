using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class member_F_productadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadTypeTwo();
                setProductInfo();
            }
        }
    }
    private void setProductInfo()
    {
        string code=Request["Code"];
        if(!String.IsNullOrWhiteSpace(code))
        {
            List<ProductModel> olist = new List<ProductModel>();
            int Count = 0;
            ProductBLL pb = new ProductBLL();
            pb.GetProductInfoList(1, 1, null, null, code, null, null, null, null,null,null,out Count, out olist);
            if(olist.Count>0)
            {
                typeone_ddl.SelectedValue = olist[0].FactoryTypeId.ToString();
                code_txt.Text = olist[0].ProductCode;
                memo_txt.Text = olist[0].ProductDes;
                mi_ddl.SelectedValue = olist[0].Length.ToString();
            }
        }
    }
    private void LoadTypeTwo()
    {
        FactoryTypeBLL ftb = new FactoryTypeBLL();
        List<FactoryTypeModel> olist = new List<FactoryTypeModel>();
        ftb.GetFactoryTypeInfo(null, out olist);
        if(olist!=null && olist.Count>0)
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