<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rolelist.aspx.cs" Inherits="member_rolelist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        try{ace.settings.check('breadcrumbs' , 'fixed')}catch(e){}
    </script>
        <ul class="breadcrumb">
            <li> <i class="icon-home home-icon"></i> <a href="home.aspx">首页</a> </li>
            <li class="active">角色管理</li>
        </ul>
        <!-- .breadcrumb --> 
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>角色列表</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>操作</th>
                                <th>名称</th>
                                <th>用户管理</th>
                                <th>资讯</th>
                                <th>反馈</th>
                                <th>促销</th>
                                <th>消息</th>
                                <th>产品代码</th>
                                <th>角色</th>
                                <th>车型</th>
                                <th>报表</th>
                                <th>车主管理</th>
                                <th>渠道产品类型</th>
                                <th>产品认证</th>
                                <th>工厂产品类型</th>
                                <th>理赔管理</th>
                            </tr>
                        </thead>
                        <tbody id="tbcon">
                            <tr>
                                <td><a href="#">编辑</a></td>
                                <td>名称名称名称</td>
                                <td><div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                                  <td>
                                	<div class="btn-group">
                                        <span class="btn btn-xs btn-success">
                                            <i class="icon-plus bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-info">
                                            <i class="icon-edit bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-danger">
                                            <i class="icon-trash bigger-120"></i>
                                        </span>
                                        <span class="btn btn-xs btn-warning">
                                            <i class="icon-list bigger-120"></i>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <!-- /.table-responsive --> 
            </div>
            <!-- /span --> 
        </div>
    </div>
    <asp:HiddenField ID="deletepermission" runat="server" />
    <asp:HiddenField ID="updatepermission" runat="server" />
    <script src="../js/rolelist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menurole").addClass("active open");
            $("#menurolelist").addClass("active");
        });
    </script>
</asp:Content>
