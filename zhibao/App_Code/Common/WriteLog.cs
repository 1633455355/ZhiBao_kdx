using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// WriteLog 的摘要说明
/// </summary>
public class WriteLog
{
    /// <summary>
    /// 写日志
    /// </summary>
    /// <param name="source"></param>
    private static void WriteLogMsg(string source)
    {
        try
        {
            ILog log = LogManager.GetLogger(source);
            log.Info(source);
        }
        catch
        {

        }
    }

    public static void WriteExceptionLog(string ObjName, Exception ex)
    {
        if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
        {
            WriteLogMsg("对象：" + ObjName + "          异常：" + ex.Message);
        }
        if (ex != null && !string.IsNullOrWhiteSpace(ex.StackTrace))
        {
            WriteLogMsg("对象：" + ObjName + "          异常：" + ex.StackTrace);
        }
    }

    public static void WriteMessage(string source)
    {
        WriteLogMsg(source);
    }
}