<%@ WebHandler Language="C#" Class="UpLoading" %>

using System;
using System.Web;
using System.IO;
using System.Net;

public class UpLoading : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            context.Response.ContentType = "text/html";
            context.Response.Write(UpImage(context));
        }
        catch (Exception ex)
        {
            context.Response.Write(ex.Message);
        }
    }
    private string  UpImage(HttpContext context)
    {
        string temp="";
        if (context.Request.Files.Count > 0)
        {
               string file = context.Request.Files[0].FileName;
               int pos = file.LastIndexOf('.');
               string fileNameTemp;
               string fileNameExt;
               fileNameExt = file.Substring(pos);
               string tempName = DateTime.Now.Ticks.ToString() + fileNameExt; ;
               fileNameTemp = context.Server.MapPath("~\\UpLoadImage\\") + tempName;
               context.Request.Files[0].SaveAs(fileNameTemp);
               return tempName;
            
        }
        else
        {
            temp = "-5";
        }
        return temp;
    }
   
    public bool IsReusable {
        get {
            return false;
        }
    }

}