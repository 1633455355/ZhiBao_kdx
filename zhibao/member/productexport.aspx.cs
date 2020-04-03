using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class member_productexport : System.Web.UI.Page
{
    private ProductBLL pb = new ProductBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        exportproduct();
    }
    public void exportproduct()
    {

        AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
        int total = 0;
        List<ProductModel> list = new List<ProductModel>();  
        try
        {
            string typeone = Request["TypeOne"];
            int? typeoneid = null;
            if (!string.IsNullOrWhiteSpace(typeone))
            {
                typeoneid = Convert.ToInt32(typeone);
            }

            string typetow = Request["TypeTwo"];
            int? typetwoid = null;
            if (!string.IsNullOrWhiteSpace(typetow))
            {
                typetwoid = Convert.ToInt32(typetow);
            }

            string status = Request["Status"];
            int? statusid = null;
            if (!string.IsNullOrWhiteSpace(status))
            {
                statusid = Convert.ToInt32(status);
            }
            string code = Request["Code"];
          
            string dealer = Request["Dealer"];
            int? dealerid = null;
            if (dealer != null && !string.IsNullOrWhiteSpace(dealer))
            {
                dealerid = Convert.ToInt32(dealer);
            }

            string store = Request["Store"];
            int? storeid = null;
            if (store != null && !string.IsNullOrWhiteSpace(store))
            {
                storeid = Convert.ToInt32(store);
            }
            string dealer_flag =Request["dealer_flag"];
            int? dealer_flagId = null;
            if (dealer_flag != null && !string.IsNullOrWhiteSpace(dealer_flag))
            {
                dealer_flagId = Convert.ToInt32(dealer_flag);
            }
            string store_flag =Request["store_flag"];
            int? store_flagId = null;
            if (store_flag != null && !string.IsNullOrWhiteSpace(store_flag))
            {
                store_flagId = Convert.ToInt32(store_flag);
            }

            if (user.Type == AdminType.Managers)
            {
                pb.GetProductInfoList(1, 1000000000, typeoneid, typetwoid, code, dealerid, storeid, statusid, null, dealer_flagId, store_flagId, out total, out list);
            }
            else if (user.Type == AdminType.Dealer)
            {
                pb.GetProductInfoList(1, 1000000000, typeoneid, typetwoid, code, user.AdminId, storeid, statusid, null, dealer_flagId, store_flagId, out total, out list);
            }
            else if (user.Type == AdminType.Stores)
            {
                pb.GetProductInfoList(1, 1000000000, typeoneid, typetwoid, code, dealerid, user.AdminId, statusid, null, dealer_flagId, store_flagId, out total, out list);
            }


            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=proudct_" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.ContentType = "application/excel";
            StringBuilder sb = new StringBuilder();
            sb.Append("类别,品牌型号,状态,卷轴号,经销商名称,经销商认证时间,门店名称,门店认证时间,质保年限,经销商是否审核通过,导入时间\r\n");

            foreach (ProductModel o in list)
            {
                sb.Append("\"" + o.ProductFirstLevelName + "\"" + ",");
                sb.Append("\"" + o.ProductSecondLevelName + "\"" + ",");
                if (o.Status == 0)
                {
                    sb.Append("\"未认证\"" + ",");
                }
                else if (o.Status == 1)
                {
                    sb.Append("\"经销商认证\"" + ",");
                }
                else if (o.Status == 2)
                {
                    sb.Append("\"门店认证\"" + ",");
                }
                else if (o.Status == 3)
                {
                    sb.Append("\"使用完毕\"" + ",");
                }
                sb.Append("\"" + o.ProductCode + "\"" + ",");
                sb.Append("\"" + o.DealerName + "\"" + ",");
                if (o.Dealer_CreateTime.ToString("yyyy-MM-dd") != "0001-01-01")
                {
                    sb.Append("\"" + o.Dealer_CreateTime + "\"" + ",");
                }
                else
                {
                    sb.Append("\"\"" + ",");
                }
                sb.Append("\"" + o.StoreName + "\"" + ",");
                if (o.Store_CreateTime.ToString("yyyy-MM-dd")!= "0001-01-01")
                {
                    sb.Append("\"" + o.Store_CreateTime + "\"" + ",");
                }
                else
                {
                    sb.Append("\"\"" + ",");
                }
               
                sb.Append("\"" + o.ProductDes + "\"" + ",");
                if (o.Dealer_Flag == 1)
                {
                    sb.Append("\"经销商认证审核通过\"" + ",");
                }
                else if(o.Dealer_Flag == 2)
                {
                    sb.Append("\"经销商认证审核未通过\"" + ",");
                }
                else
                {
                    sb.Append("\"等待审核\"" + ",");
                }
                sb.Append("\"" + o.CreateTime + "\"" + "\r\n");

            }

            Response.Write(sb.ToString());
            Response.End();


        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("exportproduct", ex);
        }
    }
}