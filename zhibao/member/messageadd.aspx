<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="messageadd.aspx.cs" Inherits="member_messageadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">信息管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>写站内信</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divtitle">
                        <label class="col-sm-2 control-label no-padding-right" for="title_txt">标题* </label>
                        <div class="col-sm-4">
                            <input type="text" placeholder="请输入标题" class="col-sm-12" id="title_txt" />
                        </div>
                        <span class="help-inline col-sm-4"><span class="middle" id="titleerr"></span></span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group" id="divtitle2">
                        <label class="col-sm-2 control-label no-padding-right" for="title_txt">收件人 </label>
                        <div class="col-sm-4">
                            <select class="form-control" id="form-field-select-1">
                                <option value="all">全部账户</option>
                                <option value="dealer">全部经销商</option>
                                <option value="store">全部门店</option>
                                <option value="self">自己筛选</option>
                            </select>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    
                    <div id="dealer_store_div">


                    

                    <div class="form-group" id="dealerdiv">
                        <label class="col-sm-2 control-label no-padding-right" for="title_txt">经销商筛选 </label>
                        <div class="col-sm-3">
                            <div class="space-2"></div>
                            <asp:DropDownList ID="dealer_ddl" runat="server" data-placeholder="请选择经销商"  class="width-80 chosen-select" multiple="" style="display: none;"></asp:DropDownList>
                            
                        </div>
                    </div>

                    <div class="form-group" id="storediv">
                        <label class="col-sm-2 control-label no-padding-right" for="title_txt">门店筛选 </label>
                        <div class="col-sm-3">
                            <div class="space-2"></div>
                            <asp:DropDownList ID="store_ddl" runat="server" data-placeholder="请选择门店"  class="width-80 chosen-select" multiple="" style="display: none;"></asp:DropDownList>
                        </div>
                    </div>

                    </div>

                    <div class="form-group" id="divcontent">
                        <label class="col-sm-2 control-label no-padding-right" for="title_txt">内容* </label>
                        <div class="col-sm-4">
                            <textarea class="form-control" id="content_txt" placeholder="请输入内容"></textarea>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="contenterr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="MessageAdd()"><i class="icon-ok bigger-110"></i>确定 </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="button" onclick="Reset()"><i class="icon-undo bigger-110"></i>重置 </button>
                        </div>
                    </div>
                </div>
                <!-- /.table-responsive -->
            </div>
            <!-- /span -->
        </div>
    </div>
    <link href="../assets/css/chosen.css" rel="stylesheet" />
    <script src="../js/messageadd.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menumessage").addClass("active open");
            $("#menumessageadd").addClass("active");
        });
    </script>
</asp:Content>

