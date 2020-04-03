using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// PromotionModel 的摘要说明
/// </summary>
public class PromotionModel
{
    /// <summary>
    ///促销信息ID
    /// </summary>
    public int PromotionId { get; set; }
    /// <summary>
    /// 促销信息标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 促销信息主图
    /// </summary>
    public string Image { get; set; }
    /// <summary>
    /// 促销信息链接
    /// </summary>
    public string URL { get; set; }
    /// <summary>
    /// 促销信息内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 促销信息添加者ID
    /// </summary>
    public int CreatorId { get; set; }
    /// <summary>
    /// 促销信息添加者名称
    /// </summary>
    public string CreatorName { get; set; }
    /// <summary>
    /// 促销信息添加时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 促销信息更新者
    /// </summary>
    public int? UpLastor { get; set; }
    /// <summary>
    /// 促销信息更新时间
    /// </summary>
    public DateTime? UpLastTime { get; set; }
    /// <summary>
    /// 经销商ID
    /// </summary>
    public List<int> DealerIdList { get; set; }
}