using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_promotion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_View, HttpContext.Current))
        {
            string idstr = Request.QueryString["id"];
            int id = 0;
            int.TryParse(idstr, out id);
            if (id > 0)
            {
                PromotionBLL pb = new PromotionBLL();
                int total = 0;
                List<PromotionModel> list = new List<PromotionModel>();
                pb.GetPromotionList(1, 1, id, null,null,null, out total, out list);
                if (list.Count == 1)
                {
                    PromotionModel model = list[0];
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