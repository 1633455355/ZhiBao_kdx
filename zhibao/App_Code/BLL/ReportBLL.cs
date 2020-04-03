using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// ReportBLL 的摘要说明
/// </summary>
public class ReportBLL
{
    ReportDAL rb = null;
	public ReportBLL()
	{
        rb = new ReportDAL();
	}
    /// <summary>
    /// 统计报表
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="type"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public string GetReport(int firsttype, int secondtype, int dealer, int store, DateTime start, DateTime end, AdminType type,int Id, out DataSet ds)
    {
        ds = new DataSet();
        try
        {
            if(type==AdminType.Managers)
            {
                ds=rb.GetAdminReportInfo(firsttype, secondtype, dealer, store, start, end,Id);
            }
            if(type==AdminType.Dealer)
            {
                ds = rb.GetAdminReportInfo(firsttype, secondtype,Id, store, start, end, Id);
            }
            if(type==AdminType.Stores)
            {
                ds=rb.GetAdminReportInfo(firsttype,secondtype,0,Id, start, end,Id);
            }
            return Config.Success;
        }
        catch(Exception ex)
        {
            WriteLog.WriteExceptionLog("ReportBLL.GetReport()", ex);
            return Config.ExceptionMsg;
        }
    }
}