using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Feedback, Common.Permission_View, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            string idstr = Request.QueryString["id"];
            int id = 0;
            int.TryParse(idstr, out id);
            if (id > 0)
            {
                FeedBackBLL fbb = new FeedBackBLL();
                int total = 0;
                List<FeedBackModel> list = new List<FeedBackModel>();
                fbb.GetFeedBackList(1, 1, id, null,null,null,null,out total, out list);
                if (list.Count == 1)
                {
                    FeedBackModel model = list[0];
                    title_txt.Text = model.Title;
                    content_txt.Text = model.Content;
                    contact_txt.Text = model.Name;
                    mobile_txt.Text = model.Mobile;
                    email_txt.Text = model.Email;
                    date_txt.Text = string.Format("{0:yyyy-MM-dd}", model.CreateTime);
                }
            }
        }
    }
}