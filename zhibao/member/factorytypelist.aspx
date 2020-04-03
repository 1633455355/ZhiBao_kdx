<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="factorytypelist.aspx.cs" Inherits="member_factorytypelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">工厂产品内部型号管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>工厂产品内部型号列表</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>操作</th>
                                <th>工厂产品内部型号</th>
                                 <th>品牌型号（默认）</th>
                            </tr>
                        </thead>
                        <tbody id="tbcon">
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

    <script type="text/javascript">
        $(document).ready(function () {
            $("#menufactorytype").addClass("active open");
            $("#menufactorytypelist").addClass("active");
        });

        $(document).ready(function () {
            GetFactoryTypeList();
        });

        function GetFactoryTypeList() {

            $("#tbcon").html('');

            var params = { Action: "GetFactoryTypeList" };

            $.ajax({
                type: "POST",
                url: "../interface/Factory.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    var total = 0;
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data != null && msg.data.length > 0) {
                            total = msg.total;
                            for (var i = 0; i < msg.data.length; i++) {
                                var li = '<tr><td><div class="btn-group"><a name="upproducttype" class="btn btn-xs btn-info" href="factorytypeupdate.aspx?id=' + msg.data[i].FactoryTypeId + '"><i class="icon-edit bigger-120"></i></a><a name="deleteproducttype" class="btn btn-xs btn-danger"  onclick="DeleteFactoryType(' + msg.data[i].FactoryTypeId + ')"><i class="icon-trash bigger-120"></i></a></div></td><td>' + msg.data[i].FactoryTypeName + '</td><td>' + msg.data[i].ProductSecondLevelNameDefalut + '</td></tr>';
                                $("#tbcon").append(li);
                            }
                        }

                        if (total == 0) {
                            var lino = '<tr><td colspan="2">暂时没有任何产品类型</td></tr>';
                            $("#tbcon").append(lino);
                        }

                    }
                    else if (msg.errorcode == "-10") {
                        alert('无权限');
                    }

                    if ($("#ContentPlaceHolder1_deletepermission").val() != "true") {
                        $('a[name="deleteproducttype"]').each(function () {
                            $(this).remove();
                        });
                    }
                    if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                        $('a[name="upproducttype"]').each(function () {
                            $(this).remove();
                        });
                    }
                }
            });
        };

        function DeleteFactoryType(id) {

            if (confirm("是否确认删除")) {
                var params = { Action: "DeleteFactoryType", ID: id };

                $.ajax({
                    type: "POST",
                    url: "../interface/Factory.ashx",
                    cache: false,
                    dataType: "json",
                    data: jQuery.param(params, true),
                    success: function (msg) {
                        var total = 0;
                        if (msg.errorcode == "0") {
                            alert('删除成功！');
                            $("#tbcon").html('');
                            GetFactoryTypeList();
                        }
                        else if (msg.errorcode == "-5") {
                            alert('已被使用，不能删除');
                        }
                        else if (msg.errorcode == "-10") {
                            alert('无权限');
                        }
                    }
                });
            }
        }
    </script>
</asp:Content>

