<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminadd.aspx.cs" Inherits="member_adminadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />

    <link rel="stylesheet" href="../assets/css/jquery-ui-1.10.3.custom.min.css" />
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
            <li class="active">用户管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>新增用户</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="form-group" id="divusername">
                        <label class="col-sm-3 control-label no-padding-right" for="username_txt">用户名* </label>
                        <div class="col-sm-9"> 
                            <input type="text" id="username_txt" placeholder="用户名" class="col-xs-10 col-sm-5"  maxlength="50">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="usernameerr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divpwd">
                        <label class="col-sm-3 control-label no-padding-right" for="pwd_txt">密码* </label>
                        <div class="col-sm-9">
                            <input type="password" id="pwd_txt" placeholder="密码" class="col-xs-10 col-sm-5" maxlength="50">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="pwderr"></span> </span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divrelastion">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">用户类型* </label>
                        <div class="col-sm-2">
                            <select class="form-control" id="relastion_ddl">
                                <option value="admin">管理员</option>
                                <option value="dealer">经销商</option>
                                <option value="store">门店</option>
                            </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="relastionerr"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divrole">
                        <label class="col-sm-3 control-label no-padding-right" for="role_ddl">角色* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="role_ddl" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="roleerr"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div id="moreinfo" style="display:none">
                        <div class="form-group" id="divname">
                            <label class="col-sm-3 control-label no-padding-right" for="name_txt">名称* </label>
                            <div class="col-sm-9">
                                <input type="text" id="name_txt" placeholder="名称" class="col-xs-10 col-sm-5" maxlength="50">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divcontact">
                            <label class="col-sm-3 control-label no-padding-right" for="contact_txt">联系人 </label>
                            <div class="col-sm-9">
                                <input type="text" id="contact_txt" placeholder="联系人" class="col-xs-10 col-sm-5" maxlength="50">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="contacterr"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="position_txt">职位 </label>
                            <div class="col-sm-9">
                                <input type="text" id="position_txt" placeholder="职位" class="col-xs-10 col-sm-5" maxlength="50">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="phone_txt">电话 </label>
                            <div class="col-sm-9">
                                <input type="text" id="phone_txt" placeholder="电话" class="col-xs-10 col-sm-5" maxlength="50">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divmobile">
                            <label class="col-sm-3 control-label no-padding-right" for="mobile_txt">手机 </label>
                            <div class="col-sm-9">
                                <input type="text" id="mobile_txt" placeholder="手机" class="col-xs-10 col-sm-5" maxlength="11">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="mobilerr"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="fax_txt">传真 </label>
                            <div class="col-sm-9">
                                <input type="text" id="fax_txt" placeholder="传真" class="col-xs-10 col-sm-5" maxlength="50">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="province_ddl">省 </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="province_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-2">市 </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="city_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span> </span>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="address_txt">地址 </label>
                            <div class="col-sm-9">
                                <input type="text" id="address_txt" placeholder="地址" class="col-xs-10 col-sm-5" maxlength="90">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divzip">
                            <label class="col-sm-3 control-label no-padding-right" for="zip_txt">邮编 </label>
                            <div class="col-sm-9">
                                <input type="text" id="zip_txt" placeholder="邮编" class="col-xs-10 col-sm-5" maxlength="6">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="ziperr"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divemail"  >
                            <label class="col-sm-3 control-label no-padding-right" for="email_txt">EMAIL </label>
                            <div class="col-sm-9">
                                <input type="text" id="email_txt" placeholder="EMAIL" class="col-xs-10 col-sm-5" maxlength="50">
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="emailerr"></span> </span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                    </div>
                    <div id="morestorefinfo" style="display:none">
                        <div class="space-4"></div>
                        <div class="form-group" id="divdealer">
                            <label class="col-sm-3 control-label no-padding-right" for="dealer_ddl">经销商* </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="dealer_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="dealererr"></span> </span>
                        </div>
                    </div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="AdminAdd()"><i class="icon-ok bigger-110"></i>确定 </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset" onclick="Reset()"><i class="icon-undo bigger-110"></i>重置 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>
    <script src="../js/adminadd.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuadmin").addClass("active open");
            $("#menuadminadd").addClass("active");
           
        });
    </script>
</asp:Content>
