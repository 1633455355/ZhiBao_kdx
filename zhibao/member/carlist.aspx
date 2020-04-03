<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="carlist.aspx.cs" Inherits="member_carlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">车型信息</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>车型信息管理</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-1 control-label no-padding-right" for="form-field-2">品牌信息： </label>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="brand_ddl" runat="server" CssClass=" col-sm-9"></asp:DropDownList>
                            <button class="btn btn-info  btn-xs" type="button" onclick="GetBrandFromAotohome()" id="brand_btn"><i class="icon-plus bigger-110"></i>获取 </button>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 control-label no-padding-right" for="form-field-2">车系信息： </label>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="system_ddl" runat="server" CssClass="col-sm-9"></asp:DropDownList>
                            <button class="btn btn-info  btn-xs" type="button" onclick="GetCarSystemFromAotohome()" id="system_btn"><i class="icon-plus bigger-110"></i>获取 </button>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 control-label no-padding-right" for="form-field-2">车型信息： </label>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="type_ddl" runat="server" CssClass=" col-sm-9"></asp:DropDownList>
                            <button class="btn btn-info  btn-xs" type="button" onclick="GetCarTypeFromAotohome()" id="type_btn"><i class="icon-plus bigger-110"></i>获取 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /span -->
        </div>
    </div>
    <script src="../js/car.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menucar").addClass("active");
        });
    </script>
</asp:Content>

