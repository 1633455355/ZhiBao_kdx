using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// UserDAL 的摘要说明
/// </summary>
public class UserDAL
{
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string AddUser(UserModel oUModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _UserId = new SqlParameter("@UserId",(Object)DBNull.Value);
        _UserId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserId);

        SqlParameter _UserName = new SqlParameter("@UserName", oUModel.UserName == null ? (Object)DBNull.Value : oUModel.UserName);
        _UserName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserName);

        SqlParameter _CarBrandCode = new SqlParameter("@CarBrandCode", oUModel.CarBrandCode);
        _CarBrandCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarBrandCode);

        SqlParameter _CarSystemCode = new SqlParameter("@CarSystemCode", oUModel.CarSystemCode);
        _CarSystemCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarSystemCode);

        SqlParameter _CarTypeCode = new SqlParameter("@CarTypeCode", oUModel.CarTypeCode);
        _CarTypeCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarTypeCode);

        SqlParameter _Licence = new SqlParameter("@Licence", oUModel.Lincence == null ? (Object)DBNull.Value : oUModel.Lincence);
        _Licence.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Licence);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", oUModel.ProvinceId);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", oUModel.CityId);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Price = new SqlParameter("@Price", oUModel.Price);
        _Price.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Price);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oUModel.Mobile == null ? (Object)DBNull.Value : oUModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Email = new SqlParameter("@Email", oUModel.Email == null ? (Object)DBNull.Value : oUModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _StoreId = new SqlParameter("@StoreId",oUModel.StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oUModel.ProductCode == null ? (Object)DBNull.Value : oUModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _F_ProductTypeId = new SqlParameter("@ProductFirstLevelId", oUModel.F_ProductTypeId);
        _F_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_F_ProductTypeId);

        SqlParameter _S_ProductTypeId = new SqlParameter("@ProductSecondLevelId", oUModel.S_ProductTypeId);
        _S_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_S_ProductTypeId);

        SqlParameter _ImageList = new SqlParameter("@ImageList", oUModel.ImageList);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", oUModel.MechanicId);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _IsQuanCare = new SqlParameter("@IsQuanCare", oUModel.IsQuanCare);
        _IsQuanCare.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_IsQuanCare);

        SqlParameter _Remark = new SqlParameter("@Remark", oUModel.Remark);
        _Remark.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Remark);
        
        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_UserInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    public string Add_T_User(UserModel oUModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _UserId = new SqlParameter("@UserId", (Object)DBNull.Value);
        _UserId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserId);

        SqlParameter _UserName = new SqlParameter("@UserName", oUModel.UserName == null ? (Object)DBNull.Value : oUModel.UserName);
        _UserName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserName);

        SqlParameter _CarBrandCode = new SqlParameter("@CarBrandCode", oUModel.CarBrandCode);
        _CarBrandCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarBrandCode);

        SqlParameter _CarSystemCode = new SqlParameter("@CarSystemCode", oUModel.CarSystemCode);
        _CarSystemCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarSystemCode);

        SqlParameter _CarTypeCode = new SqlParameter("@CarTypeCode", oUModel.CarTypeCode);
        _CarTypeCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarTypeCode);

        SqlParameter _Licence = new SqlParameter("@Licence", oUModel.Lincence == null ? (Object)DBNull.Value : oUModel.Lincence);
        _Licence.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Licence);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", oUModel.ProvinceId);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", oUModel.CityId);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Price = new SqlParameter("@Price", oUModel.Price);
        _Price.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Price);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oUModel.Mobile == null ? (Object)DBNull.Value : oUModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Email = new SqlParameter("@Email", oUModel.Email == null ? (Object)DBNull.Value : oUModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _StoreId = new SqlParameter("@StoreId", oUModel.StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oUModel.ProductCode == null ? (Object)DBNull.Value : oUModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _F_ProductTypeId = new SqlParameter("@ProductFirstLevelId", oUModel.F_ProductTypeId);
        _F_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_F_ProductTypeId);

        SqlParameter _S_ProductTypeId = new SqlParameter("@ProductSecondLevelId", oUModel.S_ProductTypeId);
        _S_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_S_ProductTypeId);

        SqlParameter _ImageList = new SqlParameter("@ImageList", oUModel.ImageList);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", oUModel.MechanicId);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _Type = new SqlParameter("@Type", oUModel.Type);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _Meter = new SqlParameter("@Meter", oUModel.Meter);
        _Meter.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Meter);

        SqlParameter _Address = new SqlParameter("@Address", oUModel.Address);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_User_T_Info", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }

    /// 更新用户
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string SetUser(UserModel oUModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _UserId = new SqlParameter("@UserId", oUModel.UserId);
        _UserId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserId);

        SqlParameter _UserName = new SqlParameter("@UserName", oUModel.UserName == null ? (Object)DBNull.Value : oUModel.UserName);
        _UserName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserName);

        SqlParameter _CarBrandCode = new SqlParameter("@CarBrandCode", oUModel.CarBrandCode);
        _CarBrandCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarBrandCode);

        SqlParameter _CarSystemCode = new SqlParameter("@CarSystemCode", oUModel.CarSystemCode);
        _CarSystemCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarSystemCode);

        SqlParameter _CarTypeCode = new SqlParameter("@CarTypeCode", oUModel.CarTypeCode);
        _CarTypeCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarTypeCode);

        SqlParameter _Licence = new SqlParameter("@Licence", oUModel.Lincence == null ? (Object)DBNull.Value : oUModel.Lincence);
        _Licence.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Licence);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", oUModel.ProvinceId);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", oUModel.CityId);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Price = new SqlParameter("@Price", oUModel.Price);
        _Price.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Price);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oUModel.Mobile == null ? (Object)DBNull.Value : oUModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Email = new SqlParameter("@Email", oUModel.Email == null ? (Object)DBNull.Value : oUModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _StoreId = new SqlParameter("@StoreId", oUModel.StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oUModel.ProductCode == null ? (Object)DBNull.Value : oUModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _F_ProductTypeId = new SqlParameter("@ProductFirstLevelId", oUModel.F_ProductTypeId);
        _F_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_F_ProductTypeId);

        SqlParameter _S_ProductTypeId = new SqlParameter("@ProductSecondLevelId", oUModel.S_ProductTypeId);
        _S_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_S_ProductTypeId);

        SqlParameter _ImageList = new SqlParameter("@ImageList", oUModel.ImageList);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", oUModel.MechanicId);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _IsQuanCare = new SqlParameter("@IsQuanCare", oUModel.IsQuanCare);
        _IsQuanCare.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_IsQuanCare);

        SqlParameter _Remark = new SqlParameter("@Remark", oUModel.Remark);
        _Remark.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Remark);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_UserInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// 删除用户
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string RemoveUser(int UserId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _UserId = new SqlParameter("@UserId",UserId);
        _UserId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserId);

        SqlParameter _UserName = new SqlParameter("@UserName", (Object)DBNull.Value);
        _UserName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_UserName);

        SqlParameter _CarBrandCode = new SqlParameter("@CarBrandCode", (Object)DBNull.Value);
        _CarBrandCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarBrandCode);

        SqlParameter _CarSystemCode = new SqlParameter("@CarSystemCode", (Object)DBNull.Value);
        _CarSystemCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarSystemCode);

        SqlParameter _CarTypeCode = new SqlParameter("@CarTypeCode", (Object)DBNull.Value);
        _CarTypeCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CarTypeCode);

        SqlParameter _Licence = new SqlParameter("@Licence", (Object)DBNull.Value);
        _Licence.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Licence);

        SqlParameter _ProvinceId = new SqlParameter("@ProvinceId", (Object)DBNull.Value);
        _ProvinceId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProvinceId);

        SqlParameter _CityId = new SqlParameter("@CityId", (Object)DBNull.Value);
        _CityId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CityId);

        SqlParameter _Price = new SqlParameter("@Price", (Object)DBNull.Value);
        _Price.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Price);

        SqlParameter _Mobile = new SqlParameter("@Mobile", (Object)DBNull.Value);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Email = new SqlParameter("@Email", (Object)DBNull.Value);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _F_ProductTypeId = new SqlParameter("@ProductFirstLevelId", (Object)DBNull.Value);
        _F_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_F_ProductTypeId);

        SqlParameter _S_ProductTypeId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _S_ProductTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_S_ProductTypeId);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", (Object)DBNull.Value);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _IsQuanCare = new SqlParameter("@IsQuanCare", (Object)DBNull.Value);
        _IsQuanCare.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_IsQuanCare);

        SqlParameter _Remark = new SqlParameter("@Remark", (Object)DBNull.Value);
        _Remark.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Remark);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_UserInfo", sqlparameterlist, Config.ConnectionString);

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
    public List<UserModel> GetUserList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<UserModel> olist = new List<UserModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_UserInfoList", sqlConnection);
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
                    UserModel oCModel = new UserModel();
                    oCModel.UserId = (int)idr["UserId"];
                    if (idr["UserName"] != DBNull.Value) { oCModel.UserName = (string)idr["UserName"]; }
                    if (idr["CarBrandCode"] != DBNull.Value) { oCModel.CarBrandCode = (int)idr["CarBrandCode"]; }
                    if (idr["CarBrandName"] != DBNull.Value) { oCModel.CarBrandCodeName = (string)idr["CarBrandName"]; }
                    if (idr["CarSystemCode"] != DBNull.Value) { oCModel.CarSystemCode = (int)idr["CarSystemCode"]; }
                    if (idr["CarSystemName"] != DBNull.Value) { oCModel.CarSysteName = (string)idr["CarSystemName"]; }
                    if (idr["CarTypeCode"] != DBNull.Value) { oCModel.CarTypeCode = (int)idr["CarTypeCode"]; }
                    if (idr["CarTypeName"] != DBNull.Value) { oCModel.CarTypeName = (string)idr["CarTypeName"]; }

                    if (idr["Licence"] != DBNull.Value) { oCModel.Lincence = (string)idr["Licence"]; }
                    if (idr["ProvinceId"] != DBNull.Value) { oCModel.ProvinceId = (int)idr["ProvinceId"]; }
                    if (idr["ProvinceName"] != DBNull.Value) { oCModel.ProvinceName = (string)idr["ProvinceName"]; }
                    if (idr["CityId"] != DBNull.Value) { oCModel.CityId = (int)idr["CityId"]; }
                    if (idr["CityName"] != DBNull.Value) { oCModel.CityName = (string)idr["CityName"]; }


                    if (idr["Price"] != DBNull.Value) { oCModel.Price = float.Parse(idr["Price"].ToString()); }
                    if (idr["Mobile"] != DBNull.Value) { oCModel.Mobile = (string)idr["Mobile"]; }
                    if (idr["Email"] != DBNull.Value) { oCModel.Email = (string)idr["Email"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }

                    if (idr["StoreId"] != DBNull.Value) { oCModel.StoreId = (int)idr["StoreId"]; }
                    if (idr["StoreName"] != DBNull.Value) { oCModel.StoreName = (string)idr["StoreName"]; }
                    if (idr["ProductCode"] != DBNull.Value) { oCModel.ProductCode = (string)idr["ProductCode"]; }

                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.F_ProductTypeId = (int)idr["ProductFirstLevelId"]; }
                    if (idr["ProductFirstLevelName"] != DBNull.Value) { oCModel.F_ProductTypeName = (string)idr["ProductFirstLevelName"]; }

                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.S_ProductTypeId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.S_ProductTypeName = (string)idr["ProductSecondLevelName"]; }
                    if (idr["ImageList"] != DBNull.Value) { oCModel.ImageList = (string)idr["ImageList"]; }
                    if (idr["MechanicId"] != DBNull.Value) { oCModel.MechanicId = (int)idr["MechanicId"]; }
                    if (idr["ZBYear"] != DBNull.Value) { oCModel.ZBYear = (string)idr["ZBYear"]; }
                   
                    if (idr["Type"] != DBNull.Value) { oCModel.Type = (int)idr["Type"]; }
                    if (idr["meter"] != DBNull.Value) { oCModel.Meter = float.Parse(idr["meter"].ToString()); }
                    if (idr["DealerId"] != DBNull.Value) { oCModel.DealerId = (int)idr["DealerId"]; }
                    if (idr["DealerCompanyName"] != DBNull.Value) { oCModel.DealerName = (string)idr["DealerCompanyName"]; }
                    if (idr["IsQuanCare"] != DBNull.Value) { oCModel.IsQuanCare = (int)idr["IsQuanCare"]; }
                    if (idr["Address"] != DBNull.Value) { oCModel.Address = (string)idr["Address"]; }
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


    /// <summary>
    /// 添加技师信息
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string AddMechanic(MechanicModel oMModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", (Object)DBNull.Value);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _Name = new SqlParameter("@Name", oMModel.Name == null ? (Object)DBNull.Value : oMModel.Name);
        _Name.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Name);

        SqlParameter _Introduction = new SqlParameter("@Introduction", oMModel.Introduction == null ? (Object)DBNull.Value : oMModel.Introduction);
        _Introduction.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Introduction);

        SqlParameter _Type = new SqlParameter("@Type", oMModel.Type);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oMModel.Mobile == null ? (Object)DBNull.Value : oMModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Address = new SqlParameter("@Address", oMModel.Address == null ? (Object)DBNull.Value : oMModel.Address);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);

        SqlParameter _Email = new SqlParameter("@Email", oMModel.Email == null ? (Object)DBNull.Value : oMModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);


        SqlParameter _StoreId = new SqlParameter("@StoreId", oMModel.StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MechanicInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// <summary>
    /// 更新技师信息
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string SetMechanic(MechanicModel oMModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", oMModel.MechanicId);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _Name = new SqlParameter("@Name", oMModel.Name == null ? (Object)DBNull.Value : oMModel.Name);
        _Name.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Name);

        SqlParameter _Introduction = new SqlParameter("@Introduction", oMModel.Introduction == null ? (Object)DBNull.Value : oMModel.Introduction);
        _Introduction.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Introduction);

        SqlParameter _Type = new SqlParameter("@Type", oMModel.Type);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _Mobile = new SqlParameter("@Mobile", oMModel.Mobile == null ? (Object)DBNull.Value : oMModel.Mobile);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Address = new SqlParameter("@Address", oMModel.Address == null ? (Object)DBNull.Value : oMModel.Address);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);

        SqlParameter _Email = new SqlParameter("@Email", oMModel.Email == null ? (Object)DBNull.Value : oMModel.Email);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);


        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MechanicInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// <summary>
    /// 删除技师信息
    /// </summary>
    /// <param name="oUModel"></param>
    /// <returns></returns>
    public string RemoveMechanic(int MechanicId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", MechanicId);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_MechanicId);

        SqlParameter _Name = new SqlParameter("@Name", (Object)DBNull.Value);
        _Name.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Name);

        SqlParameter _Introduction = new SqlParameter("@Introduction", (Object)DBNull.Value);
        _Introduction.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Introduction);

        SqlParameter _Type = new SqlParameter("@Type", (Object)DBNull.Value);
        _Type.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Type);

        SqlParameter _Mobile = new SqlParameter("@Mobile", (Object)DBNull.Value);
        _Mobile.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Mobile);

        SqlParameter _Address = new SqlParameter("@Address", (Object)DBNull.Value);
        _Address.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Address);

        SqlParameter _Email = new SqlParameter("@Email", (Object)DBNull.Value);
        _Email.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Email);


        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_MechanicInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();
    }


    /// <summary>
    /// 得到技师列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<MechanicModel> GetMechanicList(int DealerId,int StoreId)
    {
        List<MechanicModel> olist = new List<MechanicModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_MechanicInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "select");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", (Object)DBNull.Value);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_MechanicId);

        SqlParameter _Name = new SqlParameter("@Name", (Object)DBNull.Value);
        _Name.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Name);

        SqlParameter _Introduction = new SqlParameter("@Introduction", (Object)DBNull.Value);
        _Introduction.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Introduction);

        SqlParameter _Type = new SqlParameter("@Type", DealerId);
        _Type.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Type);

        SqlParameter _Mobile = new SqlParameter("@Mobile", (Object)DBNull.Value);
        _Mobile.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Mobile);

        SqlParameter _Address = new SqlParameter("@Address", (Object)DBNull.Value);
        _Address.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Address);

        SqlParameter _Email = new SqlParameter("@Email", (Object)DBNull.Value);
        _Email.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Email);


        SqlParameter _StoreId = new SqlParameter("@StoreId", StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_result);

        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    MechanicModel oCModel = new MechanicModel();
                    oCModel.MechanicId = (int)idr["MechanicId"];
                    if (idr["Name"] != DBNull.Value) { oCModel.Name = (string)idr["Name"]; }
                    if (idr["Introduction"] != DBNull.Value) { oCModel.Introduction = (string)idr["Introduction"]; }
                    if (idr["Type"] != DBNull.Value) { oCModel.Type = (int)idr["Type"]; }
                    if (idr["Mobile"] != DBNull.Value) { oCModel.Mobile = (string)idr["Mobile"]; }
                    if (idr["Email"] != DBNull.Value) { oCModel.Email = (string)idr["Email"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    if (idr["StoreId"] != DBNull.Value) { oCModel.StoreId = (int)idr["StoreId"]; }
                    if (idr["StoreName"] != DBNull.Value) { oCModel.StoreName = (string)idr["StoreName"]; }
                    if (idr["DealerCompanyName"] != DBNull.Value) { oCModel.DealerName = (string)idr["DealerCompanyName"]; }
                    if (idr["Address"] != DBNull.Value) { oCModel.Address = (string)idr["Address"]; }
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
    /// 得到技师
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public MechanicModel GetMechanic(int MechanicId)
    {
        MechanicModel oCModel = new MechanicModel();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_MechanicInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "Get");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);


        SqlParameter _MechanicId = new SqlParameter("@MechanicId", MechanicId);
        _MechanicId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_MechanicId);

        SqlParameter _Name = new SqlParameter("@Name", (Object)DBNull.Value);
        _Name.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Name);

        SqlParameter _Introduction = new SqlParameter("@Introduction", (Object)DBNull.Value);
        _Introduction.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Introduction);

        SqlParameter _Type = new SqlParameter("@Type", (Object)DBNull.Value);
        _Type.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Type);

        SqlParameter _Mobile = new SqlParameter("@Mobile", (Object)DBNull.Value);
        _Mobile.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Mobile);

        SqlParameter _Address = new SqlParameter("@Address", (Object)DBNull.Value);
        _Address.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Address);

        SqlParameter _Email = new SqlParameter("@Email", (Object)DBNull.Value);
        _Email.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Email);


        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);

        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_result);

        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                 
                    oCModel.MechanicId = (int)idr["MechanicId"];
                    if (idr["Name"] != DBNull.Value) { oCModel.Name = (string)idr["Name"]; }
                    if (idr["Introduction"] != DBNull.Value) { oCModel.Introduction = (string)idr["Introduction"]; }
                    if (idr["Type"] != DBNull.Value) { oCModel.Type = (int)idr["Type"]; }
                    if (idr["Mobile"] != DBNull.Value) { oCModel.Mobile = (string)idr["Mobile"]; }
                    if (idr["Email"] != DBNull.Value) { oCModel.Email = (string)idr["Email"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                    if (idr["StoreId"] != DBNull.Value) { oCModel.StoreId = (int)idr["StoreId"]; }
                    if (idr["StoreName"] != DBNull.Value) { oCModel.StoreName = (string)idr["StoreName"]; }
                    if (idr["Address"] != DBNull.Value) { oCModel.Address = (string)idr["Address"]; }
                 
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
        return oCModel;

    }
    public float GetProudctTMeter(string ProductCode,string StoreId)
    {
        float Total = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("select sum(meter) as Total from  UserInfo where ProductCode=@ProductCode and StoreId=@StoreId", sqlConnection);
        sqlcommand.CommandType = CommandType.Text;
        sqlcommand.Parameters.AddWithValue("@ProductCode", ProductCode);
        sqlcommand.Parameters.AddWithValue("@StoreId", StoreId);
        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    if (idr["Total"] != DBNull.Value) { Total = float.Parse(idr["Total"].ToString()); }
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
        return Total;
    }

}