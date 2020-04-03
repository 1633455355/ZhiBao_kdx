using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MD5 的摘要说明
/// </summary>
public class MD5
{
    /// <summary>
    ///MD5加密
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string SetMD5(string values)
    {
        if (values != null && values != "")
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(values, "MD5");
        }
        return "";
    }
}