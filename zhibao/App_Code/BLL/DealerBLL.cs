using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DealerBLL
{

    private DealerDAL dd;
    public DealerBLL()
    {
        dd = new DealerDAL();
    }
    /// <summary>
    /// 添加经销商数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string AddDealerInfo(DealerModel oAModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = dd.AddDealerInfo(oAModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.AddDealerInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
        /// <summary>
    /// 更新经销商数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string SetDealerInfo(DealerModel oAModel)
    {
        string ret = Config.Fail;
        try
        {
            ret =dd.SetDealerInfo(oAModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.SetDealerInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
        /// <summary>
    /// 删除经销商数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string RemoveDealerInfo(int DealerId)
    {
        string ret = Config.Fail;
        try
        {
            ret = dd.RemoveDealerInfo(DealerId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.RemoveDealerInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

        /// <summary>
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetDealerModelList(int PageIndex, int PageNum, int? DealerId, string CompanyName,out int Count, out List<DealerModel> olist)
    {
        olist = new List<DealerModel>();
        Count = 0;
        string where = " 1=1";
        if (DealerId != null)
        {
            where += " and DealerInfo.AdminId=" + DealerId.Value;
        }
        if (!String.IsNullOrEmpty(CompanyName))
        {
            where += " and DealerInfo.DealerCompanyName like '%" + CompanyName + "%'";
        }
        try
        {
            olist = dd.GetDealerModelList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.Authorization.AdminBLL.GetDealerModelList()", ex);
            return Config.ExceptionMsg;
        }
    }
}

