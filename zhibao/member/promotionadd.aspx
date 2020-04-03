<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="promotionadd.aspx.cs" Inherits="member_promotionadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">促销管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>新增促销</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="form-group" id="divtitle">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">标题 </label>
                        <div class="col-sm-9">
                            <input type="text" placeholder="请输入标题" class="col-xs-10 col-sm-5" id="title_txt" />
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="titleerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divdealer">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">请选择经销商 </label>
                        <div class="col-sm-6" >
                            <div id="dealerlist">


                            </div>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="dealererr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divcontent">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">内容 </label>
                        <div class="col-sm-6">
                            <script id="editor" type="text/plain" style="width: 100%; height: 300px;"></script>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="contenterr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="clearfix form-actions" >
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="PromotionAdd()"><i class="icon-ok bigger-110"></i>确定 </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset" onclick="Reset()"><i class="icon-undo bigger-110"></i>重置 </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
        </div>
    </div>

    <script src="../ueditor/ueditor.config.js"></script>
    <script src="../ueditor/ueditor.all.min.js"></script>
    <script src="../js/promotionadd.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menupromotion").addClass("active open");
            $("#menupromotionadd").addClass("active");
        });
    </script>
</asp:Content>

