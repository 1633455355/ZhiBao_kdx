<%@ WebHandler Language="C#" Class="Product" %>

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



public class Product : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private ProductBLL pb = new ProductBLL();

    public void ProcessRequest (HttpContext context) {

        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "SearchUser":
                    this.SearchUser(context);
                    break;
                case "ProductClear":
                    this.ProductClear(context);
                    this.ResponseResult();
                    break;
                case "LoadProductAvailable":
                    this.LoadProductAvailable(context);
                    break;
                case "User_T_Add":
                    this.User_T_Add(context);
                    this.ResponseResult();
                    break;
                case "UserAdd":
                    this.UserAdd(context);
                    this.ResponseResult();
                    break;
                case "ProductVerify":
                    this.ProductVerify(context);
                    this.ResponseResult();
                    break;
                case "UpProductVerify":
                    this.UpProductVerify(context);
                    this.ResponseResult();
                    break;
                case  "DelProductVerify":
                    this.DelProductVerify(context);
                    this.ResponseResult();
                    break;
                case "DeleteProduct":
                    this.DeleteProduct(context);
                    this.ResponseResult();
                    break;
                case "F_DeleteProduct":
                    this.F_DeleteProduct(context);
                    this.ResponseResult();
                    break;
                case "SearchProduct":
                    this.SearchProduct(context);
                    break;
                case "MobileSearchUser":
                    this.MobileSearchUser(context);
                    break;
                case "F_SearchProduct":
                    this.F_SearchProduct(context);
                    break;
                case "ProductUpdate":
                    this.ProductUpdate(context);
                    this.ResponseResult();
                    break;
                case "F_ProductUpdate":
                    this.F_ProductUpdate(context);
                    this.ResponseResult();
                    break;
                case "ProductAdd":
                    this.ProductAdd(context);
                    this.ResponseResult();
                    break;
                case "F_ProductAdd":
                    this.F_ProductAdd(context);
                    this.ResponseResult();
                    break;
                case "ProductTypeAdd":
                    this.ProductTypeAdd(context);
                    this.ResponseResult();
                    break;
                case "ProductTypeUpdate":
                    this.ProductTypeUpdate(context);
                    this.ResponseResult();
                    break;
                case "GetProductTypeList":
                    this.GetProductTypeList(context);
                    break;
                case "GetStoreList":
                    this.GetStoreList(context);
                    break;
                case "DeleteProductType":
                    this.DeleteProductType(context);
                    this.ResponseResult();
                    break;
                case "GetF_ProductTypeList":
                    this.GetFactoryType(context);
                    this.ResponseResult();
                    break;
                case "dealer":
                    this.SetProductInfoByAudDealerFlag(context);
                    this.ResponseResult();
                    break;
                case "store":
                    this.SetProductInfoByAudStoreFlag(context);
                    this.ResponseResult();
                    break;
                case "AllAud_dealer":
                    this.SetProductInfoByAllAudDealerFlag(context);
                    this.ResponseResult();
                    break;
                case "AllAud_store":
                    this.SetProductInfoByAllAudStoreFlag(context);
                    this.ResponseResult();
                    break;
                case "GetProductCode":
                    this.GetProductCode(context);
                    break;
                case "GetProductCode1":
                    this.GetProductCode1(context);
                    break;
                case "GetProduct_T_Code":
                    this.GetProduct_T_Code(context);
                    break;
                case "GetMeter":
                    this.GetMeter(context);
                    break;
                case "DeleteUser":
                    this.DeleteUser(context);
                    this.ResponseResult();
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void GetProductCode(HttpContext context)
    {
        int total = 0;
        List<string> list = new List<string>();
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, context) || Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                CompensateBLL pb = new CompensateBLL();
                string fId = context.Request["FId"];
                if (!String.IsNullOrWhiteSpace(fId))
                {
                    if (user.Type == AdminType.Stores)
                    {
                        pb.GetProductSecondLevelInfoByStoreId(int.Parse(fId), user.AdminId, out list);
                    }
                }
                errorCode = 0;
                total = list.Count;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetProductTypeList", ex);
            }

        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void GetProductCode1(HttpContext context)
    {
        int total = 0;
        List<string> list = new List<string>();
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, context) || Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                CompensateBLL pb = new CompensateBLL();
                string fId = context.Request["FId"];
                if (!String.IsNullOrWhiteSpace(fId))
                {
                    if (user.Type == AdminType.Stores)
                    {
                        pb.GetProductSecondLevelInfoByStoreId_1(int.Parse(fId), user.AdminId, out list);
                    }
                }
                errorCode = 0;
                total = list.Count;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetProductTypeList", ex);
            }

        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void GetProduct_T_Code(HttpContext context)
    {
        int total = 0;
        List<string> list = new List<string>();
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, context) || Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                CompensateBLL pb = new CompensateBLL();
                string fId = context.Request["FId"];
                if (!String.IsNullOrWhiteSpace(fId))
                {
                    if (user.Type == AdminType.Stores)
                    {
                        pb.GetProduct_T_SecondLevelInfoByStoreId(int.Parse(fId), user.AdminId, out list);
                    }
                }
                errorCode = 0;
                total = list.Count;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetProduct_T_Code", ex);
            }

        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }

    private void GetMeter(HttpContext context)
    {
        string ret = "0";
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                UserBLL pb = new UserBLL();
                string Code = context.Request["Code"];
                if (!String.IsNullOrWhiteSpace(Code))
                {
                    ret = pb.GetProudctTMeter(Code, user.AdminId.ToString());
                }
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetMeter", ex);
            }

        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);


        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(ret));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();

    }
    private void GetFactoryType(HttpContext context)
    {
        int id = Convert.ToInt32(context.Request["ID"]);
        FactoryTypeBLL ftb = new FactoryTypeBLL();
        List<FactoryTypeModel> list = new List<FactoryTypeModel>();
        ftb.GetFactoryTypeInfo(id, out list);
        if(list.Count>0)
        {
            errorCode = 0;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);


        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();

    }
    private void SearchUser(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<UserModel> list = new List<UserModel>();
        if (Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {

                int page = int.Parse(context.Request["Page"]) + 1;
                int item = int.Parse(context.Request["Item"]);

                string code = context.Request["Code"];
                string firstType = context.Request["FirstType"];
                string brand = context.Request["Brand"];
                string dealer= context.Request["Dealer"];
                string store = context.Request["Store"];
                int? firstTypeid = null;
                if (firstType != null && !string.IsNullOrWhiteSpace(firstType))
                {
                    firstTypeid = Convert.ToInt32(firstType);
                }
                int? brandid = null;
                if (brand != null && !string.IsNullOrWhiteSpace(brand))
                {
                    brandid = Convert.ToInt32(brand);
                }
                int? storeid = null;
                if (store != null && !string.IsNullOrWhiteSpace(store))
                {
                    storeid = Convert.ToInt32(store);
                }
                UserBLL ub = new UserBLL();
                if (user.Type == AdminType.Managers)
                {
                    ub.GetUserList(page, item, null, code, storeid, firstTypeid,brandid,dealer, out total, out list);
                }
                 if (user.Type == AdminType.Dealer)
                {
                    ub.GetUserList(page, item, null, code, storeid, firstTypeid,brandid,user.AdminId.ToString(), out total, out list);
                }
                else if (user.Type == AdminType.Stores)
                {
                    ub.GetUserList(page, item, null, code, user.AdminId, firstTypeid,brandid,null, out total, out list);
                }
                errorCode = 0;
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("SearchUser",ex);
            }
        }
        else
        {
            errorCode = -10;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"type\":\"");
        sb.Append(user.Type);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();

    }
    private void ProductClear(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Product_Verify, Common.Permission_Add, context))
        {
            string code=HttpUtility.UrlDecode(context.Request["Code"]);
            int count = 0;
            List<ProductModel> list = new List<ProductModel>();
            try
            {
                pb.GetProductInfoList(1, 10000, null, null, null, null, user.AdminId, 2,null,null,null, out count, out list);
                foreach (ProductModel model in list)
                {
                    if (model.ProductCode == code)
                    {
                        if (pb.SetProductInfoByStatus(code).Equals(Config.Success))
                        {
                            errorCode = 0;
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("ProductClear", ex);
            }

        }
        else {
            errorCode = -10;
        }
    }
    private void LoadProductAvailable(HttpContext context)
    {
        int count=0;
        List<ProductModel> list=new List<ProductModel>();
        AdminModel user=Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Product_Verify, Common.Permission_Add, context))
        {
            try
            {
                pb.GetProductInfoList(1, 10000, null, null, null, null, user.AdminId, 2,null,null,null,out count, out list);
                errorCode = 0;
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("LoadProductAvailable", ex);
            }
        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(count);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void Send(string mobile)
    {
        try
        {
            string url = "http://sms.bechtech.cn/Api/send/data/json?accesskey=2911&secretkey=47b6eaf17855c06b1acbd6c12c80124d58aa4912&mobile=" + mobile + "&content=" + HttpUtility.UrlEncode("感谢您选择" + Config.CompanyName + "汽车窗膜，在此提示您三天内请不要升降您的车窗，更多服务敬请拨打电话：400-100-2450进行咨询。【北极光】");
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse res = req.GetResponse();
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, System.Text.Encoding.Default);
            string resultstring = sr.ReadToEnd();
            WriteLog.WriteMessage("Mobile="+mobile+"----"+resultstring);
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("发送短信", ex);
        }
    }
    private void UserAdd(HttpContext context)
    {
        AdminModel user=Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, HttpContext.Current))
        {
            string codeone = HttpUtility.UrlDecode(context.Request["codeone"]);
            string ProductCodeone = HttpUtility.UrlDecode(context.Request["ProductCodeone"]);
            string IsQuanCar = HttpUtility.HtmlDecode(context.Request["IsQuanCar"]);
            string Remark = HttpUtility.HtmlDecode(context.Request["Remark"]);
            string codetwo = HttpUtility.UrlDecode(context.Request["codetwo"]);
            string ProductCodetwo = HttpUtility.UrlDecode(context.Request["ProductCodetwo"]);
            string name = HttpUtility.UrlDecode(context.Request["name"]);
            string mobile = HttpUtility.UrlDecode(context.Request["mobile"]);
            string email = HttpUtility.UrlDecode(context.Request["email"]);
            string brand = HttpUtility.UrlDecode(context.Request["brand"]);
            string system = HttpUtility.UrlDecode(context.Request["system"]);
            string type = HttpUtility.UrlDecode(context.Request["type"]);
            string license = HttpUtility.UrlDecode(context.Request["license"]);
            string js = HttpUtility.UrlDecode(context.Request["MJs"]);
            string province = HttpUtility.UrlDecode(context.Request["province"]);
            string city = HttpUtility.UrlDecode(context.Request["city"]);
            string price = HttpUtility.UrlDecode(context.Request["price"]);
            string _ImageList = HttpUtility.UrlDecode(context.Request["ImageList"]);

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
                        if(Convert.ToInt32(codeone)==model.S_ProductTypeId)
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

                if(!flagone)
                {
                    errorCode = 5;

                }
                if(!flagtwo)
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
                        if (!string.IsNullOrWhiteSpace(ProductCodeone))
                        {
                            model.ProductCode = ProductCodeone;
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

                        model.Lincence = license;
                        if (!string.IsNullOrWhiteSpace(js))
                        {
                            model.MechanicId = int.Parse(js);
                        }
                        model.Mobile = mobile;
                        int len = model.Mobile.Length;
                        if (len > 11)
                        {
                            model.Mobile = model.Mobile.Substring(len - 11);
                        }
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
                        model.ImageList = _ImageList;
                        model.IsQuanCare = int.Parse(IsQuanCar);
                        model.Remark = Remark;
                        ub.AddUser(model, out id);
                        if (id > 0)
                        {
                            Send(model.Mobile);
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(codetwo))
                    {
                        int id = 0;
                        UserModel model = new UserModel();
                        if (!string.IsNullOrWhiteSpace(ProductCodetwo))
                        {
                            model.ProductCode = ProductCodetwo;
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

                        model.Lincence = license;
                        if (!string.IsNullOrWhiteSpace(js))
                        {
                            model.MechanicId = int.Parse(js);
                        }
                        model.Mobile = mobile;
                        int len = model.Mobile.Length;
                        if (len > 11)
                        {
                            model.Mobile = model.Mobile.Substring(len - 11);
                        }
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
                        model.IsQuanCare = 0;
                        model.Remark = Remark;
                        ub.AddUser(model, out id);

                        if (id > 0)
                        {
                            Send(model.Mobile);

                        }
                    }
                    errorCode = 0;
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("UserAdd", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void User_T_Add(HttpContext context)
    {
        AdminModel user=Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Add, HttpContext.Current))
        {
            string codeone = HttpUtility.UrlDecode(context.Request["Codeone"]);
            string ProductCodeone = HttpUtility.UrlDecode(context.Request["ProductCodeone"]);
            string Part = HttpUtility.UrlDecode(context.Request["Part"]);

            string name = HttpUtility.UrlDecode(context.Request["name"]);
            string mobile = HttpUtility.UrlDecode(context.Request["mobile"]);
            string email = HttpUtility.UrlDecode(context.Request["email"]);
            string brand = HttpUtility.UrlDecode(context.Request["brand"]);
            string system = HttpUtility.UrlDecode(context.Request["system"]);
            string type = HttpUtility.UrlDecode(context.Request["type"]);
            string license = HttpUtility.UrlDecode(context.Request["license"]);
            string js = HttpUtility.UrlDecode(context.Request["MJs"]);
            string province = HttpUtility.UrlDecode(context.Request["province"]);
            string city = HttpUtility.UrlDecode(context.Request["city"]);
            string price = HttpUtility.UrlDecode(context.Request["price"]);
            string _ImageList = HttpUtility.UrlDecode(context.Request["ImageList"]);

            bool flagone = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(codeone))
                {
                    flagone = false;
                    List<ProductTypeModel> list = new List<ProductTypeModel>();
                    pb.GetProduct_T_SecondLevelInfoByStoreId(4, user.AdminId, out list);
                    foreach (ProductTypeModel model in list)
                    {
                        if(Convert.ToInt32(codeone)==model.S_ProductTypeId)
                        {
                            flagone = true;
                            break;
                        }
                    }
                }
                if(!flagone)
                {
                    errorCode = 5;

                }
                if (flagone)
                {
                    UserBLL ub = new UserBLL();
                    int id = 0;
                    UserModel model = new UserModel();
                    if (!string.IsNullOrWhiteSpace(ProductCodeone)){ model.ProductCode = ProductCodeone;}
                    if (!string.IsNullOrWhiteSpace(brand)){ model.CarBrandCode = Convert.ToInt32(brand); }
                    if (!string.IsNullOrWhiteSpace(system)){ model.CarSystemCode = Convert.ToInt32(system); }
                    if (!string.IsNullOrWhiteSpace(type)) {  model.CarTypeCode = Convert.ToInt32(type); }
                    if (!string.IsNullOrWhiteSpace(city)){ model.CityId = Convert.ToInt32(city);}
                    model.Lincence = license;
                    if (!string.IsNullOrWhiteSpace(js)){  model.MechanicId = int.Parse(js);}
                    model.Mobile = mobile;
                    int len = model.Mobile.Length;
                    if (len > 11){ model.Mobile = model.Mobile.Substring(len - 11);}
                    if (!string.IsNullOrWhiteSpace(price)){ model.Price = float.Parse(price);}
                    model.F_ProductTypeId = 4;
                    model.S_ProductTypeId = Convert.ToInt32(codeone);
                    if (!string.IsNullOrWhiteSpace(province)){ model.ProvinceId = Convert.ToInt32(province); }
                    model.StoreId = user.AdminId;
                    model.UserName = name;
                    model.Email = email;
                    model.ImageList = _ImageList;
                    var arry = Part.Split(',');
                    foreach(string o in arry) {
                        if (!String.IsNullOrWhiteSpace(o)){
                            model.Type = int.Parse(o);

                            if (o == "1") { model.Meter = float.Parse("2"); }
                            else if (o == "2") { model.Meter =float.Parse("1.2");}
                            else if (o == "3") { model.Meter =float.Parse("2.5");}
                            else if (o == "4") { model.Meter =float.Parse("1.3");}
                            else if (o == "5") { model.Meter =float.Parse("2.2");}
                            else if (o == "6") { model.Meter =float.Parse("2");}
                            else if (o == "7") { model.Meter =float.Parse("2");}
                            else if (o == "8") { model.Meter =float.Parse("3.5");}
                            else if (o == "9") { model.Meter =float.Parse("0.25");}
                            else if (o == "10") { model.Meter =float.Parse("0.5");}
                            else if (o == "11") { model.Meter =float.Parse("15");}
                            ub.Add_T_User(model, out id);
                        }

                    }

                    if (id > 0)
                    {
                        Send_T_SMS(model.Mobile);
                    }
                    errorCode = 0;
                }
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("User_T_Add", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void Send_T_SMS(string mobile)
    {
        try
        {
            string content = HttpUtility.UrlEncode("感谢您使用" + Config.CompanyName + "隐形车衣，验车48小时内不能清洗车身，安装三天内若有翘边等现象请回门店处理，2~3个月需做一次膜面护理 【北极光】");
            string url = "http://sms.bechtech.cn/Api/send/data/json?accesskey=2911&secretkey=47b6eaf17855c06b1acbd6c12c80124d58aa4912&mobile=" + mobile + "&content=" +content ;
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse res = req.GetResponse();
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, System.Text.Encoding.Default);
            string resultstring = sr.ReadToEnd();
            WriteLog.WriteMessage("Mobile=" + mobile + "----" + resultstring);
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("发送短信", ex);
        }
    }
    private void ProductVerify(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product_Verify, Common.Permission_Add, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);
            if (!string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Typeone"]) && !string.IsNullOrWhiteSpace(context.Request["Typetwo"]))
            {
                try
                {
                    string code = HttpUtility.UrlDecode(context.Request["Code"]);
                    string typeone = HttpUtility.UrlDecode(context.Request["Typeone"]);
                    string typetwo = HttpUtility.UrlDecode(context.Request["Typetwo"]);
                    string result = string.Empty;
                    if (user.Type == AdminType.Dealer)
                    {
                        result = pb.SetProductInfoByDealer(code, user.AdminId,Convert.ToInt32(typeone),Convert.ToInt32(typetwo),null);
                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else
                        {
                            errorCode = Convert.ToInt32(result);
                        }
                    }
                    else if (user.Type == AdminType.Stores)
                    {
                        result = pb.SetProductInfoByStore(code,  user.AdminId,Convert.ToInt32(typeone), Convert.ToInt32(typetwo),null);
                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else
                        {
                            errorCode = Convert.ToInt32(result);
                        }
                    }
                    else
                    {
                        errorCode = 1;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductVerify", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void UpProductVerify(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product_Verify, Common.Permission_Add, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);
            if (!string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Typeone"]) && !string.IsNullOrWhiteSpace(context.Request["Typetwo"]) && !string.IsNullOrWhiteSpace(context.Request["upCode"]))
            {
                try
                {
                    string code = HttpUtility.UrlDecode(context.Request["Code"]);
                    string typeone = HttpUtility.UrlDecode(context.Request["Typeone"]);
                    string typetwo = HttpUtility.UrlDecode(context.Request["Typetwo"]);
                    string upCode = HttpUtility.UrlDecode(context.Request["upCode"]);
                    string result = string.Empty;
                    if (user.Type == AdminType.Dealer)
                    {
                        result = pb.SetProductInfoByDealer(code, user.AdminId, Convert.ToInt32(typeone), Convert.ToInt32(typetwo), upCode);
                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else
                        {
                            errorCode = Convert.ToInt32(result);
                        }
                    }
                    else if (user.Type == AdminType.Stores)
                    {
                        result = pb.SetProductInfoByStore(code, user.AdminId, Convert.ToInt32(typeone), Convert.ToInt32(typetwo), upCode);
                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else
                        {
                            errorCode = Convert.ToInt32(result);
                        }
                    }
                    else
                    {
                        errorCode = 1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductVerify", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void DelProductVerify(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product_Verify, Common.Permission_Add, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);
            if (!string.IsNullOrWhiteSpace(context.Request["Code"]))
            {
                try
                {
                    string code = HttpUtility.UrlDecode(context.Request["Code"]);
                    string result = string.Empty;
                    if (user.Type == AdminType.Dealer)
                    {
                        result = pb.RemoveProductInfobyDealer(code);
                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else
                        {
                            errorCode = Convert.ToInt32(result);
                        }
                    }
                    else if (user.Type == AdminType.Stores)
                    {
                        result = pb.RemoveProductInfobyStore(code);
                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else
                        {
                            errorCode = Convert.ToInt32(result);
                        }
                    }
                    else
                    {
                        errorCode = 1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("DelProductVerify", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void DeleteProduct(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Code"]))
            {
                string code = HttpUtility.UrlDecode(context.Request["Code"]);
                List<ProductModel> list = new List<ProductModel>();
                int count = 0;
                try
                {
                    pb.GetProductInfoList(1, 1, null, null, code, null, null, null,null,null,null, out count, out list);
                    string result = string.Empty;
                    if (list.Count == 1)
                    {
                        ProductModel model = list[0];
                        if (model.Status == 0)
                        {
                            if (pb.RemoveProductInfo(code).Equals(Config.Success))
                            {
                                errorCode = 0;
                            }
                        }
                        else
                        {
                            errorCode = 1;
                        }
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteProduct", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void F_DeleteProduct(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Code"]))
            {
                string code = HttpUtility.UrlDecode(context.Request["Code"]);
                List<ProductModel> list = new List<ProductModel>();
                int count = 0;
                try
                {
                    pb.GetProductInfoList(1, 1, null, null, code, null, null, null, null,null,null, out count, out list);
                    string result = string.Empty;
                    if (list.Count == 1)
                    {
                        ProductModel model = list[0];
                        if (model.Status == 0)
                        {
                            if (pb.RemoveProductInfo(code).Equals(Config.Success))
                            {
                                errorCode = 0;
                            }
                        }
                        else
                        {
                            errorCode = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("F_DeleteProduct", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void SearchProduct(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<ProductModel> list = new List<ProductModel>();
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_View, context))
        {
            string typeone = context.Request["TypeOne"];
            int? typeoneid = null;
            if (!string.IsNullOrWhiteSpace(typeone))
            {
                typeoneid = Convert.ToInt32(typeone);
            }

            string typetow = context.Request["TypeTwo"];
            int? typetwoid = null;
            if (!string.IsNullOrWhiteSpace(typetow))
            {
                typetwoid = Convert.ToInt32(typetow);
            }

            string status = context.Request["Status"];
            int? statusid = null;
            if (!string.IsNullOrWhiteSpace(status))
            {
                statusid = Convert.ToInt32(status);
            }
            string code = context.Request["Code"];
            int page = int.Parse(context.Request["Page"]) + 1;
            int item = int.Parse(context.Request["Item"]);


            string dealer = context.Request["Dealer"];
            int? dealerid = null;
            if(dealer!=null && !string.IsNullOrWhiteSpace(dealer))
            {
                dealerid = Convert.ToInt32(dealer);
            }

            string store = context.Request["Store"];
            int? storeid = null;
            if (store != null && !string.IsNullOrWhiteSpace(store))
            {
                storeid = Convert.ToInt32(store);
            }
            string dealer_flag = context.Request["dealer_flag"];
            int? dealer_flagId = null;
            if (dealer_flag != null && !string.IsNullOrWhiteSpace(dealer_flag))
            {
                dealer_flagId = Convert.ToInt32(dealer_flag);
            }
            string store_flag = context.Request["store_flag"];
            int? store_flagId = null;
            if (store_flag != null && !string.IsNullOrWhiteSpace(store_flag))
            {
                store_flagId = Convert.ToInt32(store_flag);
            }
            try
            {
                if (user.Type == AdminType.Managers)
                {
                    pb.GetProductInfoList(page, item, typeoneid, typetwoid, code, dealerid, storeid, statusid,null,dealer_flagId,store_flagId,out total, out list);
                }
                else if (user.Type == AdminType.Dealer)
                {
                    pb.GetProductInfoList(page, item, typeoneid, typetwoid, code, user.AdminId, storeid, statusid, null, dealer_flagId, store_flagId, out total, out list);
                }
                else if (user.Type == AdminType.Stores)
                {
                    pb.GetProductInfoList(page, item, typeoneid, typetwoid, code, dealerid, user.AdminId, statusid, null, dealer_flagId, store_flagId, out total, out list);
                }

                errorCode = 0;
            }
            catch(Exception ex)
            {
                WriteLog.WriteExceptionLog("SearchProduct", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);


        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void MobileSearchUser(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<UserModel> list = new List<UserModel>();
        if (Common.CheckPermission(Common.Module_User, Common.Permission_View, context))
        {
            try
            {
                string start = context.Request["start"];
                string end = context.Request["end"];
                UserBLL ub = new UserBLL();
                ub.GetUserList(user.AdminId,start,end, out total, out list);
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("MobileSearchUser", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"type\":\"");
        sb.Append(user.Type);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void F_SearchProduct(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        int total = 0;
        List<ProductModel> list = new List<ProductModel>();
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_View, context))
        {
            string typeone = context.Request["TypeOne"];
            int? typeoneid = null;
            if (!string.IsNullOrWhiteSpace(typeone))
            {
                typeoneid = Convert.ToInt32(typeone);
            }
            string dealer_flag = context.Request["dealer_flag"];
            int? dealer_flagId = null;
            if (dealer_flag != null && !string.IsNullOrWhiteSpace(dealer_flag))
            {
                dealer_flagId = Convert.ToInt32(dealer_flag);
            }
            string store_flag = context.Request["store_flag"];
            int? store_flagId = null;
            if (store_flag != null && !string.IsNullOrWhiteSpace(store_flag))
            {
                store_flagId = Convert.ToInt32(store_flag);
            }
            string code = context.Request["Code"];
            int page = int.Parse(context.Request["Page"]) + 1;
            int item = int.Parse(context.Request["Item"]);

            try
            {
                pb.GetProductInfoList(page, item, null, null, code, null, null, null, typeoneid, dealer_flagId, store_flagId, out total, out list);
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("F_SearchProduct", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void ProductUpdate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["TypeOne"]) && !string.IsNullOrWhiteSpace(context.Request["TypeTwo"]) && !string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["OldCode"]))
            {
                int count = 0;
                string code = HttpUtility.UrlDecode(context.Request["Code"]);
                string oldcode = HttpUtility.UrlDecode(context.Request["OldCode"]);
                List<ProductModel> list = new List<ProductModel>();
                try
                {
                    pb.GetProductInfoList(1, 1, null, null, oldcode, null, null, null,null,null,null, out count, out list);
                    string result = string.Empty;
                    if (list.Count == 1)
                    {
                        ProductModel model = list[0];
                        model.ProductDes = HttpUtility.UrlDecode(context.Request["Memo"]);
                        if (model.Status == 0)
                        {
                            model.ProductFirstLevelId = Convert.ToInt32(HttpUtility.UrlDecode(context.Request["TypeOne"]));
                            model.ProductSecondLevelId = Convert.ToInt32(HttpUtility.UrlDecode(context.Request["TypeTwo"]));
                            result = pb.SetProductInfo(model, code);
                        }
                        else
                        {
                            result = pb.SetProductInfo(model, model.ProductCode);
                        }

                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else if (result.Equals("-2"))
                        {
                            errorCode = -2;
                        }
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductUpdate",ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void F_ProductUpdate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);
            string FactoryTypeId = context.Request["TypeOne"];
            string NewsCode = context.Request["NewsCode"];
            string Code = context.Request["Code"];
            string Memo = context.Request["Memo"];
            string Length = context.Request["Length"];
            if (!string.IsNullOrWhiteSpace(FactoryTypeId) && !string.IsNullOrWhiteSpace(NewsCode) && !string.IsNullOrWhiteSpace(Code) && !string.IsNullOrWhiteSpace(Memo)&& !string.IsNullOrWhiteSpace(Length))
            {
                int count = 0;
                List<ProductModel> list = new List<ProductModel>();
                try
                {
                    pb.GetProductInfoList(1, 1, null, null, Code, null, null, null, null,null,null, out count, out list);
                    string result = string.Empty;
                    if (list.Count == 1)
                    {
                        ProductModel model = list[0];
                        model.ProductDes = HttpUtility.UrlDecode(Memo);
                        model.ProductCode = HttpUtility.UrlDecode(Code);
                        model.FactoryTypeId = int.Parse(HttpUtility.UrlDecode(FactoryTypeId));
                        model.Length = float.Parse(HttpUtility.UrlDecode(Length));
                        if (model.Status == 0)
                        {
                            result = pb.SetProductInfo(model, NewsCode);
                        }

                        if (result.Equals(Config.Success))
                        {
                            errorCode = 0;
                        }
                        else if (result.Equals("-2"))
                        {
                            errorCode = -2;
                        }
                        else if (result.Equals("-1"))
                        {
                            errorCode = -2;
                        }
                        else if (result.Equals("-5"))
                        {
                            errorCode = -2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("F_ProductUpdate", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void ProductAdd(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Add, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["TypeOne"]) && !string.IsNullOrWhiteSpace(context.Request["TypeTwo"]) && !string.IsNullOrWhiteSpace(context.Request["Code"]))
            {
                ProductModel model = new ProductModel();
                model.ProductFirstLevelId = Convert.ToInt32(HttpUtility.UrlDecode(context.Request["TypeOne"]));
                model.ProductSecondLevelId = Convert.ToInt32(HttpUtility.UrlDecode(context.Request["TypeTwo"]));
                model.ProductCode = HttpUtility.UrlDecode(context.Request["Code"]);
                model.ProductDes = HttpUtility.UrlDecode(context.Request["Memo"]);
                model.Length = int.Parse(HttpUtility.UrlDecode(context.Request["Length"]));
                model.CreatorId = user.AdminId;

                try
                {
                    string result = pb.AddProductInfo(model);
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-2"))
                    {
                        errorCode = -2;
                    }
                    else if (result.Equals("-5"))
                    {
                        errorCode = -5;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductAdd", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void SetProductInfoByAudDealerFlag(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Update, context) || Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Status"]))
            {
                string ProductCode = context.Request["Code"].ToString();
                string Flag = context.Request["Status"].ToString();
                try
                {
                    string result = pb.SetProductInfoByAudDealerFlag(ProductCode,int.Parse(Flag));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-1"))
                    {
                        errorCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("SetProductInfoByAudDealerFlag", ex);
                }
            }
            else
            {
                errorCode = -1;
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void SetProductInfoByAllAudDealerFlag(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Update, context) || Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Status"]))
            {
                string ProductCode = context.Request["Code"].ToString();
                string Flag = context.Request["Status"].ToString();
                try
                {
                    string []CodeArry = ProductCode.Split(',');
                    string result = pb.SetProductInfoByAllAudDealerFlag(CodeArry, int.Parse(Flag));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-1"))
                    {
                        errorCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("SetProductInfoByAllAudDealerFlag", ex);
                }
            }
            else
            {
                errorCode = -1;
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void SetProductInfoByAudStoreFlag(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Update, context) || Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Status"]))
            {
                string ProductCode = context.Request["Code"].ToString();
                string Flag = context.Request["Status"].ToString();
                try
                {
                    string result = pb.SetProductInfoByAudStoreFlag(ProductCode, int.Parse(Flag));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-1"))
                    {
                        errorCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("SetProductInfoByAudDealerFlag", ex);
                }
            }
            else
            {
                errorCode = -1;
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void SetProductInfoByAllAudStoreFlag(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product, Common.Permission_Update, context) || Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Status"]))
            {
                string ProductCode = context.Request["Code"].ToString();
                string Flag = context.Request["Status"].ToString();
                string[] CodeArry = ProductCode.Split(',');
                try
                {
                    string result = pb.SetProductInfoByAllAudStoreFlag(CodeArry, int.Parse(Flag));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-1"))
                    {
                        errorCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("SetProductInfoByAudDealerFlag", ex);
                }
            }
            else
            {
                errorCode = -1;
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void F_ProductAdd(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Add, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["TypeOne"])  && !string.IsNullOrWhiteSpace(context.Request["Code"]) && !string.IsNullOrWhiteSpace(context.Request["Length"]))
            {
                ProductModel model = new ProductModel();
                model.FactoryTypeId = Convert.ToInt32(HttpUtility.UrlDecode(context.Request["TypeOne"]));
                model.ProductCode = HttpUtility.UrlDecode(context.Request["Code"]);
                model.ProductDes = HttpUtility.UrlDecode(context.Request["Memo"]);
                model.Length = float.Parse(HttpUtility.UrlDecode(context.Request["Length"]));
                model.CreatorId = user.AdminId;

                try
                {
                    string result = pb.AddF_ProductInfo(model);
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-2"))
                    {
                        errorCode = -2;
                    }
                    else if (result.Equals("-5"))
                    {
                        errorCode = -5;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("F_ProductAdd", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void DeleteProductType(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product_Type, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    string result = pb.RemoveProductSecondLevelInfo(Convert.ToInt32(context.Request["ID"]));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-2"))
                    {
                        errorCode = -2;
                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteProductType", ex);
                }

            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetProductTypeList(HttpContext context)
    {
        int total = 0;
        List<ProductTypeModel> list = new List<ProductTypeModel>();
        if (Common.CheckPermission(Common.Module_Product_Type, Common.Permission_View, context) || Common.CheckPermission(Common.Module_Product, Common.Permission_View, context))
        {
            try
            {
                NewsBLL nb = new NewsBLL();

                if (string.IsNullOrWhiteSpace(context.Request["id"]))
                {
                    pb.GetProductSecondLevelInfo(null, out list);
                }
                else
                {
                    pb.GetProductSecondLevelInfo(Convert.ToInt32(context.Request["id"]), out list);
                }

                errorCode = 0;
                total = list.Count;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetProductTypeList", ex);
            }

        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void GetStoreList(HttpContext context)
    {
        int total = 0;
        List<StoreModel> list = new List<StoreModel>();
        if (Common.CheckPermission(Common.Module_User, Common.Permission_View, context)
                || Common.CheckPermission(Common.Module_Product, Common.Permission_View, context))
        {
            try
            {
                StoreBLL nb = new StoreBLL();
                int count = 0;
                if (!string.IsNullOrWhiteSpace(context.Request["ID"]))
                {
                    nb.GetStoreModelList(1, 10000000, null, null, int.Parse(context.Request["ID"]), out count, out list);
                }
                errorCode = 0;
                total =count;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetProductTypeList", ex);
            }

        }
        else
        {
            errorCode = -10;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);

        sb.Append("\",\"total\":\"");
        sb.Append(total);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void ProductTypeUpdate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product_Type, Common.Permission_Update, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Name"]) && !string.IsNullOrWhiteSpace(context.Request["ID"]) && !string.IsNullOrWhiteSpace(context.Request["FacType"]))
            {
                string name = HttpUtility.UrlDecode(context.Request["Name"]);
                string factype = HttpUtility.UrlDecode(context.Request["FacType"]);
                int id = Convert.ToInt32(context.Request["ID"]);
                ProductBLL pb = new ProductBLL();

                try
                {
                    string result = pb.SetProductSecondLevelInfo(name,id, Convert.ToInt32(factype));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                        Update(id.ToString(), name, context);
                    }
                    else
                    {
                        if (result == "-2")
                        {
                            errorCode = -2;
                        }
                        else if(result == "-5")
                        {
                            errorCode = -5;
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductTypeUpdate", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }

    }
    private void ProductTypeAdd(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Product_Type, Common.Permission_Add, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Name"]) && !string.IsNullOrWhiteSpace(context.Request["FacType"]))
            {
                string name = HttpUtility.UrlDecode(context.Request["Name"]);
                string factype = HttpUtility.UrlDecode(context.Request["FacType"]);
                int first = Convert.ToInt32(context.Request["First"]);

                int id = 0;
                try
                {
                    string result=pb.AddProductSecondLevelInfo(name, first, Convert.ToInt32(factype), out id);
                    if (id > 0)
                    {
                        errorCode = 0;
                        Insert(id.ToString(), name, context);
                    }
                    else
                    {
                        if (result == "-2")
                        {
                            errorCode = -2;
                        }
                        else if(result == "-5")
                        {
                            errorCode = -5;
                        }

                    }
                }
                catch(Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductTypeAdd", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }

    private void DeleteUser(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_User, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    UserBLL ub = new UserBLL();
                    string result = ub.RemoveUser(Convert.ToInt32(context.Request["ID"]));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                    }
                    else if (result.Equals("-1"))
                    {
                        errorCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteProductType", ex);
                }

            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void ResponseResult()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{\"errorcode\":\"");
        sb.Append(errorCode);
        sb.Append("\",\"returnmsg\":\"");
        sb.Append(returnMsg);
        sb.Append("\"}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    public void Insert(string Id, string Name, HttpContext context)
    {
        string path = context.Server.MapPath("\\Template\\");
        path = path + "Template.xlsx";
        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Extended Properties='Excel 12.0;HDR=yes;IMEX=0';" + "data source=" + path;
        string sql = "insert into [品牌型号$] (品牌型号) values ('" + Id + ":" + Name + "')";
        OleDbConnection myConn = new OleDbConnection(strCon);
        OleDbCommand command = new OleDbCommand(sql, myConn);

        try
        {
            myConn.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FInsert", ex);
        }
        finally
        {
            myConn.Close();
        }
    }
    public void Update(string Id, string Name, HttpContext context)
    {
        string path = context.Server.MapPath("\\Template\\");
        path = path + "F_Template.xlsx";
        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Extended Properties='Excel 12.0;HDR=yes;IMEX=0';" + "data source=" + path;
        string sql = "update  [品牌型号$] set 品牌型号='" + Id + ":" + Name + "' where 品牌型号 like '" + Id + ":%'";
        OleDbConnection myConn = new OleDbConnection(strCon);
        OleDbCommand command = new OleDbCommand(sql, myConn);
        try
        {
            myConn.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("FUpdate", ex);
        }
        finally
        {
            myConn.Close();
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
}