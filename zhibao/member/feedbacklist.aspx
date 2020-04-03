<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="feedbacklist.aspx.cs" Inherits="member_feedbacklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
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
            <li class="active">反馈管理</li>
        </ul>
        <!-- .breadcrumb --> 
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>反馈列表</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>操作</th>
                                <th>日期</th>
                                <th>标题</th>
                                <th>联系人</th>
                                <th>手机</th>
                                <th>EMAIL</th>
                                <th>内容</th>
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
    <asp:HiddenField ID="deletepermission" runat="server" />
    <script src="../js/jquery.pagination.js"></script>
    <script src="../js/feedbacklist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menufeedback").addClass("active open");
            $("#menufeedbacklist").addClass("active");
        });
    </script>
</asp:Content>

