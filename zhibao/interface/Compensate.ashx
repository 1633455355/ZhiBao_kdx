<%@ WebHandler Language="C#" Class="Compensate" %>

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


public class Compensate : IHttpHandler, IRequiresSessionState {

    private string action = string.Empty;
    private int errorCode = -5;
    private string returnMsg = string.Empty;
    private CompensateBLL pb = new CompensateBLL();
    public void ProcessRequest (HttpContext context) {
        if (context.Request["Action"] != null)
        {
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "GetList":
                    this.GetList(context);
                    break;
                case "GetProductCode":
                    this.GetProductCode(context);
                    break;
                case "CompensateAdd":
                    this.CompensateAdd(context);
                    this.ResponseResult();
                    break;
                case "CompensateUpdate":
                    this.CompensateUpdate(context);
                    this.ResponseResult();
                    break;
                case "SetStatus":
                    this.SetCompensateStatus(context);
                    this.ResponseResult();
                    break;
                case "DeleteCompensate":
                    this.DeleteCompensate(context);
                    this.ResponseResult();
                    break;
                case "GetCompensate":
                    this.GetCompensate(context);
                    break;
                default:
                    this.ResponseResult();
                    break;
            }
        }
       
    }
    private void GetCompensate(HttpContext context)
    {
        int total = 0;
        AdminModel user = Common.GetLoginAdmin(context);
        List<CompensateModel> list = new List<CompensateModel>();
        CompensateModel o = null;
        if (Common.CheckPermission(Common.Module_Compensate, Common.Permission_View, context))
        {
            try
            {
                string no = null;
                if (!String.IsNullOrWhiteSpace(context.Request["no"]))
                {
                    no = HttpUtility.UrlDecode(context.Request["no"]);
                }
                pb.GetCompensateList(no, null, null, null, null, null, 1, 1, out total, out  list);
                if(list.Count>0)
                {
                    o = list[0];
                }
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("CompenstateGetList", ex);
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

        sb.Append("\",\"type\":\"");
        sb.Append(user.Type);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(o));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
    private void DeleteCompensate(HttpContext context)
    {
        if (Common.CheckPermission(Common.Module_Compensate, Common.Permission_Delete, HttpContext.Current))
        {
            string No = HttpUtility.UrlDecode(context.Request["no"]);
            if (!String.IsNullOrWhiteSpace(No))
            {
                string ret = pb.RemoveCompensateInfo(No);
                if (ret.Equals(Config.Success)) {
                    errorCode = 0;
                }
                else {
                    errorCode = int.Parse(ret);
                }
            }
            else
            {
                errorCode = -5;
            }
        } 
        else
        {
            errorCode = -10;
        }
    }
    
    private void SetCompensateStatus(HttpContext context)
    {
        if(Common.CheckPermission(Common.Module_Compensate, Common.Permission_Update, HttpContext.Current))
        {
            string No = HttpUtility.UrlDecode(context.Request["no"]);
            string status = HttpUtility.UrlDecode(context.Request["status"]);
            if(!String.IsNullOrWhiteSpace(No)&&!String.IsNullOrWhiteSpace(status))
            {
                string ret = pb.SetCompensateInfoStatus(No, int.Parse(status));
                if(ret.Equals(Config.Success)) {
                    errorCode = 0;
                }
                else
                {
                     errorCode = int.Parse(ret);
                }
            }
            else
            {
                errorCode = -5;
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void CompensateUpdate(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Compensate, Common.Permission_Add, HttpContext.Current))
        {
            string compensateno = HttpUtility.UrlDecode(context.Request["compensateno"]);
            string compensatename = HttpUtility.UrlDecode(context.Request["compensatename"]);
            string compensateType = HttpUtility.UrlDecode(context.Request["compensateType"]);
            string compensatePeson = HttpUtility.UrlDecode(context.Request["compensatePeson"]);
            string tel = HttpUtility.UrlDecode(context.Request["tel"]);
            string fax = HttpUtility.UrlDecode(context.Request["fax"]);
            string productSecondLevelId = HttpUtility.UrlDecode(context.Request["productSecondLevelId"]);
            string productCode = HttpUtility.UrlDecode(context.Request["productCode"]);
            string specifications = HttpUtility.UrlDecode(context.Request["specifications"]);
            string lengthnum = HttpUtility.UrlDecode(context.Request["lengthnum"]);
            string compensateStore = HttpUtility.UrlDecode(context.Request["compensateStore"]);
            string compensateDate = HttpUtility.UrlDecode(context.Request["compensateDate"]);
            string position = HttpUtility.UrlDecode(context.Request["position"]);
            string problemDes = HttpUtility.UrlDecode(context.Request["problemDes"]);
            string findTime = HttpUtility.UrlDecode(context.Request["findTime"]);
            string installationTime = HttpUtility.UrlDecode(context.Request["installationTime"]);
            string otherDes = HttpUtility.UrlDecode(context.Request["otherDes"]);
            string imagelist = HttpUtility.UrlDecode(context.Request["imagelist"]);
            string AtchmentList = HttpUtility.UrlDecode(context.Request["AtchmentList"]);
            string status = HttpUtility.UrlDecode(context.Request["status"]);
            string productSecondLevelName = HttpUtility.UrlDecode(context.Request["productSecondLevelName"]);

            try
            {
                CompensateModel model = new CompensateModel();
                model.CompensateNo = compensateno;
                model.CompensateName = compensatename;
                model.CompensateType = compensateType;
                model.CompensatePeson = compensatePeson;
                model.Tel = tel;
                model.Fax = fax;
                model.ProductSecondLevelId = int.Parse(productSecondLevelId);
                model.ProductCode = productCode;
                model.Specifications = specifications;
                model.Length = lengthnum;
                model.CompensateStore = compensateStore;
                if (!String.IsNullOrWhiteSpace(compensateDate))
                {
                    model.CompensateDate = Convert.ToDateTime(compensateDate);
                }
                model.Position = position;
                model.ProblemDes = problemDes;
                model.FindTime = findTime;
                if (!String.IsNullOrWhiteSpace(installationTime))
                {
                    model.InstallationTime = Convert.ToDateTime(installationTime);
                }
                model.OtherDes = otherDes;

                model.ImageList = imagelist;
                model.AtchmentList = AtchmentList;
                model.Status = int.Parse(status);
                model.ProductSecondLevelName = productSecondLevelName;
                if (user.Type == AdminType.Dealer)
                {
                    model.DealerId = user.AdminId;
                }
                if (user.Type == AdminType.Stores)
                {
                    model.StoreId = user.AdminId;
                }

                string filepath = context.Server.MapPath("~\\Template\\Compensate\\Order\\");
                string Templatepath = context.Server.MapPath("~\\Template\\Compensate\\");
                string ret = pb.SetCompensateInfo(model, filepath, Templatepath);
                if (ret.Equals(Config.Success))
                {
                    errorCode = 0;
                }
                else
                {
                    errorCode = int.Parse(ret);
                }

            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("CompensateAdd", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void CompensateAdd(HttpContext context)
    {
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Compensate, Common.Permission_Add, HttpContext.Current))
        {
            string compensatename = HttpUtility.UrlDecode(context.Request["compensatename"]);
            string compensateType = HttpUtility.UrlDecode(context.Request["compensateType"]);
            string compensatePeson = HttpUtility.UrlDecode(context.Request["compensatePeson"]);
            string tel = HttpUtility.UrlDecode(context.Request["tel"]);
            string fax = HttpUtility.UrlDecode(context.Request["fax"]);
            string productSecondLevelId = HttpUtility.UrlDecode(context.Request["productSecondLevelId"]);
            string productCode = HttpUtility.UrlDecode(context.Request["productCode"]);
            string specifications = HttpUtility.UrlDecode(context.Request["specifications"]);
            string lengthnum = HttpUtility.UrlDecode(context.Request["lengthnum"]);
            string compensateStore = HttpUtility.UrlDecode(context.Request["compensateStore"]);
            string compensateDate = HttpUtility.UrlDecode(context.Request["compensateDate"]);
            string position = HttpUtility.UrlDecode(context.Request["position"]);
            string problemDes = HttpUtility.UrlDecode(context.Request["problemDes"]);
            string findTime = HttpUtility.UrlDecode(context.Request["findTime"]);
            string installationTime = HttpUtility.UrlDecode(context.Request["installationTime"]);
            string otherDes = HttpUtility.UrlDecode(context.Request["otherDes"]);
            string imagelist = HttpUtility.UrlDecode(context.Request["imagelist"]);
            string AtchmentList = HttpUtility.UrlDecode(context.Request["AtchmentList"]);
            string status = HttpUtility.UrlDecode(context.Request["status"]);
            string productSecondLevelName = HttpUtility.UrlDecode(context.Request["productSecondLevelName"]);

            try
            {
                CompensateModel model = new CompensateModel();
                model.CompensateName = compensatename;
                model.CompensateType = compensateType;
                model.CompensatePeson = compensatePeson;
                model.Tel = tel;
                model.Fax = fax;
                model.ProductSecondLevelId = int.Parse(productSecondLevelId);
                model.ProductCode = productCode;
                model.Specifications = specifications;
                model.Length = lengthnum;
                model.CompensateStore = compensateStore;
                if (!String.IsNullOrWhiteSpace(compensateDate)){
                    model.CompensateDate = Convert.ToDateTime(compensateDate);
                }
                model.Position = position;
                model.ProblemDes = problemDes;
                model.FindTime = findTime;
                if(!String.IsNullOrWhiteSpace(installationTime)){
                    model.InstallationTime = Convert.ToDateTime(installationTime);
                }
                model.OtherDes = otherDes;
                
                model.ImageList = imagelist;
                model.AtchmentList = AtchmentList;
                model.Status = int.Parse(status);
                model.ProductSecondLevelName = productSecondLevelName;
                if(user.Type== AdminType.Dealer)
                {
                    model.DealerId = user.AdminId;
                }
                if(user.Type==AdminType.Stores)
                {
                    model.StoreId = user.AdminId;
                }
                
                string filepath=context.Server.MapPath("~\\Template\\Compensate\\Order\\");
                string Templatepath=context.Server.MapPath("~\\Template\\Compensate\\");
                string ret=pb.AddCompensateInfo(model, filepath, Templatepath);
                if(ret.Equals(Config.Success))
                {
                    errorCode = 0;
                }
                else
                {
                    errorCode = int.Parse(ret);
                }
              
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("CompensateAdd", ex);
            }
        }
        else
        {
            errorCode = -10;
        }
    }
    private void GetProductCode(HttpContext context)
    {
        int total = 0;
        List<string> list = new List<string>();
        AdminModel user = Common.GetLoginAdmin(context);
        if (Common.CheckPermission(Common.Module_Compensate, Common.Permission_Add, context) || Common.CheckPermission(Common.Module_Product, Common.Permission_View, context))
        {
            try
            {
                string fId = context.Request["FId"];
                if (!String.IsNullOrWhiteSpace(fId))
                {
                    if (user.Type == AdminType.Dealer)
                    {
                        pb.GetProductSecondLevelInfoByDealerId(int.Parse(fId),user.AdminId, out list);
                    }
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
    private void GetList(HttpContext context)
    {
        int total = 0;
        AdminModel user = Common.GetLoginAdmin(context);
        List<CompensateModel> list = new List<CompensateModel>();
        if (Common.CheckPermission(Common.Module_Compensate, Common.Permission_View, context))
        {
            try
            {
                int page = int.Parse(context.Request["Page"]) + 1;
                int item = int.Parse(context.Request["Item"]);
                int? fid=null;
                if(!String.IsNullOrWhiteSpace(context.Request["FId"])) {
                    fid = int.Parse(context.Request["FId"]);
                }
                string code = null;
                if (!String.IsNullOrWhiteSpace(context.Request["Code"])) {
                    code = context.Request["Code"];
                }
                int? status = null;
                if (!String.IsNullOrWhiteSpace(context.Request["Status"]))
                {
                    status = int.Parse(context.Request["Status"]);
                }
                if (user.Type == AdminType.Managers)
                {
                    pb.GetCompensateList(null, fid, code, null, null, status, page, item, out total, out list);
                }
                else if (user.Type == AdminType.Dealer )
                {
                    pb.GetCompensateList(null, null, null,user.AdminId,null,status, page, item, out total, out list);
                }
                else if (user.Type == AdminType.Stores)
                {
                    pb.GetCompensateList(null, null, null, null, user.AdminId, status, page, item, out total, out list);
                }
                errorCode = 0;
            }
            catch (Exception ex)
            {
                WriteLog.WriteExceptionLog("CompenstateGetList", ex); 
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

        sb.Append("\",\"type\":\"");
        sb.Append(user.Type);

        sb.Append("\",\"data\":");
        sb.Append(JsonConvert.SerializeObject(list));
        sb.Append("}");
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
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
    public bool IsReusable {
        get {
            return false;
        }
    }

}