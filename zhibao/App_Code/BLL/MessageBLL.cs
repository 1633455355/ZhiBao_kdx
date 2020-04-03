using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MessageBLL 的摘要说明
/// </summary>
public class MessageBLL
{
    private MessageDAL md = null;
	public MessageBLL()
	{
        md = new MessageDAL();
	}
    /// <summary>
    ///  添加消息信息
    /// </summary>
    /// <param name="oMModel"></param>
    /// <param name="MessageId"></param>
    /// <returns></returns>
    public string AddMessageInfo(MessageModel oMModel, out int MessageId)
    {
        string ret = Config.Fail;
        MessageId = 0;
        try
        {
            ret = md.AddMessageInfo(oMModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                MessageId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.AddMessageInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }


     /// <summary>
    /// 发所有经销商
    /// </summary>
    /// <param name="oMModel"></param>
    /// <returns></returns>
    public string AddAllDealerMessageInfo(MessageModel oMModel,out int MessageId)
    {
        string ret = Config.Fail;
        MessageId = 0;
        try
        {
            ret = md.AddAllDealerMessageInfo(oMModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                MessageId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.AddAllDealerMessageInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
      /// <summary>
    /// 发所有加盟店
    /// </summary>
    /// <param name="oMModel"></param>
    /// <returns></returns>
    public string AddAllStoreMessageInfo(MessageModel oMModel, out int MessageId)
    {
        string ret = Config.Fail;
        MessageId = 0;
        try
        {
            ret = md.AddAllStoreMessageInfo(oMModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                MessageId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.AddAllStoreMessageInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 删除消息信息
    /// </summary>
    /// <param name="FeedBackId"></param>
    /// <returns></returns>
    public string RemoveMessageInfo(int MessageId)
    {
        string ret = Config.Fail;
        try
        {
            ret = md.RemoveMessageInfo(MessageId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.RemoveMessageInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 根据到达信息的人删除消息
    /// </summary>
    /// <param name="MessageId"></param>
    /// <param name="To"></param>
    /// <returns></returns>
    public string RemoveMessageInfoByTo(int MessageId,int To)
    {
        string ret = Config.Fail;
        try
        {
            ret = md.RemoveMessageInfoTo(MessageId, To);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.RemoveMessageInfoByTo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新已经读了此消息
    /// </summary>
    /// <param name="MessageId"></param>
    /// <param name="IsRead"></param>
    /// <returns></returns>
    public string SetIsReadMessageInfo(int MessageId, bool IsRead)
    {
        string ret = Config.Fail;
        try
        {
            ret = md.SetIsReadMessageInfo(MessageId,IsRead);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.SetIsReadMessageInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 得到消息列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="MessageId"></param>
    /// <param name="Title"></param>
    /// <param name="IsRead"></param>
    /// <param name="From"></param>
    /// <param name="To"></param>
    /// <param name="Count"></param>
    /// <param name="NotReadCount"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetMessageList(int PageIndex, int PageNum, int? MessageId, string Title, bool? IsRead, int? From, int? To, out int Count, out int NotReadCount, out List<MessageModel> olist)
    {
        olist = new List<MessageModel>();
        Count = 0;
        NotReadCount = 0;
        string where = " 1=1";
        if (MessageId != null) { where += " and MessageInfo.MessageId=" + MessageId.Value; }
        if (!String.IsNullOrEmpty(Title)) {  where += " and MessageInfo.Title like '%" + Title + "%'"; }
        if (IsRead!=null){ 
            if(IsRead.Value)
            { where += " and MessageInfo.IsRead=1"; }
            else
            { where += " and MessageInfo.IsRead=0"; }
            
        }
        if (From != null){  where += " and MessageInfo.[From]=" + From.Value; }
        if (To != null) {  where += " and MessageInfo.[To]=" + To.Value; }
        try
        {
            olist = md.GetMessageList(PageIndex, PageNum, where, out Count,out NotReadCount);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("MessageBLL.GetMessageList()", ex);
            return Config.ExceptionMsg;
        }
    }
}