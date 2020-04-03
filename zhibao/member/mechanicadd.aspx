<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mechanicadd.aspx.cs" Inherits="member_mechanicadd" %>

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
            <h1>新增技师</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">

                    <div class="form-group" id="divname">
                        <label class="col-sm-3 control-label no-padding-right" for="name_txt">姓名* </label>
                        <div class="col-sm-9">
                            <input type="text" id="name_txt" placeholder="姓名" class="col-xs-10 col-sm-5" maxlength="50">

                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                     <div class="form-group" id="divIntroduction">
                        <label class="col-sm-3 control-label no-padding-right" for="Introduction_txt">简介</label>
                        <div class="col-sm-9">
                            <textarea  id="Introduction_txt" class="col-xs-10 col-sm-5"></textarea>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="Introductionerr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divmobile">
                        <label class="col-sm-3 control-label no-padding-right" for="mobile_txt">手机*</label>
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
                    <div class="form-group"  id="diveAddress">
                        <label class="col-sm-3 control-label no-padding-right" for="Address_txt">地址 </label>
                        <div class="col-sm-9">
                            <input type="text" id="Address_txt" placeholder="地址" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="Addresserr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="province_ddl">技师类别 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="Type" runat="server" CssClass="form-control">
                                <asp:ListItem  Value="1">电工</asp:ListItem>
                                <asp:ListItem  Value="2">机修</asp:ListItem>
                                <asp:ListItem  Value="3">钣金</asp:ListItem>
                                <asp:ListItem  Value="4">涂装</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                    </div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="MechanicAdd()"><i class="icon-ok bigger-110"></i>确定 </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset"><i class="icon-undo bigger-110"></i>重置 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>

     <script src="../js/mechanicadd.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#menuuser").addClass("active open");
             $("#mechanicadd").addClass("active");
         });
    </script>
</asp:Content>

