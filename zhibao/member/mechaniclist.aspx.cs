using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_mechaniclist : System.Web.UI.Page
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
                this.LoadUser();
                AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
                if (user.Type == AdminType.Managers)
                {
                    LoadDealer();
                    dealer_pl.Visible = true;
                    store_pl.Visible = true;
                }
                else if (user.Type == AdminType.Dealer)
                {
                    this.LoadStore(user);
                    dealer_pl.Visible = false;
                    store_pl.Visible = true;
                    js = " $(\"#ContentPlaceHolder1_store_ddl\").chosen({ allow_single_deselect: true });";
                }
                else
                {
                    dealer_pl.Visible = false;
                    store_pl.Visible = false;
                }
                   
            }
        }
    }
    private void LoadUser()
    {
         AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
         if (user.Type == AdminType.Managers)
         {
             tbheader = "  <th>操作</th><th>经销商</th><th>店面</th><th>技师姓名</th><th>介绍</th><th>类别</th><th>手机</th><th>邮箱</th><th>地址</th><th>时间</th>";
         }
         else if(user.Type == AdminType.Dealer)
        {
            tbheader = "<th>操作</th><th>店面</th><th>技师姓名</th><th>介绍</th><th>类别</th><th>手机</th><th>邮箱</th><th>地址</th><th>时间</th>";
        }
         else if (user.Type == AdminType.Stores)
         {
             tbheader = "  <th>操作</th><th>技师姓名</th><th>介绍</th><th>类别</th><th>手机</th><th>邮箱</th><th>地址</th><th>时间</th>";
         }
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
        sb.GetStoreModelList(1, 10000000, null, null, user.AdminId, out count, out list);
        foreach (StoreModel model in list)
        {
            ListItem item = new ListItem();
            item.Text = model.StoreName;
            item.Value = model.AdminId.ToString();
            store_ddl.Items.Add(item);
        }

    }
}