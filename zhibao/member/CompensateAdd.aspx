<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompensateAdd.aspx.cs" Inherits="member_CompensateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />

    <link rel="stylesheet" href="../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../assets/css/chosen.css" />
    <link rel="stylesheet" href="../assets/css/datepicker.css" />
    <link rel="stylesheet" href="../assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="../assets/css/daterangepicker.css" />
    <link rel="stylesheet" href="../assets/css/colorpicker.css" />
    <link rel="stylesheet" href="../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../assets/css/ace-skins.min.css" />
    <link href="../assets/js/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    

    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home icon-home"></i><a href="home.aspx">首页</a> </li>
            <li class="active">理赔管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>申请理赔</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">

                    <div class="form-group" id="divDealerName_txt">
                        <label class="col-sm-3 control-label no-padding-right" for="frontcode_ddl">申请经销商</label>
                        <div class="col-sm-9">
                           <input type="text" id="DealerName_txt" placeholder="申请经销商" class="col-xs-10 col-sm-5" >
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="DealerName_txt_err"></span></span>
                    </div>
                    <div class="space-4"></div>
                  

                    <div class="form-group" id="divCompensateType">
                        <label class="col-sm-3 control-label no-padding-right" for="backcode_ddl">经销商级别*</label>
                        <div class="col-sm-2">
                            <label><input name="CompensateType" type="radio" class="ace" value="1"><span class="lbl"> 大区</span></label>
                            <label><input name="CompensateType" type="radio" class="ace" value="2"><span class="lbl"> 省级</span></label>
                            <label><input name="CompensateType" type="radio" class="ace" value="3"><span class="lbl"> 加盟店</span></label>
                       </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="CompensateTyp_txt_err"></span></span>
                    </div>
                    <div class="space-4"></div>

               
                    <div class="form-group" id="divCompensatePeson">
                        <label class="col-sm-3 control-label no-padding-right" for="CompensatePeson_txt"> 申请人*</label>
                        <div class="col-sm-9">
                            <input type="text" id="CompensatePeson_txt" placeholder="申请人" class="col-xs-10 col-sm-5">

                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="CompensatePeson_txt_err"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divTel">
                        <label class="col-sm-3 control-label no-padding-right" for="Tel_txt">联系电话* </label>
                        <div class="col-sm-9">
                            <input type="text" id="Tel_txt" placeholder="联系电话" class="col-xs-10 col-sm-5" >
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="Tel_txt_err"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group"  id="divFax">
                        <label class="col-sm-3 control-label no-padding-right" for="email_txt">联系传真 </label>
                        <div class="col-sm-9">
                            <input type="text" id="Fax_txt" placeholder="联系传真" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="Fax_txt_err"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divProductSecondLevelName">
                        <label class="col-sm-3 control-label no-padding-right" for="cartypeone_ddl">索赔窗膜型号* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ProductSecondLevelName_ddl" runat="server"  CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"  id="ProductSecondLevelName_dll_err"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divProductCode">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">索赔窗膜卷轴号* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ProductCode_ddl" runat="server"  CssClass="form-control">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="ProductCode_ddl_err"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divSpecifications">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">幅宽/规格(米)* </label>
                        <div class="col-sm-2">
                            <label><input name="Specifications" type="radio" class="ace" value="1"> <span class="lbl"> 20</span></label>   
                            <label><input name="Specifications" type="radio" class="ace" value="2"> <span class="lbl"> 36 </span></label>   
                            <label><input name="Specifications" type="radio" class="ace" value="3"> <span class="lbl"> 40</span></label>   
                            <label><input name="Specifications" type="radio" class="ace" value="4"> <span class="lbl"> 60</span></label>   
                            <label><input name="Specifications" type="radio" class="ace" value="5"> <span class="lbl"> 72</span></label>  
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="Specifications_err"></span> </span>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">数量/长度 (米)</label>
                        <div class="col-sm-2">
                          <input type="text" id="Length_txt" placeholder="数量/长度 (米)" class="col-xs-10 col-sm-10">
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="CompensateStore_txt">问题发生的施工店</label>
                        <div class="col-sm-9">
                            <input type="text" id="CompensateStore_txt" placeholder="问题发生的施工店" class="col-xs-10 col-sm-5" >
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right">问题发现日期（年-月-日） </label>
                        <div class="input-group col-sm-2 "> 
                            <span class="input-group-addon"> <i class="icon-calendar bigger-10"></i> </span>
                            <input type="text" data-date-format="yyyy-mm-dd" id="CompensateDate_txt" class="form-control date-picker">
                        </div>
                </div>
                  
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="Position_dll">问题发生部位(相对于整卷<br />窗膜而言)</label>
                        <div class="col-sm-2">
                           <label><input name="Position" type="checkbox" class="ace" value="1"> <span class="lbl">  开始</span></label>   
                           <label><input name="Position" type="checkbox" class="ace" value="2"> <span class="lbl">  中间</span></label>   
                           <label><input name="Position" type="checkbox" class="ace" value="3"> <span class="lbl">  末尾</span></label>   
                           <label><input name="Position" type="checkbox" class="ace" value="4"> <span class="lbl">  整卷</span></label>   
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="price_txt">问题描述（其他请详细描<br />述） </label>
                        <div class="col-sm-9">
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="1"> <span class="lbl">   胶点(膜上面呈现出圆形的亮点)</span></label><br />
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="2"> <span class="lbl">   胶纹（透过膜看物体，物体有变形，好像波浪一样）</span></label> <br /> 
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="3">  <span class="lbl">  杂质（膜里面有异物）</span></label><br />
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="4">  <span class="lbl">  折线（膜里有一条被褶的线）</span></label><br />
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="5">  <span class="lbl">  压痕（膜里面有被压的印子）</span></label><br />
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="6">  <span class="lbl">  褶痕（膜里面有被褶的印子）</span></label><br />
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="7">  <span class="lbl">  变色/退色（与正常颜色不一样或浅一些）</span></label> <br /> 
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="8">  <span class="lbl">  橘皮（看上去跟橘子皮一样的形状）</span></label><br />
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="9">  <span class="lbl">  膜根</span></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="10"> <span class="lbl">  脱胶</span></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="11"> <span class="lbl">  分层</span></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="12"> <span class="lbl">  发黄</span></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="13"> <span class="lbl">  色差</span></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                          <label><input name="ProblemDes" type="checkbox" class="ace" value="14"> <span class="lbl">  其他</span></label>
                        </div>
                    </div>
                    <div class="space-4"></div>
                       <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="FindTime">发现问题的阶段</label>
                        <div class="col-sm-9">
                           <label><input name="FindTime" type="radio" class="ace" value="1"> <span class="lbl">  施工前安装人员发现</span></label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp  
                           <label><input name="FindTime" type="radio" class="ace" value="2"> <span class="lbl">  安装后车主投诉</span></label>   
                         
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right">安装日期（年-月-日） </label>
                        <div class="input-group col-sm-2 "> 
                            <span class="input-group-addon"> <i class="icon-calendar bigger-10"></i> </span>
                            <input type="text" data-date-format="yyyy-mm-dd" id="InstallationTime" class="form-control date-picker">
                        </div>
                   </div>
                  <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="OtherDes_txt">其他需说明的事宜</label>
                        <div class="col-sm-9">
                            <textarea id="OtherDes_txt"  class="col-xs-10 col-sm-5"></textarea>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group" id="divtypeone">
                        <label class="col-sm-3 control-label no-padding-right" for="province_ddl">上传图片</label>
                        <div class="col-sm-3" id="Loading">
                            <input  type="hidden" name="tempImage" id="tempImage" />
                            <div><input type="file" style="margin-top:3px; display:inline-block; vertical-align:middle;"  id="uploadify"  name="uploadify" /></div>
                            <div id="ImageResult">
                             
                            </div>
                        </div>
                       
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="Image_eerr"></span> </span>
                    </div>
                     <div class="space-4"></div>
                     <div class="form-group" id="divtypeone1">
                        <label class="col-sm-3 control-label no-padding-right" for="province_ddl">上传附件</label>
                        <div class="col-sm-3" id="Loading1">
                            <input  type="hidden" name="tempImage1" id="tempImage1" />
                            <div><input type="file" style="margin-top:3px; display:inline-block; vertical-align:middle;"  id="uploadify1"  name="uploadify" /></div>
                            <div id="AtchmentList">
                             
                            </div>
                        </div>
                       
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="Atchment_err"></span> </span>
                    </div>
                   <div class="form-group" id="divStatus" style="display:none">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">状态* </label>
                        <div class="col-sm-2">
                           <select id="statusValue" name="statusValue" class="form-control">
                               <option value=""></option>
                               <option value="0">未处理</option>
                               <option value="3">已经补充资料</option>
                           </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="status_ddl_err"></span> </span>
                    </div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="CompensateAdd()"><i class="icon-ok bigger-110"></i>确定 </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset" \ ><i class="icon-undo bigger-110"></i>重置 </button>
                           
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>
    <script type="text/javascript" src="../assets/js/uploadify/jquery.uploadify.min.js"></script>
    <script src="../js/jquery.query.js"></script>
    <script src="../js/Compensateadd.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#menucompensate").addClass("active open");
            $("#compensateAdd").addClass("active");

            $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });
        });
    </script>


</asp:Content>

