using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public abstract class UserPageBase : PageBase
{

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.CheckKey();
    }
    private void CheckKey()
    {
        int Flag = 0;
        //if (Session["UserInfo"] == null) { Response.Redirect("/Login.aspx?ReturnUrl=" + Request.RawUrl); }
        Flag = GetModulePermission(this.ModuleKey, this.PermissionsKey);
        if (Flag == 0) { alert(this.Page, "您没有此模块的相应权限！"); }


    }
    /// <summary>
    /// 判断权限
    /// </summary>
    /// <param name="ModuleKeyList"></param>
    /// <returns></returns>
    private int GetModulePermission(string _ModuleKey,int _PermissionsKey)
    {
        AdminModel oAModel = (AdminModel)Session["AdminModel"];
        if (oAModel != null && oAModel.Role != null && oAModel.Role.Permissions != null && oAModel.Role.Permissions.Count> 0)
        {
            foreach (PermissionsModel MPModel in oAModel.Role.Permissions)
            {
                if(MPModel.ModuleKey==_ModuleKey&&MPModel.PermissionsId==_PermissionsKey)
                {
                    return 1;
                }
            }
        }
        return 0;
    }

    /// <summary>
    /// 现实信息
    /// </summary>
    /// <param name="page"></param>
    /// <param name="msg"></param>
    public void alert(Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "alterMsg", "<script>alert('" + msg + "'); self.history.go(-1); </script>)");
    }
}
