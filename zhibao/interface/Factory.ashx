<%@ WebHandler Language="C#" Class="Factory" %>

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

public class Factory : IHttpHandler, IRequiresSessionState
{
    private string action = string.Empty;
    private int errorCode = -1;
    private string returnMsg = string.Empty;


    private FactoryTypeBLL ftb = new FactoryTypeBLL();
    private OperLogBLL olb = new OperLogBLL();
    
    public void ProcessRequest (HttpContext context) {
        
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "FactoryTypeUpdate":
                    this.FactoryTypeUpdate(context);
                    this.ResponseResult();
                    break;
                case "DeleteFactoryType":
                    this.DeleteFactoryType(context);
                    this.ResponseResult();
                    break; 
                case "FactoryTypeAdd":
                    this.FactoryTypeAdd(context);
                    this.ResponseResult();
                    break;
                case "GetFactoryTypeList":
                    this.GetFactoryTypeList(context);
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
    }
    private void FactoryTypeUpdate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Update, context))
        {
            AdminModel user = Common.GetLoginAdmin(context);

            if (!string.IsNullOrWhiteSpace(context.Request["ID"]) && !string.IsNullOrWhiteSpace(context.Request["Name"]) && !string.IsNullOrWhiteSpace(context.Request["Namep"]))
            {
                string id = HttpUtility.UrlDecode(context.Request["ID"]);
                string name = HttpUtility.UrlDecode(context.Request["Name"]);
                string namep = HttpUtility.UrlDecode(context.Request["Namep"]);

                try
                {
                    string result = ftb.SetFactoryTypeInfo(name,namep,Convert.ToInt32(id));
                    if(result.Equals(Config.Success))
                    {
                        errorCode = 0;
                        Update(id.ToString(), name, context);
                        olb.AddOperLog(user.AdminId, "更新工厂类型", name);
                        
                    }
                    else if(result=="-5")
                    {
                        errorCode = -5;
                    }
                    else if (result == "-2")
                    {
                        errorCode = -2;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("ProductUpdate", ex);
                }
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void DeleteFactoryType(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Delete, context))
        {
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                try
                {
                    string result = ftb.RemoveFactoryTypeInfo(Convert.ToInt32(context.Request["ID"]));
                    if (result.Equals(Config.Success))
                    {
                        errorCode = 0;
                        AdminModel user = Common.GetLoginAdmin(context);
                        olb.AddOperLog(user.AdminId, "删除工厂类型", "ID:"+context.Request["ID"]);
                    }
                    else if(result.Equals("-5"))
                    {
                        errorCode = -5;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("DeleteFactoryType", ex);
                }

            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetFactoryTypeList(HttpContext context)
    {
        List<FactoryTypeModel> list = new List<FactoryTypeModel>();
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_View, context))
        {
            try
            {
                ftb.GetFactoryTypeInfo(null, out list);
                errorCode = 0;
                AdminModel user = Common.GetLoginAdmin(context);
                olb.AddOperLog(user.AdminId, "获取工厂类型列表", "");
                
                //重置模板的时候使用
                //foreach (FactoryTypeModel model in list)
                //{
                //    Insert(model.FactoryTypeId.ToString(), model.FactoryTypeName, context);
                //}
                
                
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("GetFactoryTypeList", ex);
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
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void FactoryTypeAdd(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Add, context))
        {
            if (!string.IsNullOrWhiteSpace(context.Request["Name"]) && !string.IsNullOrWhiteSpace(context.Request["Namep"]))
        {
            string name = HttpUtility.UrlDecode(context.Request["Name"]);
            string namep = HttpUtility.UrlDecode(context.Request["Namep"]);
            int id = 0;
            try
            {
                AdminModel user = Common.GetLoginAdmin(context);
                string result=ftb.AddFactoryTypeInfo(name,namep, user.AdminId, out id); 
                if (id > 0)
                {
                    errorCode = 0;
                    Insert(id.ToString(), name, context);
                    olb.AddOperLog(user.AdminId, "新增工厂内不型号", name+"/"+namep);
                }
                else
                {
                    if (result == "-2")
                    {
                        errorCode = -2;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("FactoryTypeAdd", ex);
            }
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

    public void Insert(string Id, string Name, HttpContext context)
    {
        string path = context.Server.MapPath("\\Template\\");
        path = path + "F_Template.xlsx";
        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Extended Properties='Excel 12.0;HDR=yes;IMEX=0';" + "data source=" + path;
        string sql = "insert into [厂家内部型号$] (厂家内部型号) values ('" + Id + ":" + Name + "')";
        OleDbConnection myConn = new OleDbConnection(strCon);
        OleDbCommand command = new OleDbCommand(sql, myConn);
        
        try
        {
            myConn.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Insert", ex);
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
        string sql = "update  [厂家内部型号$] set 厂家内部型号='" + Id + ":" + Name + "' where 厂家内部型号 like '" + Id + ":%'";
        OleDbConnection myConn = new OleDbConnection(strCon);
        OleDbCommand command = new OleDbCommand(sql, myConn);
        try
        {
            myConn.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Update", ex);
        }
        finally
        {
            myConn.Close();
        }
    }
}