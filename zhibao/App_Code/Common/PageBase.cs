using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public abstract class PageBase:Page
{
    protected abstract string ModuleKey
    {
        get;
    }
    protected abstract int PermissionsKey
    {
        get;
    }
}
