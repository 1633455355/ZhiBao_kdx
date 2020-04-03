using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class StoreBLL
{
    private StoreDAL sd;
    public StoreBLL()
    {
        sd = new StoreDAL();
    }
    /// <summary>
    /// 添加加盟店数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string AddStoreInfo(StoreModel oAModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = sd.AddStoreInfo(oAModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.StoreBLL.AddStoreInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新加盟店数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string SetStoreInfo(StoreModel oAModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = sd.SetStoreInfo(oAModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.StoreBLL.SetStoreInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 删除加盟店数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string RemoveStoreInfo(int AdminId)
    {
        string ret = Config.Fail;
        try
        {
            ret = sd.RemoveStoreInfo(AdminId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.StoreBLL.RemoveDealerInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 得到加盟店列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetStoreModelList(int PageIndex, int PageNum, int? AdminId, string StoreName,int? DealerId, out int Count, out List<StoreModel> olist)
    {
        olist = new List<StoreModel>();
        Count = 0;
        string where = " 1=1";
        if (AdminId != null)
        {
            where += " and StoreInfo.AdminId=" + AdminId.Value;
        }
        if (!String.IsNullOrEmpty(StoreName))
        {
            where += " and StoreInfo.StoreName like '%" + StoreName + "%'";
        }
        if(DealerId!=null)
        {
            where += " and StoreInfo.DealerId=" + DealerId.Value;
        }
        try
        {
            olist = sd.GetStoreModelList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.StoreBLL.GetStoreModelList()", ex);
            return Config.ExceptionMsg;
        }
    }
}
