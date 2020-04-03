using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// ProductDAL 的摘要说明
/// </summary>
public class ProductDAL
{
    /// <summary>
    /// 添加产品代码
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
	public string AddProductInfo(ProductModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oPModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", oPModel.ProductDes == null ? (Object)DBNull.Value : oPModel.ProductDes);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", oPModel.ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId",oPModel.ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _Length = new SqlParameter("@Length", oPModel.Length);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", oPModel.FactoryTypeId);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

     
        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 更新产品代码信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetProductInfo(ProductModel oPModel,string NewsProductCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oPModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct",NewsProductCode);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", oPModel.ProductDes == null ? (Object)DBNull.Value : oPModel.ProductDes);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId",oPModel.ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", oPModel.ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _Length = new SqlParameter("@Length", oPModel.Length);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", oPModel.FactoryTypeId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", oPModel.FactoryTypeId);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 删除产品代码信息
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <returns></returns>
    public string RemoveProductInfo(string ProductCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode",ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId",(Object)DBNull.Value );
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    public string RemoveProductInfobyDealer(string ProductCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Dealer_Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", (Object)DBNull.Value);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    public string RemoveProductInfobyStore(string ProductCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Store_Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", (Object)DBNull.Value);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);


        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);


        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 经销商认证产品信息
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string SetProductInfoByDealer(string ProductCode, int DealerId, int ProductFirstLevelId, int ProductSecondLevelId,string UpCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Dealer_Vaild");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode",ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", UpCode == null ? (Object)DBNull.Value : UpCode);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", DealerId);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 加盟店认证产品信息
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public string SetProductInfoByStore(string ProductCode, int StoreId, int ProductFirstLevelId, int ProductSecondLevelId, string UpCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Store_Vaild");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", UpCode == null ? (Object)DBNull.Value : UpCode);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);


        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", StoreId);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 设置产品状态
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <returns></returns>
    public string SetProductInfoByStatus(string ProductCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Code");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", (Object)DBNull.Value);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);


        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 添加产品二级分类
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string AddProductSecondLevelInfo(string ProductSecondLevelName, int ProductFirstLevelId, int FactoryTypeId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "AddSecond");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", ProductSecondLevelName);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", FactoryTypeId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);


        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 更新产品二级分类
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string SetProductSecondLevelInfo(string ProductSecondLevelName, int ProductSecondLevelId, int FactoryTypeId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "UpSecond");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", ProductSecondLevelName);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", FactoryTypeId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);


        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 删除产品二级分类
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string RemoveProductSecondLevelInfo(int ProductSecondLevelId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "DelSecond");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", (Object)DBNull.Value);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", ProductSecondLevelId);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 得到一级产品类别
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public List<ProductTypeModel> GetProductFirstLevelInfo(int? ProductFirstLevelId)
    {
        List<ProductTypeModel> olist = new List<ProductTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_ProductInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "selectFirst");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", ProductFirstLevelId == null ? (Object)DBNull.Value : ProductFirstLevelId.Value);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlcommand.Parameters.Add(_FactoryTypeId);


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
                    if (idr["ProductFirstLevelName"] != DBNull.Value) { oCModel.F_ProductTypeName = (string)idr["ProductFirstLevelName"]; }
              
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
    /// 得到二级产品类别
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public List<ProductTypeModel> GetProductSecondLevelInfo(int? ProductFirstLevelId)
    {
        List<ProductTypeModel> olist = new List<ProductTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_ProductInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "selectSecond");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", (Object)DBNull.Value);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", ProductFirstLevelId == null ? (Object)DBNull.Value : ProductFirstLevelId.Value);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_StoreId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Length);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlcommand.Parameters.Add(_FactoryTypeId);


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

                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.S_ProductTypeId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.S_ProductTypeName = (string)idr["ProductSecondLevelName"]; }
                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.F_ProductTypeId = (int)idr["ProductFirstLevelId"]; }
                    if (idr["ProductFirstLevelName"] != DBNull.Value) { oCModel.F_ProductTypeName = (string)idr["ProductFirstLevelName"]; }
                    if (idr["FactoryTypeId"] != DBNull.Value) { oCModel.FactoryTypeId = (int)idr["FactoryTypeId"]; }
                    if (idr["FactoryTypeName"] != DBNull.Value) { oCModel.FactoryTypeName = (string)idr["FactoryTypeName"]; }
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
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public List<ProductModel> GetProductList(int PageIndex, int PageNum, string where, out int Count)
    {
        List<ProductModel> olist = new List<ProductModel>();
        Count = 0;
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_ProductInfoList", sqlConnection);
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
                    ProductModel oCModel = new ProductModel();
                    if (idr["ProductCode"] != DBNull.Value) { oCModel.ProductCode = (string)idr["ProductCode"]; }
                    if (idr["ProductDes"] != DBNull.Value) { oCModel.ProductDes = (string)idr["ProductDes"]; }
                    if (idr["DealerCompanyName"] != DBNull.Value) { oCModel.DealerName = (string)idr["DealerCompanyName"]; }
                    if (idr["DealerId"] != DBNull.Value) { oCModel.DealerId = (int)idr["DealerId"]; }
                    if (idr["Dealer_CreateTime"] != DBNull.Value) { oCModel.Dealer_CreateTime = (DateTime)idr["Dealer_CreateTime"]; }
                    if (idr["Status"] != DBNull.Value) { oCModel.Status = (int)idr["Status"]; }
                    if (idr["StoreName"] != DBNull.Value) { oCModel.StoreName = (string)idr["StoreName"]; }
                    if (idr["StoreId"] != DBNull.Value) { oCModel.StoreId = (int)idr["StoreId"]; }
                    if (idr["Store_CreateTime"] != DBNull.Value) { oCModel.Store_CreateTime = (DateTime)idr["Store_CreateTime"]; }
                    if (idr["CreateTime"] != DBNull.Value) { oCModel.CreateTime = (DateTime)idr["CreateTime"]; }

                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["AdminName"] != DBNull.Value) { oCModel.CreatorName= (string)idr["AdminName"]; }
                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.ProductFirstLevelId = (int)idr["ProductFirstLevelId"]; }
                    if (idr["ProductFirstLevelName"] != DBNull.Value) { oCModel.ProductFirstLevelName = (string)idr["ProductFirstLevelName"]; }
                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.ProductSecondLevelId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.ProductSecondLevelName = (string)idr["ProductSecondLevelName"]; }

                    if (idr["FactoryTypeId"] != DBNull.Value) { oCModel.FactoryTypeId = (int)idr["FactoryTypeId"]; }
                    if (idr["FactoryTypeName"] != DBNull.Value) { oCModel.FactoryTypeName = (string)idr["FactoryTypeName"]; }
                    if (idr["Dealer_Flag"] != DBNull.Value) { oCModel.Dealer_Flag = (int)idr["Dealer_Flag"]; }
                    if (idr["Store_Flag"] != DBNull.Value) { oCModel.Store_Flag = (int)idr["Store_Flag"]; }
                    if (idr["Length"] != DBNull.Value) { oCModel.Length = float.Parse(idr["Length"].ToString()); }

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
    /// 添加用户信息是，得到类别列表
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public List<ProductTypeModel> GetProductSecondLevelInfoByStoreId(int ProductFirstLevelId, int StoreId)
    {
        List<ProductTypeModel> olist = new List<ProductTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_ProductType", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;


        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevel", ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductFirstLevelId);


        SqlParameter _StoreId = new SqlParameter("@StorerId", StoreId);
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
                    ProductTypeModel oCModel = new ProductTypeModel();

                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.S_ProductTypeId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.S_ProductTypeName = (string)idr["ProductSecondLevelName"]; }
                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.F_ProductTypeId = (int)idr["ProductFirstLevelId"]; }
                   // if (idr["ProductFirstLevelName"] != DBNull.Value) { oCModel.F_ProductTypeName = (string)idr["ProductFirstLevelName"]; }
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


    // <summary>
    /// 添加用户信息是，得到类别列表
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public List<ProductTypeModel> GetProduct_T_SecondLevelInfoByStoreId(int ProductFirstLevelId, int StoreId)
    {
        List<ProductTypeModel> olist = new List<ProductTypeModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_Product_T_Type", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;


        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevel", ProductFirstLevelId);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_ProductFirstLevelId);


        SqlParameter _StoreId = new SqlParameter("@StorerId", StoreId);
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
                    ProductTypeModel oCModel = new ProductTypeModel();

                    if (idr["ProductSecondLevelId"] != DBNull.Value) { oCModel.S_ProductTypeId = (int)idr["ProductSecondLevelId"]; }
                    if (idr["ProductSecondLevelName"] != DBNull.Value) { oCModel.S_ProductTypeName = (string)idr["ProductSecondLevelName"]; }
                    if (idr["ProductFirstLevelId"] != DBNull.Value) { oCModel.F_ProductTypeId = (int)idr["ProductFirstLevelId"]; }
                    if (idr["ProductFirstLevelName"] != DBNull.Value) { oCModel.F_ProductTypeName = (string)idr["ProductFirstLevelName"]; }
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
    /// 工厂添加产品代码
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddF_ProductInfo(ProductModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oPModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProductCode = new SqlParameter("@NewsProductCode", (Object)DBNull.Value);
        _NewsProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProductCode);


      
        SqlParameter _ProductDes = new SqlParameter("@ProductDes", oPModel.ProductDes == null ? (Object)DBNull.Value : oPModel.ProductDes);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);


        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", oPModel.FactoryTypeId);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeId);

        SqlParameter _Length = new SqlParameter("@Length", oPModel.Length);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_F_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }



    /// <summary>
    /// 工厂更新产品代码
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetF_ProductInfo(ProductModel oPModel,string NewsProductCode)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Up");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", oPModel.ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProductCode = new SqlParameter("@NewsProductCode", NewsProductCode == null ? (Object)DBNull.Value : NewsProductCode);
        _NewsProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProductCode);



        SqlParameter _ProductDes = new SqlParameter("@ProductDes", oPModel.ProductDes == null ? (Object)DBNull.Value : oPModel.ProductDes);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);


        SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", oPModel.FactoryTypeId);
        _FactoryTypeId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _Length = new SqlParameter("@Length", oPModel.Length);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_F_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 经销商上认证审核
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="Dealer_Flag"></param>
    /// <returns></returns>
    public string SetProductInfoByAudDealerFlag(string ProductCode,int Dealer_Flag)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "DealerAud");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", Dealer_Flag);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 店面认证审核
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="Dealer_Flag"></param>
    /// <returns></returns>
    public string SetProductInfoByAudStoreFlag(string ProductCode, int Store_Flag)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "StoreAud");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _ProductCode = new SqlParameter("@ProductCode", ProductCode);
        _ProductCode.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductCode);

        SqlParameter _NewsProduct = new SqlParameter("@NewsProduct", (Object)DBNull.Value);
        _NewsProduct.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_NewsProduct);

        SqlParameter _ProductDes = new SqlParameter("@ProductDes", (Object)DBNull.Value);
        _ProductDes.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductDes);

        SqlParameter _ProductFirstLevelId = new SqlParameter("@ProductFirstLevelId", Store_Flag);
        _ProductFirstLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductFirstLevelId);

        SqlParameter _ProductSecondLevelId = new SqlParameter("@ProductSecondLevelId", (Object)DBNull.Value);
        _ProductSecondLevelId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_ProductSecondLevelId);

        SqlParameter _DealerId = new SqlParameter("@DealerId", (Object)DBNull.Value);
        _DealerId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_DealerId);

        SqlParameter _StoreId = new SqlParameter("@StoreId", (Object)DBNull.Value);
        _StoreId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_StoreId);

        SqlParameter _Length = new SqlParameter("@Length", (Object)DBNull.Value);
        _Length.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Length);

        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);



        //SqlParameter _FactoryTypeId = new SqlParameter("@FactoryTypeId", (Object)DBNull.Value);
        //_FactoryTypeId.Direction = ParameterDirection.Input;
        //sqlparameterlist.Add(_FactoryTypeId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_ProductInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }


}