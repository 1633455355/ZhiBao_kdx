<%@ WebHandler Language="C#" Class="Car" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

public class Car : IHttpHandler, IRequiresSessionState
{

    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;
    private OperLogBLL olb = new OperLogBLL();
    
    public void ProcessRequest (HttpContext context) {
        
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "GetBrandFromAotohome":
                    this.GetBrandFromAotohome(context);
                    this.ResponseResult();
                    break;
                case "GetCarSystemFromAotohome":
                    this.GetCarSystemFromAotohome(context);
                    this.ResponseResult();
                    break;
                case "GetCarTypeFromAotohome":
                    this.GetCarTypeFromAotohome(context);
                    this.ResponseResult();
                    break;
                case "GetBrandFromUs":
                    this.GetBrandFromUs(context);
                    break;
                case "GetSysytemFromUs":
                    this.GetSysytemFromUs(context);
                    break;
                case "GetTypeFromUs":
                    this.GetTypeFromUs(context);
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void GetTypeFromUs(HttpContext context)
    {
        List<CarTypeModel> list = new List<CarTypeModel>();
        int total = 0;
        Province_City_CarBLL pcc = new Province_City_CarBLL();
        try
        {
            pcc.GetCarTypeList(Convert.ToInt32(context.Request["ID"]), out total, out list);
            errorCode = 0;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("GetTypeFromUs", ex);
        }
        errorCode = 0;

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
    private void GetSysytemFromUs(HttpContext context)
    {
        List<CarSystemModel> list = new List<CarSystemModel>();
        int total = 0;
        if (Common.CheckPermission(Common.Module_Car, Common.Permission_Add, context) || Common.CheckPermission(Common.Module_User, Common.Permission_Add, context))
        {
            Province_City_CarBLL pcc = new Province_City_CarBLL();
            try
            {
                pcc.GetCarSystemList(Convert.ToInt32(context.Request["ID"]), out total, out list);
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetSysytemFromUs", ex);
            }
            errorCode = 0;
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
    private void GetBrandFromUs(HttpContext context)
    {
        List<CarBrandModel> list = new List<CarBrandModel>();
        int total = 0;
        if (Common.CheckPermission(Common.Module_Car, Common.Permission_Add, context) || Common.CheckPermission(Common.Module_User, Common.Permission_Add, context))
        {
            Province_City_CarBLL pcc = new Province_City_CarBLL();
            try
            {
                pcc.GetCarBrandList(null, out total, out list);
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetBrandFromUs", ex);
            }
            errorCode = 0;
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
    
    private void GetCarTypeFromAotohome(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Car, Common.Permission_Add, context))
        {
            try
            {
                Province_City_CarBLL pcb = new Province_City_CarBLL();
                int count = 0;
                List<CarSystemModel> list = new List<CarSystemModel>();
                pcb.GetCarSystemList(null, out count, out list);
                if (list.Count > 0)
                {
                    foreach (CarSystemModel mode in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        string url = "http://www.autohome.com.cn/ashx/AjaxIndexCarFind.ashx?type=5&value=" + mode.CarSystemCode;
                        WebRequest req = WebRequest.Create(url);
                        WebResponse res = req.GetResponse();
                        Stream ReceiveStream = res.GetResponseStream();
                        StreamReader sr = new System.IO.StreamReader(ReceiveStream, System.Text.Encoding.Default);
                        string resultstring = sr.ReadToEnd();
                        JObject obj = (JObject)JsonConvert.DeserializeObject(resultstring);
                        JToken items = obj["result"];
                        JToken yearitems = items["yearitems"];
                        JToken itemlist = yearitems[0]["specitems"];
                        sb.Append("delete from CarTypeInfo where CarSystemCode=" + mode.CarSystemCode + ";");
                        foreach (JToken a in itemlist)
                        {
                            string id = a["id"].ToString();
                            string name = a["name"].ToString();
                            sb.Append("insert into CarTypeInfo (CarTypeCode,CarTypeName,CarSystemCode) values (" + id + ",'" + name + "'," + mode.CarSystemCode + ");");
                        }
                        SqlActuator.ExecuteNonQuery(sb.ToString(), Config.ConnectionString);
                    }
                }
                errorCode = 0;

                AdminModel user = Common.GetLoginAdmin(context);
                olb.AddOperLog(user.AdminId, "获取CarType", "");
                
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetCarTypeFromAotohome", ex);
            }
        }
        else
        {
            errorCode=-10; 
        }
    }
    private void GetCarSystemFromAotohome(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Car, Common.Permission_Add, context) )
        {
            try
            {
                Province_City_CarBLL pcb = new Province_City_CarBLL();
                int count = 0;
                List<CarBrandModel> list = new List<CarBrandModel>();
                pcb.GetCarBrandList(null, out count, out list);
                if (list.Count > 0)
                {
                    foreach (CarBrandModel mode in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        string url = "http://www.autohome.com.cn/ashx/AjaxIndexCarFind.ashx?type=3&value=" + mode.CarBrandCode;
                        WebRequest req = WebRequest.Create(url);
                        WebResponse res = req.GetResponse();
                        Stream ReceiveStream = res.GetResponseStream();
                        StreamReader sr = new System.IO.StreamReader(ReceiveStream, System.Text.Encoding.Default);
                        string resultstring = sr.ReadToEnd();
                        JObject obj = (JObject)JsonConvert.DeserializeObject(resultstring);
                        JToken items = obj["result"];
                        JToken factorylsit = items["factoryitems"];
                        JToken itemlist = factorylsit[0]["seriesitems"];
                        sb.Append("delete from CarSystemInfo where CarBrandCode='" + mode.CarBrandCode + "';");
                        foreach (JToken a in itemlist)
                        {
                            string id = a["id"].ToString();
                            string name = a["name"].ToString();
                            string letter = a["firstletter"].ToString();
                            sb.Append("insert into CarSystemInfo (CarSystemCode,CarSystemName,CarBrandCode,SY) values ('" + id + "','" + name + "','" + mode.CarBrandCode + "','" + letter + "');");
                        }
                        SqlActuator.ExecuteNonQuery(sb.ToString(), Config.ConnectionString);
                    }
                }
                errorCode = 0;

                AdminModel user = Common.GetLoginAdmin(context);
                olb.AddOperLog(user.AdminId, "获取CarSystem", "");
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetCarSystemFromAotohome", ex);
            }
        }
        else
        {
            errorCode=-10;
        }
    }
    private void GetBrandFromAotohome(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Car, Common.Permission_Add, context))
        {
            try
            {
                string url = "http://www.autohome.com.cn/ashx/AjaxIndexCarFind.ashx?type=1";
                WebRequest req = WebRequest.Create(url);
                WebResponse res = req.GetResponse();
                Stream ReceiveStream = res.GetResponseStream();
                StreamReader sr = new System.IO.StreamReader(ReceiveStream, System.Text.Encoding.Default);
                string resultstring = sr.ReadToEnd();
                JObject obj = (JObject)JsonConvert.DeserializeObject(resultstring);
                JToken items = obj["result"];
                JToken brandlsit = items["branditems"];
                StringBuilder sb = new StringBuilder();
                sb.Append("delete from CarBrand;");
                foreach (JToken a in brandlsit)
                {
                    string id = a["id"].ToString();
                    string name = a["name"].ToString();
                    string letter = a["bfirstletter"].ToString();
                    sb.Append("insert into CarBrand (CarBrandCode,CarBrandName,Firstletter) values ('" + id + "','" + name + "','" + letter + "');");
                }
                SqlActuator.ExecuteNonQuery(sb.ToString(), Config.ConnectionString);
                errorCode = 0;
                
                AdminModel user = Common.GetLoginAdmin(context);
                olb.AddOperLog(user.AdminId, "获取CarBrand", "");
                
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetBrandFromAotohome", ex);
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

}