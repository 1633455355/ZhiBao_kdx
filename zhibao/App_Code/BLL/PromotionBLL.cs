using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// PromotionBLL 的摘要说明
/// </summary>
public class PromotionBLL
{
    private PromotionDAL pd = null;
	public PromotionBLL()
	{
        pd = new PromotionDAL();
	}
    /// <summary>
    /// 添加促销信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <param name="PromotionId"></param>
    /// <returns></returns>
    public string AddPromotionInfo(PromotionModel oPModel, out int PromotionId)
    {
        string ret = Config.Fail;
        PromotionId = 0;
        try
        {
            ret = pd.AddPromotionInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                PromotionId = Id;
                if(oPModel.DealerIdList!=null&&oPModel.DealerIdList.Count>0) {
                    foreach(int dealerId in oPModel.DealerIdList) {
                        pd.AddPromotionDealerInfo(PromotionId, dealerId);
                    }
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("PromotionBLL.AddPromotionInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新促销信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetPromotionInfo(PromotionModel oPModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetPromotionInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                if (oPModel.DealerIdList != null && oPModel.DealerIdList.Count > 0) {
                    pd.RemovePromotionDealerInfo(oPModel.PromotionId);
                    foreach (int dealerId in oPModel.DealerIdList) {
                        pd.AddPromotionDealerInfo(oPModel.PromotionId, dealerId);
                    }
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("PromotionBLL.SetPromotionInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 删除促销信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string RemovePromotionInfo(int PromotionId)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.RemovePromotionInfo(PromotionId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0) {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("PromotionBLL.RemovePromotionInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 得到促销信息列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="PromotionId"></param>
    /// <param name="Title"></param>
    /// <param name="DealerId"></param>
    /// <param name="StoreId"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetPromotionList(int PageIndex, int PageNum, int? PromotionId, string Title,int? DealerId,int? StoreId, out int Count, out List<PromotionModel> olist)
    {
        olist = new List<PromotionModel>();
        Count = 0;
        string where = " 1=1";
        if (PromotionId != null)
        {
            where += " and PromotionInfo.PromotionId=" + PromotionId.Value;
        }
        if (!String.IsNullOrEmpty(Title))
        {
            where += " and PromotionInfo.Title like '%" + Title + "%'";
        }
        if (DealerId != null)
        {
            where += " and PromotionInfo.PromotionId in(select PromotionId from Promotion_DealerInfo where DealerId=" + DealerId.Value + ")";
        }
        if(StoreId!=null)
        {
            where += " and PromotionInfo.PromotionId in(select PromotionId from Promotion_DealerInfo where DealerId in(select DealerId from StoreInfo where AdminId=" + StoreId .Value+ "))";
        }
        try
        {
            olist = pd.GetPromotionList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("PromotionBLL.GetPromotionList()", ex);
            return Config.ExceptionMsg;
        }
    }
}