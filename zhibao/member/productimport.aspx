<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productimport.aspx.cs" Inherits="member_productimport" %>

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
            <h1>模板下载/编码导入</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">

                     <asp:Literal  runat="server" ID="error"></asp:Literal>

                     <asp:Literal  runat="server" ID="rigth"></asp:Literal>
                   
                    <div class="form-group" id="divtypeone">
                        <label class="col-sm-3 control-label no-padding-right" for="province_ddl">模板下载 </label>
                        <div class="col-sm-2">
                           <a class="btn btn-sm btn-danger" href="/Template/Template.xlsx">
                                <i class="icon-download bigger-110"></i>
                                <span class="bigger-110 no-text-shadow">点击下载</span>
                            </a>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="typeoneerr"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divtypeone">
                        <label class="col-sm-3 control-label no-padding-right" for="province_ddl">导入数据 </label>
                        <div class="col-sm-3">
                           <input type="file" style="margin-top:3px;"  name="importfile" id="importfile"/>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"><span class="middle" id="typeoneerr"></span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button"  onclick="ValidSubmit();"><i class="icon-ok bigger-110"></i>确定 </button>
                          
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>
    <script src="../js/productimport.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuproduct").addClass("active open");
            $("#productimport").addClass("active");
			


        });
    </script>

</asp:Content>

