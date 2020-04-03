using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Common 的摘要说明
/// </summary>
public class Common
{
    
	public Common()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static int Permission_Add = 1;
    public static int Permission_Update = 2;
    public static int Permission_Delete = 3;
    public static int Permission_View = 4;

    public static string Module_Message = "XXGL"; //信息模块
    public static string Module_News = "ZXGL"; //资讯
    public static string Module_Promotion = "CXHDGL"; //促销管理
    public static string Module_Admin = "YHGL"; //用户管理
    public static string Module_Feedback = "FKXXGL"; //反馈管理
    public static string Module_Car = "CXGL"; //车型管理
    public static string Module_Product = "CPDMGL"; //产品编码管理
    public static string Module_Report = "TJBBGL"; //报表管理
    public static string Module_User = "KHGL"; //客户管理
    public static string Module_Role = "QXGL"; //角色管理
    public static string Module_Product_Type = "CPLXGL"; //产品类型管理
    public static string Module_Product_Verify = "CPRZGL"; //产品认证管理
    public static string Module_Factory_Type = "GCCPLXGL"; //工厂产品类型管理
    public static string Module_Compensate = "LPGL"; //理赔管理
    public static bool CheckPermission(string modulekey,int permission,HttpContext context)
    {
        bool flag = false;
        AdminModel user = GetLoginAdmin(context);
        if (context != null && user!=null)
        {
            List<PermissionsModel> list = user.Role.Permissions;
            foreach (PermissionsModel per in list)
            {
                if (per.ModuleKey.Equals(modulekey) && per.PermissionsId == permission)
                {
                    flag = true;
                    break;
                }
            }
        }
        return flag;
    }
    public static bool CheckPermission(string modulekey, int permission, int AdminId)
    {
        bool flag = false;
        AdminModel user = GetLoginAdmin(AdminId);
        if (user != null)
        {
            List<PermissionsModel> list = user.Role.Permissions;
            foreach (PermissionsModel per in list)
            {
                if (per.ModuleKey.Equals(modulekey) && per.PermissionsId == permission)
                {
                    flag = true;
                    break;
                }
            }
        }
        return flag;
    }
    public static void ClearSessinAdminInfro(HttpContext context)
    {
        if (context.Session != null && context.Session["admin"] != null)
        {
            context.Session["admin"] = null;
        }
    }
    public static AdminModel GetLoginAdmin(HttpContext context)
    {
        AdminModel model = null;

        if (context.User.Identity.IsAuthenticated)
        {
            if (context.Session != null && context.Session["admin"] != null)
            {
                model = (AdminModel)context.Session["admin"];
            }

            try
            {
                if (model == null)
                {
                    AdminBLL ab = new AdminBLL();
                    List<AdminModel> list = new List<AdminModel>();
                    int count = 0;
                    ab.GetAdminList(1, 1, Convert.ToInt32(context.User.Identity.Name), null, null, null, null, null, out count, out list);
                    //ab.GetAdminList(1, 1, 1, null, null, null, null, null, out count, out list);
                    if (list.Count == 1)
                    {
                        model = list[0];
                        context.Session["admin"] = model;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return model;
    }
    public static AdminModel GetLoginAdmin(int AdminId)
    {
            AdminModel model = null;
            try
            {
                if (model == null)
                {
                    AdminBLL ab = new AdminBLL();
                    List<AdminModel> list = new List<AdminModel>();
                    int count = 0;
                    ab.GetAdminList(1, 1, AdminId, null, null, null, null, null, out count, out list);
                    if (list.Count == 1)
                    {
                        model = list[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
        return model;
    }
    public static List<ProvinceModel> LoadProvince()
    {
        Province_City_CarBLL pcc = new Province_City_CarBLL();
        int count = 0;
        List<ProvinceModel> list = new List<ProvinceModel>();
        pcc.GetProvinceList(null, out count, out list);
        return list;
    }

    public static List<CityModel> LoadCityByProvinceID(int id)
    {
        Province_City_CarBLL pcc = new Province_City_CarBLL();
        List<CityModel> list = new List<CityModel>();
        int count = 0;
        pcc.GetCityList(id, out count, out list);
        return list;
    }
    public static List<ProductTypeModel> GetProductTypeOneList()
    {
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        ProductBLL pb = new ProductBLL();
        pb.GetProductFirstLevelInfo(null, out list);
        return list;
    }
    public static List<ProductTypeModel> GetProductTypeTwoList(int id)
    {
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        ProductBLL pb = new ProductBLL();
        pb.GetProductSecondLevelInfo(id, out list);
        return list;
    }
    public static List<DealerModel> GetDealerList(out int total)
    {
        List<DealerModel> list = new List<DealerModel>();
        total = 0;
        try
        {
            DealerBLL db = new DealerBLL();
            
            db.GetDealerModelList(1, 1000000, null, null, out total, out list);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return list;
    }
    public static List<StoreModel> GtetStoreList(out int total)
    {
        List<StoreModel> list = new List<StoreModel>();
        total = 0;
        try
        {
            StoreBLL sb = new StoreBLL();

            sb.GetStoreModelList(1, 1000000, null, null,null, out total, out list);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return list;
    }
    public static List<RoleModel> GetRoleList()
    {
        List<RoleModel> list = new List<RoleModel>();
        AdminBLL ab = new AdminBLL();
        ab.GetRoleList(null, out list);
        return list;
    }
    public static string IPAddress
    {
        get
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理 
                if (result.IndexOf(".") == -1)    //没有“.”肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];    //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null;    //代理中的内容 非IP，取IP 
                }

            }

            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
                && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty)
                ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;

            return result;
        }
    }

    /// <summary>
    /// 判断是否是IP地址格式 0.0.0.0
    /// </summary>
    /// <param name="str1">待判断的IP地址</param>
    /// <returns>true or false</returns>
    public static bool IsIPAddress(string str1)
    {
        if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15)
            return false;

        string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

        Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
        return regex.IsMatch(str1);
    }
   
}