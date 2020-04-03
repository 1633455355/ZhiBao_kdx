<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="feedbackadd.aspx.cs" Inherits="member_feedbackadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    
<div class="breadcrumbs" id="breadcrumbs"> 
    <script type="text/javascript">
    try{ace.settings.check('breadcrumbs' , 'fixed')}catch(e){}
    </script>
    <ul class="breadcrumb">
        <li> <i class="icon-home home-icon"></i> <a href="home.aspx">首页</a> </li>
        <li class="active">反馈管理</li>
    </ul>
    <!-- .breadcrumb --> 
</div>
<div class="page-content">
    <div class="page-header">
            <h1>提交反馈</h1>
    </div>
    <div class="row">
        <div class="col-xs-12"> 
            <!-- PAGE CONTENT BEGINS -->
            <div class="form-horizontal">
                <div class="form-group" id="divtitle">
                    <label class="col-sm-3 control-label no-padding-right" for="title_txt"> 标题* </label>
                    <div class="col-sm-9">
                        <input type="text" placeholder="标题" class="col-xs-10 col-sm-5" id="title_txt" />
                        <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="titleerr"></span> </span> </div>
                </div>
                <div class="space-4"></div>

                <asp:Panel class="form-group" id="divdealer" runat="server">
                    <label class="col-sm-3 control-label no-padding-right" for="dealer_cb"> 反馈给经销商 </label>
                    <div class="col-sm-9">
                        <input type="checkbox" class="col-xs-10 col-sm-1" id="dealer_cb" />
                        <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="dealererr"></span> </span> </div>

                </asp:Panel>
                <div class="space-4"></div>


                <div class="form-group" id="divcontact">
                    <label class="col-sm-3 control-label no-padding-right" for="contact_txt"> 联系人 </label>
                    <div class="col-sm-9">
                        <input type="text" placeholder="联系人" class="col-xs-10 col-sm-5" id="contact_txt" />
                        <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="contacterr"></span> </span> </div>
                </div>
                <div class="space-4"></div>

                <div class="form-group" id="divmobile">
                    <label class="col-sm-3 control-label no-padding-right" for="mobile_txt"> 手机 </label>
                    <div class="col-sm-9">
                        <input type="text" placeholder="手机" class="col-xs-10 col-sm-5" id="mobile_txt" />
                        <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="mobileerr"></span> </span> </div>
                </div>
                <div class="space-4"></div>

                <div class="form-group" id="divemail">
                    <label class="col-sm-3 control-label no-padding-right" for="email_txt"> EMAIL </label>
                    <div class="col-sm-9">
                        <input type="text" placeholder="EMAIL" class="col-xs-10 col-sm-5" id="email_txt" />
                        <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="emailerr"></span> </span> </div>
                </div>
                <div class="space-4"></div>


                <div class="form-group" id="divcontent">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 内容* </label>
                    <div class="col-sm-6">
                        <script id="editor" type="text/plain" style="width: 100%; height: 300px;"></script>
                        <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="contenterr"></span> </span> </div>
                    </div>
                </div>
                <div class="space-4"></div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <button class="btn btn-info" type="button" onclick="FeeedbackAdd()"> <i class="icon-ok bigger-110"></i> 确定 </button>
                        &nbsp; &nbsp; &nbsp;
                        <button class="btn" type="reset"> <i class="icon-undo bigger-110"></i> 重置 </button>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col --> 
    </div>
    

    <script src="../ueditor/ueditor.config.js"></script>
    <script src="../ueditor/ueditor.all.min.js"></script>    
    <script src="../js/feedbackadd.js"></script>
	<script type="text/javascript">
		    $(document).ready(function () {
		        $("#menufeedback").addClass("active open");
		        $("#menufeedbackadd").addClass("active");
		    });
    </script>
		
</asp:Content>

