<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="producttypeupdate.aspx.cs" Inherits="member_producttypeupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">品牌产品类型管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>更新品牌产品类型</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divtypeon">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">一级类别 </label>
                        <label class="col-sm-2">
                            <asp:Label ID="typeone_lb" runat="server" Text=""></asp:Label>
                        </label>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="typeoneerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                </div>

                <div class="form-horizontal">
                    <div class="form-group" id="divtypefac">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">工厂类型 </label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="typefac_ddl" runat="server"  CssClass="form-control"></asp:DropDownList>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="typefacerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                </div>

                <div class="form-horizontal">
                    <div class="form-group" id="divname">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt"><%=Config.CompanyName %>类型</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="name_txt" runat="server" placeholder="<%=Config.CompanyName %>类型" class="col-xs-10 col-sm-5" maxlength="50"></asp:TextBox>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                </div>
                

            </div>
        </div>

        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <button class="btn btn-info" type="button" onclick="ProductTypeUpdate()"><i class="icon-ok bigger-110"></i>更新 </button>
            </div>
        </div>

    </div>
    <script src="../js/jquery.query.js"></script>
    <script src="../js/producttypeupdate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuproducttype").addClass("active open");
            $('#ContentPlaceHolder1_typefac_ddl').chosen({ allow_single_deselect: true });
        });
    </script>
</asp:Content>

