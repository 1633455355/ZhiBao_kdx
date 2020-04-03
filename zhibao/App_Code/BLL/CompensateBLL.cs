using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// CompensateBLL 的摘要说明
/// </summary>
public class CompensateBLL
{
    private CompensateDAL cDAL = null;
    private CommentDAL cmDAL = null;

	public CompensateBLL()
	{
        cDAL = new CompensateDAL();
        cmDAL = new CommentDAL();
	}
       /// <summary>
    /// 增加理赔信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddCompensateInfo(CompensateModel oPModel,string OrderPath,string OrderTemplate)
    {
        string ret = Config.Fail;
        try
        {
            string No = Config.GUNo;
            if(oPModel!=null)
            {
                oPModel.CompensateNo = No.ToUpper();
            }
            ret = cDAL.AddCompensateInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                string _orderPath = OrderPath + oPModel.CompensateNo + ".html";
                string _orderTemplate = OrderTemplate + "CompensateTemplate.html";
                CompensateOrder(oPModel, _orderPath, _orderTemplate);
                if (oPModel.ConmentInfo!=null)
                {
                    CommentModel c = oPModel.ConmentInfo;
                    c.CompensateNo = No;
                    cmDAL.AddCommentInfo(c);
                }
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.AddCompensateInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    public void  CompensateOrder(CompensateModel oPModel,string OrderPath,string OrderTemplate)
    {
        FileStream fStream=null;
        StreamReader sr=null;
        StreamWriter sw = null;
        try{
             fStream = new FileStream(OrderTemplate, FileMode.Open);
             sr = new StreamReader(fStream);
             string Content = sr.ReadToEnd();
             string NewsContent = RespaceCompensateOrder(oPModel, Content);
             sw = new StreamWriter(OrderPath);
             sw.Write(NewsContent);
        }
        catch(Exception ex){
            throw ex;
        }
        finally {
            sr.Dispose();
            sw.Dispose();
            fStream.Dispose();
        }
    }
    public string RespaceCompensateOrder(CompensateModel oPModel,string _Content)
    {
        string Content=_Content;
        if(oPModel!=null)
        {
            ///理赔单号
            if (!String.IsNullOrWhiteSpace(oPModel.CompensateNo)) { Content = Content.Replace("<%CompensateNo%>", oPModel.CompensateNo); }
            else { Content = Content.Replace("<%CompensateNo%>", ""); }
            ///申请经销商
            if (!String.IsNullOrWhiteSpace(oPModel.CompensateName)) { Content = Content.Replace("<%DealerName%>", oPModel.CompensateName); }
            else { Content = Content.Replace("<%DealerName%>", ""); }
            ///经销商级别
            if (!String.IsNullOrWhiteSpace(oPModel.CompensateType)) 
            {
                if (oPModel.CompensateType == "1") { Content = Content.Replace("<%CompensateType_1%>", "是"); }
                else { Content = Content.Replace("<%CompensateType_1%>", ""); }

                if (oPModel.CompensateType == "2") { Content = Content.Replace("<%CompensateType_2%>", "是"); }
                else { Content = Content.Replace("<%CompensateType_2%>", ""); }

                if (oPModel.CompensateType == "3") { Content = Content.Replace("<%CompensateType_3%>", "是"); }
                else { Content = Content.Replace("<%CompensateType_3%>", ""); }
            }
            else {
                Content = Content.Replace("<%CompensateType_1%>", "");
                Content = Content.Replace("<%CompensateType_2%>", "");
                Content = Content.Replace("<%CompensateType_3%>", "");
            }
            /// 申请人
            if (!String.IsNullOrWhiteSpace(oPModel.CompensatePeson)) { Content = Content.Replace("<%CompensatePeson%>", oPModel.CompensatePeson); }
            else { Content = Content.Replace("<%CompensatePeson%>", ""); }
            ///联系电话
            if (!String.IsNullOrWhiteSpace(oPModel.Tel)) { Content = Content.Replace("<%Tel%>", oPModel.Tel); }
            else { Content = Content.Replace("<%Tel%>", ""); }
            ///联系传真
            if (!String.IsNullOrWhiteSpace(oPModel.Fax)) { Content = Content.Replace("<%Fax%>", oPModel.Fax); }
            else { Content = Content.Replace("<%Fax%>", ""); }
            ///索赔窗膜型号
            if (!String.IsNullOrWhiteSpace(oPModel.ProductSecondLevelName)) { Content = Content.Replace("<%ProductSecondLevelName%>", oPModel.ProductSecondLevelName); }
            else { Content = Content.Replace("<%ProductSecondLevelName%>", ""); }
            ///索赔窗膜卷轴号
            if (!String.IsNullOrWhiteSpace(oPModel.ProductCode)) { Content = Content.Replace("<%ProductCode%>", oPModel.ProductCode); }
            else { Content = Content.Replace("<%ProductCode%>", ""); }

            ///幅宽/规格(英寸)
            if (!String.IsNullOrWhiteSpace(oPModel.Specifications))
            {
                if (oPModel.Specifications == "1") { Content = Content.Replace("<%Specifications1%>", "<u>20</u>"); }
                else { Content = Content.Replace("<%Specifications1%>", "20"); }

                if (oPModel.Specifications == "2") { Content = Content.Replace("<%Specifications2%>", "<u>36</u>"); }
                else { Content = Content.Replace("<%Specifications2%>", "36"); }

                if (oPModel.Specifications == "3") { Content = Content.Replace("<%Specifications3%>", "<u>40</u>"); }
                else { Content = Content.Replace("<%Specifications3%>", "40"); }

                if (oPModel.Specifications == "4") { Content = Content.Replace("<%Specifications4%>", "<u>60</u>"); }
                else { Content = Content.Replace("<%Specifications4%>", "60"); }

                if (oPModel.Specifications == "5") { Content = Content.Replace("<%Specifications5%>", "<u>72</u>"); }
                else { Content = Content.Replace("<%Specifications5%>", "72"); }
            }
            else
            {
                Content = Content.Replace("<%Specifications1%>", "20");
                Content = Content.Replace("<%Specifications2%>", "36");
                Content = Content.Replace("<%Specifications3%>", "40");
                Content = Content.Replace("<%Specifications4%>", "60");
                Content = Content.Replace("<%Specifications5%>", "72");
            }
            ///问题发生的施工店
            if (!String.IsNullOrWhiteSpace(oPModel.CompensateStore)) { Content = Content.Replace("<%CompensateStore%>", oPModel.CompensateStore); }
            else { Content = Content.Replace("<%CompensateStore%>", ""); }
            ///问题发现日期（年/月/日)
            if (oPModel.CompensateDate != null) { Content = Content.Replace("<%CompensateDate%>", oPModel.CompensateDate.Value.ToString("yyy/MM/dd")); }
            else { Content = Content.Replace("<%CompensateDate%>", ""); }

            ///问题发生部位(相对于整卷窗膜而言)
            if (!String.IsNullOrWhiteSpace(oPModel.Position)) {
                List<int> PositionId = StringManager.ConvertIntList(oPModel.Position);
                foreach(int id in PositionId)  {
                    if (id == 1) { Content = Content.Replace("<%Position_1%>", "是"); }
                    else if (id == 2) { Content = Content.Replace("<%Position_2%>", "是"); }
                    else if (id == 3) { Content = Content.Replace("<%Position_3%>", "是"); }
                    else if (id == 4) { Content = Content.Replace("<%Position_4%>", "是"); }
                }
                Content = Content.Replace("<%Position_1%>", "");
                Content = Content.Replace("<%Position_2%>", "");
                Content = Content.Replace("<%Position_3%>", "");
                Content = Content.Replace("<%Position_4%>", "");
            }
            else{
                Content = Content.Replace("<%Position_1%>", "");
                Content = Content.Replace("<%Position_2%>", "");
                Content = Content.Replace("<%Position_3%>", "");
                Content = Content.Replace("<%Position_4%>", "");
            }
            if (!String.IsNullOrWhiteSpace(oPModel.Length)) { Content = Content.Replace("<%Length%>", oPModel.Length); }
            else { Content = Content.Replace("<%Length%>", ""); }
            if (!String.IsNullOrWhiteSpace(oPModel.ProblemDes))
            {
                List<int> ProblemDesId = StringManager.ConvertIntList(oPModel.ProblemDes);
                foreach (int id in ProblemDesId)
                {
                    if (id == 1) { Content = Content.Replace("<%ProblemDes_1%>", "是"); }
                    else if (id == 2) { Content = Content.Replace("<%ProblemDes_2%>", "是"); }
                    else if (id == 3) { Content = Content.Replace("<%ProblemDes_3%>", "是"); }
                    else if (id == 4) { Content = Content.Replace("<%ProblemDes_4%>", "是"); }
                    else if (id == 5) { Content = Content.Replace("<%ProblemDes_5%>", "是"); }
                    else if (id == 6) { Content = Content.Replace("<%ProblemDes_6%>", "是"); }
                    else if (id == 7) { Content = Content.Replace("<%ProblemDes_7%>", "是"); }
                    else if (id == 8) { Content = Content.Replace("<%ProblemDes_8%>", "是"); }
                    else if (id == 9) { Content = Content.Replace("<%ProblemDes_9%>", "是"); }
                    else if (id == 10) { Content = Content.Replace("<%ProblemDes_10%>", "是"); }
                    else if (id == 11) { Content = Content.Replace("<%ProblemDes_11%>", "是"); }
                    else if (id == 12) { Content = Content.Replace("<%ProblemDes_12%>", "是"); }
                    else if (id == 13) { Content = Content.Replace("<%ProblemDes_13%>", "是"); }
                    else if (id == 14) { Content = Content.Replace("<%ProblemDes_14%>", "是"); }
                }
                Content = Content.Replace("<%ProblemDes_1%>", "");
                Content = Content.Replace("<%ProblemDes_2%>", "");
                Content = Content.Replace("<%ProblemDes_3%>", "");
                Content = Content.Replace("<%ProblemDes_4%>", "");
                Content = Content.Replace("<%ProblemDes_5%>", "");
                Content = Content.Replace("<%ProblemDes_6%>", "");
                Content = Content.Replace("<%ProblemDes_7%>", "");
                Content = Content.Replace("<%ProblemDes_8%>", "");
                Content = Content.Replace("<%ProblemDes_9%>", "");
                Content = Content.Replace("<%ProblemDes_10%>", "");
                Content = Content.Replace("<%ProblemDes_11%>", "");
                Content = Content.Replace("<%ProblemDes_12%>", "");
                Content = Content.Replace("<%ProblemDes_13%>", "");
                Content = Content.Replace("<%ProblemDes_14%>", "");
            }
            else
            {
                Content = Content.Replace("<%ProblemDes_1%>", "");
                Content = Content.Replace("<%ProblemDes_2%>", "");
                Content = Content.Replace("<%ProblemDes_3%>", "");
                Content = Content.Replace("<%ProblemDes_4%>", "");
                Content = Content.Replace("<%ProblemDes_5%>", "");
                Content = Content.Replace("<%ProblemDes_6%>", "");
                Content = Content.Replace("<%ProblemDes_7%>", "");
                Content = Content.Replace("<%ProblemDes_8%>", "");
                Content = Content.Replace("<%ProblemDes_9%>", "");
                Content = Content.Replace("<%ProblemDes_10%>", "");
                Content = Content.Replace("<%ProblemDes_11%>", "");
                Content = Content.Replace("<%ProblemDes_12%>", "");
                Content = Content.Replace("<%ProblemDes_13%>", "");
                Content = Content.Replace("<%ProblemDes_14%>", "");
            }
            ///发现问题的阶段
            if (!String.IsNullOrWhiteSpace(oPModel.FindTime))
            {
                List<int> FindTimeId = StringManager.ConvertIntList(oPModel.FindTime);
                foreach (int id in FindTimeId) {
                    if (id == 1) { Content = Content.Replace("<%FindTime_1%>", "是"); }
                    else if (id == 2) { Content = Content.Replace("<%FindTime_2%>", "是"); }
                  
                }
                Content = Content.Replace("<%FindTime_1%>", "");
                Content = Content.Replace("<%FindTime_2%>", "");
            }
            else{
                Content = Content.Replace("<%FindTime_1%>", "");
                Content = Content.Replace("<%FindTime_2%>", "");
            }
            ///安装日期
            if (oPModel.InstallationTime != null) { Content = Content.Replace("<%InstallationTime%>", oPModel.InstallationTime.Value.ToString("yyy/MM/dd")); }
            else { Content = Content.Replace("<%InstallationTime%>", ""); }
            ///其他需说明的事宜
            if (!String.IsNullOrWhiteSpace(oPModel.OtherDes)) { Content = Content.Replace("<%OtherDes%>", oPModel.OtherDes); }
            else { Content = Content.Replace("<%OtherDes%>", ""); }

        }
        return Content;
    }
      /// <summary>
    /// 更新理赔信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetCompensateInfo(CompensateModel oPModel, string OrderPath, string OrderTemplate)
    {
        string ret = Config.Fail;
        try
        {
            ret = cDAL.SetCompensateInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                string _orderPath = OrderPath + oPModel.CompensateNo + ".html";
                string _orderTemplate = OrderTemplate + "CompensateTemplate.html";
                CompensateOrder(oPModel, _orderPath, _orderTemplate);
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.SetCompensateInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
     /// <summary>
    /// 更新理赔信息状态
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string SetCompensateInfoStatus(string CompensateNo,int Status)
    {
        string ret = Config.Fail;
        try
        {
            ret = cDAL.SetCompensateInfoStatus(CompensateNo, Status);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.SetCompensateInfoStatus()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

    
    /// <summary>
    /// 删除理赔信息
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string RemoveCompensateInfo(string CompensateNo)
    {
        string ret = Config.Fail;
        try
        {
            ret = cDAL.RemoveCompensateInfo(CompensateNo);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.RemoveCompensateInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }
    /// <summary>
    /// 得到经销商认证过的品牌的型号
    /// </summary>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string GetProductSecondLevelInfoByDealerId(int DealerId,out List<ProductTypeModel> olist)
    {
        olist = new List<ProductTypeModel>();
        try
        {
            olist = cDAL.GetProductSecondLevelInfoByDealerId(DealerId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetProductSecondLevelInfoByDealerId()", ex);
            return Config.ExceptionMsg;
        }
    }
    /// <summary>
    /// 得到经销商认证过的卷轴号
    /// </summary>
    /// <param name="ProductSecondLevelId"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string GetProductSecondLevelInfoByDealerId(int ProductSecondLevelId, int DealerId,out List<string> olist)
    {
        olist = new List<string>();
        try
        {
            olist = cDAL.GetProductSecondLevelInfoByDealerId(ProductSecondLevelId, DealerId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetProductSecondLevelInfoByDealerId()_1", ex);
            return Config.ExceptionMsg;
        }
    }
      /// <summary>
    /// 得到门店认证过的品牌的型号
    /// </summary>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string  GetProductSecondLevelInfoByStoreId(int StoreId,out List<ProductTypeModel> olist)
    {
        olist = new List<ProductTypeModel>();
        try
        {
            olist = cDAL.GetProductSecondLevelInfoByStoreId(StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetProductSecondLevelInfoByStoreId()", ex);
            return Config.ExceptionMsg;
        }
    }
     /// <summary>
    /// 得到门店认证过的卷轴号
    /// </summary>
    /// <param name="ProductSecondLevelId"></param>
    /// <param name="DealerId"></param>
    /// <returns></returns>
    public string GetProductSecondLevelInfoByStoreId(int ProductSecondLevelId, int StoreId, out List<string> olist)
    {
        olist = new List<string>();
        try
        {
            olist = cDAL.GetProductSecondLevelInfoByStoreId(ProductSecondLevelId, StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetProductSecondLevelInfoByStoreId()_1", ex);
            return Config.ExceptionMsg;
        }
    }
    /// <summary>
    /// 侧后挡
    /// </summary>
    /// <param name="ProductSecondLevelId"></param>
    /// <param name="StoreId"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetProductSecondLevelInfoByStoreId_1(int ProductSecondLevelId, int StoreId, out List<string> olist)
    {
        olist = new List<string>();
        try
        {
            olist = cDAL.GetProductSecondLevelInfoByStoreId_1(ProductSecondLevelId, StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetProductSecondLevelInfoByStoreId_1", ex);
            return Config.ExceptionMsg;
        }
    }
    public string GetProduct_T_SecondLevelInfoByStoreId(int ProductSecondLevelId, int StoreId, out List<string> olist)
    {
        olist = new List<string>();
        try
        {
            olist = cDAL.GetProduct_T_SecondLevelInfoByStoreId(ProductSecondLevelId, StoreId);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetProduct_T_SecondLevelInfoByStoreId()_1", ex);
            return Config.ExceptionMsg;
        }
    }

    /// <summary>
    /// 得到理赔列表
    /// </summary>
    /// <param name="PageIndex"></param>
    /// <param name="PageNum"></param>
    /// <param name="where"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetCompensateList(string CompensateNo, int? ProductSecondLevelId, string ProductCode,int? DealerId,int? StoreId,int? Status, int PageIndex, int PageNum, out int Count, out  List<CompensateModel> olist)
    {
        olist = new  List<CompensateModel>();
        Count = 0;
        string whereMsg = " 1=1";
        if (!String.IsNullOrEmpty(CompensateNo))
        {
            whereMsg += " and CompensateInfo.CompensateNo='" + CompensateNo + "'";
        }
        if (ProductSecondLevelId != null)
        {
            whereMsg += " and CompensateInfo.ProductSecondLevelId in(select ProductSecondLevelId from ProductSecondLevelInfo where FactoryTypeId='" + ProductSecondLevelId.Value+"')";
        }
        if (!String.IsNullOrEmpty(ProductCode))
        {
            whereMsg += " and CompensateInfo.ProductCode='" + ProductCode + "'";
        }
        if (DealerId != null)
        {
            whereMsg += " and CompensateInfo.DealerId=" + DealerId.Value;
        }
        if (StoreId != null)
        {
            whereMsg += " and CompensateInfo.StoreId=" + StoreId.Value;
        }
        if (Status != null)
        {
            whereMsg += " and CompensateInfo.Status=" + Status.Value;
        }
        try
        {
            olist = cDAL.GetCompensateList(PageIndex, PageNum, whereMsg, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetCompensateList()", ex);
            return Config.ExceptionMsg;
        }
    }

     /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddCommentInfo(CommentModel oPModel)
    {
        string ret = Config.Fail;
        try
        {
            ret = cmDAL.AddCommentInfo(oPModel);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.AddCommentInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;
    }

      /// <summary>
    /// 删除评论
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string RemoveCommentInfo(int CommentId)
    {
        string ret = Config.Fail;
        try
        {
            ret = cmDAL.RemoveCommentInfo(CommentId);
            int Id = 0;
            bool flag = Int32.TryParse(ret, out Id);
            if (flag && Id > 0)
            {
                return Config.Success;
            }
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.RemoveCommentInfo()", ex);
            return Config.ExceptionMsg;
        }
        return ret;

    }
     /// <summary>
    /// 得到评论
    /// </summary>
    /// <param name="CompensateNo"></param>
    /// <returns></returns>
    public string GetCommentList(string CompensateNo,out List<CommentModel> olist)
    {
        olist = new List<CommentModel>();
        try
        {
            olist = cmDAL.GetCommentList(CompensateNo);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("BLL.CompensateBLL.GetCommentList()", ex);
            return Config.ExceptionMsg;
        }
    }
}