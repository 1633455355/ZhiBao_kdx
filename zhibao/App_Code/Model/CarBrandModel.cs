using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CarBrandModel 的摘要说明
/// </summary>
public class CarBrandModel
{
    /// <summary>
    /// 车品牌代码
    /// </summary>
    public int CarBrandCode { get; set; }
    /// <summary>
    /// 车品牌
    /// </summary>
    public string CarBrandName { get; set; }
    /// <summary>
    /// 车品牌拼音第一个字母
    /// </summary>

    public string Firstletter { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>

    public DateTime CreateTime { get; set; }
}