using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_messageadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Message, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            this.LoadDealer();
            this.LoadStore();
        }
    }
    private void LoadDealer()
    {
        //dealer_ddl.Items.Add(new ListItem("", ""));
        int total = 0;
        List<DealerModel> list = Common.GetDealerList(out total);
        foreach(DealerModel model in list)
        {
            ListItem item=new ListItem();
            item.Value=model.AdminId.ToString();
            item.Text=model.DealerCompanyName;
            dealer_ddl.Items.Add(item);
        }
    }
    private void LoadStore()
    {
        //store_ddl.Items.Add(new ListItem("", ""));
        int total = 0;
        List<StoreModel> list = Common.GtetStoreList(out total);
        foreach (StoreModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.AdminId.ToString();
            item.Text = model.StoreName;
            store_ddl.Items.Add(item);
        }
    }
}