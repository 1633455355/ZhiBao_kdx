using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OperLogBLL 的摘要说明
/// </summary>
public class OperLogBLL
{
    private OperLogDAL od;
	public OperLogBLL()
	{
        od = new OperLogDAL();
	}
    public string AddOperLog(int AdminId, string Module, string OpeDes)
    {
        string ret = Config.Fail;
        try
        {
            ret = od.AddOperLog(AdminId, Module, OpeDes);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ZB.BLL.AddOperLog.AddOperLog()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
}