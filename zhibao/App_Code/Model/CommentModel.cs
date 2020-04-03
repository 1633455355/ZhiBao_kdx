using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CommentModel 的摘要说明
/// </summary>
public class CommentModel
{
    /// <summary>
    /// 评论ID
    /// </summary>
    public int CommentId { get; set; }
    /// <summary>
    /// 理赔单号
    /// </summary>
    public string CompensateNo { get; set; }
    /// <summary>
    /// 评论内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 发布者ID
    /// </summary>
    public int CreatorId { get; set; }
    /// <summary>
    /// 发布者名称
    /// </summary>
    public string CreatorName { get; set; }
    /// </summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 回复的评论ID
    /// </summary>
    public int Parents_CommentId { get; set; }
}