<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userupdate.aspx.cs" Inherits="member_userupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet" href="../assets/css/bootstrap.min.css" />

    <link rel="stylesheet" href="../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../assets/css/chosen.css" />
    <link rel="stylesheet" href="../assets/css/datepicker.css" />
    <link rel="stylesheet" href="../assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="../assets/css/daterangepicker.css" />
    <link rel="stylesheet" href="../assets/css/colorpicker.css" />
    <link rel="stylesheet" href="../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../assets/css/ace-skins.min.css" />
    
    <div class="breadcrumbs" id="breadcrumbs"> 
        <script type="text/javascript">
        try{ace.settings.check('breadcrumbs' , 'fixed')}catch(e){}
    </script>
        <ul class="breadcrumb">
            <li> <i class="icon-home home-icon"></i> <a href="home.aspx">首页</a> </li>
            <li class="active">车主管理</li>
        </ul>
        <!-- .breadcrumb --> 
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>车主更新</h1>
        </div>
        <div class="row">
            <div class="col-xs-12"> 
                <!-- PAGE CONTENT BEGINS -->
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 姓名 </label>
                        <div class="col-sm-9">
                            <input type="text" id="form-field-2" placeholder="Password" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle">Inline help text</span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 车型1 </label>
                        <div class="col-sm-2">
                            <select class="form-control" id="form-field-select-1">
                                <option value="">&nbsp;</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                            </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"> <span class="middle">Inline help text</span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 车型2 </label>
                        <div class="col-sm-2">
                            <select class="form-control" id="form-field-select-1">
                                <option value="">&nbsp;</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                            </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"> <span class="middle">Inline help text</span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 车型3 </label>
                        <div class="col-sm-2">
                            <select class="form-control" id="form-field-select-1">
                                <option value="">&nbsp;</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                            </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"> <span class="middle">Inline help text</span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 驾照 </label>
                        <div class="col-sm-9">
                            <input type="text" id="form-field-2" placeholder="Password" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle">Inline help text</span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 省 </label>
                        <div class="col-sm-2">
                            <select class="form-control" id="form-field-select-1">
                                <option value="">&nbsp;</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                            </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"> <span class="middle">Inline help text</span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 市 </label>
                        <div class="col-sm-2">
                            <select class="form-control" id="form-field-select-1">
                                <option value="">&nbsp;</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                            </select>
                        </div>
                        <span class="help-inline col-xs-12 col-sm-4"> <span class="middle">Inline help text</span> </span>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 价格 </label>
                        <div class="col-sm-9">
                            <input type="text" id="form-field-2" placeholder="Password" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle">Inline help text</span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 手机 </label>
                        <div class="col-sm-9">
                            <input type="text" id="form-field-2" placeholder="Password" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle">Inline help text</span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 邮箱 </label>
                        <div class="col-sm-9">
                            <input type="text" id="form-field-2" placeholder="Password" class="col-xs-10 col-sm-5">
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle">Inline help text</span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" > 商品码 </label>
                        <label class="col-sm-9 no-padding-right" > 商品码商品码商品码商品码商品码 </label>
                    </div>
                    <div class="space-4"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-2"> 商品类型 </label>
                        <div class="col-sm-9">
                            <label>
                                <input name="form-field-checkbox" type="checkbox" class="ace">
                                <span class="lbl"> 上 </span>
                            </label>
                            <label>
                                <input name="form-field-checkbox" type="checkbox" class="ace">
                                <span class="lbl"> 下 </span>
                            </label>
                            <label>
                                <input name="form-field-checkbox" type="checkbox" class="ace">
                                <span class="lbl"> 左 </span>
                            </label>
                            <label>
                                <input name="form-field-checkbox" type="checkbox" class="ace">
                                <span class="lbl"> 右 </span>
                            </label>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button"> <i class="icon-ok bigger-110"></i> Submit </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset"> <i class="icon-undo bigger-110"></i> Reset </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col --> 
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#menuuser").addClass("active open");
        });
    </script>

</asp:Content>

