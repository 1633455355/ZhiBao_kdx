<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="useradd.aspx.cs" Inherits="member_useradd" %>

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
            <h1>新增车主</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">

                    <div class="form-group" id="divtfrontcode">
                        <label class="col-sm-3 control-label no-padding-right" for="frontcode_ddl">前档* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="frontcode_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="frontcodeerr"></span></span>
                    </div>
                    <div class="space-4"></div>

                     <div class="form-group" id="divtfrontProductcode">
                        <label class="col-sm-3 control-label no-padding-right" for="frontcode_ddl">前档卷轴号* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="frontProductCode" runat="server" CssClass="form-control"></asp:DropDownList>
                         
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="frontProductcodeerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group" id="divIsQuanCar">
                        <label class="col-sm-3 control-label no-padding-right" for="frontcode_ddl"> 贴类型</label>
                        <div class="col-sm-2">
                             <input type="radio" value="1" name="IsQuanCar"/>全车
                             <input type="radio" value="2" name="IsQuanCar"/>单车
                             <input type="radio" value="3" name="IsQuanCar"/>单车含侧挡
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="IsQuanCarerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divtbackcode">
                        <label class="col-sm-3 control-label no-padding-right" for="backcode_ddl">侧/后档* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="backcode_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="backcodeerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group" id="divtbackProductcode">
                        <label class="col-sm-3 control-label no-padding-right" for="backcode_ddl">侧/后档卷轴号* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="backProductCode" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="backProductcodeerr"></span></span>
                    </div>
                    <div class="space-4"></div>

                    <div class="form-group" id="divname">
                        <label class="col-sm-3 control-label no-padding-right" for="name_txt">姓名* </label>
                        <div class="col-sm-9">
                            <input type="text" id="name_txt" placeholder="姓名" class="col-xs-10 col-sm-5" maxlength="50">

                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span> </span>
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
                    <div class="form-group"  id="divLicense">
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
                     <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="price_txt">备注 </label>
                        <div class="col-sm-9">
                            <input type="text" id="remark_txt" placeholder="备注" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                        </div>
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
    <script type="text/javascript" src="../assets/js/uploadify/jquery.uploadify.min.js"></script>
    <script src="../js/useradd.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuuser").addClass("active open");
            $("#menuuseradd").addClass("active");
            $('#ContentPlaceHolder1_brand_ddl').chosen({ allow_single_deselect: true });
        });
    </script>

</asp:Content>

