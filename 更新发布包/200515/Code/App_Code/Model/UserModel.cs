using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserModel 的摘要说明
/// </summary>
public class UserModel
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// 用户车子品牌代码
    /// </summary>
    public int CarBrandCode { get; set; }
    /// <summary>
    /// 用户车子品牌名称
    /// </summary>
    public string CarBrandCodeName { get; set; }
    /// <summary>
    /// 用户车子车系代码
    /// </summary>
    public int CarSystemCode { get; set; }
    /// <summary>
    /// 用户车子车系名称
    /// </summary>
    public string CarSysteName { get; set; }
    /// <summary>
    /// 用户车子类型代码
    /// </summary>
    public int CarTypeCode { get; set; }
    /// <summary>
    /// 用户车子类型名称
    /// </summary>
    public string CarTypeName { get; set; }
    /// <summary>
    /// 用户车牌
    /// </summary>
    public string Lincence { get; set; }
    /// <summary>
    /// 用户省份ID
    /// </summary>
    public int ProvinceId { get; set; }
    /// <summary>
    /// 用户省份名称
    /// </summary>
    public string ProvinceName { get; set; }
    /// <summary>
    /// 用户城市ID
    /// </summary>
    public int CityId { get; set; }
    /// <summary>
    /// 用户城市名称
    /// </summary>
    public string CityName { get; set; }
    /// <summary>
    /// 价格
    /// </summary>
    public float Price { get; set; }
    /// <summary>
    /// 用户手机
    /// </summary>
    public string Mobile { get; set; }
    /// <summary>
    /// 用户EMAIL
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// 加盟店ID
    /// </summary>
    public int StoreId { get; set; }
    /// <summary>
    /// 加盟店名称
    /// </summary>
    public string StoreName { get; set; }
    /// <summary>
    /// 产品代码
    /// </summary>
    public string ProductCode { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 一级类别ID
    /// </summary>
    public int F_ProductTypeId { get; set; }
    /// <summary>
    /// 二级类别名称
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

    public string ImageList { get; set; }

    public int MechanicId { get; set; }

    public int MechanicName { get; set; }

    public string ZBYear { get; set; }

    public int Type { get; set; }

    public float Meter { get; set; }

    public int DealerId { get; set; }

    public string DealerName { get; set; }

    public int IsQuanCare{get;set;}

    public string Remark { get; set; }
    public string Address { get; set; }
}