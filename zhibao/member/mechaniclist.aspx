<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mechaniclist.aspx.cs" Inherits="member_mechaniclist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" href="../assets/css/chosen.css" />
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
            <h1>技师列表</h1>
        </div>
        <div class="row" style="height: 80px;">
            <asp:Panel ID="dealer_pl" runat="server" class="col-xs-2">
                <label for="role_ddl">经销商</label>
                <asp:DropDownList ID="dealer_ddl" runat="server" class="form-control">
                </asp:DropDownList>
            </asp:Panel>
            <asp:Panel ID="store_pl" runat="server" class="col-xs-2">
                <label for="role_ddl">门店</label>
                <asp:DropDownList ID="store_ddl" runat="server" class="form-control">
                </asp:DropDownList>
            </asp:Panel>
            <div class="col-xs-1" style="display:none">
                <label for="name_txt">产品编码</label>
                <asp:TextBox ID="code_txt" runat="server" class="form-control"></asp:TextBox>
            </div>

            <div class="col-xs-1">
                <label for="form-field-select-1"></label>
                <br />
                <button class="btn btn-sm btn-info" type="button" onclick="SearchMechanic()">
                    <i class="icon-search bigger-110"></i>
                    搜索
                </button>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <%=tbheader %>
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
    <script src="../js/mechaniclist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuuser").addClass("active open");
            $("#mechaniclist").addClass("active");
            $('#ContentPlaceHolder1_dealer_ddl').chosen({ allow_single_deselect: true });
            <%=js%>
        });
    </script>
</asp:Content>

