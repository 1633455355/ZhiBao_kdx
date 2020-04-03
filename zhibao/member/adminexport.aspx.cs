using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class member_adminexport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        importAdmin();
    }
    public void importAdmin()
    {
        string username =Request["Username"];
        string relastion =Request["Relastion"];
        string role = Request["Role"];
        string name = Request["Name"];
        string dealer =Request["Dealer"];

        int? roleId = null;
        if (!string.IsNullOrWhiteSpace(role))
        {
            roleId = int.Parse(role);
        }

        int? dealerid = null;
        if (!string.IsNullOrWhiteSpace(dealer))
        {
            dealerid = int.Parse(dealer);
        }
        try
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=admin_" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.ContentType = "application/excel";
            StringBuilder sb = new StringBuilder();
            AdminBLL ab = new AdminBLL();
            List<AdminModel> list = new List<AdminModel>();
            int total = 0;
            if (relastion.Equals("admin"))
            {
                ab.GetAdminList(1, 1000000000, null, username, AdminType.Managers, roleId, null, null, out total, out list);

                sb.Append("用户名,用户类型,角色,状态\r\n");

                foreach (AdminModel o in list)
                {
                    sb.Append("\"" + o.AdminName + "\"" + ",");
                    sb.Append("\"管理员\"" + ",");
                    sb.Append("\"" + o.Role.RoleName + "\"" + ",");
                    if (o.Status)
                    {
                        sb.Append("\"正常\"" + ",");
                    }
                    else
                    {
                        sb.Append("\"禁止登陆\"" + ",");
                    }
                
                    sb.Append("\r\n");

                }
            }
            else if (relastion.Equals("dealer"))
            {
                ab.GetAdminList(1, 10000000, null, username, AdminType.Dealer, roleId, name, null, out total, out list);
                sb.Append("用户名,用户类型,角色,状态,名称,联系人,职位,电话,手机,传真,省,市,地址,邮编,邮箱\r\n");

                foreach (AdminModel o in list)
                {
                    sb.Append("\"" + o.AdminName + "\"" + ",");
                    sb.Append("\"经销商\"" + ",");
                    sb.Append("\"" + o.Role.RoleName + "\"" + ",");
                    if (o.Status)
                    {
                        sb.Append("\"正常\"" + ",");
                    }
                    else
                    {
                        sb.Append("\"禁止登陆\"" + ",");
                    }
                    sb.Append("\"" + o.Dealer.DealerCompanyName + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Contacts + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Position + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Phone + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Mobile + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Fax + "\"" + ",");
                    sb.Append("\"" + o.Dealer.ProvinceName + "\"" + ",");
                    sb.Append("\"" + o.Dealer.CityName + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Address + "\"" + ",");
                    sb.Append("\"" + o.Dealer.Zip + "\"" + ",");
                   
                    sb.Append("\"" + o.Dealer.Email + "\"" + "\r\n");

                }
            }
            else if (relastion.Equals("store"))
            {
                ab.GetAdminList(1, 100000000, null, username, AdminType.Stores, roleId, name, dealerid, out total, out list);
                sb.Append("用户名,用户类型,角色,状态,名称,联系人,职位,电话,手机,传真,省,市,地址,邮编,邮箱,所属经销商\r\n");

                foreach (AdminModel o in list)
                {
                    sb.Append("\"" + o.AdminName + "\"" + ",");
                    sb.Append("\"门店\"" + ",");
                    sb.Append("\"" + o.Role.RoleName + "\"" + ",");
                    if (o.Status)
                    {
                        sb.Append("\"正常\"" + ",");
                    }
                    else
                    {
                        sb.Append("\"禁止登陆\"" + ",");
                    }
                    sb.Append("\"" + o.Store.StoreName + "\"" + ",");
                    sb.Append("\"" + o.Store.Contacts + "\"" + ",");
                    sb.Append("\"" + o.Store.Position + "\"" + ",");
                    sb.Append("\"" + o.Store.Phone + "\"" + ",");
                    sb.Append("\"" + o.Store.Mobile + "\"" + ",");
                    sb.Append("\"" + o.Store.Fax + "\"" + ",");
                    sb.Append("\"" + o.Store.ProvinceName + "\"" + ",");
                    sb.Append("\"" + o.Store.CityName + "\"" + ",");
                    sb.Append("\"" + o.Store.Address + "\"" + ",");
                    sb.Append("\"" + o.Store.Zip + "\"" + ",");
                  
                    sb.Append("\"" + o.Store.Email + "\"" + ",");

                    sb.Append("\"" + o.Store.DealerCompanyName + "\"" + "\r\n");

                }
            }

          
           


            Response.Write(sb.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("importAdmin", ex);
        }
    }
}