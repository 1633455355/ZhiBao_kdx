<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productverify.aspx.cs" Inherits="member_productverify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
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
            <h1>产品编码认证</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divcode">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">产品卷轴号 </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="code_txt" runat="server"  class="col-xs-10 col-sm-5" maxlength="20"></asp:TextBox>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="codeerr"></span></span>
                    </div>
                    <div class="space-4"></div>


                    <div class="form-group" id="divtypeone">
                            <label class="col-sm-3 control-label no-padding-right" for="province_ddl">产品类别 </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="typeone_ddl" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="typeone_ddl_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="typeoneerr"></span> </span>
                        </div>
                   <div class="space-4"></div>


                    <div class="form-group" id="divtypetwo">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-2">品牌型号 </label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="typetwo_ddl" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <span class="help-inline col-xs-12 col-sm-4"><span class="middle"  id="typetwoerr"></span> </span>
                    </div>

                </div>
            </div>
        </div>

        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <button class="btn btn-info" type="button" onclick="ProductVerify()"><i class="icon-ok bigger-110"></i>认证 </button>
            </div>
        </div>

    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">

        <div class="page-content">
        <div class="page-header">
            <h1>产品编码清除</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divcode2">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">产品编码 </label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="code_ddl" runat="server" class="col-xs-10 col-sm-5"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="code2err"></span></span>
                    </div>
                    <div class="space-4"></div>
                    
                </div>
            </div>
        </div>

        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <button class="btn btn-info" type="button" onclick="ProductClear()"><i class="icon-ok bigger-110"></i>已使用完 </button>
            </div>
        </div>

    </div>
    </asp:Panel>
    
    <script src="../js/jquery.query.js"></script>
    <script src="../js/productverify.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuproduct").addClass("active open");
            $("#menuproductverify").addClass("active");
            $('#ContentPlaceHolder1_typetwo_ddl').chosen({ allow_single_deselect: true });
        });
    </script>
</asp:Content>

