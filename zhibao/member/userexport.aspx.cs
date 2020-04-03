using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class member_userexport : System.Web.UI.Page
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
            string firstType =Request["FirstType"];
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
            sb.Append("经销商,店面,前后挡,品牌型号,卷轴号,是否全车,姓名,手机,邮箱,品牌信息,车系信息,车型信息,车牌,省,市,价格,部位,备注,时间\r\n");

            foreach (UserModel o in list)
            {
                sb.Append("\"" +o.DealerName + "\"" + ",");
                sb.Append("\"" +o.StoreName + "\"" + ",");
                sb.Append("\"" + o.F_ProductTypeName + "\"" + ",");
                sb.Append("\"" + o.S_ProductTypeName+ "\"" + ",");
                sb.Append("\"" + o.ProductCode + "\"" + ",");
                if (o.IsQuanCare == 0)
                {
                    sb.Append("\"否\"" + ",");
                }
                else
                {
                    sb.Append("\"是\"" + ",");
                }
                sb.Append("\"" +o.UserName + "\"" + ",");
                sb.Append("\"" + o.Mobile + "\"" + ",");
                sb.Append("\"" + o.Email + "\"" + ",");
                sb.Append("\"" + o.CarBrandCodeName + "\"" + ",");
                sb.Append("\"" + o.CarSysteName + "\"" + ",");
                sb.Append("\"" + o.CarTypeName + "\"" + ",");
                sb.Append("\"" + o.Lincence + "\"" + ",");
                sb.Append("\"" + o.ProvinceName + "\"" + ",");
                sb.Append("\"" + o.CityName + "\"" + ",");
                sb.Append("\"" + o.Price + "\"" + ",");
                if (o.Type == 1)
                {
                    sb.Append("\"机头盖\"" + ",");
                }
                else if (o.Type == 2) { sb.Append("\"单侧前（左/右）叶子板\"" + ","); }
                else if (o.Type == 3) { sb.Append("\"单侧后（左/右）叶子板\"" + ","); }
                else if (o.Type == 4) { sb.Append("\"单车门（左前/左后/右前/右后）\"" + ","); }
                else if (o.Type == 5) { sb.Append("\"车顶\"" + ","); }
                else if (o.Type == 6) { sb.Append("\"车后备箱\"" + ","); }
                else if (o.Type == 7) { sb.Append("\"群边（左下/右下）\"" + ","); }
                else if (o.Type == 8) { sb.Append("\"保险杠（前杠/后杠）\"" + ","); }
                else if (o.Type == 9) { sb.Append("\"B柱\"" + ","); }
                else if (o.Type == 10) { sb.Append("\"倒后镜\"" + ","); }
                else if (o.Type == 11) { sb.Append("\"整车\"" + ","); }
               
                sb.Append("\"" + o.Remark + "\"" + ",");
              
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