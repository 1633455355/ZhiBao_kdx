using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class AdminModel
{
    /// <summary>
    /// 管理员ID
    /// </summary>
    public int AdminId { get; set; }
    /// <summary>
    /// 管理员名称
    /// </summary>
    public string AdminName { get; set; }
    /// <summary>
    /// 管理员密码
    /// </summary>
    public string AdminPassword { get; set; }
    /// <summary>
    /// 登陆类别
    /// </summary>
    public AdminType Type { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 创建者ID
    /// </summary>
    public int CreatorId { get; set; }
    /// <summary>
    /// 创建者名称
    /// </summary>
    public string Creator { get; set; }
    /// <summary>
    /// 角色ID
    /// </summary>
    public int RoleId { get; set; }
    /// <summary>
    /// 角色信息
    /// </summary>
    public RoleModel Role { get; set; }
    /// <summary>
    /// 经销商
    /// </summary>
    public DealerModel Dealer { get; set; }
    /// <summary>
    /// 加盟店
    /// </summary>
    public StoreModel Store { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public bool Status { get; set; }
}

