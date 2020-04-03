using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


public class DealerDAL
{
    /// <summary>
    /// 添加经销商数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string AddDealerInfo(DealerModel oAModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _AdminId = new SqlParameter("@AdminId", oAModel.AdminId);
        _AdminId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminId);

        SqlParameter _DealerCompanyName = new SqlParameter("@DealerCompanyName", oAModel.DealerCompanyName == null ? (Object)DBNull.Value : oAModel.DealerCompanyName);
        _DealerCompanyName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerCompanyName);

        SqlParameter _Contacts = new SqlParameter("@Contacts", oAModel.Contacts==null?(Object)DBNull.Value:oAModel.Contacts);
        _Contacts.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Contacts);

        SqlParameter _Position = new SqlParameter("@Position", oAModel.Position == null ? (Object)DBNull.Value : oAModel.Position);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _Phone = new SqlParameter("@Phone", oAModel.Phone == null ? (Object)DBNull.Value : oAModel.Phone);
        _Phone.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Phone);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oAModel.Mobile == null ? (Object)DBNull.Value : oAModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Fax = new SqlParameter("@Fax", oAModel.Fax == null ? (Object)DBNull.Value : oAModel.Fax);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", oAModel.ProvinceId);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", oAModel.CityId);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Address = new SqlParameter("@Address", oAModel.Address == null ? (Object)DBNull.Value : oAModel.Address);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);

        SqlParameter _Zip = new SqlParameter("@Zip", oAModel.Zip == null ? (Object)DBNull.Value : oAModel.Zip);
        _Zip.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Zip);

        SqlParameter _Email = new SqlParameter("@Email", oAModel.Email == null ? (Object)DBNull.Value : oAModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _URL = new SqlParameter("@URL", oAModel.URL == null ? (Object)DBNull.Value : oAModel.URL);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);

        SqlParameter _DealerAreaLevelDes = new SqlParameter("@DealerAreaLevelDes", oAModel.DealerAreaLevelDes == null ? (Object)DBNull.Value : oAModel.DealerAreaLevelDes);
        _DealerAreaLevelDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerAreaLevelDes);

        SqlParameter _Remark = new SqlParameter("@Remark", oAModel.Remark == null ? (Object)DBNull.Value : oAModel.Remark);
        _Remark.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Remark);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_DealerInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 更新经销商数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string SetDealerInfo(DealerModel oAModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _AdminId = new SqlParameter("@AdminId", oAModel.AdminId);
        _AdminId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminId);

        SqlParameter _DealerCompanyName = new SqlParameter("@DealerCompanyName", oAModel.DealerCompanyName == null ? (Object)DBNull.Value : oAModel.DealerCompanyName);
        _DealerCompanyName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerCompanyName);

        SqlParameter _Contacts = new SqlParameter("@Contacts", oAModel.Contacts == null ? (Object)DBNull.Value : oAModel.Contacts);
        _Contacts.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Contacts);

        SqlParameter _Position = new SqlParameter("@Position", oAModel.Position == null ? (Object)DBNull.Value : oAModel.Position);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _Phone = new SqlParameter("@Phone", oAModel.Phone == null ? (Object)DBNull.Value : oAModel.Phone);
        _Phone.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Phone);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oAModel.Mobile == null ? (Object)DBNull.Value : oAModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Fax = new SqlParameter("@Fax", oAModel.Fax == null ? (Object)DBNull.Value : oAModel.Fax);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", oAModel.ProvinceId);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", oAModel.CityId);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Address = new SqlParameter("@Address", oAModel.Address == null ? (Object)DBNull.Value : oAModel.Address);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);

        SqlParameter _Zip = new SqlParameter("@Zip", oAModel.Zip == null ? (Object)DBNull.Value : oAModel.Zip);
        _Zip.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Zip);

        SqlParameter _Email = new SqlParameter("@Email", oAModel.Email == null ? (Object)DBNull.Value : oAModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _URL = new SqlParameter("@URL", oAModel.URL == null ? (Object)DBNull.Value : oAModel.URL);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);

        SqlParameter _DealerAreaLevelDes = new SqlParameter("@DealerAreaLevelDes", oAModel.DealerAreaLevelDes == null ? (Object)DBNull.Value : oAModel.DealerAreaLevelDes);
        _DealerAreaLevelDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerAreaLevelDes);

        SqlParameter _Remark = new SqlParameter("@Remark", oAModel.Remark == null ? (Object)DBNull.Value : oAModel.Remark);
        _Remark.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Remark);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_DealerInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// <summary>
    /// 删除经销商数据
    /// </summary>
    /// <param name="oAModel"></param>
    /// <returns></returns>
    public string RemoveDealerInfo(int AdminId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _AdminId = new SqlParameter("@AdminId", AdminId);
        _AdminId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AdminId);

        SqlParameter _DealerCompanyName = new SqlParameter("@DealerCompanyName", (Object)DBNull.Value);
        _DealerCompanyName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerCompanyName);

        SqlParameter _Contacts = new SqlParameter("@Contacts",(Object)DBNull.Value);
        _Contacts.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Contacts);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _Phone = new SqlParameter("@Phone", (Object)DBNull.Value);
        _Phone.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Phone);

        SqlParameter _Mobile = new SqlParameter("@Mobile", (Object)DBNull.Value);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

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

        SqlParameter _Email = new SqlParameter("@Email", (Object)DBNull.Value);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _URL = new SqlParameter("@URL", (Object)DBNull.Value);
        _URL.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_URL);

        SqlParameter _DealerAreaLevelDes = new SqlParameter("@DealerAreaLevelDes", (Object)DBNull.Value);
        _DealerAreaLevelDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerAreaLevelDes);

        SqlParameter _Remark = new SqlParameter("@Remark", (Object)DBNull.Value);
        _Remark.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Remark);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_DealerInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }
    /// <summary>
    /// 得到经销商列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<DealerModel> GetDealerModelList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<DealerModel> olist = new List<DealerModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_DealerList", sqlConnection);
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
                    DealerModel oCModel = new DealerModel();
                    if (idr["AdminId"] != DBNull.Value) { oCModel.AdminId = (int)idr["AdminId"]; }
                    if (idr["DealerCompanyName"] != DBNull.Value) { oCModel.DealerCompanyName = (string)idr["DealerCompanyName"]; } else { oCModel.DealerCompanyName="";}
                    if (idr["Contacts"] != DBNull.Value) { oCModel.Contacts = (string)idr["Contacts"]; }else { oCModel.Contacts="";}
                    if (idr["Position"] != DBNull.Value) { oCModel.Position = (string)idr["Position"]; }else { oCModel.Position="";}
                    if (idr["Phone"] != DBNull.Value) { oCModel.Phone = (string)idr["Phone"]; }else { oCModel.Phone="";}
                    if (idr["Mobile"] != DBNull.Value) { oCModel.Mobile = (string)idr["Mobile"]; }else { oCModel.Mobile="";}
                    if (idr["Fax"] != DBNull.Value) { oCModel.Fax = (string)idr["Fax"]; }else { oCModel.Fax="";}
                    if (idr["ProvinceId"] != DBNull.Value) { oCModel.ProvinceId = (int)idr["ProvinceId"]; }
                    if (idr["ProvinceName"] != DBNull.Value) { oCModel.ProvinceName = (string)idr["ProvinceName"]; }else { oCModel.ProvinceName="";}
                    if (idr["CityId"] != DBNull.Value) { oCModel.CityId = (int)idr["CityId"]; }
                    if (idr["CityName"] != DBNull.Value) { oCModel.CityName = (string)idr["CityName"]; }else { oCModel.CityName="";}
                    if (idr["Address"] != DBNull.Value) { oCModel.Address = (string)idr["Address"]; }else { oCModel.Address="";}
                    if (idr["Zip"] != DBNull.Value) { oCModel.Zip = (string)idr["Zip"]; }else { oCModel.Zip="";}
                    if (idr["Email"] != DBNull.Value) { oCModel.Email = (string)idr["Email"]; } else { oCModel.Email = ""; }
                    if (idr["URL"] != DBNull.Value) { oCModel.URL = (string)idr["URL"]; }
                    if (idr["DealerAreaLevelDes"] != DBNull.Value) { oCModel.DealerAreaLevelDes = (string)idr["DealerAreaLevelDes"]; }
                    if (idr["Remark"] != DBNull.Value) { oCModel.Remark = (string)idr["Remark"]; }

                     
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

