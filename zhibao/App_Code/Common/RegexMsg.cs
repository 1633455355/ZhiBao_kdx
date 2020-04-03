using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// RegexMsg 的摘要说明
/// </summary>
public class RegexMsg
{
    /// <summary>
    /// 防止SQL注入
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string StrRegex(string values)
    {
        string str = values;
        if (Regex.IsMatch(values, @"[;|,|/|(|)|[|]|}|{|%|!|']", RegexOptions.IgnoreCase))
        {
            str = Regex.Replace(values, @"[;|,|/|(|)|[|]|}|{|%|!|']", "", RegexOptions.IgnoreCase);
        }
        return str;
    }
}