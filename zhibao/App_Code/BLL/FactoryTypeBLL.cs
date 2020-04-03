using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FactoryTypeBLL 的摘要说明
/// </summary>
public class FactoryTypeBLL
{
    private FactoryTypeDAL ftd = null;
	public FactoryTypeBLL()
	{
        ftd = new FactoryTypeDAL();
	}
    /// <summary>
    /// 加厂家类别
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string AddFactoryTypeInfo(string FactoryTypeName,string ProductSecondLevelNameDefalut, int CreatorId, out int FactoryType)
    {
        string ret = Config.Fail;
        FactoryType=0;
        try
        {
            ret = ftd.AddFactoryTypeInfo(FactoryTypeName,ProductSecondLevelNameDefalut,CreatorId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                FactoryType = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FactoryTypeBLL.AddFactoryTypeInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    ///更新厂家类别
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string SetFactoryTypeInfo(string FactoryTypeName,string ProductSecondLevelNameDefalut,int FactoryTypeId)
    {
        string ret = Config.Fail;
        try
        {
            ret = ftd.SetFactoryTypeInfo(FactoryTypeName,ProductSecondLevelNameDefalut, FactoryTypeId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FactoryTypeBLL.SetFactoryTypeInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 删除厂家类别
    /// </summary>
    /// <param name="FactoryTypeId"></param>
    /// <returns></returns>
    public string RemoveFactoryTypeInfo(int FactoryTypeId)
    {
        string ret = Config.Fail;
        try
        {
            ret = ftd.RemoveFactoryTypeInfo(FactoryTypeId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FactoryTypeBLL.RemoveFactoryTypeInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    ///得到厂家类别
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string GetFactoryTypeInfo(int? ProductFirstLevelId, out List<FactoryTypeModel> olist)
    {
        olist = new List<FactoryTypeModel>();
        try
        {
            olist = ftd.GetFactoryTypeInfo(ProductFirstLevelId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FactoryTypeBLL.GetFactoryTypeInfo()", ex);
            return Config.ExceptionMsg;
        }
    }


    /// <summary>
    ///得到厂家类别未被使用过的
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string GetFactoryTypeInfoByNotUsed(out List<FactoryTypeModel> olist)
    {
        olist = new List<FactoryTypeModel>();
        try
        {
            olist = ftd.GetFactoryTypeInfoByNotUsed();
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FactoryTypeBLL.GetFactoryTypeInfoByNotUsed()", ex);
            return Config.ExceptionMsg;
        }
    }
}