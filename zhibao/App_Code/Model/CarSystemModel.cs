using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CarSystemModel 的摘要说明
/// </summary>
public class CarSystemModel
{
    /// <summary>
    /// 车系代码
    /// </summary>
    public int CarSystemCode { get; set; }
    /// <summary>
    /// 车系名称
    /// </summary>
    public string CarSystemName { get; set; }
    /// <summary>
    /// 车品牌代码
    /// </summary>
    public int CarBrandCode { get; set; }
    /// <summary>
    /// 车系拼音第一个字母
    /// </summary>
    public string SY { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}