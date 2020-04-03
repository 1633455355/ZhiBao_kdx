using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DealerModel
{
    /// <summary>
    /// ID
    /// </summary>
    public int AdminId { get; set; }
    /// <summary>
    /// 经销商公司名称
    /// </summary>
    public string DealerCompanyName { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    public string Contacts { get; set;}
    /// <summary>
    /// 职位
    /// </summary>
    public string Position
    {
        get;
        set;
    }
    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// 手机
    /// </summary>
    public string Mobile { get; set; }
    /// <summary>
    /// 传真
    /// </summary>
    public string Fax { get; set; }
    /// <summary>
    /// 省ID
    /// </summary>
    public int ProvinceId { get; set; }
    /// <summary>
    /// 省名称
    /// </summary>
    public string ProvinceName { get; set; }
    /// <summary>
    /// 市ID
    /// </summary>
    public int CityId { get; set; }
    /// <summary>
    /// 市名称
    /// </summary>
    public string CityName { get; set; }
    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// 邮编
    /// </summary>
    public string Zip { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// 连接地址
    /// </summary>
    public string URL { get; set; }
    /// <summary>
    /// 经销商区域、几级代理描述
    /// </summary>
    public string DealerAreaLevelDes { get; set; }
    /// <summary>
    /// 注释
    /// </summary>
    public string Remark { get; set; }
}

