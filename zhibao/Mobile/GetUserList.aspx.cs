using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Mobile_GetUserList : System.Web.UI.Page
{
    public string style = "";
    public string nav = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["type"] != null)
        {
            //style = "<style>body {zoom:1;}</style>";
            nav = " <div class=\"nav\" ><span class=\"crr\" id=\"s0\"><a href=\"mobileadduser.aspx?s=0&type=" + Request["type"].ToString() + "\">质保录入</a></span><span class=\"w34\" id=\"s1\"><div><a  href=\"GetUserInfoByMobile.aspx?s=1&type=" + Request["type"].ToString() + "\"> 质保查询</a></div></span><span id=\"s2\"><a href=\"GetStoreUserList.aspx?s=2&type=" + Request["type"].ToString() + "\">业务查询</a></span> </div>";
        }
        if (!Page.IsPostBack)
        {
            Content.Text = "";
            string mob = Request["mobile"];
            string car = Request["car"];
            mobileTxt.Text = mob;
            carTxt.Text = car;
            GetList(mob, car);
           
        }
        
       
    }
    private void GetList(string mobile,string car)
    {
        List<UserModel> olist = null;
        int count = 0;
        if (String.IsNullOrWhiteSpace(mobile))
        {
            mobile = null;
        }
        if (String.IsNullOrWhiteSpace(car))
        {
            car = null;
        }
        UserBLL user = new UserBLL();
        string ret = user.GetUserList(1, 10000000, null, car, null, mobile, out count, out olist);
        StringBuilder html = new StringBuilder();
        if(olist!=null &&olist.Count>0)
        {
            int i = 0;
            foreach(UserModel o in olist)
            {
                html.Append("<p class=\"name\">车主姓名："+o.UserName+"</p>");
                if (i == 0)
                {
                    html.Append("<dl class=\"now\" id=\"dd" + i + "\">");
                }
                else
                {
                    html.Append("<dl id=\"dd" + i + "\">");
                }
                html.Append("<dt>");
                html.Append("<strong>" + o.CreateTime.ToString("yyyy年MM年dd日") + "</strong>");
                html.Append("<a href=\"javascript:void(0)\" onclick=\"Display('dd" + i + "')\"></a>");
                html.Append("</dt>");
                html.Append("<dd>");
                html.Append("<ul>");
                html.Append("<li><span>贴膜门店名称：</span><em>" + o.StoreName + "</em></li>");
                html.Append("<li><span>贴膜类型：</span><em>" + o.F_ProductTypeName + "-" + o.S_ProductTypeName + "</em></li>");
                html.Append("</ul>");
                html.Append("</dd>");
                html.Append("</dl>");
                i++;

            }
            Content.Text = html.ToString();
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Content.Text = "";
        GetList(mobileTxt.Text, carTxt.Text);
    }
}