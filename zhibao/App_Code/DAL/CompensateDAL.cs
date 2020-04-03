using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// CompensateDAL 的摘要说明
/// </summary>
public class CompensateDAL
{
    /// <summary>
    /// 增加理赔信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddCompensateInfo(CompensateModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", oPModel.CompensateNo == null ? (Object)DBNull.Value : oPModel.CompensateNo);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", oPModel.ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oPModel.ProductCode == null ? (Object)DBNull.Value : oPModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", oPModel.CompensateName == null ? (Object)DBNull.Value : oPModel.CompensateName);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", oPModel.Tel == null ? (Object)DBNull.Value : oPModel.Tel);
        _Tel.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", oPModel.Fax == null ? (Object)DBNull.Value : oPModel.Fax);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", oPModel.CompensateType == null ? (Object)DBNull.Value : oPModel.CompensateType);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", oPModel.CompensatePeson == null ? (Object)DBNull.Value : oPModel.CompensatePeson);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", oPModel.Specifications == null ? (Object)DBNull.Value : oPModel.Specifications);
        _Specifications.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", oPModel.Length == null ? (Object)DBNull.Value : oPModel.Length);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", oPModel.CompensateStore == null ? (Object)DBNull.Value : oPModel.CompensateStore);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", oPModel.CompensateDate == null ? (Object)DBNull.Value : oPModel.CompensateDate);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", oPModel.Position == null ? (Object)DBNull.Value : oPModel.Position);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", oPModel.ProblemDes == null ? (Object)DBNull.Value : oPModel.ProblemDes);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", oPModel.ProblemOtherDes == null ? (Object)DBNull.Value : oPModel.ProblemOtherDes);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", oPModel.FindTime == null ? (Object)DBNull.Value : oPModel.FindTime);
        _FindTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", oPModel.InstallationTime == null ? (Object)DBNull.Value : oPModel.InstallationTime);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", oPModel.OtherDes == null ? (Object)DBNull.Value : oPModel.OtherDes);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId",  oPModel.DealerId == null?(Object)DBNull.Value:oPModel.DealerId.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", oPModel.StoreId == null ? (Object)DBNull.Value : oPModel.StoreId.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", oPModel.Status);
        _Status.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", oPModel.ImageList == null ? (Object)DBNull.Value : oPModel.ImageList);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", oPModel.AtchmentList == null ? (Object)DBNull.Value : oPModel.AtchmentList);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AtchmentList);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_CompensateInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 更新理赔信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetCompensateInfo(CompensateModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", oPModel.CompensateNo == null ? (Object)DBNull.Value : oPModel.CompensateNo);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", oPModel.ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oPModel.ProductCode == null ? (Object)DBNull.Value : oPModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", oPModel.CompensateName == null ? (Object)DBNull.Value : oPModel.CompensateName);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", oPModel.Tel == null ? (Object)DBNull.Value : oPModel.Tel);
        _Tel.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", oPModel.Fax == null ? (Object)DBNull.Value : oPModel.Fax);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", oPModel.CompensateType == null ? (Object)DBNull.Value : oPModel.CompensateType);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", oPModel.CompensatePeson == null ? (Object)DBNull.Value : oPModel.CompensatePeson);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", oPModel.Specifications == null ? (Object)DBNull.Value : oPModel.Specifications);
        _Specifications.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", oPModel.Length == null ? (Object)DBNull.Value : oPModel.Length);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", oPModel.CompensateStore == null ? (Object)DBNull.Value : oPModel.CompensateStore);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", oPModel.CompensateDate == null ? (Object)DBNull.Value : oPModel.CompensateDate);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", oPModel.Position == null ? (Object)DBNull.Value : oPModel.Position);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", oPModel.ProblemDes == null ? (Object)DBNull.Value : oPModel.ProblemDes);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", oPModel.ProblemOtherDes == null ? (Object)DBNull.Value : oPModel.ProblemOtherDes);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", oPModel.FindTime == null ? (Object)DBNull.Value : oPModel.FindTime);
        _FindTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", oPModel.InstallationTime == null ? (Object)DBNull.Value : oPModel.InstallationTime);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", oPModel.OtherDes == null ? (Object)DBNull.Value : oPModel.OtherDes);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", oPModel.DealerId == null ? (Object)DBNull.Value : oPModel.DealerId.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", oPModel.StoreId == null ? (Object)DBNull.Value : oPModel.StoreId.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", oPModel.Status);
        _Status.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", oPModel.ImageList == null ? (Object)DBNull.Value : oPModel.ImageList);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", oPModel.AtchmentList == null ? (Object)DBNull.Value : oPModel.AtchmentList);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AtchmentList);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_CompensateInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 更新理赔信息状态
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetCompensateInfoStatus(string CompensateNo,int Status)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Status");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", CompensateNo == null ? (Object)DBNull.Value :CompensateNo);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status",Status);
        _Status.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AtchmentList);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_CompensateInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }


    /// <summary>
    /// 删除理赔信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string RemoveCompensateInfo(string CompensateNo)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", CompensateNo == null ? (Object)DBNull.Value : CompensateNo);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_AtchmentList);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_CompensateInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 得到经销商认证过的品牌的型号
    /// </summary>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public List<ProductTypeModel> GetProductSecondLevelInfoByDealerId(int DealerId)
    {
        List<ProductTypeModel> olist = new List<ProductTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetPSDealer");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", DealerId);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AtchmentList);


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
                    ProductTypeModel oCModel = new ProductTypeModel();
                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.F_ProductTypeId = (int)idr["ProductFirstLevelId"]; }
                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.S_ProductTypeId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.S_ProductTypeName = (string)idr["ProductSecondLevelName"]; }
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
    /// 得到经销商认证过的卷轴号
    /// </summary>
    /// <param name="ProductSecondLevelId"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public List<string> GetProductSecondLevelInfoByDealerId(int ProductSecondLevelId, int DealerId)
    {
        List<string> olist = new List<string>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetPCDealer");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", DealerId);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AtchmentList);


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
                    if (idr["ProductCode"] != DBNull.Value) { olist.Add(idr["ProductCode"].ToString()); }
                   
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
    /// 得到门店认证过的品牌的型号
    /// </summary>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public List<ProductTypeModel> GetProductSecondLevelInfoByStoreId(int StoreId)
    {
        List<ProductTypeModel> olist = new List<ProductTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetPSStore");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AtchmentList);


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
                    ProductTypeModel oCModel = new ProductTypeModel();
                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.F_ProductTypeId = (int)idr["ProductFirstLevelId"]; }
                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.S_ProductTypeId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.S_ProductTypeName = (string)idr["ProductSecondLevelName"]; }
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
    /// 得到门店认证过的卷轴号
    /// </summary>
    /// <param name="ProductSecondLevelId"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public List<string> GetProductSecondLevelInfoByStoreId(int ProductSecondLevelId, int StoreId)
    {
        List<string> olist = new List<string>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetPCStore");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AtchmentList);


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
                    if (idr["ProductCode"] != DBNull.Value) {
                        string ret = idr["ProductCode"].ToString() + "|" + idr["S_Total"].ToString()+"|" + idr["Length"].ToString();
                        olist.Add(ret);
                    }

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
    /// 侧后挡
    /// </summary>
    /// <param name="ProductSecondLevelId"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public List<string> GetProductSecondLevelInfoByStoreId_1(int ProductSecondLevelId, int StoreId)
    {
        List<string> olist = new List<string>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetPCStore_1");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AtchmentList);


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
                    if (idr["ProductCode"] != DBNull.Value)
                    {
                        string ret = idr["ProductCode"].ToString() + "|" + idr["S_Total"].ToString();
                        olist.Add(ret);
                    }

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


    public List<string> GetProduct_T_SecondLevelInfoByStoreId(int ProductSecondLevelId, int StoreId)
    {
        List<string> olist = new List<string>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "GetPCTStore");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _CompensateName = new SqlParameter("@CompensateName", (Object)DBNull.Value);
        _CompensateName.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateName);

        SqlParameter _Tel = new SqlParameter("@Tel", (Object)DBNull.Value);
        _Tel.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Tel);

        SqlParameter _Fax = new SqlParameter("@Fax", (Object)DBNull.Value);
        _Fax.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Fax);

        SqlParameter _CompensateType = new SqlParameter("@CompensateType", (Object)DBNull.Value);
        _CompensateType.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateType);

        SqlParameter _CompensatePeson = new SqlParameter("@CompensatePeson", (Object)DBNull.Value);
        _CompensatePeson.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensatePeson);

        SqlParameter _Specifications = new SqlParameter("@Specifications", (Object)DBNull.Value);
        _Specifications.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Specifications);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);


        SqlParameter _CompensateStore = new SqlParameter("@CompensateStore", (Object)DBNull.Value);
        _CompensateStore.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateStore);


        SqlParameter _CompensateDate = new SqlParameter("@CompensateDate", (Object)DBNull.Value);
        _CompensateDate.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateDate);

        SqlParameter _Position = new SqlParameter("@Position", (Object)DBNull.Value);
        _Position.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Position);

        SqlParameter _ProblemDes = new SqlParameter("@ProblemDes", (Object)DBNull.Value);
        _ProblemDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemDes);

        SqlParameter _ProblemOtherDes = new SqlParameter("@ProblemOtherDes", (Object)DBNull.Value);
        _ProblemOtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProblemOtherDes);


        SqlParameter _FindTime = new SqlParameter("@FindTime", (Object)DBNull.Value);
        _FindTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_FindTime);

        SqlParameter _InstallationTime = new SqlParameter("@InstallationTime", (Object)DBNull.Value);
        _InstallationTime.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_InstallationTime);


        SqlParameter _OtherDes = new SqlParameter("@OtherDes", (Object)DBNull.Value);
        _OtherDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_OtherDes);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);



        SqlParameter _Status = new SqlParameter("@Status", (Object)DBNull.Value);
        _Status.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Status);

        SqlParameter _ImageList = new SqlParameter("@ImageList", (Object)DBNull.Value);
        _ImageList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ImageList);


        SqlParameter _AtchmentList = new SqlParameter("@AtchmentList", (Object)DBNull.Value);
        _AtchmentList.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_AtchmentList);


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
                    if (idr["ProductCode"] != DBNull.Value) { olist.Add(idr["ProductCode"].ToString()); }

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
    /// 得到理赔列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<CompensateModel> GetCompensateList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<CompensateModel> olist = new List<CompensateModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CompensateInfoList", sqlConnection);
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
                    CompensateModel oCModel = new CompensateModel();
                    if (idr["CompensateNo"] != DBNull.Value) { oCModel.CompensateNo = (string)idr["CompensateNo"]; }
                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.ProductSecondLevelId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.ProductSecondLevelName = (string)idr["ProductSecondLevelName"]; }
                    if (idr["ProductCode"] != DBNull.Value) { oCModel.ProductCode = (string)idr["ProductCode"]; }
                    if (idr["CompensateName"] != DBNull.Value) { oCModel.CompensateName = (string)idr["CompensateName"]; }
                    if (idr["Tel"] != DBNull.Value) { oCModel.Tel = (string)idr["Tel"]; }
                    if (idr["Fax"] != DBNull.Value) { oCModel.Fax = (string)idr["Fax"]; }
                    if (idr["CompensateType"] != DBNull.Value) { oCModel.CompensateType = (string)idr["CompensateType"]; }
                    if (idr["CompensatePeson"] != DBNull.Value) { oCModel.CompensatePeson = (string)idr["CompensatePeson"]; }
                    if (idr["Specifications"] != DBNull.Value) { oCModel.Specifications = (string)idr["Specifications"]; }
                    if (idr["Length"] != DBNull.Value) { oCModel.Length = (string)idr["Length"]; }
                    if (idr["CompensateStore"] != DBNull.Value) { oCModel.CompensateStore = (string)idr["CompensateStore"]; }
                    if (idr["CompensateDate"] != DBNull.Value) { oCModel.CompensateDate = (DateTime)idr["CompensateDate"]; }
                    if (idr["Position"] != DBNull.Value) { oCModel.Position = (string)idr["Position"]; }
                    if(!String.IsNullOrWhiteSpace(oCModel.Position))
                    {
                        oCModel.PositionList = StringManager.ConvertIntList(oCModel.Position);
                    }
                    if (idr["ProblemDes"] != DBNull.Value) { oCModel.ProblemDes = (string)idr["ProblemDes"]; }
                    if(!String.IsNullOrWhiteSpace(oCModel.ProblemDes))
                    {
                        oCModel.ProblemDesList = StringManager.ConvertIntList(oCModel.ProblemDes);
                    }
                    if (idr["ProblemOtherDes"] != DBNull.Value) { oCModel.ProblemOtherDes = (string)idr["ProblemOtherDes"]; }
                    if (idr["FindTime"] != DBNull.Value) { oCModel.FindTime = (string)idr["FindTime"]; }
                    if (idr["InstallationTime"] != DBNull.Value) { oCModel.InstallationTime = (DateTime)idr["InstallationTime"]; }
                    if (idr["OtherDes"] != DBNull.Value) { oCModel.OtherDes = (string)idr["OtherDes"]; }
                    if (idr["DealerId"] != DBNull.Value) { oCModel.DealerId = (int)idr["DealerId"]; }
                    if (idr["DealerCompanyName"] != DBNull.Value) { oCModel.DealerName = (string)idr["DealerCompanyName"]; }
                    if (idr["StoreId"] != DBNull.Value) { oCModel.StoreId = (int)idr["StoreId"]; }
                    if (idr["StoreName"] != DBNull.Value) { oCModel.StoreName = (string)idr["StoreName"]; }
                    if (idr["Status"] != DBNull.Value) { oCModel.Status = (int)idr["Status"]; }
                    if (idr["ImageList"] != DBNull.Value) { oCModel.ImageList = (string)idr["ImageList"]; }
                    if(!String.IsNullOrWhiteSpace(oCModel.ImageList))
                    {
                        oCModel.ImageArray = StringManager.ConvertStringList(oCModel.ImageList);
                    }
                    if (idr["AtchmentList"] != DBNull.Value) { oCModel.AtchmentList = (string)idr["AtchmentList"]; }
                    if (!String.IsNullOrWhiteSpace(oCModel.AtchmentList))
                    {
                        oCModel.AtchmentArray = StringManager.ConvertStringList(oCModel.AtchmentList);
                    }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }
                 
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