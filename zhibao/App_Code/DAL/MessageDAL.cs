using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// MessageDAL 的摘要说明
/// </summary>
public class MessageDAL
{
    /// <summary>
    /// 添加消息信息
    /// </summary>
    /// <param name="oMModel"></param>
    /// <returns></returns>
    public string AddMessageInfo(MessageModel oMModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Messageid = new SqlParameter("@Messageid", (Object)DBNull.Value);
        _Messageid.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Messageid);

        SqlParameter _Title = new SqlParameter("@Title", oMModel.Title == null ? (Object)DBNull.Value : oMModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", oMModel.Content == null ? (Object)DBNull.Value : oMModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _isRead = new SqlParameter("@isRead", (Object)DBNull.Value);
        _isRead.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_isRead);

        SqlParameter _From = new SqlParameter("@From", oMModel.From);
        _From.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_From);

        SqlParameter _To = new SqlParameter("@To", oMModel.To);
        _To.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_To);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MessageInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 发所有经销商
    /// </summary>
    /// <param name="oMModel"></param>
    /// <returns></returns>
    public string AddAllDealerMessageInfo(MessageModel oMModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "AddDealer");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Messageid = new SqlParameter("@Messageid", (Object)DBNull.Value);
        _Messageid.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Messageid);

        SqlParameter _Title = new SqlParameter("@Title", oMModel.Title == null ? (Object)DBNull.Value : oMModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", oMModel.Content == null ? (Object)DBNull.Value : oMModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _isRead = new SqlParameter("@isRead", (Object)DBNull.Value);
        _isRead.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_isRead);

        SqlParameter _From = new SqlParameter("@From", oMModel.From);
        _From.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_From);

        SqlParameter _To = new SqlParameter("@To", oMModel.To);
        _To.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_To);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MessageInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// <summary>
    /// 发所有加盟店
    /// </summary>
    /// <param name="oMModel"></param>
    /// <returns></returns>
    public string AddAllStoreMessageInfo(MessageModel oMModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "AddStore");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Messageid = new SqlParameter("@Messageid", (Object)DBNull.Value);
        _Messageid.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Messageid);

        SqlParameter _Title = new SqlParameter("@Title", oMModel.Title == null ? (Object)DBNull.Value : oMModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", oMModel.Content == null ? (Object)DBNull.Value : oMModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _isRead = new SqlParameter("@isRead", (Object)DBNull.Value);
        _isRead.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_isRead);

        SqlParameter _From = new SqlParameter("@From", oMModel.From);
        _From.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_From);

        SqlParameter _To = new SqlParameter("@To", oMModel.To);
        _To.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_To);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MessageInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// <summary>
    /// 删除消息信息
    /// </summary>
    /// <param name="MessageId"></param>
    /// <returns></returns>
    public string RemoveMessageInfo(int MessageId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Messageid = new SqlParameter("@Messageid",MessageId);
        _Messageid.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Messageid);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _isRead = new SqlParameter("@isRead", (Object)DBNull.Value);
        _isRead.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_isRead);

        SqlParameter _From = new SqlParameter("@From", (Object)DBNull.Value);
        _From.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_From);

        SqlParameter _To = new SqlParameter("@To", (Object)DBNull.Value);
        _To.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_To);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MessageInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 删除消息信息
    /// </summary>
    /// <param name="MessageId"></param>
    /// <returns></returns>
    public string RemoveMessageInfoTo(int MessageId,int To)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "DelTo");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Messageid = new SqlParameter("@Messageid", MessageId);
        _Messageid.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Messageid);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _isRead = new SqlParameter("@isRead", (Object)DBNull.Value);
        _isRead.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_isRead);

        SqlParameter _From = new SqlParameter("@From", (Object)DBNull.Value);
        _From.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_From);

        SqlParameter _To = new SqlParameter("@To", To);
        _To.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_To);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MessageInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 删除消息信息
    /// </summary>
    /// <param name="MessageId"></param>
    /// <returns></returns>
    public string SetIsReadMessageInfo(int MessageId,bool IsRead)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "IsRead");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _Messageid = new SqlParameter("@Messageid", MessageId);
        _Messageid.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Messageid);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _isRead = new SqlParameter("@isRead", IsRead);
        _isRead.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_isRead);

        SqlParameter _From = new SqlParameter("@From", (Object)DBNull.Value);
        _From.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_From);

        SqlParameter _To = new SqlParameter("@To", (Object)DBNull.Value);
        _To.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_To);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MessageInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 等到信息列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<MessageModel> GetMessageList(int PageIndex, int PageNum, string where, out int Count, out int NotReadCount)
    {
        List<MessageModel> olist = new List<MessageModel>();
        Count = 0;
        NotReadCount = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_MessageList", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _PageIndex = new SqlParameter("@PageIndex", PageIndex);
        _PageIndex.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PageIndex);

        SqlParameter _PageNum = new SqlParameter("@PageNum", PageNum);
        _PageNum.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PageNum);

        SqlParameter _where = new SqlParameter("@where", where);
        _where.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_where);

        SqlParameter _Count = new SqlParameter("@Count", SqlDbType.Int);
        _Count.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_Count);

        SqlParameter _IsReadCount = new SqlParameter("@IsReadCount", SqlDbType.Int);
        _IsReadCount.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_IsReadCount);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    MessageModel oCModel = new MessageModel();
                    oCModel.MessageId = (int)idr["MessageId"];
                    if (idr["Title"] != DBNull.Value) { oCModel.Title = (string)idr["Title"]; }
                    if (idr["Content"] != DBNull.Value) { oCModel.Content = (string)idr["Content"]; }
                    if (idr["IsRead"] != DBNull.Value) { oCModel.IsRead = (bool)idr["IsRead"]; }
                    if (idr["From"] != DBNull.Value) { oCModel.From = (int)idr["From"]; }
                    if (idr["To"] != DBNull.Value) { oCModel.To = (int)idr["To"]; }
                    if (idr["FromName"] != DBNull.Value) { oCModel.FromName = (string)idr["FromName"]; }
                    if (idr["ToName"] != DBNull.Value) { oCModel.ToName = (string)idr["ToName"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    olist.Add(oCModel);
                }
            }
            Count = int.Parse(_Count.Value.ToString());
            NotReadCount = int.Parse(_IsReadCount.Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }
        return olist;

    }
}