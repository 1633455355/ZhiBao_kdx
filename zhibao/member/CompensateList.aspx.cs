using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_CompensateList : System.Web.UI.Page
{
    public string tbheader = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Compensate, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
                LoadTypeTwo(user);
                this.LoadCompensateInfo(user);
                
            }
        }

    }
    private void LoadTypeTwo(AdminModel user)
    {
        FactoryTypeBLL ftb = new FactoryTypeBLL();
        List<FactoryTypeModel> olist = new List<FactoryTypeModel>();
        ftb.GetFactoryTypeInfo(null, out olist);
        if (olist != null && olist.Count > 0)
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
        if(user.Type!=AdminType.Managers)
        {
            Compensate_pl.Visible = false;
        }
    }
    private void LoadCompensateInfo(AdminModel user)
    {;
        if (user.Type == AdminType.Managers)
        {
            tbheader = "<th>品牌型号</th><th>卷轴号</th><th>申请人</th><th>处理状态</th><th>经销商名称</th><th>店面名称</th><th>图片</th><th>附件</th><th>理赔时间</th><th>订单详细信息</th><th>处理订单</th>";
        }

        else if (user.Type == AdminType.Dealer)
        {
            tbheader = "<th>处理状态更新</th><th>品牌型号</th><th>卷轴号</th><th>申请人</th><th>处理状态</th><th>经销商名称</th><th>图片</th><th>附件</th><th>理赔时间</th><th>订单详细信息</th>";
        }
        else if (user.Type == AdminType.Stores)
        {
            tbheader = "<th>处理状态更新</th><th>品牌型号</th><th>卷轴号</th><th>申请人</th><th>处理状态</th><th>店面名称</th><th>图片</th><th>附件</th><th>理赔时间</th><th>订单详细信息</th>";
        }
    }
}