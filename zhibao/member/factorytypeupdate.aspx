<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="factorytypeupdate.aspx.cs" Inherits="factorytypeupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">工厂产品类型管理</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>更新工厂产品类型</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divname">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">工厂产品类型 </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="name_txt" runat="server" placeholder="工厂产品类型" class="col-xs-10 col-sm-5" maxlength="50"></asp:TextBox>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nameerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                      <div class="form-group" id="divnamep">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt">品牌型号（默认） </label>
                        <div class="col-sm-9">
                             <asp:TextBox ID="namep_txt" runat="server" placeholder="品牌型号（默认）" class="col-xs-10 col-sm-5" maxlength="50"></asp:TextBox>
                            <span class="help-inline col-xs-12 col-sm-7"><span class="middle" id="nampeerr"></span></span>
                        </div>
                    </div>
                    <div class="space-4"></div>
                </div>
            </div>
        </div>

        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <button class="btn btn-info" type="button" onclick="FactoryTypeUpdate()"><i class="icon-ok bigger-110"></i>更新 </button>
            </div>
        </div>

    </div>
    <script src="../js/jquery.query.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menufactorytype").addClass("active open");
        });

        function Reset() {
            $("#divname").removeClass("has-error");
            $("#nameerr").html("");
            $("#ContentPlaceHolder1_name_txt").val('');

            $("#divnamep").removeClass("has-error");
            $("#nameperr").html("");
            $("#ContentPlaceHolder1_namep_txt").val('');
        }

        function FactoryTypeUpdate() {
            var flag = true;
            var name = $("#ContentPlaceHolder1_name_txt").val().Trim();
            if (name == "") {
                flag = false;
                $("#divname").addClass("has-error");
                $("#nameerr").html("请输入工厂内部型号");
            }
            var namep = $("#ContentPlaceHolder1_namep_txt").val().Trim();
            if (namep == "") {
                flag = false;
                $("#divnamep").addClass("has-error");
                $("#nameperr").html("请输入品牌型号（默认）");
            }
            var id = $.query.get('id');

            if (flag) {
                var params = { Action: "FactoryTypeUpdate", Name: encodeURIComponent(name), Namep: encodeURIComponent(namep), ID: id };

                $.ajax({
                    type: "POST",
                    url: "../interface/Factory.ashx",
                    cache: false,
                    dataType: "json",
                    data: jQuery.param(params, true),
                    success: function (msg) {
                        if (msg.errorcode == "0") {
                            alert('更新成功！');
                            location.href = 'factorytypelist.aspx';
                        }
                        else if (msg.errorcode == "-10") {
                            alert('无权限');
                        }
                        else if (msg.errorcode == "-5") {
                            $("#divname").addClass("has-error");
                            $("#nameerr").html("产品已被使用，不能更新");
                        }
                        else if (msg.errorcode == "-2") {
                            $("#divname").addClass("has-error");
                            $("#nameerr").html("产品型号已经存在，请更换");
                        }
                    }
                });
            }
        }
    </script>
</asp:Content>

