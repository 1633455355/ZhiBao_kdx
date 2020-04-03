using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CompensateModel 的摘要说明
/// </summary>
public class CompensateModel
{
    /// <summary>
    /// 理赔单号
    /// </summary>
    public string CompensateNo { get;set;}
    /// <summary>
    /// 理赔品牌型号ID
    /// </summary>
    public int ProductSecondLevelId { get; set; }
    /// <summary>
    /// 理赔品牌型号名
    /// </summary>
    public string ProductSecondLevelName { get; set; }
    /// <summary>
    /// 卷轴号
    /// </summary>
    public string ProductCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string CompensateName { get; set; }
    /// <summary>
    /// 电话
    /// </summary>
    public string Tel { get; set; }
    /// <summary>
    /// 传真
    /// </summary>
    public string Fax { get; set; }
    /// <summary>
    /// 1:大区      2：省级      3：加盟店  
    /// </summary>
    public string CompensateType { get; set; }
    /// <summary>
    ///  申请人
    /// </summary>
    public string CompensatePeson { get; set; }
    /// <summary>
    /// 幅宽/规格(英寸) 1:20/2:36/3:40/4:60/5:72
    /// </summary>
    public string Specifications { get; set; }
    /// <summary>
    /// 数量/长度 (米)
    /// </summary>
    public string Length { get; set; }
    /// <summary>
    /// 问题发生的施工店
    /// </summary>
    public string CompensateStore { get; set; }
    /// <summary>
    /// 问题发现日期（年/月/日）
    /// </summary>
    public DateTime? CompensateDate { get; set; }
    /// <summary>
    /// 问题发生部位(相对于整卷窗膜而言)      1:开始/2:中间/3:末尾/4:整卷
    /// </summary>
    public string Position { get; set; }
    public List<int> PositionList { get; set; }
    /// <summary>
    /// 问题描述（其他请详细描述）     1:胶点(膜上面呈现出圆形的亮点)/2:胶纹（透过膜看物体，物体有变形，好像波浪一样）
    /// 3:杂质（膜里面有异物）/4:折线（膜里有一条被褶的线）/5:压痕（膜里面有被压的印子/6:褶痕（膜里面有被褶的印子）
    /// 7:变色/退色（与正常颜色不一样或浅一些）/8:橘皮（看上去跟橘子皮一样的形状）/9:膜根/10:脱胶/11:分层/12:发黄/13:色差/14:其他
    /// </summary>
    public string ProblemDes { get; set; }
    public List<int> ProblemDesList { get; set; }
    /// <summary>
    /// 14:其他的描述
    /// </summary>
    public string ProblemOtherDes { get; set; }
    /// <summary>
    /// 1:施工前安装人员发现/2:安装后车主投诉
    /// </summary>
    public string FindTime { get; set; }
    /// <summary>
    /// 安装日期
    /// </summary>
    public DateTime? InstallationTime { get; set; }
    /// <summary>
    /// 其他需说明的事宜
    /// </summary>
    public string OtherDes { get; set; }
    /// <summary>
    ///经销商ID
    /// </summary>
    public int? DealerId { get; set; }
    /// <summary>
    /// 经销商名称
    /// </summary>
    public string DealerName { get; set; }
    /// <summary>
    /// 店面ID
    /// </summary>
    public int? StoreId { get; set; }
    /// <summary>
    /// 店面名称
    /// </summary>
    public string StoreName { get; set; }
    /// <summary>
    /// 0:未处理1:正在处理 2:需要补充资料 3:已经补充资料 4：已经处理完成
    /// </summary>
    public int Status { get; set; }
    /// <summary>
    /// 图片
    /// </summary>
    public string ImageList { get; set; }
    public List<string> ImageArray { get; set; }
    /// <summary>
    /// 附件
    /// </summary>
    public string AtchmentList { get; set; }
    public List<string> AtchmentArray { get; set; }
    /// <summary>
    /// 理赔单生成时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 评论信息
    /// </summary>
    public CommentModel ConmentInfo { get; set; }



}