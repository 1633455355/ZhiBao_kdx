<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="F_productlist.aspx.cs" Inherits="F_productlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">工厂产品类别管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>编码(卷轴号)列表</h1>
        </div>
        <div class="row" style="height: 80px;">
            <div class="col-xs-3">
                <label for="username_txt">厂家内部型号</label>
                <asp:DropDownList ID="typeone_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-1">
                <label for="relastion_ddl">品牌默认型号</label>
                <asp:TextBox ID="typetwo_ddl" runat="server"  placeholder="品牌默认型号" class="form-control"  ></asp:TextBox>
            </div>
           
          
            <div class="col-xs-1">
                <label for="name_txt">产品编码</label>
                <asp:TextBox ID="code_txt" runat="server" class="form-control"></asp:TextBox>
            </div>
               <div class="col-xs-2" id="ADealer">
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
                                <th>经销商名称</th>
                                <th>经销商认证时间</th>
                                <th>门店名称</th>
                                <th>门店认证时间</th>
                                <th>备注</th>
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
    <script src="../js/F_productlist.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menufactorytype").addClass("active open");
            $("#F_productlist").addClass("active");
             $('#ContentPlaceHolder1_typeone_ddl').chosen({ allow_single_deselect: true });
        });
    </script>

</asp:Content>

