using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

/// <summary>
/// HtmlManager 的摘要说明
/// </summary>
public class HtmlManager
{
    /// <summary>
    /// 替换特殊HTML标签为编号
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string CovertHTML(string message)
    {
        DataSet oDS = new DataSet();
        if (String.IsNullOrEmpty(message))
        {
            return message;
        }
        try
        {
            if (File.Exists(Config.XMLPath))
            {
                oDS.ReadXml(Config.XMLPath);
                for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                {
                    string temp = oDS.Tables[0].Rows[i]["Key"].ToString().Trim();
                    if (message.IndexOf(temp) >= 0)
                    {
                        message = message.Replace(temp, oDS.Tables[0].Rows[i]["Value"].ToString());
                    }

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return message;
    }
    /// <summary>
    /// 替换特殊HTML编号为标签
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string DecovertHTML(string message)
    {
        DataSet oDS = new DataSet();
        if (String.IsNullOrEmpty(message))
        {
            return message;
        }
        try
        {
            if (File.Exists(Config.XMLPath))
            {
                oDS.ReadXml(Config.XMLPath);
                for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                {
                    string temp = oDS.Tables[0].Rows[i]["Value"].ToString().Trim();
                    if (message.IndexOf(temp) >= 0)
                    {
                        message = message.Replace(temp, oDS.Tables[0].Rows[i]["Key"].ToString());
                    }

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return message;
    }

}