using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserBLL 的摘要说明
/// </summary>
public class UserBLL
{
    private UserDAL ud = null;
	public UserBLL()
	{
        ud = new UserDAL();
	}
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="oUModel"></param>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public string AddUser(UserModel oUModel, out int UserId)
    {
        string ret = Config.Fail;
        UserId = 0;
        try
        {
            ret = ud.AddUser(oUModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                UserId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.AddUser()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    public string Add_T_User(UserModel oUModel, out int UserId)
    {
        string ret = Config.Fail;
        UserId = 0;
        try
        {
            ret = ud.Add_T_User(oUModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                UserId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.Add_T_User()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string SetUser(UserModel oUModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = ud.SetUser(oUModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.SetUser()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string RemoveUser(int UserId)
    {
        string ret = Config.Fail;
        try
        {
            ret = ud.RemoveUser(UserId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.RemoveUser()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="UserId"></param>
    /// <param name="ProductCode"></param>
    /// <param name="StoreId"></param>
    /// <param name="Title"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetUserList(int PageIndex, int PageNum, int? UserId, string ProductCode,int? StoreId,string Title, out int Count, out List<UserModel> olist)
    {
        olist = new List<UserModel>();
        Count = 0;
        string where = " 1=1";
        if (UserId != null)
        {
            where += " and UserInfo.UserId=" + UserId.Value;
        }
        if (!String.IsNullOrEmpty(ProductCode))
        {
            where += " and UserInfo.Licence='" + ProductCode + "'";
        }
        if (StoreId != null)
        {
            where += " and UserInfo.StoreId=" + StoreId.Value;
        }
        if(!String.IsNullOrEmpty(Title))
        {
            where += " and UserInfo.Mobile='" + Title + "'";
        }
        try
        {
            olist = ud.GetUserList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.GetUserList()", ex);
            return Config.ExceptionMsg;
        }
    }

    public string GetUserList(int? StoreId, string start,string end, out int Count, out List<UserModel> olist)
    {
        olist = new List<UserModel>();
        Count = 0;
        string where = " 1=1";
      
        if (StoreId != null)
        {
            where += " and UserInfo.StoreId=" + StoreId.Value;
        }
        if (!String.IsNullOrEmpty(start)&&!String.IsNullOrWhiteSpace(end))
        {
            where += " and UserInfo.CreateTime between '" + start + "' and '"+end+"'";
        }
        try
        {
            olist = ud.GetUserList(1, 1000000000, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.GetUserList1()", ex);
            return Config.ExceptionMsg;
        }
    }

    public string GetUserList(int PageIndex, int PageNum,
      int? UserId,
      string ProductCode,
      int? StoreId,
      int? FirstType,
      int? SecondType,
      string Dealer,
      out int Count, out List<UserModel> olist)
    {
        olist = new List<UserModel>();
        Count = 0;
        string where = " 1=1";
        if (UserId != null)
        {
            where += " and UserInfo.UserId=" + UserId.Value;
        }
        if (!String.IsNullOrEmpty(ProductCode))
        {
            where += " and UserInfo.ProductCode='" + ProductCode + "'";
        }
        if (StoreId != null)
        {
            where += " and UserInfo.StoreId=" + StoreId.Value;
        }
        if (FirstType != null)
        {
            where += " and UserInfo.ProductFirstLevelId=" + FirstType.Value;
        }
        if (SecondType != null)
        {
            where += " and UserInfo.ProductSecondLevelId=" + SecondType.Value;
        }
        if (!String.IsNullOrEmpty(Dealer))
        {
            where += " and DealerInfo.AdminId='" + Dealer + "'";
        }

        try
        {
            olist = ud.GetUserList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.GetUserList()", ex);
            return Config.ExceptionMsg;
        }
    }

    /// <summary>
    /// 添加技师信息
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>

    public string AddMechanic(MechanicModel oMModel, out int MechanicId)
    {
        string ret = Config.Fail;
        MechanicId = 0;
        try
        {
            ret = ud.AddMechanic(oMModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                MechanicId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.AddMechanic()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 更新技师信息
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string SetMechanic(MechanicModel oMModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = ud.SetMechanic(oMModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.SetMechanic()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 删除技师信息
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string RemoveMechanic(int MechanicId)
    {
        string ret = Config.Fail;
        try
        {
            ret = ud.RemoveMechanic(MechanicId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.RemoveMechanic()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 得到技师列表
    /// </summary>
    /// <param name="StoreId"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetMechanicList(int DealerId,int StoreId, out List<MechanicModel> olist)
    {
        olist = new List<MechanicModel>();
        try
        {
            olist = ud.GetMechanicList(DealerId,StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.GetMechanicList()", ex);
            return Config.ExceptionMsg;
        }

    }



    /// <summary>
    /// 得到技师列表
    /// </summary>
    /// <param name="StoreId"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetMechanic(int MechanicId, out MechanicModel o)
    {
        o = new MechanicModel();
        try
        {
            o = ud.GetMechanic(MechanicId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.GetMechanic()", ex);
            return Config.ExceptionMsg;
        }

    }
    public string GetProudctTMeter(string ProductCode, string StoreId)
    {
        try{
            return ud.GetProudctTMeter(ProductCode, StoreId).ToString(); 
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("UserBLL.GetProudctTMeter()", ex);
            return Config.ExceptionMsg;
        }

    }
}