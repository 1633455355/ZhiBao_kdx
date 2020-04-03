using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProductBLL 的摘要说明
/// </summary>
public class ProductBLL
{
    private ProductDAL pd = null;
	public ProductBLL()
	{
        pd = new ProductDAL();
	}
    
    /// <summary>
    /// 添加产品代码
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
	public string AddProductInfo(ProductModel oPModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.AddProductInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.AddProductInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
     /// <summary>
    /// 更新产品代码信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetProductInfo(ProductModel oPModel,string NewsProductCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductInfo(oPModel, NewsProductCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

      /// <summary>
    /// 删除产品代码信息
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <returns></returns>
    public string RemoveProductInfo(string ProductCode)
    {
       string ret = Config.Fail;
        try
        {
            ret = pd.RemoveProductInfo(ProductCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.RemoveProductInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    public string RemoveProductInfobyDealer(string ProductCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.RemoveProductInfobyDealer(ProductCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.RemoveProductInfobyDealer()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    public string RemoveProductInfobyStore(string ProductCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.RemoveProductInfobyStore(ProductCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.RemoveProductInfobyStore()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 经销商认证产品信息
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string SetProductInfoByDealer(string ProductCode, int DealerId, int ProductFirstLevelId, int ProductSecondLevelId, string UpCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductInfoByDealer(ProductCode, DealerId, ProductFirstLevelId, ProductSecondLevelId, UpCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductInfoByDealer()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
      /// <summary>
    /// 加盟店认证产品信息
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public string SetProductInfoByStore(string ProductCode, int StoreId, int ProductFirstLevelId, int ProductSecondLevelId,string UpCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductInfoByStore(ProductCode, StoreId, ProductFirstLevelId, ProductSecondLevelId, UpCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductInfoByStore()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 设置产品状态
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <returns></returns>
    public string SetProductInfoByStatus(string ProductCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductInfoByStatus(ProductCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductInfoByStatus()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 添加产品二级分类
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string AddProductSecondLevelInfo(string ProductSecondLevelName, int ProductFirstLevelId, int FactoryTypeId, out int ProductSecondLevelId)
    {
        string ret = Config.Fail;
        ProductSecondLevelId = 0;
        try
        {
            ret = pd.AddProductSecondLevelInfo(ProductSecondLevelName, ProductFirstLevelId, FactoryTypeId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                ProductSecondLevelId = Id;
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.AddProductSecondLevelInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    /// <summary>
    /// 更新产品二级分类
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string SetProductSecondLevelInfo(string ProductSecondLevelName, int ProductSecondLevelId, int FactoryTypeId)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductSecondLevelInfo(ProductSecondLevelName, ProductSecondLevelId, FactoryTypeId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductSecondLevelInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

     /// <summary>
    /// 删除产品二级分类
    /// </summary>
    /// <param name="ProductSecondLeveName"></param>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string RemoveProductSecondLevelInfo(int ProductSecondLevelId)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.RemoveProductSecondLevelInfo(ProductSecondLevelId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.RemoveProductSecondLevelInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
     /// <summary>
    /// 得到一级产品类别
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string GetProductFirstLevelInfo(int? ProductFirstLevelId,out List<ProductTypeModel> olist)
    {
        olist = new List<ProductTypeModel>();
        try
        {
            olist = pd.GetProductFirstLevelInfo(ProductFirstLevelId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.GetProductFirstLevelInfo()", ex);
            return Config.ExceptionMsg;
        }
    }
     /// <summary>
    /// 得到二级产品类别
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <returns></returns>
    public string GetProductSecondLevelInfo(int? ProductFirstLevelId, out List<ProductTypeModel> olist)
    {
        olist = new List<ProductTypeModel>();
        try
        {
            olist = pd.GetProductSecondLevelInfo(ProductFirstLevelId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.GetProductSecondLevelInfo()", ex);
            return Config.ExceptionMsg;
        }
    }

       /// <summary>
    /// 得到用户列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetProductInfoList(int PageIndex, int PageNum, int? ProductFirstLevelId, int? ProductSecondLevelId, string ProductCode, int? DealerId, int? StoreId, int? Status, int? FactoryTypeId,int? dealer_flag,int? store_flag, out int Count, out List<ProductModel> olist)
    {
        olist = new List<ProductModel>();
        Count = 0;
        string where = " 1=1";
        if (ProductFirstLevelId!=null) {
            where += " and ProductInfo.ProductFirstLevelId=" + ProductFirstLevelId.Value;
        }
        if (ProductSecondLevelId != null){
            where += " and ProductInfo.ProductSecondLevelId=" + ProductSecondLevelId.Value;
        }
        if (!String.IsNullOrEmpty(ProductCode)) {
            where += " and ProductInfo.ProductCode='" + ProductCode + "'";
        }
        if (DealerId != null){
            where += " and ProductInfo.DealerId=" + DealerId.Value;
        }
        if (StoreId != null)  {
            where += " and ProductInfo.StoreId=" + StoreId.Value;
        }
        if (Status != null) {
            where += " and ProductInfo.Status=" + Status.Value;
        }
        if (FactoryTypeId!=null)
        {
            where += " and ProductInfo.FactoryTypeId=" + FactoryTypeId.Value;
        }
        if(dealer_flag!=null)
        {
            where += " and ProductInfo.Dealer_Flag=" + dealer_flag.Value;
        }
        if (store_flag != null)
        {
            where += " and ProductInfo.Store_Flag=" + store_flag.Value;
        }
        try
        {
            olist = pd.GetProductList(PageIndex, PageNum, where, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.GetProductInfoList()", ex);
            return Config.ExceptionMsg;
        }
    }
    /// <summary>
    /// 添加用户信息是，得到类别列表
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public string GetProductSecondLevelInfoByStoreId(int ProductFirstLevelId,int StoreId, out List<ProductTypeModel> olist)
    {
        olist = new List<ProductTypeModel>();
        try
        {
            olist = pd.GetProductSecondLevelInfoByStoreId(ProductFirstLevelId, StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.GetProductSecondLevelInfoByStoreId()", ex);
            return Config.ExceptionMsg;
        }
    }

    /// <summary>
    /// 添加用户信息是，得到类别列表
    /// </summary>
    /// <param name="ProductFirstLevelId"></param>
    /// <param name="StoreId"></param>
    /// <returns></returns>
    public string GetProduct_T_SecondLevelInfoByStoreId(int ProductFirstLevelId, int StoreId, out List<ProductTypeModel> olist)
    {
        olist = new List<ProductTypeModel>();
        try
        {
            olist = pd.GetProduct_T_SecondLevelInfoByStoreId(ProductFirstLevelId, StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.GetProduct_T_SecondLevelInfoByStoreId()", ex);
            return Config.ExceptionMsg;
        }
    }


    /// <summary>
    /// 添加产品代码
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddF_ProductInfo(ProductModel oPModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.AddF_ProductInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.AddF_ProductInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }



    /// <summary>
    /// 添加产品代码
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetF_ProductInfo(ProductModel oPModel, string NewsProductCode)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetF_ProductInfo(oPModel, NewsProductCode);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetF_ProductInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 经销商上认证审核
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="Dealer_Flag"></param>
    /// <returns></returns>
    public string SetProductInfoByAudDealerFlag(string ProductCode, int Dealer_Flag)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductInfoByAudDealerFlag(ProductCode,Dealer_Flag);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductInfoByAudDealerFlag()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    public string SetProductInfoByAllAudDealerFlag(string []CodeList,int Dealer_Flag)
    {
        string msg="";
        if(CodeList!=null &&CodeList.Length>0)
        {
            foreach(string code in CodeList)
            {
                if (!String.IsNullOrWhiteSpace(code))
                {
                    msg = SetProductInfoByAudDealerFlag(code, Dealer_Flag);
                }
            }
        }
        return msg;
       
    }
     /// <summary>
    /// 店面认证审核
    /// </summary>
    /// <param name="ProductCode"></param>
    /// <param name="Dealer_Flag"></param>
    /// <returns></returns>
    public string SetProductInfoByAudStoreFlag(string ProductCode, int Store_Flag)
    {
        string ret = Config.Fail;
        try
        {
            ret = pd.SetProductInfoByAudStoreFlag(ProductCode, Store_Flag);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("ProductBLL.SetProductInfoByAudStoreFlag()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    public string SetProductInfoByAllAudStoreFlag(string [] CodeList, int Store_Flag)
    {
        string msg = "";
        if (CodeList != null && CodeList.Length > 0)
        {
            foreach (string code in CodeList)
            {
                if (!String.IsNullOrWhiteSpace(code))
                {
                    msg = SetProductInfoByAudStoreFlag(code, Store_Flag);
                }
            }
        }
        return msg;

    }
}