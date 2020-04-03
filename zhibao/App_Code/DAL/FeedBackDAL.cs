using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// FeedBackDAL 的摘要说明
/// </summary>
public class FeedBackDAL
{
    /// <summary>
    /// 添加反馈信息
    /// </summary>
    /// <param name="oFBModel"></param>
    /// <returns></returns>
    public string AddFeedBackInfo(FeedBackModel oFBModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _FeedBackId = new SqlParameter("@FeedBackId", (Object)DBNull.Value);
        _FeedBackId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FeedBackId);

        SqlParameter _Title = new SqlParameter("@Title", oFBModel.Title == null ? (Object)DBNull.Value : oFBModel.Title);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", oFBModel.Content == null ? (Object)DBNull.Value : oFBModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _Name = new SqlParameter("@Name", oFBModel.Name == null ? (Object)DBNull.Value : oFBModel.Name);
        _Name.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Name);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oFBModel.Mobile == null ? (Object)DBNull.Value : oFBModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Email = new SqlParameter("@Email", oFBModel.Email == null ? (Object)DBNull.Value : oFBModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", oFBModel.ProvinceId);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", oFBModel.CityId);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Address = new SqlParameter("@Address", oFBModel.Address == null ? (Object)DBNull.Value : oFBModel.Address);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);


        SqlParameter _Zip = new SqlParameter("@Zip", oFBModel.Zip == null ? (Object)DBNull.Value : oFBModel.Zip);
        _Zip.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Zip);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oFBModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

         SqlParameter _IsdisplayDealer = new SqlParameter("@IsdisplayDealer", oFBModel.IsdisplayDealer);
        _IsdisplayDealer.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_IsdisplayDealer);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_FeedBackInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 删除反馈信息
    /// </summary>
    /// <param name="FeedBackId"></param>
    /// <returns></returns>
    public string RemoveFeedBackInfo(int FeedBackId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _FeedBackId = new SqlParameter("@FeedBackId", FeedBackId);
        _FeedBackId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FeedBackId);

        SqlParameter _Title = new SqlParameter("@Title", (Object)DBNull.Value);
        _Title.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Title);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);

        SqlParameter _Name = new SqlParameter("@Name", (Object)DBNull.Value);
        _Name.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Name);

        SqlParameter _Moblie = new SqlParameter("@Mobile", (Object)DBNull.Value);
        _Moblie.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Moblie);

        SqlParameter _Email = new SqlParameter("@Email", (Object)DBNull.Value);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", (Object)DBNull.Value);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", (Object)DBNull.Value);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Address = new SqlParameter("@Address", (Object)DBNull.Value);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);


        SqlParameter _Zip = new SqlParameter("@Zip", (Object)DBNull.Value);
        _Zip.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Zip);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _IsdisplayDealer = new SqlParameter("@IsdisplayDealer", (Object)DBNull.Value);
        _IsdisplayDealer.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_IsdisplayDealer);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_FeedBackInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<FeedBackModel> GetFeedBackList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<FeedBackModel> olist = new List<FeedBackModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_FeedBackList", sqlConnection);
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
                    FeedBackModel oCModel = new FeedBackModel();
                    oCModel.FeedBackId = (int)idr["FeedBackId"];
                    if (idr["Title"] != DBNull.Value) { oCModel.Title = (string)idr["Title"]; }
                    if (idr["Content"] != DBNull.Value) { oCModel.Content = (string)idr["Content"]; }
                    if (idr["Name"] != DBNull.Value) { oCModel.Name = (string)idr["Name"]; }
                    if (idr["Mobile"] != DBNull.Value) { oCModel.Mobile = (string)idr["Mobile"]; }
                    if (idr["Email"] != DBNull.Value) { oCModel.Email = (string)idr["Email"]; }
                    if (idr["Mobile"] != DBNull.Value) { oCModel.Mobile = (string)idr["Mobile"]; }

                    if (idr["ProvinceId"] != DBNull.Value) { oCModel.ProvinceId = (int)idr["ProvinceId"]; }
                    if (idr["ProvinceName"] != DBNull.Value) { oCModel.ProvinceName = (string)idr["ProvinceName"]; }

                    if (idr["CityId"] != DBNull.Value) { oCModel.CityId = (int)idr["CityId"]; }
                    if (idr["CityName"] != DBNull.Value) { oCModel.CityName = (string)idr["CityName"]; }
                    if (idr["Address"] != DBNull.Value) { oCModel.Address = (string)idr["Address"]; }
                    if (idr["Zip"] != DBNull.Value) { oCModel.Zip = (string)idr["Zip"]; }

                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["AdminName"] != DBNull.Value) { oCModel.CreateName = (string)idr["AdminName"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    if (idr["IsdisplayDealer"] != DBNull.Value) { oCModel.IsdisplayDealer = (bool)idr["IsdisplayDealer"]; }
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