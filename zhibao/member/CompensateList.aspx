<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompensateList.aspx.cs" Inherits="member_CompensateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home icon-home"></i><a href="home.aspx">首页</a> </li>
            <li class="active">理赔管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>理赔单列表</h1>
        </div>
         <div class="row" style="height: 80px;">
            <asp:Panel ID="Compensate_pl" runat="server" >
            <div class="col-xs-2" >
                <label for="name_txt">工厂内部型号</label>
                <asp:DropDownList ID="typeone_ddl" runat="server" class="form-control" ></asp:DropDownList>
                </div>
             <div class="col-xs-2">
                <label for="name_txt">品牌型号(工厂默认)</label>
               <asp:TextBox ID="typetwo_ddl" runat="server"  class="form-control"  disabled></asp:TextBox>
            </div>

            <div class="col-xs-1">
                <label for="name_txt">产品编码</label>
                <asp:TextBox ID="code_txt" runat="server" class="form-control"></asp:TextBox>
            </div>
            </asp:Panel>
             <div class="col-xs-1">
                <label for="name_txt">处理状态</label>
                <asp:DropDownList ID="status" runat="server" class="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="0">未处理</asp:ListItem>
                    <asp:ListItem Value="1">正在处理</asp:ListItem>
                    <asp:ListItem Value="2">需要补充资料</asp:ListItem>
                    <asp:ListItem Value="3">已经补充资料</asp:ListItem>
                    <asp:ListItem Value="4">已经处理完成</asp:ListItem>
                </asp:DropDownList>
                 </div>
               <div class="col-xs-1">
                <label for="form-field-select-1"></label>
                   <br />
                <button class="btn btn-sm btn-info" type="button" onclick="CompensateSearch()">
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

    <script src="../js/CompensateList.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menucompensate").addClass("active open");
            $("#compensateList").addClass("active");
             $('#ContentPlaceHolder1_typeone_ddl').chosen({ allow_single_deselect: true });
        });
    </script>
</asp:Content>

