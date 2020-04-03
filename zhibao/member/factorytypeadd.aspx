<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="factorytypeadd.aspx.cs" Inherits="member_factorytypeadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">工厂产品内部型号管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>新增工厂内部型号</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divname">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">工厂内部型号 </label>
                        <div class="col-sm-9">
                            <input type="text" placeholder="工厂内部型号" class="col-xs-10 col-sm-5" id="name_txt" maxlength="50" />
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                      <div class="form-group" id="divnamep">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">品牌型号（默认） </label>
                        <div class="col-sm-9">
                            <input type="text" placeholder="品牌型号（默认）" class="col-xs-10 col-sm-5" id="namep_txt" maxlength="50" />
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nampeerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                </div>
            </div>
        </div>
        
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <button class="btn btn-info" type="button" onclick="FactoryTypeAdd()"><i class="icon-ok bigger-110"></i>新增 </button>
                &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="button" onclick="Reset()"><i class="icon-undo bigger-110"></i>重置 </button>
            </div>
        </div>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menufactorytype").addClass("active open");
            $("#menufactorytypeadd").addClass("active");
        });

        function Reset() {
            $("#divname").removeClass("has-error");
            $("#nameerr").html("");
            $("#name_txt").val('');

            $("#divnamep").removeClass("has-error");
            $("#nameperr").html("");
            $("#namep_txt").val('');
        }

        function FactoryTypeAdd() {
            var flag = true;
            var name = $("#name_txt").val().Trim();
            if (name == "") {
                flag = false;
                $("#divname").addClass("has-error");
                $("#nameerr").html("请输入工厂内部型号");
                return;
            }
            var namep = $("#namep_txt").val().Trim();
            if (namep == "") {
                flag = false;
                $("#divnamep").addClass("has-error");
                $("#nameperr").html("请输入品牌型号（默认）");
            }

            if (flag) {
                var params = { Action: "FactoryTypeAdd", Name: encodeURIComponent(name), Namep: encodeURIComponent(namep) };

                $.ajax({
                    type: "POST",
                    url: "../interface/Factory.ashx",
                    cache: false,
                    dataType: "json",
                    data: jQuery.param(params, true),
                    success: function (msg) {
                        if (msg.errorcode == "0") {
                            alert('添加成功！');
                            Reset();
                        }
                        else if (msg.errorcode == "-10") {
                            alert('无权限');
                        }
                        else if (msg.errorcode == "-2") {
                            $("#divname").addClass("has-error");
                            $("#nameerr").html("工厂产品类型重复，请更换");
                        }
                        else {
                            $("#divname").addClass("has-error");
                            $("#nameerr").html("系统错误");
                        }
                    }
                });
            }
        }
    </script>
</asp:Content>
