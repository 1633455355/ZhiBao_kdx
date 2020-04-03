using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.CheckPermission(Common.Module_News, Common.Permission_View, HttpContext.Current))
        {
            string idstr = Request.QueryString["id"];
            int id = 0;
            int.TryParse(idstr, out id);
            if (id > 0)
            {
                NewsBLL nb = new NewsBLL();
                int total = 0;
                List<NewsModel> list = new List<NewsModel>();
                nb.GetNewsList(1, 1, id, null, out total, out list);
                if (list.Count == 1)
                {
                    NewsModel model = list[0];
                    title_txt.Text = model.Title;
                    content_txt.Text = model.Content;
                    date_txt.Text = string.Format("{0:yyyy-MM-dd}", model.CreateTime);
                }
            }
        }
        else
        {
            Response.Redirect("nopermission.aspx");
        }
    }
}