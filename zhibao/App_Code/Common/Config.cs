using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.IO;


/// <summary>
/// Config 的摘要说明
/// </summary>
public class Config
{
    private static bool noCache = true;
    private static JObject BuildItems()
    {
        var json = File.ReadAllText(HttpContext.Current.Server.MapPath("config.json"));
        return JObject.Parse(json);
    }

    public static JObject Items
    {
        get
        {
            if (noCache || _Items == null)
            {
                _Items = BuildItems();
            }
            return _Items;
        }
    }
    private static JObject _Items;


    public static T GetValue<T>(string key)
    {
        return Items[key].Value<T>();
    }

    public static String[] GetStringList(string key)
    {
        return Items[key].Select(x => x.Value<String>()).ToArray();
    }

    public static String GetString(string key)
    {
        return GetValue<String>(key);
    }

    public static int GetInt(string key)
    {
        return GetValue<int>(key);
    }

    /// <summary>
    /// 公司名称
    /// </summary>
    public static string CompanyName
    {
        get
        {
            return ConfigurationManager.AppSettings["Company"];
        }
    }
    /// <summary>
    /// 日志地址
    /// </summary>
    public static string LogPath
    {
        get
        {
            return ConfigurationManager.AppSettings["LogPath"];
        }
    }
    /// <summary>
    /// 数据库连接串
    /// </summary>
    public static string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
    /// <summary>
    /// 缓存时间
    /// </summary>
    public static int Time
    {
        get
        {
            return int.Parse(ConfigurationManager.AppSettings["Time"]);
        }
    }
    /// <summary>
    /// 加密串
    /// </summary>
    public static string DESString
    {
        get
        {
            return ConfigurationManager.AppSettings["DESString"];
        }
    }
    /// <summary>
    ///成功
    /// </summary>
    public static string Success = "0";
    /// <summary>
    /// 抛出异常
    /// </summary>
    public static string ExceptionMsg = "-4";
    /// <summary>
    /// 失败
    /// </summary>
    public static string Fail = "-3";
    /// <summary>
    /// 缓存KEY值
    /// </summary>
    public static string CacheKey = "CacheKey_";
    /// <summary>
    /// 特殊字符出来路径
    /// </summary>
    public static string XMLPath
    {
        get
        {
            return ConfigurationManager.AppSettings["XMLPath"];
        }
    }

    public static string GUNo
    {
        get
        {
            return System.Guid.NewGuid().ToString(); 
        }
    }
}