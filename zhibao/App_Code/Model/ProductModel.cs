using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProductModel 的摘要说明
/// </summary>
public class ProductModel
{
    /// <summary>
    /// 产品代码
    /// </summary>
    public string ProductCode { get; set; }
    /// <summary>
    /// 产品描述
    /// </summary>
    public string ProductDes { get; set; }
    /// <summary>
    ///  产品到达状态
    /// </summary>
    public int Status { get; set; }
    /// <summary>
    /// 经销商ID
    /// </summary>
    public int DealerId { get; set; }
    /// <summary>
    /// 经销商名称
    /// </summary>
    public string DealerName { get; set; }
    /// <summary>
    /// 经销商认证时间
    /// </summary>
    public DateTime Dealer_CreateTime { get; set; }
    /// <summary>
    /// 加盟店ID
    /// </summary>
    public int StoreId { get; set; }
    /// <summary>
    /// 加盟店名称
    /// </summary>
    public string StoreName { get; set; }
    /// <summary>
    /// 加盟店认证时间
    /// </summary>
    public DateTime Store_CreateTime { get; set; }
    /// <summary>
    /// 添加产品者ID
    /// </summary>
    public int CreatorId { get; set; }
    /// <summary>
    /// 添加产品者名称
    /// </summary>
    public string CreatorName { get; set; }
    /// <summary>
    /// 添加产品时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 产品一级分类ID
    /// </summary>
    public int ProductFirstLevelId { get; set; }
    /// <summary>
    /// 产品一级分类名称
    /// </summary>
    public string ProductFirstLevelName { get; set; }
    /// <summary>
    /// 产品二级分类ID
    /// </summary>
    public int ProductSecondLevelId { get; set; }
    /// <summary>
    /// 产品二级分类名称
    /// </summary>
    public string ProductSecondLevelName { get; set; }
    public int FactoryTypeId
    {
        get;
        set;
    }
    public string FactoryTypeName
    {
        get;
        set;
    }
    /// <summary>
    /// 经销商是否审核通过
    /// </summary>
    public int Dealer_Flag
    {
        get;
        set;
    }
    /// <summary>
    /// 门店是否审核通过
    /// </summary>
    public int Store_Flag
    {
        get;
        set;
    }
    //一卷膜的长度
    public float Length { get; set; }
}