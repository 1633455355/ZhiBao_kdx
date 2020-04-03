using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RoleModel
{
    /// <summary>
    /// 角色ID
    /// </summary>
    public int RoleId { get; set; }
    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; set; }
    /// <summary>
    /// 创建者ID
    /// </summary>
    public int CreatorId { get; set; }
    /// <summary>
    /// 创建者名
    /// </summary>
    public string Creator { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 权限
    /// </summary>
    public List<PermissionsModel> Permissions { get; set; }
}

