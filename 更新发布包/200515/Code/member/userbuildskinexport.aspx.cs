using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class member_userbuildskinexport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        exportUser();
    }
    public void exportUser()
    {

        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        int total = 0;
        List<UserModel> list = new List<UserModel>();
        try
        {
            string code = Request["Code"];
            string firstType ="6";
            string brand =Request["Brand"];
            string dealer =Request["Dealer"];
            string store =Request["Store"];
            int? firstTypeid = null;
            if (firstType != null && !string.IsNullOrWhiteSpace(firstType))
            {
                firstTypeid = Convert.ToInt32(firstType);
            }
            int? brandid = null;
            if (brand != null && !string.IsNullOrWhiteSpace(brand))
            {
                brandid = Convert.ToInt32(brand);
            }
            int? storeid = null;
            if (store != null && !string.IsNullOrWhiteSpace(store))
            {
                storeid = Convert.ToInt32(store);
            }
            UserBLL ub = new UserBLL();
            if (user.Type == AdminType.Managers)
            {
                ub.GetUserList(1, 100000000, null, code, storeid, firstTypeid, brandid, dealer, out total, out list);
            }
            else if (user.Type == AdminType.Stores)
            {
                ub.GetUserList(1, 1000000, null, code, user.AdminId, firstTypeid, brandid, null, out total, out list);
            }

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=user_" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.ContentType = "application/excel";
            StringBuilder sb = new StringBuilder();
            sb.Append("经销商,店面,品牌型号,卷轴号,姓名,手机,邮箱,省,市,地址,时间\r\n");

            foreach (UserModel o in list)
            {
                sb.Append("\"" +o.DealerName + "\"" + ",");
                sb.Append("\"" +o.StoreName + "\"" + ",");
                sb.Append("\"" + o.S_ProductTypeName+ "\"" + ",");
                sb.Append("\"" + o.ProductCode + "\"" + ",");
                
                sb.Append("\"" +o.UserName + "\"" + ",");
                sb.Append("\"" + o.Mobile + "\"" + ",");
                sb.Append("\"" + o.Email + "\"" + ",");
               
                sb.Append("\"" + o.ProvinceName + "\"" + ",");
                sb.Append("\"" + o.CityName + "\"" + ",");
               
               
                sb.Append("\"" + o.Address + "\"" + ",");
              
                sb.Append("\"" +o.CreateTime + "\"" + "\r\n");

            }

            Response.Write(sb.ToString());
            Response.End();


        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("InportUser", ex);
        }
    }
}