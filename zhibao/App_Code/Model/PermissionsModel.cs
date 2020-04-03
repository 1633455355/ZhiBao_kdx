using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PermissionsModel
{
    /// <summary>
    /// 权限ID
    /// </summary>
    public int PermissionsId { get; set; }
    /// <summary>
    /// 权限名称
    /// </summary>
    public string PermissionsName { get; set; }

    /// <summary>
    /// 模块名称
    /// </summary>
    public string ModuleName { get; set; }
    /// <summary>
    /// 模块KEY值（唯一性）
    /// </summary>
    public string ModuleKey { get; set; }
    /// <summary>
    /// 模块连接
    /// </summary>
    public string ModuleLink { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>

    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 创建者ID
    /// </summary>
    public int CreatorId { get; set; }

}
