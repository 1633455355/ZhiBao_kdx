using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class member_reportexport : System.Web.UI.Page
{
    private ReportBLL rb = new ReportBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        exportreport();
    }
    public void exportreport()
    {
        try
        {
            int FirstType = 0;
            int SecondType = 0;
            int Dealer = 0;
            int Store = 0;
            DateTime start = DateTime.Now.AddYears(-100);
            DateTime end = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(Request["FirstType"]))
            {
                FirstType = int.Parse(Request["FirstType"]);
            }
            if (!string.IsNullOrWhiteSpace(Request["SecondType"]))
            {
                SecondType = int.Parse(Request["SecondType"]);
            }
            if (!string.IsNullOrWhiteSpace(Request["Dealer"]))
            {
                Dealer = int.Parse(Request["Dealer"]);
            }
            if (!string.IsNullOrWhiteSpace(Request["Store"]))
            {
                Store = int.Parse(Request["Store"]);
            }
            if (!string.IsNullOrWhiteSpace(Request["Start"]))
            {
                start = Convert.ToDateTime(Request["Start"]);
            }
            if (!string.IsNullOrWhiteSpace(Request["End"]))
            {
                end = Convert.ToDateTime(Request["End"]);
            }
            AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
            System.Data.DataSet ds = null;

            rb.GetReport(FirstType, SecondType, Dealer, Store, start, end, user.Type, user.AdminId, out ds);


            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=report_" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.ContentType = "application/excel";
            StringBuilder sb = new StringBuilder();
            sb.Append("一级分类,品牌型号,经销商,门店,总商品码（卷）,经销商认证商品码（卷）,门店认证商品码（卷）,贴车数(台)\r\n");

            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                sb.Append("\"" + ds.Tables[0].Rows[i]["ProductFirstLevelName"] + "\"" + ",");
                sb.Append("\"" + ds.Tables[0].Rows[i]["ProductSecondLevelName"] + "\"" + ",");
               
                sb.Append("\"" + ds.Tables[0].Rows[i]["DealerCompanyName"] + "\"" + ",");
                sb.Append("\"" + ds.Tables[0].Rows[i]["StoreName"] + "\"" + ",");
                sb.Append("\"" + ds.Tables[0].Rows[i]["Total"] + "\"" + ",");
                
                sb.Append("\"" + ds.Tables[0].Rows[i]["DealerTotal"] + "\"" + ",");
             

                sb.Append("\"" + ds.Tables[0].Rows[i]["StoreTotal"] + "\"" + ",");
              
                sb.Append("\"" + ds.Tables[0].Rows[i]["UserTotal"] + "\"" + "\r\n");

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