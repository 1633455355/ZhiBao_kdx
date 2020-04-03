using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_mobileadduser : System.Web.UI.Page
{
    private ProductBLL pb = new ProductBLL();
    public string style = "";
    public string type = "";
    public string nav = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["type"] != null)
        {
            //style = "<style>body {zoom:1;}</style>";
            type = Request["type"].ToString();
            nav = " <div class=\"nav\" ><span class=\"crr\" id=\"s0\"><a href=\"mobileadduser.aspx?s=0&type=" + Request["type"].ToString() + "\">质保录入</a></span><span class=\"w34\" id=\"s1\"><div><a  href=\"GetUserInfoByMobile.aspx?s=1&type=" + Request["type"].ToString() + "\"> 质保查询</a></div></span><span id=\"s2\"><a href=\"GetStoreUserList.aspx?s=2&type=" + Request["type"].ToString() + "\">业务查询</a></span> </div>";
        }
        if (!Common.CheckPermission(Common.Module_User, Common.Permission_View, HttpContext.Current))
        {
            if(!String.IsNullOrWhiteSpace(type))
            {
                Response.Redirect("/MobileLogin.aspx?type=" + type);
            }
            else
            {
                Response.Redirect("/MobileLogin.aspx");
            }
           
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadCodeOne();
                this.LoadCodeTwo();
                this.LoadCarTypeOne();
                this.LoadProvince();
                this.LoadJs();
            }
        }
    }
    private void LoadJs()
    {
        UserBLL Ub = new UserBLL();
        List<MechanicModel> olist = new List<MechanicModel>();
        AdminModel user = null;
        if (Request["uId"] != null)
        {
            user = Common.GetLoginAdmin(int.Parse(Request["uId"]));
        }
        else
        {
            user = Common.GetLoginAdmin(Context);
        }
        if (user != null)
        {
            if (user.Type == AdminType.Managers)
            {
                Ub.GetMechanicList(0, out olist);
            }
            if (user.Type == AdminType.Stores)
            {
                Ub.GetMechanicList(user.AdminId, out olist);
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
    public void alert(Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "alterMsg", "<script>alert('" + msg + "')</script>)");
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
        AdminModel user = null;
        if (Request["uId"] != null)
        {
            user = Common.GetLoginAdmin(int.Parse(Request["uId"]));
        }
        else
        {
            user = Common.GetLoginAdmin(HttpContext.Current);
        }
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        pb.GetProductSecondLevelInfoByStoreId(1, user.AdminId, out list);
        foreach (ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.S_ProductTypeId.ToString();
            item.Text = model.S_ProductTypeName;
            frontcode_ddl.Items.Add(item);
        }
    }
    private void LoadCodeTwo()
    {
        ListItem empty = new ListItem();
        empty.Value = "";
        empty.Text = "";
        backcode_ddl.Items.Add(empty);
        AdminModel user = null;
        if (Request["uId"] != null)
        {
            user = Common.GetLoginAdmin(int.Parse(Request["uId"]));
        }
        else
        {
            user = Common.GetLoginAdmin(HttpContext.Current);
        }
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        pb.GetProductSecondLevelInfoByStoreId(2, user.AdminId, out list);
        foreach (ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.S_ProductTypeId.ToString();
            item.Text = model.S_ProductTypeName;
            backcode_ddl.Items.Add(item);
        }
    }
}