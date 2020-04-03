using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// StringManager 的摘要说明
/// </summary>
public class StringManager
{
    /// <summary>
    /// 转化字符串
    /// </summary>
    /// <param name="IdList"></param>
    /// <returns></returns>
    public static string ConvertString(List<int> IdList)
    {
        if (IdList != null && IdList.Count > 0)
        {
            string sIdList = "";
            for (int i = 0; i < IdList.Count; i++)
            {
                if (i == 0)
                {
                    sIdList = IdList[i].ToString();
                }
                else
                {
                    sIdList += "," + IdList[i].ToString();
                }

            }
            return sIdList;
        }
        return "";
    }
    /// <summary>
    /// 传唤INT
    /// </summary>
    /// <param name="Liststr"></param>
    /// <returns></returns>
    public static List<int> ConvertIntList(string Liststr)
    {
        List<int> IntList = new List<int>();
        int temp = 0;
        string[] sArray = null;
        if (!string.IsNullOrEmpty(Liststr))
        {
            sArray = Liststr.Split(',');
            temp = sArray.Length;
        }
        if (temp == 0)
        {
            return IntList;
        }
        for (int i = 0; i < temp; i++)
        {
            if (!String.IsNullOrWhiteSpace(sArray[i]))
            {
                IntList.Add(int.Parse(sArray[i]));
            }
        }

        return IntList;
    }
    public static List<string> ConvertStringList(string Liststr)
    {
        List<string> IntList = new List<string>();
        int temp = 0;
        string[] sArray = null;
        if (!string.IsNullOrEmpty(Liststr))
        {
            sArray = Liststr.Split(',');
            temp = sArray.Length;
        }
        if (temp == 0)
        {
            return IntList;
        }
        for (int i = 0; i < temp; i++)
        {
            if (!String.IsNullOrWhiteSpace(sArray[i]))
            {
                IntList.Add(sArray[i]);
            }
        }

        return IntList;
    }

    public static void alert(Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "alterMsg", "<script>alert('" + msg + "')</script>)");
    }
}