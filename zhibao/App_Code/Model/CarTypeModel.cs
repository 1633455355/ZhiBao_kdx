using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CarTypeModel 的摘要说明
/// </summary>
public class CarTypeModel
{
    /// <summary>
    /// 车类型代码
    /// </summary>
    public int CarTypeCode { get;set; }
    /// <summary>
    /// 车类型名称
    /// </summary>
    public string CarTypeName { get; set; }
    /// <summary>
    /// 车系代码
    /// </summary>
    public int CarSystemCode { get; set; }
    /// <summary>
    /// 车类型拼音第一个字母
    /// </summary>
    public string TY { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}