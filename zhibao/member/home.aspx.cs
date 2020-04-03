using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_home : Page
{
  
    public string reporthead = string.Empty;
    public string reportbody = string.Empty;

    public string promohead = string.Empty;
    public string promobody = string.Empty;


    public string newsbody = string.Empty;
    public string fbbody = string.Empty;
    AdminModel user;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Common.GetLoginAdmin(HttpContext.Current);
       // this.LoadReport();
        this.LoadPromo();
        this.LoadNews();
        this.LoadFeedback();
        
    }

    private void LoadReport()
    {
        int total = 0;
        int dealer = 0;
        int store = 0;
        int used = 0;
        if (Common.CheckPermission(Common.Module_Report, Common.Permission_View, HttpContext.Current))
        {
            ReportBLL rb = new ReportBLL();
            if (user.Type == AdminType.Managers)
            {
                reporthead = "<tr><th>总商品码（卷）</th><th>经销商认证（卷）</th><th>门店认证（卷）</th><th>贴车数（台）</th></tr>";
                DataSet ds = null;
                rb.GetReport(0,0,0,0,DateTime.Now.AddYears(-100), DateTime.Now.AddYears(1), AdminType.Managers, user.AdminId, out ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        total = total + Convert.ToInt32(ds.Tables[0].Rows[i]["Total"]);
                        dealer = dealer + Convert.ToInt32(ds.Tables[0].Rows[i]["DealerTotal"]);
                        store = store + Convert.ToInt32(ds.Tables[0].Rows[i]["StoreTotal"]);
                        used = used + Convert.ToInt32(ds.Tables[0].Rows[i]["UserTotal"]);
                    }
                }
                reportbody = "<tr><td>" + total + "</td><td>" + dealer + "</td><td>" + store + "</td><td>" + used + "</td></tr>";

            }
            else if (user.Type == AdminType.Dealer)
            {
                reporthead = "<tr><th>经销商认证（卷）</th><th>门店认证（卷）</th><th>贴车数（台）</th></tr>";
                DataSet ds = null;
                rb.GetReport(0,0,user.AdminId,0,DateTime.Now.AddYears(-100), DateTime.Now.AddYears(1), AdminType.Dealer, user.AdminId, out ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dealer = dealer + Convert.ToInt32(ds.Tables[0].Rows[i]["DealerTotal"]);
                        store = store + Convert.ToInt32(ds.Tables[0].Rows[i]["StoreTotal"]);
                        used = used + Convert.ToInt32(ds.Tables[0].Rows[i]["UserTotal"]);
                    }
                }
                reportbody = "<tr><td>" + dealer + "</td><td>" + store + "</td><td>" + used + "</td></tr>";
            }
            else if (user.Type == AdminType.Stores)
            {
                reporthead = "<tr><th>门店认证（卷）</th><th>贴车数（台）</th></tr>";
                DataSet ds = null;
                rb.GetReport(0,0,0,user.AdminId,DateTime.Now.AddYears(-100), DateTime.Now.AddYears(1), AdminType.Stores, user.AdminId, out ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        store = store + Convert.ToInt32(ds.Tables[0].Rows[i]["StoreTotal"]);
                        used = used + Convert.ToInt32(ds.Tables[0].Rows[i]["UserTotal"]);
                    }
                }
                reportbody = "<tr><td>" + store + "</td><td>" + used + "</td></tr>";
            }
        }
        else
        {
           // reportpl.Visible = false;
        }
    }
    private void LoadPromo()
    {
        PromotionBLL pb = new PromotionBLL();
        int total = 0;
        List<PromotionModel> list = new List<PromotionModel>();
        if (Common.CheckPermission(Common.Module_Promotion, Common.Permission_View, HttpContext.Current))
        {
            promohead = "<tr><th>日期</th><th>标题</th></tr>";
            try
            {
                if (user.Type == AdminType.Dealer)
                {
                    pb.GetPromotionList(1, 5, null, null, user.AdminId, null, out total, out list);
                }
                else if (user.Type == AdminType.Stores)
                {
                    pb.GetPromotionList(1, 5, null, null, null, user.AdminId, out total, out list);
                }
                else
                {
                    pb.GetPromotionList(1, 5, null, null, null, null, out total, out list);
                }

                if (list.Count > 0)
                {
                    for(int i=0;i<list.Count;i++)
                    {
                        PromotionModel model = list[i];
                        promobody = promobody + "<tr><td>" + model .CreateTime+ "</td><td><a target=\"_blank\" href=\"promotion.aspx?id="+model.PromotionId+"\">"+model.Title+"</a></td></tr>";
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("LoadPromo", ex);
            }
        }
        else
        {
            promopl.Visible = false;
        }
    }
    private void LoadFeedback()
    {
        FeedBackBLL fbb = new FeedBackBLL();
        int total = 0;
        List<FeedBackModel> list = new List<FeedBackModel>();
        if (Common.CheckPermission(Common.Module_Feedback, Common.Permission_View, HttpContext.Current))
        {
            try
            {
                if (user.Type == AdminType.Managers)
                {
                    fbb.GetFeedBackList(1, 5, null, null, null, null, null, out total, out list);
                }
                else
                {
                    fbb.GetFeedBackList(1, 5, null, null, null, user.AdminId, true, out total, out list);
                }

                for(int i =0;i<list.Count;i++)
                {
                    FeedBackModel model=list[i];
                    fbbody = fbbody + "<tr><td>" + model.CreateTime + "</td><td><a target=\"_blank\" href=\"feedback.aspx?id=" + model.Title + "\">" + model.Title + "</a></td></tr>";
                }
                
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("LoadFeedback", ex);
            }
        }
        else
        {
            feedbackpl.Visible = false;
        }
    }
    
    private void LoadNews()
    {
        int total = 0;
        List<NewsModel> list = new List<NewsModel>();
        if (Common.CheckPermission(Common.Module_News, Common.Permission_View, HttpContext.Current))
        {
            try
            {
                NewsBLL nb = new NewsBLL();
                nb.GetNewsList(1, 5, null, null, out total, out list);

                for(int i=0;i<list.Count;i++)
                {
                    NewsModel model = list[i];
                    newsbody = newsbody + "<tr><td>" + model.CreateTime + "</td><td><a target=\"_blank\" href=\"news.aspx?id=" + model.NewsId + "\">" + model.Title + "</a></td></tr>";
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("LoadNews", ex);
            }   
        }
        else
        {
            newspl.Visible = false;
        }
    }


}