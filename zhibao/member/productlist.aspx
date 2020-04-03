<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productlist.aspx.cs" Inherits="member_productlist" %>

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
            <li class="active">产品编码管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>产品编码</h1>
        </div>
        <div class="row" style="height: 80px;">
            <div class="col-xs-1">
                <label for="username_txt">一级类别</label>
                <asp:DropDownList ID="typeone_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-1">
                <label for="relastion_ddl">品牌型号</label>
                <asp:DropDownList ID="typetwo_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-1">
                <label for="role_ddl">状态</label>
                <asp:DropDownList ID="status_ddl" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
            <asp:Panel ID="dealer_pl" runat="server" class="col-xs-2">
                <label for="role_ddl">经销商</label>
                <asp:DropDownList ID="dealer_ddl" runat="server" class="form-control">
                </asp:DropDownList>
            </asp:Panel>
            <asp:Panel ID="store_pl" runat="server" class="col-xs-2">
                <label for="role_ddl">门店</label>
                <asp:DropDownList ID="store_ddl" runat="server" class="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
            <div class="col-xs-1">
                <label for="name_txt">产品编码</label>
                <asp:TextBox ID="code_txt" runat="server" class="form-control"></asp:TextBox>
            </div>
             <div class="col-xs-1" id="ADealer">
                <label for="role_ddl">经销商审核状态</label>
                <asp:DropDownList ID="Aud_Dealer" runat="server" class="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="0">等待审核</asp:ListItem>
                     <asp:ListItem Value="1">认证审核通过</asp:ListItem>
                    <asp:ListItem Value="2">认证审核未通过</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-xs-1" id="AStore">
                <label for="role_ddl">门店审核状态</label>
                <asp:DropDownList ID="Aud_Store" runat="server" class="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="0">等待审核</asp:ListItem>
                     <asp:ListItem Value="1">认证审核通过</asp:ListItem>
                    <asp:ListItem Value="2">认证审核未通过</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-1">
                <label for="form-field-select-1">　</label>
                <br />
                <button class="btn btn-sm btn-info" type="button" onclick="SearchProduct()">
                    <i class="icon-search bigger-110"></i>
                    搜索
                </button>
            </div>
            
              <asp:Panel ID="import_button" class="col-xs-1"  runat="server">
                <label for="form-field-select-1"></label>
                <br />
                <button class="btn btn-sm btn-info" type="button" onclick="ImportProduct()" >
                    <i class="icon-search bigger-110"></i>
                    导出
                </button>
              </asp:Panel>
            
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead id="tbheader">
                            <tr>
                                <th>操作</th>
                                <th>一级类别</th>
                                <th>二级类别</th>
                                <th>状态</th>
                                <th>产品编码</th>
                                <th>尺寸(M)</th>
                                <th>经销商名称</th>
                                <th>经销商认证时间</th>
                                <th>门店名称</th>
                                <th>门店认证时间</th>
                                <th>质保年限</th>
                               <th>经销商是否审核通过</th>
                                <th>经销商审核操作</th>
                                <th>门店是否审核通过</th>
                                <th>门店审核操作</th>
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
    <asp:HiddenField ID="updatepermission" runat="server" />
    <asp:HiddenField ID="userstatus" runat="server" />
    <script src="../js/jquery.pagination.js"></script>
    <script src="../js/productlist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuproduct").addClass("active open");
            $("#menuproductlist").addClass("active");
            $('#ContentPlaceHolder1_dealer_ddl').chosen({ allow_single_deselect: true });
            <%=js%>
        });
    </script>
</asp:Content>

