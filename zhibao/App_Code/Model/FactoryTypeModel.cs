using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FactoryTypeModel 的摘要说明
/// </summary>
public class FactoryTypeModel
{
    public int FactoryTypeId
    {
        get;
        set;
    }
    public string FactoryTypeName
    {
        get;
        set;
    }
    public string ProductSecondLevelNameDefalut
    {
        get;
        set;
    }
    public int CreatorId
    {
        get;
        set;
    }
    public DateTime CreateTime
    {
        get;
        set;
    }
}