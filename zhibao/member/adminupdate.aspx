<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminupdate.aspx.cs" Inherits="member_adminupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <h1>更新用户信息</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="form-group" id="divstatus">
                        <label class="col-sm-3 control-label no-padding-right" for="status_txt">状态 </label>
                        <label class="col-sm-9">
                            <asp:Label ID="status_txt" runat="server" Text="正常登录"></asp:Label><asp:Button ID="status_btn" runat="server" Text="解禁" class="btn btn-yellow btn-info middle" OnClick="status_btn_Click" />
                        </label>
                    </div>

                    <div class="form-group" id="divusername">
                        <label class="col-sm-3 control-label no-padding-right" for="username_txt">用户名* </label>
                        <label class="col-sm-9">
                            <asp:Label ID="username_txt" runat="server" Text="Label"></asp:Label>
                        </label>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divpwd">
                        <label class="col-sm-3 control-label no-padding-right" for="pwd_txt" style="margin-top:10px;">密码* </label>
                        <label class="col-sm-6"><button class="btn btn-yellow btn-info middle" type="button" onclick="PwdReset()"><i class="icon-ok bigger-110"></i>密码重置 </button> <span class="middle text-danger" id="pwderr">密码会被重置成 111111</span></label>
                        
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divrelastion">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2">用户类型* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="relastion_ddl" runat="server" class="form-control">
                                <asp:ListItem Value="admin">管理员</asp:ListItem>
                                <asp:ListItem Value="dealer">经销商</asp:ListItem>
                                <asp:ListItem Value="store">门店</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="relastionerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divrole">
                        <label class="col-sm-3 control-label no-padding-right" for="role_ddl">角色* </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="role_ddl" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="roleerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                    <asp:Panel ID="moreinfo" runat="server">
                        <div class="form-group" id="divname">
                            <label class="col-sm-3 control-label no-padding-right" for="name_txt">名称* </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="name_txt" runat="server" placeholder="名称" class="col-xs-10 col-sm-5" MaxLength="50"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divcontact">
                            <label class="col-sm-3 control-label no-padding-right" for="contact_txt">联系人 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="contact_txt" runat="server" placeholder="联系人" class="col-xs-10 col-sm-5" MaxLength="50"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="contacterr"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="position_txt">职位 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="position_txt" runat="server" placeholder="职位" class="col-xs-10 col-sm-5" MaxLength="50"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="phone_txt">电话 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="phone_txt" runat="server" placeholder="电话" class="col-xs-10 col-sm-5" MaxLength="50"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divmobile">
                            <label class="col-sm-3 control-label no-padding-right" for="mobile_txt">手机 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="mobile_txt" runat="server" placeholder="手机" class="col-xs-10 col-sm-5" MaxLength="11"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="mobilerr"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="fax_txt">传真 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="fax_txt" runat="server" placeholder="传真" class="col-xs-10 col-sm-5" MaxLength="50"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="province_ddl">省 </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="province_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span></span>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-2">市 </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="city_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle"></span></span>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="address_txt">地址 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="address_txt" runat="server" placeholder="地址" class="col-xs-10 col-sm-5" MaxLength="90"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divzip">
                            <label class="col-sm-3 control-label no-padding-right" for="zip_txt">邮编 </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="zip_txt" runat="server" placeholder="邮编" class="col-xs-10 col-sm-5" MaxLength="6"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="ziperr"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="form-group" id="divemail">
                            <label class="col-sm-3 control-label no-padding-right" for="email_txt">EMAIL </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="email_txt" runat="server" placeholder="EMAIL" class="col-xs-10 col-sm-5" MaxLength="50"></asp:TextBox>
                                <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="emailerr"></span></span>
                            </div>
                        </div>
                        <div class="space-4"></div>


                    </asp:Panel>
                    <asp:Panel ID="morestorefinfo" runat="server">
                        <div class="space-4"></div>
                        <div class="form-group" id="divdealer">
                            <label class="col-sm-3 control-label no-padding-right" for="dealer_ddl">经销商* </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="dealer_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="dealererr"></span></span>
                        </div>
                    </asp:Panel>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="AdminUpdate()"><i class="icon-ok bigger-110"></i>确定 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>
    <script src="../js/jquery.query.js"></script>
    <script src="../js/adminupdate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuadmin").addClass("active open");
             $('#ContentPlaceHolder1_dealer_ddl').chosen({ allow_single_deselect: true });
        });
    </script>
</asp:Content>

