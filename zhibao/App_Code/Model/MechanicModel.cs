using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MechanicModel 的摘要说明
/// </summary>
public class MechanicModel
{
    public int MechanicId { get; set; }
    public string Name { get; set; }
    public string Introduction { get; set; }
    public int Type { get; set; }

    public string TypeName{get;set;}
    public string Mobile { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public int StoreId { get; set; }

    public string StoreName{ get; set; }

    public DateTime CreateTime { get; set; }

    public string DealerName { get; set; }
}