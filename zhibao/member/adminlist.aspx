<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminlist.aspx.cs" Inherits="member_adminlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="../assets/css/font-awesome.min.css" />
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
            <li class="active">用户管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>用户列表</h1>
        </div>
        <div class="row" style="height: 80px;">
            <div class="col-xs-2">
                <label for="username_txt">用户名</label>
                <asp:TextBox ID="username_txt" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-xs-2">
                <label for="relastion_ddl">用户类型</label>
                <asp:DropDownList ID="relastion_ddl" runat="server" class="form-control">
                    <asp:ListItem Value="admin">管理员</asp:ListItem>
                    <asp:ListItem Value="dealer">经销商</asp:ListItem>
                    <asp:ListItem Value="store">门店</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-2">
                <label for="role_ddl">角色</label>
                <asp:DropDownList ID="role_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-2" id="dealerdiv" style="display:none">
                <label for="name_txt">名称</label>
                <asp:TextBox ID="name_txt" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-xs-2" id="storediv" style="display:none">
                <label for="role_ddl">所属经销商</label>
                <asp:DropDownList ID="dealer_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-2">
                <label for="form-field-select-1">　</label>
                <br />
                <button class="btn btn-sm btn-info" type="button" onclick="SearchAdmin()">
                    <i class="icon-search bigger-110"></i>
                    搜索
                </button>
            </div>
            <div class="col-xs-2">
             <label for="form-field-select-1"></label>
               <br />
                <button class="btn btn-sm btn-info" type="button" onclick="ImportAdmin()" >
                    <i class="icon-search bigger-110"></i>
                    导出
                </button>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead id="tbheader">
                            <tr>
                                <th>操作</th>
                                <th>用户名</th>
                                <th>用户类型</th>
                                <th>角色</th>
                                <th>状态</th>
                                <th>名称</th>
                                <th>联系人</th>
                                <th>职位</th>
                                <th>电话</th>
                                <th>传真</th>
                                <th>省</th>
                                <th>市</th>
                                <th>地址</th>
                                <th>邮编</th>
                                <th>邮箱</th>
                                <th>所属经销商</th>
                            </tr>
                        </thead>
                        <tbody id="tbcon">
                        </tbody>
                    </table>
                    <div id="Pagination">
                    </div>
                </div>
                <!-- /.table-responsive -->
            </div>
            <!-- /span -->
        </div>
    </div>
    <script src="../js/jquery.pagination.js"></script>
    <script src="../js/adminlist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuadmin").addClass("active open");
            $("#menuadminlist").addClass("active");
            $("#ContentPlaceHolder1_dealer_ddl").chosen({ allow_single_deselect: true, width: "100%" });
        });
    </script>
</asp:Content>

