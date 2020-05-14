using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_F_producttemplate : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        FactoryTypeBLL factorybll = new FactoryTypeBLL();
        List<FactoryTypeModel> list = new List<FactoryTypeModel>();
        factorybll.GetFactoryTypeInfoByNotUsed(out list);
        //Response.Write(list.Count.ToString());

        string workTmp = Server.MapPath("~/Template/NewF_Template.xlsx");

        string newfileTempFolder = Server.MapPath("~/Template/template_cache");
        if (Directory.Exists(newfileTempFolder) == false)
        {
            Directory.CreateDirectory(newfileTempFolder);
        }
        string newfileTempFile = newfileTempFolder + "/" + DateTime.Now.Ticks.ToString() + ".xlsx";
        File.Copy(workTmp, newfileTempFile);

        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Extended Properties='Excel 12.0;HDR=YES;';" + "data source=" + newfileTempFile;
        ;

        using (OleDbConnection myConn = new OleDbConnection(strCon))
        {
            myConn.Open();
            string strCom = " insert into [厂家内部型号$] values ( @Name )";
            foreach (FactoryTypeModel item in list)
            {
                OleDbCommand dbCommand = new OleDbCommand(strCom, myConn);
                dbCommand.Parameters.Add(new OleDbParameter("@Name", string.Format("{0}:{1}",item.FactoryTypeId,item.FactoryTypeName)));
                dbCommand.ExecuteNonQuery();
            }
        }

        string filePath = newfileTempFile;
        FileInfo fileinfo = new FileInfo(filePath);
        Response.Clear();         //清除缓冲区流中的所有内容输出
        Response.ClearContent();  //清除缓冲区流中的所有内容输出
        Response.ClearHeaders();  //清除缓冲区流中的所有头
        Response.Buffer = true;   //该值指示是否缓冲输出，并在完成处理整个响应之后将其发送
        Response.AddHeader("Content-Disposition", "attachment;filename=NewF_Template.xlsx" );
        Response.AddHeader("Content-Length", fileinfo.Length.ToString());
        Response.AddHeader("Content-Transfer-Encoding", "binary");
        Response.ContentType = "application/unknow";  //获取或设置输出流的 HTTP MIME 类型
        Response.TransmitFile(filePath);
        Response.End();

        Response.End();
    }

    
}