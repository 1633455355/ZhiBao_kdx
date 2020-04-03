using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_productlist : System.Web.UI.Page
{
    public string js = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Product, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadTypeOne();
                this.LoadTypeTwo();
                this.LoadStatus();
            }
        }
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Delete, HttpContext.Current))
        {
            deletepermission.Value = "true";
        }
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Update, HttpContext.Current))
        {
            updatepermission.Value = "true";
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

    private void LoadStatus()
    {
        

        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        if (user.Type == AdminType.Managers)
        {
            import_button.Visible = true;
            ListItem emptyitem = new ListItem();
            emptyitem.Text = "";
            emptyitem.Value = "";
            status_ddl.Items.Add(emptyitem);

            ListItem no = new ListItem();
            no.Text = "未认证";
            no.Value = "0";
            status_ddl.Items.Add(no);

            ListItem dealer = new ListItem();
            dealer.Text = "经销商认证";
            dealer.Value = "1";
            status_ddl.Items.Add(dealer);

            ListItem store = new ListItem();
            store.Text = "门店认证";
            store.Value = "2";
            status_ddl.Items.Add(store);

            //ListItem outstock = new ListItem();
            //outstock.Text = "使用完毕";
            //outstock.Value = "3";
            //status_ddl.Items.Add(outstock);

            this.LoadDealer();
            //this.LoadStore();
            userstatus.Value = "managers";
        }
        else if(user.Type == AdminType.Dealer)
        {
            import_button.Visible = false;
            ListItem emptyitem = new ListItem();
            emptyitem.Text = "";
            emptyitem.Value = "";
            status_ddl.Items.Add(emptyitem);


            ListItem dealer = new ListItem();
            dealer.Text = "经销商认证";
            dealer.Value = "1";
            status_ddl.Items.Add(dealer);

            ListItem store = new ListItem();
            store.Text = "门店认证";
            store.Value = "2";
            status_ddl.Items.Add(store);

            //ListItem outstock = new ListItem();
            //outstock.Text = "使用完毕";
            //outstock.Value = "3";
            //status_ddl.Items.Add(outstock);

            dealer_pl.Visible = false;
            this.LoadStore();
            userstatus.Value = "dealer";
        }
        else if(user.Type == AdminType.Stores)
        {
            import_button.Visible = false;
            ListItem store = new ListItem();
            store.Text = "门店认证";
            store.Value = "2";
            status_ddl.Items.Add(store);

            //ListItem outstock = new ListItem();
            //outstock.Text = "使用完毕";
            //outstock.Value = "3";
            //status_ddl.Items.Add(outstock);

            dealer_pl.Visible = false;
            store_pl.Visible = false;

            userstatus.Value = "store";
        }
    }

    private void LoadDealer()
    {
        ListItem emptyitem = new ListItem();
        emptyitem.Text = "";
        emptyitem.Value = "";
        dealer_ddl.Items.Add(emptyitem);
        

        DealerBLL db = new DealerBLL();
        int count=0;
        List<DealerModel> list=new List<DealerModel>();
        db.GetDealerModelList(1, 10000000, null, null, out count, out list);
        foreach(DealerModel model in list )
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
        if (user.Type==AdminType.Managers)
        {
            sb.GetStoreModelList(1, 10000000, null, null, null,out count, out list);
        }
        else if (user.Type == AdminType.Dealer)
        {
            sb.GetStoreModelList(1, 10000000, null, null,user.AdminId, out count, out list);
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