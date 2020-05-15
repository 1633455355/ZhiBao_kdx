using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_userlist : System.Web.UI.Page
{
    public string tbheader = string.Empty;
    public string js = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_User, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        { 
            if (!Page.IsPostBack)
            {

                this.LoadTypeOne();
                this.LoadTypeTwo();
                this.LoadUser();
                AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
               
                if (user.Type == AdminType.Managers)
                {
                    this.LoadDealer();
                   // this.LoadStore();
                    dealer_pl.Visible = true;
                    store_pl.Visible = true;
                    import_button.Visible = true;
                }
                else if(user.Type == AdminType.Dealer)
                {
                    dealer_pl.Visible = false;
                    store_pl.Visible = true;
                    import_button.Visible = false;
                    this.LoadStore(user);
                    js = " $(\"#ContentPlaceHolder1_store_ddl\").chosen({ allow_single_deselect: true });";
                }
                else if(user.Type == AdminType.Stores)
                {
                    dealer_pl.Visible = false;
                    store_pl.Visible = false;
                    import_button.Visible = false;
                }
                   
            }
        }
    }
    private void LoadUser()
    {
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        if (user.Type == AdminType.Managers)
        {
            tbheader = "<th>操作</th><th>经销商</th><th>店面</th><th>前后挡</th><th>品牌型号</th><th>卷轴号</th><th>是否全车</th><th>姓名</th><th>手机</th><th>邮箱</th><th>品牌信息</th><th>车系信息</th><th>车型信息</th><th>车牌</th><th>省</th><th>市</th><th>价格</th><th>部位</th><th>备注</th><th>时间</th>";
        }
        if (user.Type == AdminType.Dealer)
        {
            tbheader = "<th>店面</th><th>前后挡</th><th>品牌型号</th><th>卷轴号</th><th>是否全车</th><th>姓名</th><th>手机</th><th>邮箱</th><th>品牌信息</th><th>车系信息</th><th>车型信息</th><th>车牌</th><th>省</th><th>市</th><th>价格</th><th>部位</th><th>备注</th><th>时间</th>";
        }
        else if (user.Type == AdminType.Stores)
        {
            tbheader = "<th>前后挡</th><th>品牌型号</th><th>卷轴号</th><th>是否全车</th><th>姓名</th><th>手机</th><th>邮箱</th><th>品牌信息</th><th>车系信息</th><th>车型信息</th><th>车牌</th><th>省</th><th>市</th><th>价格</th><th>部位</th><th>备注</th><th>时间</th>";
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
            if (model.F_ProductTypeId.ToString() != "6")
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
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        typetwo_ddl.Items.Add(emptyitem);
    }
    private void LoadDealer()
    {
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        dealer_ddl.Items.Add(emptyitem);


        DealerBLL db = new DealerBLL();
        int count = 0;
        List<DealerModel> list = new List<DealerModel>();
        db.GetDealerModelList(1, 10000000, null, null, out count, out list);
        foreach (DealerModel model in list)
        {
            ListItem item = new ListItem();
            item.Text = model.DealerCompanyName;
            item.Value = model.AdminId.ToString();
            dealer_ddl.Items.Add(item);
        }
    }
    private void LoadStore(AdminModel user)
    {
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        store_ddl.Items.Add(emptyitem);

        StoreBLL sb = new StoreBLL();
        int count = 0;
        List<StoreModel> list = new List<StoreModel>();
        sb.GetStoreModelList(1, 10000000, null, null,user.AdminId , out count, out list);
        foreach (StoreModel model in list)
        {
            ListItem item = new ListItem();
            item.Text = model.StoreName;
            item.Value = model.AdminId.ToString();
            store_ddl.Items.Add(item);
        }
    }
}