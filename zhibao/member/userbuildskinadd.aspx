<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userbuildskinadd.aspx.cs" Inherits="member_userbuildskinadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">客户管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>新增建筑膜车主</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="form-group" id="divtfrontcode">
                        <label class="col-sm-3 control-label no-padding-right" for="frontcode_ddl">建筑膜型号* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="frontcode_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="frontcodeerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group" id="divtfrontProductcode">
                        <label class="col-sm-3 control-label no-padding-right" for="frontcode_ddl">建筑膜卷轴号* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="frontProductCode" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="frontProductcodeerr"></span></span>
                    </div>
                    <div class="space-4"></div>

                    <div class="form-group" id="divtbackcode" style="display:none;">
                        <label class="col-sm-3 control-label no-padding-right" for="backcode_ddl">部位名称* </label>
                        <div class="col-sm-3">
                          <input type="checkbox" value="1" name="YHGL" />机头盖  &nbsp; &nbsp; &nbsp;    &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp;   &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp;  
                          <input type="checkbox" value="2" name="YHGL" />单侧前（左/右）叶子板  <br />
                          <input type="checkbox" value="3" name="YHGL" />单侧后（左/右）叶子板  &nbsp; 
                          <input type="checkbox" value="4" name="YHGL" />单车门（左前/左后/右前/右后）<br />
                          <input type="checkbox" value="5" name="YHGL" />车顶    &nbsp; &nbsp; &nbsp;    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                          <input type="checkbox" value="6" name="YHGL" />车后备箱 <br />
                          <input type="checkbox" value="7" name="YHGL" />群边（左下/右下） &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;
                          <input type="checkbox" value="8" name="YHGL" />保险杠（前杠/后杠）<br />
                          <input type="checkbox" value="9" name="YHGL" />B柱  &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp;&nbsp;&nbsp;  &nbsp; &nbsp; &nbsp;  &nbsp;&nbsp;  &nbsp; &nbsp; &nbsp;  &nbsp;&nbsp;  &nbsp; &nbsp; &nbsp; 
                          <input type="checkbox" value="10" name="YHGL" />倒后镜<br />
                          <input type="checkbox" value="12" name="YHGLG" checked="checked" /><strong>整车</strong><br />
                        
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="backcodeerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>

                    <div class="form-group" id="divname">
                        <label class="col-sm-3 control-label no-padding-right" for="name_txt">姓名* </label>
                        <div class="col-sm-9">
                            <input type="text" id="name_txt" placeholder="姓名" class="col-xs-10 col-sm-5" maxlength="50">

                            <span class="help-inline col-xs-12 col-sm-10"><span class="middle" id="nameerr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divmobile">
                        <label class="col-sm-3 control-label no-padding-right" for="mobile_txt">手机* </label>
                        <div class="col-sm-9">
                            <input type="text" id="mobile_txt" placeholder="手机" class="col-xs-10 col-sm-5" maxlength="11">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="mobileerr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group"  id="divemail">
                        <label class="col-sm-3 control-label no-padding-right" for="email_txt">邮箱 </label>
                        <div class="col-sm-9">
                            <input type="text" id="email_txt" placeholder="邮箱" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="emailerr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divbrand">
                        <label class="col-sm-3 control-label no-padding-right" for="cartypeone_ddl">品牌信息* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="brand_ddl" runat="server"  CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"  id="branderr"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divsystem">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">车系信息 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="system_ddl" runat="server"  CssClass="form-control">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="systemerr"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">车型信息 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="type_ddl" runat="server"  CssClass="form-control">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">技师 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="js_ddl" runat="server"  CssClass="form-control">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divLicense">
                        <label class="col-sm-3 control-label no-padding-right" for="license_txt">车牌号 </label>
                        <div class="col-sm-9">
                            <input type="text" id="license_txt" placeholder="车牌号" class="col-xs-10 col-sm-5" maxlength="50">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="errLicense"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="province_ddl">省 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="province_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="city_ddl">市 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="city_ddl" runat="server" CssClass="form-control">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="price_txt">价格 </label>
                        <div class="col-sm-9">
                            <input type="text" id="price_txt" placeholder="价格" class="col-xs-10 col-sm-5" onkeyup="validatePices(this);" onblur="validatePices(this);">
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
                       
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="typeoneerr"></span> </span>
                    </div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button"><i class="icon-ok bigger-110"></i>确定 </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset"><i class="icon-undo bigger-110"></i>重置 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>

    <input id="firstlevel" value="6"  type="hidden" />
    <script type="text/javascript" src="../assets/js/uploadify/jquery.uploadify.min.js"></script>
    <script src="../js/usertbuildskinadd.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuuser").addClass("active open");
            $("#menubuildskinadd").addClass("active");
            $('#ContentPlaceHolder1_brand_ddl').chosen({ allow_single_deselect: true });
        });
    </script>

</asp:Content>

