using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// PromotionDAL 的摘要说明
/// </summary>
public class PromotionDAL
{
    /// <summary>
    /// 添加促销信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddPromotionInfo(PromotionModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _PromotionId = new SqlParameter("@PromotionId", (Object)DBNull.Value);
        _PromotionId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PromotionId);

        SqlParameter _Title = new SqlParameter("@Title", oPModel.Title == null ? (Object)DBNull.Value : oPModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", oPModel.Content == null ? (Object)DBNull.Value : oPModel.Content);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);


        SqlParameter _Image = new SqlParameter("@Image", oPModel.Image == null ? (Object)DBNull.Value : oPModel.Image);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", oPModel.URL == null ? (Object)DBNull.Value : oPModel.URL);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", oPModel.CreatorId);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_PromotionInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 更新促销信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetPromotionInfo(PromotionModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _PromotionId = new SqlParameter("@PromotionId", oPModel.PromotionId);
        _PromotionId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PromotionId);

        SqlParameter _Title = new SqlParameter("@Title", oPModel.Title == null ? (Object)DBNull.Value : oPModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", oPModel.Content == null ? (Object)DBNull.Value : oPModel.Content);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _Image = new SqlParameter("@Image", oPModel.Image == null ? (Object)DBNull.Value : oPModel.Image);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", oPModel.URL == null ? (Object)DBNull.Value : oPModel.URL);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", oPModel.CreatorId);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_PromotionInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// <summary>
    /// 删除促销信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string RemovePromotionInfo(int PromotionId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _PromotionId = new SqlParameter("@PromotionId", PromotionId);
        _PromotionId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PromotionId);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _Image = new SqlParameter("@Image", (Object)DBNull.Value);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", (Object)DBNull.Value);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_PromotionInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 添加促销信息让那个经销商看到
    /// </summary>
    /// <param name="PromotionId"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string AddPromotionDealerInfo(int PromotionId,int DealerId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "AddDealer");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _PromotionId = new SqlParameter("@PromotionId", PromotionId);
        _PromotionId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PromotionId);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _Image = new SqlParameter("@Image", (Object)DBNull.Value);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", (Object)DBNull.Value);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", DealerId);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_PromotionInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 删除促销信息让那个经销商看到
    /// </summary>
    /// <param name="PromotionId"></param>
    /// <returns></returns>
    public string RemovePromotionDealerInfo(int PromotionId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "DelDealer");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _PromotionId = new SqlParameter("@PromotionId", PromotionId);
        _PromotionId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_PromotionId);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _Image = new SqlParameter("@Image", (Object)DBNull.Value);
        _Image.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Image);

        SqlParameter _URL = new SqlParameter("@URL", (Object)DBNull.Value);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_PromotionInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 得到促销信息让那个经销商看到
    /// </summary>
    /// <param name="PromotionId"></param>
    /// <returns></returns>
    public List<int> GetDealerInfo(int PromotionId)
    {
        List<int> olist = new List<int>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("select * from Promotion_DealerInfo where PromotionId=@PromotionId", sqlConnection);
        sqlcommand.CommandType = CommandType.Text;

        SqlParameter _PromotionId = new SqlParameter("PromotionId", PromotionId);
        _PromotionId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_PromotionId);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    int oCModel = new int();
                    oCModel = (int)idr["DealerId"];
                    olist.Add(oCModel);
                }
            }
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

    /// <summary>
    /// 得到促销信息列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<PromotionModel> GetPromotionList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<PromotionModel> olist = new List<PromotionModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_PromotionList", sqlConnection);
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
                    PromotionModel oCModel = new PromotionModel();
                    oCModel.PromotionId = (int)idr["PromotionId"];
                    if (idr["Title"] != DBNull.Value) { oCModel.Title = (string)idr["Title"]; }
                    if (idr["Image"] != DBNull.Value) { oCModel.Image = (string)idr["Image"]; }
                    if (idr["URL"] != DBNull.Value) { oCModel.URL = (string)idr["URL"]; }
                    if (idr["Content"] != DBNull.Value) { oCModel.Content = (string)idr["Content"]; }
                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["AdminName"] != DBNull.Value) { oCModel.CreatorName = (string)idr["AdminName"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    if(oCModel.PromotionId!=0)
                    {
                        oCModel.DealerIdList = GetDealerInfo(oCModel.PromotionId);
                    }
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