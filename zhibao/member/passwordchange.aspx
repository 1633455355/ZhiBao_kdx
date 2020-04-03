<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="passwordchange.aspx.cs" Inherits="member_passwordchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">个人中心</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>修改密码</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="space-4"></div>
                    <div class="form-group" id="divoldpwd">
                        <label class="col-sm-3 control-label no-padding-right" for="old_pwd_txt">旧密码* </label>
                        <div class="col-sm-9">
                            <input type="password" id="old_pwd_txt" placeholder="密码" class="col-xs-10 col-sm-5" maxlength="50">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="oldpwderr"></span></span>
                        </div>
                    </div>
                    <div class="form-group" id="divnewpwd">
                        <label class="col-sm-3 control-label no-padding-right" for="new_pwd_txt">新密码* </label>
                        <div class="col-sm-9">
                            <input type="password" id="new_pwd_txt" placeholder="密码长度至少6位" class="col-xs-10 col-sm-5" maxlength="50">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="newpwderr"></span></span>
                        </div>
                    </div>
                    <div class="form-group" id="divconpwd">
                        <label class="col-sm-3 control-label no-padding-right" for="con_pwd_txt">确认新密码* </label>
                        <div class="col-sm-9">
                            <input type="password" id="con_pwd_txt" placeholder="密码长度至少6位" class="col-xs-10 col-sm-5" maxlength="50">
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="conpwderr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="PasswordChange()"><i class="icon-ok bigger-110"></i>确定 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>
    <script src="../js/passwordchange.js"></script>
</asp:Content>

