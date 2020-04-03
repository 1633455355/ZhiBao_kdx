using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;

public partial class member_F_productimport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Common.CheckPermission(Common.Module_Factory_Type, Common.Permission_Add, HttpContext.Current))
        {
            if (Page.IsPostBack)
            {
                try
                {
                    error.Text = "";
                    rigth.Text = "";
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFile file = Request.Files[0];
                        string path = Server.MapPath("\\Template\\Temp\\");
                        path = path + DateTime.Now.Ticks.ToString() + ".xlsx";
                        file.SaveAs(path);

                        DataSet ds = getData(path);
                        StringBuilder errorData = new StringBuilder();
                        if (ds.Tables[0].Columns.Count != 4)
                        {
                            StringBuilder html = new StringBuilder();
                            html.Append("<div class=\"alert alert-danger\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
                            html.Append("<i class=\"icon-remove\"></i>");
                            html.Append(" </button>");
                            html.Append(" <strong>  <i class=\"icon-remove\"></i> Oh snap!  </strong>");
                            html.Append(" 导入格式不正确，请下载正确的导入模板");
                            html.Append(" <br>    </div>");
                            error.Text = html.ToString();
                        }
                        else
                        {

                            AdminModel user = Common.GetLoginAdmin(HttpContext.Current);
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                string errorStr = "";
                                ProductModel model = new ProductModel();
                                string[] FactoryTypeId = ds.Tables[0].Rows[i]["厂家内部型号"].ToString().Split(':');
                                if (FactoryTypeId != null & FactoryTypeId.Length > 0)
                                {
                                    model.FactoryTypeId = Convert.ToInt32(FactoryTypeId[0]);

                                }
                                model.ProductCode = ds.Tables[0].Rows[i]["卷轴号"].ToString();
                                model.ProductDes = ds.Tables[0].Rows[i]["质保年限"].ToString();
                                string L = ds.Tables[0].Rows[i]["长度"].ToString();
                                if (!String.IsNullOrWhiteSpace(L))
                                {
                                    model.Length = float.Parse(ds.Tables[0].Rows[i]["长度"].ToString());
                                }
                                else
                                {
                                    model.Length = 0;
                                }
                               
                                model.CreatorId = user.AdminId;
                                if (model.FactoryTypeId > 0)
                                {
                                    errorStr = AddProductInfo(model);

                                    if (errorStr == "-2")
                                    {
                                        errorData.Append("<tr>");
                                        errorData.Append("<td style=\"width: 132px\">第" + (i + 2) + "行</td>");
                                        errorData.Append("  <td style=\"width: 137px\">" + ds.Tables[0].Rows[i]["卷轴号"] + "</td>");
                                        errorData.Append("<td style=\"width: 232px\">卷轴号重复</td>");
                                        errorData.Append("</tr>");

                                    }
                                    else if (errorStr == "-5")
                                    {
                                        errorData.Append("<tr>");
                                        errorData.Append("<td style=\"width: 132px\">第" + (i + 2) + "行</td>");
                                        errorData.Append("  <td style=\"width: 137px\">" + ds.Tables[0].Rows[i]["卷轴号"] + "</td>");
                                        errorData.Append("<td style=\"width: 232px\">模板中的厂家内部型号和系统中不相符</td>");
                                        errorData.Append("</tr>");
                                        errorData.AppendLine();
                                    }
                                    if (errorStr == "-1")
                                    {
                                        errorData.Append("<tr>");
                                        errorData.Append("<td style=\"width: 132px\">第" + (i + 2) + "行</td>");
                                        errorData.Append("  <td style=\"width: 137px\"></td>");
                                        errorData.Append("<td style=\"width: 232px\">卷轴号为空</td>");
                                        errorData.Append("</tr>");

                                    }

                                }

                            }
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (!String.IsNullOrEmpty(errorData.ToString()))
                                {
                                    StringBuilder html = new StringBuilder();
                                    html.Append("<div class=\"alert alert-danger\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
                                    html.Append("<i class=\"icon-remove\"></i>");
                                    html.Append(" </button>");
                                    html.Append(" <strong>  <i class=\"icon-remove\"></i> Oh snap!  </strong>");
                                    html.Append(" <table>" + errorData + "</table>");
                                    html.Append(" <br>    </div>");
                                    error.Text = html.ToString();
                                }
                                else
                                {
                                    rigth.Text = "  <div class=\"alert alert-block alert-success\"> <button type=\"button\" class=\"close\" data-dismiss=\"alert\"> <i class=\"icon-remove\"></i> </button><p>"
                                        + "<strong><i class=\"icon-ok\"></i> Well done! </strong>导入成功.</p> </div>";
                                }
                            }
                            else
                            {

                                StringBuilder html = new StringBuilder();
                                html.Append("<div class=\"alert alert-danger\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
                                html.Append("<i class=\"icon-remove\"></i>");
                                html.Append(" </button>");
                                html.Append(" <strong>  <i class=\"icon-remove\"></i> Oh snap!  </strong>");
                                html.Append(" 导入文件中数据为空，请输入之后，再导入");
                                html.Append(" <br>    </div>");
                                error.Text = html.ToString();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    WriteLog.WriteExceptionLog("导入", ex);
                    StringBuilder html = new StringBuilder();
                    html.Append("<div class=\"alert alert-danger\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
                    html.Append("<i class=\"icon-remove\"></i>");
                    html.Append(" </button>");
                    html.Append(" <strong>  <i class=\"icon-remove\"></i> Oh snap!  </strong>");
                    html.Append(" 导入格式不正确，请下载正确的导入模板");
                    html.Append(" <br>    </div>");
                    error.Text = html.ToString();
                }
            }
        }
    }

    public string AddProductInfo(ProductModel model)
    {
        ProductBLL pd = new ProductBLL();
        return pd.AddF_ProductInfo(model);
    }
    public DataSet getData(string path)
    {
        DataSet ds = new DataSet();
        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Extended Properties='Excel 12.0;HDR=yes;IMEX=1';" + "data source=" + path;
        OleDbConnection myConn = new OleDbConnection(strCon);
        string strCom = " SELECT * FROM [导入卷轴号数据$]";
        try
        {
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            myCommand.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }
        return ds;
    }

}