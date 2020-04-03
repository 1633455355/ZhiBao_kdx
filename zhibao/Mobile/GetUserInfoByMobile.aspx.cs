using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mobile_GetUserInfoByMobile : System.Web.UI.Page
{
    public string style = "";
    public string type = "";
    public string nav = "";
    public string s = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["type"] != null)
        {
            //style = "<style>body {zoom:1;}</style>";
            type = "<input type=\"hidden\" value=\"app\" name=\"type\" id=\"type\" />";
         
            nav = " <div class=\"nav\" ><span class=\"crr\" id=\"s0\"><a href=\"mobileadduser.aspx?s=0&type=" + Request["type"].ToString() + "\">质保录入</a></span><span class=\"w34\" id=\"s1\"><div><a  href=\"GetUserInfoByMobile.aspx?s=1&type=" + Request["type"].ToString() + "\"> 质保查询</a></div></span><span id=\"s2\"><a href=\"GetStoreUserList.aspx?s=2&type=" + Request["type"].ToString() + "\">业务查询</a></span> </div>";
        }
        if(Request["s"]!=null)
        {
            s = "<input type=\"hidden\" value=\""+Request["s"].ToString()+"\" name=\"s\" id=\"s\" />";
        }
    }
}