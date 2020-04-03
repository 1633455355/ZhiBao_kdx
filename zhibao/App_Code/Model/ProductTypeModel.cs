using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProductTypeModel 的摘要说明
/// </summary>
public class ProductTypeModel
{
    /// <summary>
    /// 一级类别ID
    /// </summary>
    public int F_ProductTypeId { get; set; }
    /// <summary>
    /// 一级类别名称
    /// </summary>
    public string F_ProductTypeName { get; set; }

    /// <summary>
    /// 二级类别ID
    /// </summary>
    public int S_ProductTypeId { get; set; }
    /// <summary>
    /// 二级类别名称
    /// </summary>
    public string S_ProductTypeName { get; set; }
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


}