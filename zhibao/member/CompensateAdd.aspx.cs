using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_CompensateAdd : System.Web.UI.Page
{
    private CompensateBLL pb = new CompensateBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Compensate, Common.Permission_Add, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadType();
            }
        }
    }

    private void LoadType()
    {
        ListItem empty = new ListItem();
        empty.Value = "";
        empty.Text = "";
        ProductSecondLevelName_ddl.Items.Add(empty);
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        AdminModel user = Common.GetLoginAdmin(Context);
        if (user != null)
        {
            if (user.Type == AdminType.Dealer)
            {
                pb.GetProductSecondLevelInfoByDealerId(user.AdminId, out list);
            }
            if (user.Type == AdminType.Stores)
            {
                pb.GetProductSecondLevelInfoByStoreId(user.AdminId, out list);
            }
        }
        foreach (ProductTypeModel model in list)
        {
            ListItem item = new ListItem();
            item.Value = model.S_ProductTypeId.ToString();
            string temp="";
            if(model!=null)
            {
                if(model.F_ProductTypeId==1) {
                    temp = "前档";
                }
                if(model.F_ProductTypeId==2){
                    temp = "侧挡/后挡";
                }
                if (model.F_ProductTypeId == 3) {
                    temp = "安全膜";
                }
            }
            item.Text = temp + "----" + model.S_ProductTypeName;
            ProductSecondLevelName_ddl.Items.Add(item);
        }
      
    }
 
}