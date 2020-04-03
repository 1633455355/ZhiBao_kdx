using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NewsBLL 的摘要说明
/// </summary>
public class NewsBLL
{
    private NewsDAL nb = null;
	public NewsBLL()
	{
        nb = new NewsDAL();
	}
    /// <summary>
    /// 添加新闻信息
    /// </summary>
    /// <param name="oRModel"></param>
    /// <returns></returns>
    public string AddNewsInfo(NewsModel oNModel, out int NewsId)
    {
        string ret = Config.Fail;
        NewsId = 0;
        try
        {
            ret = nb.AddNewsInfo(oNModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                NewsId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("NewsBLL.AddNewsInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新新闻信息
    /// </summary>
    /// <param name="oRModel"></param>
    /// <returns></returns>
    public string SetNewsInfo(NewsModel oNModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = nb.SetNewsInfo(oNModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("NewsBLL.SetNewsInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 删除新闻
    /// </summary>
    /// <param name="NewsId"></param>
    /// <returns></returns>
    public string RemoveNewsInfo(int NewsId)
    {
        string ret = Config.Fail;
        try
        {
            ret = nb.RemoveNewsInfo(NewsId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("NewsBLL.RemoveNewsInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 得到新闻列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="NewsId"></param>
    /// <param name="Title"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetNewsList(int PageIndex, int PageNum, int? NewsId, string Title, out int Count, out List<NewsModel> olist)
    {
        olist = new List<NewsModel>();
        Count = 0;
        string where = " 1=1";
        if (NewsId != null)
        {
            where += " and NewsInfo.NewsId=" + NewsId.Value;
        }
        if (!String.IsNullOrEmpty(Title))
        {
            where += " and NewsInfo.Title like '%" + Title + "%'";
        }
        try
        {
            olist = nb.GetNewsList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("NewsBLL.GetNewsList()", ex);
            return Config.ExceptionMsg;
        }
    }
}