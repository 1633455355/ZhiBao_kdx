<%@ WebHandler Language="C#" Class="MobileProductHandler" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.OleDb;



public class MobileProductHandler : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private ProductBLL pb = new ProductBLL();
    
    public void ProcessRequest (HttpContext context) {
        UserAdd(context);
        ResponseResult();
    }
    private void ResponseResult()
    {
        HttpContext.Current.Response.ContentType = "text/html";
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);
        sb.Append("\",\"returnmsg\":\"");
        sb.Append(returnMsg);
        sb.Append("\"}"); 
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private string UpImage(HttpContext context)
    {
        string temp = "";
        if (context.Request.Files.Count > 0)
        {
            for(int i=0;i<context.Request.Files.Count;i++)
            {
                if (i == 0)
                {
                    string file = context.Request.Files[i].FileName;
                    int pos = file.LastIndexOf('.');
                    string fileNameTemp;
                    string fileNameExt;
                    fileNameExt = file.Substring(pos);
                    string tempName = DateTime.Now.Ticks.ToString() + fileNameExt; ;
                    fileNameTemp = context.Server.MapPath("~\\UpLoadImage\\") + tempName;
                    context.Request.Files[i].SaveAs(fileNameTemp);
                    temp=tempName;
                }
                else
                {
                    string file = context.Request.Files[i].FileName;
                    int pos = file.LastIndexOf('.');
                    string fileNameTemp;
                    string fileNameExt;
                    fileNameExt = file.Substring(pos);
                    string tempName = DateTime.Now.Ticks.ToString() + fileNameExt; ;
                    fileNameTemp = context.Server.MapPath("~\\UpLoadImage\\") + tempName;
                    context.Request.Files[i].SaveAs(fileNameTemp);
                    temp = temp + "|" + tempName;
                }

            }
           
        }
        return temp;
    }
   
    private void UserAdd(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, HttpContext.Current))
        {

            string codeone = context.Request["frontcode_ddl"];
            string Productcodeone = context.Request["frontProductcode_ddl"];
            string codetwo = context.Request["backcode_ddl"];
            string Productcodetwo = context.Request["backProductcode_ddl"];
            string name = context.Request["name_txt"];
            string mobile = context.Request["mobile_txt"];
            string email =context.Request["email_txt"];
            string brand = context.Request["brand_ddl"];
            string system = context.Request["system_ddl"] ;
            string type =context.Request["type_ddl"];
            string js = context.Request["js_ddl"];
            string license = context.Request["license_txt"];
            string province =context.Request["province_ddl"];
            string city =context.Request["city_ddl"];
            string price =context.Request["price_txt"];
            string _ImageList = UpImage(context);
           
            bool flagone = true;
            bool flagtwo = true;
            try
            {

                if (!string.IsNullOrWhiteSpace(codeone))
                {
                    flagone = false;
                    List<ProductTypeModel> list = new List<ProductTypeModel>();
                    pb.GetProductSecondLevelInfoByStoreId(1, user.AdminId, out list);
                    foreach (ProductTypeModel model in list)
                    {
                        if (Convert.ToInt32(codeone) == model.S_ProductTypeId)
                        {
                            flagone = true;
                            break;
                        }
                    }
                }
                //int counttwo = 0;
                if (!string.IsNullOrWhiteSpace(codetwo))
                {
                    flagtwo = false;
                    List<ProductTypeModel> list = new List<ProductTypeModel>();
                    pb.GetProductSecondLevelInfoByStoreId(2, user.AdminId, out list);
                    foreach (ProductTypeModel model in list)
                    {
                        if (Convert.ToInt32(codetwo) == model.S_ProductTypeId)
                        {
                            flagtwo = true;
                            break;
                        }
                    }
                }

                if (!flagone)
                {
                    errorCode = 5;

                }
                if (!flagtwo)
                {
                    errorCode = 6;
                }

                if (flagone && flagtwo)
                {
                    UserBLL ub = new UserBLL();
                    if (!string.IsNullOrWhiteSpace(codeone))
                    {


                        int id = 0;
                        UserModel model = new UserModel();
                        if (!string.IsNullOrWhiteSpace(Productcodeone))
                        {
                            model.ProductCode = Productcodeone;
                        }
                        if (!string.IsNullOrWhiteSpace(brand))
                        {
                            model.CarBrandCode = Convert.ToInt32(brand);
                        }
                        if (!string.IsNullOrWhiteSpace(system))
                        {
                            model.CarSystemCode = Convert.ToInt32(system);
                        }
                        if (!string.IsNullOrWhiteSpace(type))
                        {
                            model.CarTypeCode = Convert.ToInt32(type);
                        }
                        if (!string.IsNullOrWhiteSpace(city))
                        {
                            model.CityId = Convert.ToInt32(city);
                        }
                        model.MechanicId = Int16.Parse(js);
                        model.Lincence = license;
                        model.Mobile = mobile;
                        if (!string.IsNullOrWhiteSpace(price))
                        {
                            model.Price = float.Parse(price);
                        }
                        model.F_ProductTypeId = 1;
                        model.S_ProductTypeId = Convert.ToInt32(codeone);
                        if (!string.IsNullOrWhiteSpace(province))
                        {
                            model.ProvinceId = Convert.ToInt32(province);
                        }

                        model.StoreId = user.AdminId;
                        model.UserName = name;
                        model.Email = email;
                        model.ImageList =_ImageList;
                        ub.AddUser(model, out id);
                    }
                    if (!string.IsNullOrWhiteSpace(codetwo))
                    {
                        int id = 0;
                        UserModel model = new UserModel();
                        if (!string.IsNullOrWhiteSpace(Productcodetwo))
                        {
                            model.ProductCode = Productcodetwo;
                        }
                        if (!string.IsNullOrWhiteSpace(brand))
                        {
                            model.CarBrandCode = Convert.ToInt32(brand);
                        }
                        if (!string.IsNullOrWhiteSpace(system))
                        {
                            model.CarSystemCode = Convert.ToInt32(system);
                        }
                        if (!string.IsNullOrWhiteSpace(type))
                        {
                            model.CarTypeCode = Convert.ToInt32(type);
                        }
                        if (!string.IsNullOrWhiteSpace(city))
                        {
                            model.CityId = Convert.ToInt32(city);
                        }
                        model.MechanicId = Int16.Parse(js);
                        model.Lincence = license;
                        model.Mobile = mobile;
                        if (!string.IsNullOrWhiteSpace(price))
                        {
                            model.Price = float.Parse(price);
                        }
                        model.F_ProductTypeId = 2;
                        model.S_ProductTypeId = Convert.ToInt32(codetwo);
                        if (!string.IsNullOrWhiteSpace(province))
                        {
                            model.ProvinceId = Convert.ToInt32(province);
                        }

                        model.StoreId = user.AdminId;
                        model.UserName = name;
                        model.Email = email;
                        model.ImageList = _ImageList;
                        ub.AddUser(model, out id);

                        if (id > 0)
                        {
                            try
                            {
                                string url = "http://sms.bechtech.cn/Api/send/data/json?accesskey=2911&secretkey=47b6eaf17855c06b1acbd6c12c80124d58aa4912&mobile=" + model.Mobile + "&content=" + HttpUtility.UrlEncode("感谢您选择" + Config.CompanyName + "汽车窗膜，在此提示您三天内请不要升降您的车窗，更多服务敬请拨打电话：400-700-3007进行咨询。【北极光】");
                                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                                System.Net.WebResponse res = req.GetResponse();
                                Stream ReceiveStream = res.GetResponseStream();
                                StreamReader sr = new StreamReader(ReceiveStream, System.Text.Encoding.Default);
                                string resultstring = sr.ReadToEnd();
                            }
                            catch (Exception ex)
                            {
                                WriteLog.WriteExceptionLog("发送短信", ex);
                            }

                        }
                    }
                    errorCode = 0;
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("UserAdd", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
  
    public bool IsReusable {
        get {
            return false;
        }
    }

}