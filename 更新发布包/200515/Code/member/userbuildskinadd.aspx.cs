using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_userbuildskinadd : System.Web.UI.Page
{
    private ProductBLL pb = new ProductBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_User, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadCodeOne();
                this.LoadProvince();
            }
        }
    }
    private void LoadProvince()
    {
        province_ddl.Items.Add(new ListItem("", ""));
        List<ProvinceModel> list = Common.LoadProvince();
        if (list.Count > 0)
        {
            foreach (ProvinceModel model in list)
            {
                ListItem item = new ListItem();
                item.Text = model.ProvinceName;
                item.Value = model.ProvinceId.ToString();
                province_ddl.Items.Add(item);
            }
        }
    }


    private void LoadCodeOne()
    {
        ListItem empty = new ListItem();
        empty.Value = "";
        empty.Text = "";
        frontcode_ddl.Items.Add(empty);
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        pb.GetProduct_T_SecondLevelInfoByStoreId(6, user.AdminId, out list);
        foreach (ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.S_ProductTypeId.ToString();
            item.Text = model.S_ProductTypeName;
            frontcode_ddl.Items.Add(item);
        }
    }



}