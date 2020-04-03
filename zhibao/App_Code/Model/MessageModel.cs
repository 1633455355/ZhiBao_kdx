using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MessageModel 的摘要说明
/// </summary>
public class MessageModel
{
    /// <summary>
    /// 消息ID
    /// </summary>
    public int MessageId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool IsRead { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int From { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string FromName { get; set; }
    public int To { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ToName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime CreateTime { get; set; }

}