using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class MasterPage : System.Web.UI.MasterPage
{
    public string reportsb = string.Empty;
    public string producttypeaddsb = string.Empty;
    public string producttypelistsb = string.Empty;
    public string menumessageadd = string.Empty;
    public string menumessagelist = string.Empty;
    public string menucar = string.Empty;
    public string menuadminadd = string.Empty;
    public string menuadminlist = string.Empty;
    
    public string menustorelist = string.Empty;
    public string menuroleadd = string.Empty;
    public string menurolelist = string.Empty;
    public string menufeedbackadd = string.Empty;
    public string menufeedbacklist = string.Empty;
    public string meunnewsadd = string.Empty;
    public string meunnewslist = string.Empty;
    public string menuproductadd = string.Empty;
    public string menuproductimport = string.Empty;
    public string menuproductlist = string.Empty;
    public string menuproductverify = string.Empty;
    public string menupromotionadd = string.Empty;
    public string menupromotionlist = string.Empty;
    public string menuuseradd = string.Empty;
    public string menuuserlist = string.Empty;

    public string mechanicadd = string.Empty;
    public string mechaniclist = string.Empty;


    public string factorytypeaddsb = string.Empty;
    public string factorytypeaddsb_1 = string.Empty;
    public string factorytypelistsb = string.Empty;
    public string factorytypelistsb_1 = string.Empty;

    public string menupcompensateadd = string.Empty;
    public string menupcompensatelist = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        companyname_lb.Text = Config.CompanyName;
        adminname_lb.Text = user.AdminName;
        if(user.Type==AdminType.Managers)
        {
            profile_lk.Visible = false;
        }
        this.GetNoReadMessage();
        this.SetMenu();

        if(user.Type==AdminType.Dealer)
        {
            menustorelist = "<li id=\"menustorelist\"><a href=\"storelist.aspx\"><i class=\"icon-double-angle-right\"></i>门店列表</a></li>";
        }
    }
    private void GetNoReadMessage()
    {
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        int notread = 0;
        int total = 0;
        List<MessageModel> list = new List<MessageModel>();
        MessageBLL mb = new MessageBLL();
        try
        {
            mb.GetMessageList(1, 100000, null, null, false, null, user.AdminId, out total, out notread, out list);
            messagenocount_lb.Text = total.ToString();
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("GetMessage", ex);
        }

    }

    private void SetMenu()
    {
        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        if(user.Role!=null)
        {
            List<PermissionsModel> list = user.Role.Permissions;
            
            foreach (PermissionsModel per in list)
            {
                if (per.ModuleKey == Common.Module_Report && per.PermissionsId == Common.Permission_View)
                {
                    reportsb = "<li id=\"menureport\"><a href=\"report.aspx\"><i class=\"icon-bar-chart \"></i><span class=\"menu-text\">报表 </span></a></li>";
                }
                if (per.ModuleKey == Common.Module_Product_Type && per.PermissionsId == Common.Permission_Add)
                {
                    producttypeaddsb = "<li id=\"menuproducttypeadd\"><a href=\"producttypeadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增工产品型号</a></li>";
                }
                if (per.ModuleKey == Common.Module_Product_Type && per.PermissionsId == Common.Permission_View)
                {
                    producttypelistsb = "<li id=\"menuproductypelisty\"><a href=\"producttypelist.aspx\"><i class=\"icon-double-angle-right\"></i>工厂-品牌产品型号管理</a></li>";
                }



                if (per.ModuleKey == Common.Module_Factory_Type && per.PermissionsId == Common.Permission_Add)
                {
                    factorytypeaddsb = "<li id=\"menuproducttypeadd\"><a href=\"factorytypeadd.aspx\"><i class=\"icon-double-angle-right\"></i>工厂产品内部型号管理</a></li>";
                 }
                if (per.ModuleKey == Common.Module_Factory_Type && per.PermissionsId == Common.Permission_View)
                {
                    factorytypelistsb = "<li id=\"menufactorytypelist\"><a href=\"factorytypelist.aspx\"><i class=\"icon-double-angle-right\"></i>产品内部型号列表</a></li>";
                }
                if (per.ModuleKey == Common.Module_Factory_Type && per.PermissionsId == Common.Permission_Add)
                {
                    factorytypeaddsb_1 = "<li id=\"member_F_productadd\"><a href=\"member_F_productadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增产品卷轴号</a></li>";
                    factorytypeaddsb_1 += "<li id=\"F_productimport\"><a href=\"F_productimport.aspx\"><i class=\"icon-double-angle-right\"></i>模板下载/(卷轴号)导入</a></li>";
                }
                if (per.ModuleKey == Common.Module_Factory_Type && per.PermissionsId == Common.Permission_View)
                {
                    factorytypelistsb_1 = "<li id=\"F_productlist\"><a href=\"F_productlist.aspx\"><i class=\"icon-double-angle-right\"></i>编码（卷轴号）列表</a></li>";
                }


                if (per.ModuleKey == Common.Module_Message && per.PermissionsId == Common.Permission_Add)
                {
                    menumessageadd = "<li id=\"menumessageadd\"><a href=\"messageadd.aspx\"><i class=\"icon-double-angle-right\"></i>写站内信</a></li>";
                }
                if (per.ModuleKey == Common.Module_Message && per.PermissionsId == Common.Permission_View)
                {
                    menumessagelist = "<li id=\"menumessagelist\"><a href=\"inbox.aspx\"><i class=\"icon-double-angle-right\"></i>收件箱</a></li>";
                }
                if (per.ModuleKey == Common.Module_Car && per.PermissionsId == Common.Permission_Add)
                {
                    menucar = "<li id=\"menucar\"><a href=\"carlist.aspx\"><i class=\"icon-dashboard\"></i><span class=\"menu-text\">车型管理 </span></a></li>";
                }
                if (per.ModuleKey == Common.Module_Admin && per.PermissionsId == Common.Permission_Add)
                {
                    menuadminadd = "<li id=\"menuadminadd\"><a href=\"adminadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增用户</a></li>";
                }
                if (per.ModuleKey == Common.Module_Admin && per.PermissionsId == Common.Permission_View)
                {
                    menuadminlist = "<li id=\"menuadminlist\"><a href=\"adminlist.aspx\"><i class=\"icon-double-angle-right\"></i>用户列表</a></li>";
                }
                if (per.ModuleKey == Common.Module_Role && per.PermissionsId == Common.Permission_Add)
                {
                    menuroleadd = "<li id=\"menuroleadd\"><a href=\"roleadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增角色</a></li>";
                }
                if (per.ModuleKey == Common.Module_Role && per.PermissionsId == Common.Permission_View)
                {
                    menurolelist = "<li id=\"menurolelist\"><a href=\"rolelist.aspx\"><i class=\"icon-double-angle-right\"></i>角色列表</a></li>";
                }
                if (per.ModuleKey == Common.Module_Feedback && per.PermissionsId == Common.Permission_Add)
                {
                    menufeedbackadd = "<li id=\"menufeedbackadd\"><a href=\"feedbackadd.aspx\"><i class=\"icon-double-angle-right\"></i>提交反馈</a></li>";
                }
                if (per.ModuleKey == Common.Module_Feedback && per.PermissionsId == Common.Permission_View)
                {
                    menufeedbacklist = "<li id=\"menufeedbacklist\"><a href=\"feedbacklist.aspx\"><i class=\"icon-double-angle-right\"></i>反馈列表</a></li>";
                }

                if (per.ModuleKey == Common.Module_News && per.PermissionsId == Common.Permission_Add)
                {
                    meunnewsadd = "<li id=\"meunnewsadd\"><a href=\"newsadd.aspx\"><i class=\"icon-double-angle-right\"></i>添加资讯</a></li>";
                }

                if (per.ModuleKey == Common.Module_News && per.PermissionsId == Common.Permission_View)
                {
                    meunnewslist = "<li id=\"meunnewslist\"><a href=\"newslist.aspx\"><i class=\"icon-double-angle-right\"></i>资讯列表</a></li>";
                }

                if (per.ModuleKey == Common.Module_Product && per.PermissionsId == Common.Permission_Add)
                {
                   // menuproductadd = "<li id=\"menuproductadd\"><a href=\"productadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增编码(卷轴号)</a></li>";
                }
                if (per.ModuleKey == Common.Module_Product && per.PermissionsId == Common.Permission_Add)
                {
                   // menuproductimport = "<li id=\"productimport\"><a href=\"productimport.aspx\"><i class=\"icon-double-angle-right\"></i>模板下载/编码(卷轴号)导入</a></li>";
                }
                if (per.ModuleKey == Common.Module_Product && per.PermissionsId == Common.Permission_View)
                {
                    menuproductlist = "<li id=\"menuproductlist\"><a href=\"productlist.aspx\"><i class=\"icon-double-angle-right\"></i>编码(卷轴号)列表</a></li>";
                }
                if (per.ModuleKey == Common.Module_Product_Verify && per.PermissionsId == Common.Permission_Add)
                {
                    menuproductverify = "<li id=\"menuproductverify\"><a href=\"productverify.aspx\"><i class=\"icon-double-angle-right\"></i>产品(卷轴号)认证</a></li>";
                }

                if (per.ModuleKey == Common.Module_Promotion && per.PermissionsId == Common.Permission_Add)
                {
                    menupromotionadd = "<li id=\"menupromotionadd\"><a href=\"promotionadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增促销</a></li>";
                }
                
                if (per.ModuleKey == Common.Module_Promotion && per.PermissionsId == Common.Permission_View)
                {
                    menupromotionlist = "<li id=\"menupromotionlist\"><a href=\"promotionlist.aspx\"><i class=\"icon-double-angle-right\"></i>促销列表</a></li>";
                }

                if (per.ModuleKey == Common.Module_User && per.PermissionsId == Common.Permission_Add)
                {
                    menuuseradd = "<li id=\"menuuseradd\"><a href=\"useradd.aspx\"><i class=\"icon-double-angle-right\"></i>新增太阳膜客户</a></li>";
                    menuuseradd += "<li id=\"menuusertadd\"><a href=\"usertadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增漆面客户</a></li>";
                    menuuseradd += "<li id=\"menubuildskinadd\"><a href=\"userbuildskinadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增建筑膜客户</a></li>";
                    menuuseradd += "<li id=\"menucolorskinadd\"><a href=\"usercolorskinadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增改色膜客户</a></li>";
                    mechanicadd = "<li id=\"mechanicadd\"><a href=\"mechanicadd.aspx\"><i class=\"icon-double-angle-right\"></i>新增技师</a></li>";
                }
                if (per.ModuleKey == Common.Module_User && per.PermissionsId == Common.Permission_View)
                {
                    menuuserlist = "<li id=\"menuuserlist\"><a href=\"userlist.aspx\"><i class=\"icon-double-angle-right\"></i>客户列表</a></li>";
                    mechaniclist = "<li id=\"mechaniclist\"><a href=\"mechaniclist.aspx\"><i class=\"icon-double-angle-right\"></i>技师列表</a></li>";

                }

                if (per.ModuleKey==Common.Module_Compensate&&per.PermissionsId==Common.Permission_View)
                {
                    menupcompensatelist = "<li id=\"compensateList\"><a href=\"CompensateList.aspx\"><i class=\"icon-double-angle-right\"></i>理赔列表</a></li>";
                }
                if (per.ModuleKey==Common.Module_Compensate&&per.PermissionsId==Common.Permission_Add)
                {
                    menupcompensateadd = "<li id=\"compensateAdd\"><a href=\"CompensateAdd.aspx\"><i class=\"icon-double-angle-right\"></i>申请理赔</a></li>";
                }
            }
        }
    }

}
