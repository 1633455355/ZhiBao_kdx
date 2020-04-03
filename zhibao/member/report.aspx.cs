using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_report : System.Web.UI.Page
{
    public string tbheader = string.Empty;
    public string js = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Report, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if(!Page.IsPostBack)
            {
                this.LoadUser();
                this.LoadTypeOne();
                this.LoadTypeTwo();
                AdminModel user = Common.GetLoginAdmin(HttpContext.Current);

                if (user.Type == AdminType.Managers)
                {
                    LoadDealer();
                }
                else if (user.Type == AdminType.Dealer)
                {
                    LoadStore();
                    dealer_pl.Visible = false;
                    import_button.Visible = false;
                }
                else if (user.Type == AdminType.Stores)
                {
                    dealer_pl.Visible = false;
                    import_button.Visible = false;
                    store_pl.Visible = false;
                }
            }
        }
    }
    private void LoadUser()
    {
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        if(user.Type==AdminType.Managers)
        {
            tbheader = "<th>一级分类</th><th>品牌型号</th><th>经销商</th><th>门店</th><th>总商品码（卷）</th><th>经销商认证商品码（卷）</th><th>门店认证商品码（卷）</th><th>贴车数(台)</th>";
        }
        else if(user.Type==AdminType.Dealer)
        {
            tbheader = "<th>一级分类</th><th>品牌型号</th><th>门店</th><th>已认证商品码（卷）</th><th>门店认证商品码（卷）</th><th>贴车数（台）</th>";
        }
        else if(user.Type==AdminType.Stores)
        {
            tbheader = "<th>一级分类</th><th>品牌型号</th><th>已认证商品码（卷）</th><th>贴车数（台）</th>";
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

    private void LoadStore()
    {
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        store_ddl.Items.Add(emptyitem);

        StoreBLL sb = new StoreBLL();
        int count = 0;
        List<StoreModel> list = new List<StoreModel>();
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        if (user.Type == AdminType.Managers)
        {
            sb.GetStoreModelList(1, 10000000, null, null, null, out count, out list);
        }
        else if (user.Type == AdminType.Dealer)
        {
            sb.GetStoreModelList(1, 10000000, null, null, user.AdminId, out count, out list);
            js = " $('#ContentPlaceHolder1_store_ddl').chosen({ allow_single_deselect: true });";
        }
        foreach (StoreModel model in list)
        {
            ListItem item = new ListItem();
            item.Text = model.StoreName;
            item.Value = model.AdminId.ToString();
            store_ddl.Items.Add(item);
        }
    }
}