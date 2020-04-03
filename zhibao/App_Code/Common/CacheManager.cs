using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CacheManager 的摘要说明
/// </summary>
public class CacheManager
{
    /// <summary>
    /// 获取缓存值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static object GetCacheData(string key)
    {
        object o = HttpRuntime.Cache[key];
        return o;
    }
    /// <summary>
    /// 数据放入缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="seconds"></param>
    public static void InserCacheData(string key, object data, int seconds)
    {
        try
        {
            HttpRuntime.Cache.Insert(key, data, null, DateTime.Now.AddSeconds(seconds), TimeSpan.Zero);
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("JNJ.HR.Common.Cache.CacheManager.InserCacheData", ex);
        }
    }
    /// <summary>
    /// 缓存是否存在
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool ExistsCacheData(string key)
    {
        return GetCacheData(key) != null;
    }
    /// <summary>
    /// 删除缓存
    /// </summary>
    /// <param name="key"></param>
    public static void RemoveCacheData(string key)
    {
        try
        {
            if (key != "" && CacheManager.ExistsCacheData(key))
            {
                HttpRuntime.Cache.Remove(key);
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("JNJ.HR.Common.Cache.CacheManager.RemoveCacheData", ex);
        }
    }
}