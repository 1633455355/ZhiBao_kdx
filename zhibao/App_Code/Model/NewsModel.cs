using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NewsModel 的摘要说明
/// </summary>
public class NewsModel
{
    /// <summary>
    /// 新闻ID
    /// </summary>
    public int NewsId { get; set; }
    /// <summary>
    /// 新闻标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 新闻主图
    /// </summary>
    public string Image { get; set; }
    /// <summary>
    /// 链接
    /// </summary>
    public string URL { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 创建者ID
    /// </summary>
    public int CreatorId{get;set;}
    /// <summary>
    /// 创建者名
    /// </summary>
    public string CreatorName { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 更新者ID
    /// </summary>
    public int? UpLastor { get; set; }
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpLastTime { get; set; }
}