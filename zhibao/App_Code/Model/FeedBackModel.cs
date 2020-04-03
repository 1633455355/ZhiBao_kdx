using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FeedBackModel 的摘要说明
/// </summary>
public class FeedBackModel
{
    /// <summary>
    /// 反馈信息ID
    /// </summary>
    public int FeedBackId { get; set; }
    /// <summary>
    /// 反馈的信息标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 反馈内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 联系人姓名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 联系人电话
    /// </summary>
    public string Mobile { get; set; }
    /// <summary>
    /// 联系人邮件
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// 联系人的省ID
    /// </summary>
    public int ProvinceId { get; set; }
    /// <summary>
    /// 联系人的省份
    /// </summary>
    public string ProvinceName { get; set; }
    /// <summary>
    /// 联系人的市ID
    /// </summary>
    public int CityId { get; set; }
    /// <summary>
    /// 联系人的市
    /// </summary>
    public string CityName { get; set; }
    /// <summary>
    /// /联系人的地址
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// 联系人的邮编
    /// </summary>
    public string Zip { get; set; }
    /// <summary>
    /// 发送人的ID
    /// </summary>
    public int CreatorId { get; set; }
    /// <summary>
    /// 发送人的名称
    /// </summary>
    public string CreateName { get; set; }
    /// <summary>
    /// 发送时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 是否让经销商看到
    /// </summary>
    public bool IsdisplayDealer { get; set; }
}