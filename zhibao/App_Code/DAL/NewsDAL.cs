using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// NewDAL 的摘要说明
/// </summary>
public class NewsDAL
{
    /// <summary>
    /// 添加新闻
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string AddNewsInfo(NewsModel oNModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _NewsId = new SqlParameter("@NewsId",(Object)DBNull.Value);
        _NewsId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsId);

        SqlParameter _Title = new SqlParameter("@Title", oNModel.Title == null ? (Object)DBNull.Value : oNModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Image = new SqlParameter("@Image", oNModel.Image == null ? (Object)DBNull.Value : oNModel.Image);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", oNModel.URL == null ? (Object)DBNull.Value : oNModel.URL);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);

        SqlParameter _Content = new SqlParameter("@Content", oNModel.Content == null ? (Object)DBNull.Value : oNModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oNModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_NewsInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 更新新闻
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string SetNewsInfo(NewsModel oNModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _NewsId = new SqlParameter("@NewsId", oNModel.NewsId);
        _NewsId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsId);

        SqlParameter _Title = new SqlParameter("@Title", oNModel.Title == null ? (Object)DBNull.Value : oNModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Image = new SqlParameter("@Image", oNModel.Image == null ? (Object)DBNull.Value : oNModel.Image);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", oNModel.URL == null ? (Object)DBNull.Value : oNModel.URL);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);

        SqlParameter _Content = new SqlParameter("@Content", oNModel.Content == null ? (Object)DBNull.Value : oNModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oNModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_NewsInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 删除新闻
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string RemoveNewsInfo(int NewsId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _NewsId = new SqlParameter("@NewsId", NewsId);
        _NewsId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsId);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Image = new SqlParameter("@Image", (Object)DBNull.Value);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", (Object)DBNull.Value);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_NewsInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<NewsModel> GetNewsList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<NewsModel> olist = new List<NewsModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_NewsList", sqlConnection);
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
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    NewsModel oCModel = new NewsModel();
                    oCModel.NewsId = (int)idr["NewsId"];
                    if (idr["Title"] != DBNull.Value) { oCModel.Title = (string)idr["Title"]; }
                    if (idr["Image"] != DBNull.Value) { oCModel.Image = (string)idr["Image"]; }
                    if (idr["URL"] != DBNull.Value) { oCModel.URL = (string)idr["URL"]; }
                    if (idr["Content"] != DBNull.Value) { oCModel.Content = (string)idr["Content"]; }
                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["AdminName"] != DBNull.Value) { oCModel.CreatorName = (string)idr["AdminName"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }

                    if (idr["UpLastor"] != DBNull.Value) { oCModel.UpLastor = (int)idr["UpLastor"]; }
                    if (idr["UpLastTime"] != DBNull.Value) { oCModel.UpLastTime = (DateTime)idr["UpLastTime"]; }
                    olist.Add(oCModel);
                }
            }
            Count = int.Parse(_Count.Value.ToString());
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