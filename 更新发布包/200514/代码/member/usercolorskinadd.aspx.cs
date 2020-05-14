using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_usercolorskinadd : System.Web.UI.Page
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
                this.LoadCarTypeOne();
                this.LoadProvince();
                this.LoadJs();
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
    private void LoadJs()
    {
        UserBLL Ub = new UserBLL();
        List<MechanicModel> olist = new List<MechanicModel>();
        AdminModel user = Common.GetLoginAdmin(Context);
        if (user != null)
        {
            if (user.Type == AdminType.Managers)
            {
                Ub.GetMechanicList(0, 0, out olist);
            }
            if (user.Type == AdminType.Stores)
            {
                Ub.GetMechanicList(0, user.AdminId, out olist);
            }
        }
        if (olist != null && olist.Count > 0)
        {
            js_ddl.DataTextField = "Name";
            js_ddl.DataValueField = "MechanicId";
            js_ddl.DataSource = olist;
            js_ddl.DataBind();
            js_ddl.Items.Insert(0, new ListItem("请选择", "0"));
        }
    }
    private void LoadCarTypeOne()
    {

        ListItem empty = new ListItem();
        empty.Value = "";
        empty.Text = "";
        brand_ddl.Items.Add(empty);
        List<CarBrandModel> list = new List<CarBrandModel>();
        int total = 0;
        Province_City_CarBLL pcc = new Province_City_CarBLL();
        pcc.GetCarBrandList(null, out total, out list);
        foreach (CarBrandModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.CarBrandCode.ToString();
            item.Text = model.CarBrandName;
            brand_ddl.Items.Add(item);
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
        pb.GetProduct_T_SecondLevelInfoByStoreId(7, user.AdminId, out list);
        foreach (ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.S_ProductTypeId.ToString();
            item.Text = model.S_ProductTypeName;
            frontcode_ddl.Items.Add(item);
        }
    }



}