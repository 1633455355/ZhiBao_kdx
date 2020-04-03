<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="storelist.aspx.cs" Inherits="member_storelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <h1>所属门店列表</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead id="tbheader">
                            <tr>
                                <th>名称</th>
                                <th>联系人</th>
                                <th>职位</th>
                                <th>电话</th>
                                <th>手机</th>
                                <th>传真</th>
                                <th>省</th>
                                <th>市</th>
                                <th>地址</th>
                                <th>邮编</th>
                                <th>邮箱</th>
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
    <script src="../js/storelist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuadmin").addClass("active open");
            $("#menustorelist").addClass("active");
        });
    </script>
</asp:Content>

