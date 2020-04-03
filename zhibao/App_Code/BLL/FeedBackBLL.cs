using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FeedBackBLL 的摘要说明
/// </summary>
public class FeedBackBLL
{
    private FeedBackDAL fbd = null;
	public FeedBackBLL()
	{
        fbd = new FeedBackDAL();
	}
    /// <summary>
    /// 添加反馈信息
    /// </summary>
    /// <param name="oFBModel"></param>
    /// <param name="FeedBackId"></param>
    /// <returns></returns>
    public string AddFeedBackInfo(FeedBackModel oFBModel, out int FeedBackId)
    {
        string ret = Config.Fail;
        FeedBackId = 0;
        try
        {
            ret = fbd.AddFeedBackInfo(oFBModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                FeedBackId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FeedBackBLL.AddFeedBackInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 删除反馈信息
    /// </summary>
    /// <param name="FeedBackId"></param>
    /// <returns></returns>
    public string RemoveFeedBackInfo(int FeedBackId)
    {
        string ret = Config.Fail;
        try
        {
            ret = fbd.RemoveFeedBackInfo(FeedBackId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FeedBackBLL.RemoveFeedBackInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 得到反馈信息列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="FeedBackId"></param>
    /// <param name="Title"></param>
    /// <param name="CreatorId"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetFeedBackList(int PageIndex, int PageNum, int? FeedBackId, string Title,int? CreatorId,int? DealerId,bool? IsdisplayDealer, out int Count, out List<FeedBackModel> olist)
    {
        olist = new List<FeedBackModel>();
        Count = 0;
        string where = " 1=1";
        if (FeedBackId != null)
        {
            where += " and FeedBackInfo.FeedBackId=" + FeedBackId.Value;
        }
        if (!String.IsNullOrEmpty(Title))
        {
            where += " and FeedBackInfo.Title like '%" + Title + "%'";
        }
        if (CreatorId != null)
        {
            where += " and FeedBackInfo.CreatorId=" + CreatorId.Value;
        }
        if (DealerId!=null)
        {
            where += " and FeedBackInfo.CreatorId in (select AdminId from StoreInfo  where DealerId='" + DealerId.Value + "')";
        }
        if(IsdisplayDealer!=null)
        {
            if(IsdisplayDealer.Value){ where += " and FeedBackInfo.IsdisplayDealer=1" ; }
            else {  where += " and FeedBackInfo.IsdisplayDealer=0" ; }
        }
        try
        {
            olist = fbd.GetFeedBackList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("NewsBLL.GetFeedBackList()", ex);
            return Config.ExceptionMsg;
        }
    }
}