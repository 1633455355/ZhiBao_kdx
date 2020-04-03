<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="member_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../assets/css/datepicker.css" rel="stylesheet" />
    <link href="../assets/css/daterangepicker.css" rel="stylesheet" />
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home icon-home"></i><a href="home.aspx">首页</a> </li>
            <li class="active">报表</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>报表</h1>
        </div>
        <div class="row" style="height: 80px;">
            <div class="col-xs-1">
                <label for="username_txt">一级类别</label>
                <asp:DropDownList ID="typeone_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-1">
                <label for="relastion_ddl">品牌型号</label>
                <asp:DropDownList ID="typetwo_ddl" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <asp:Panel ID="dealer_pl" runat="server" class="col-xs-2">
                <label for="role_ddl">经销商</label>
                <asp:DropDownList ID="dealer_ddl" runat="server" class="form-control">
                </asp:DropDownList>
            </asp:Panel>
            <asp:Panel ID="store_pl" runat="server" class="col-xs-2">
                <label for="role_ddl">门店</label>
                <asp:DropDownList ID="store_ddl" runat="server" class="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
            <div class="col-xs-1">
                <label for="username_txt">开始日期</label>
                <div class="input-group"> <span class="input-group-addon"> <i class="icon-calendar bigger-110"></i> </span>
                    <input type="text" data-date-format="yyyy-mm-dd" id="start_dt" class="form-control date-picker">
                </div>
            </div>
            
            <div class="col-xs-1" id="storediv">
                <label for="role_ddl">结束日期</label>
                <div class="input-group"> <span class="input-group-addon"> <i class="icon-calendar bigger-110"></i> </span>
                    <input type="text" data-date-format="yyyy-mm-dd" id="end_dt" class="form-control date-picker">
                </div>
            </div>
            <div class="col-xs-1">
                <label for="form-field-select-1">　</label>
                <br />
                <button class="btn btn-sm btn-info" type="button" onclick="GetReport()">
                    <i class="icon-search bigger-110"></i>
                    搜索
                </button>
            </div>
              <asp:Panel ID="import_button" class="col-xs-1"  runat="server">
                <label for="form-field-select-1"></label>
                <br />
                <button class="btn btn-sm btn-info" type="button" onclick="ExportReport()" >
                    <i class="icon-search bigger-110"></i>
                    导出
                </button>
              </asp:Panel>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead id="tbheader">
                            <tr>
                                <%=tbheader %>
                            </tr>
                        </thead>
                        <tbody id="tbcon">
                        </tbody>
                    </table>
                </div>
                <!-- /.table-responsive -->
            </div>
            <!-- /span -->
        </div>
    </div>
    <div style="width:100%;height:100%;position:fixed;top:0;left:0;background:rgb(0,0,0);opacity:0.5;z-index:9999; display:none" id="diplayId">
        <img style="position: relative;top: 50%;left: 50%;margin-top: -100px;margin-left: -100px;width:10%" src="../Images/Loading.gif" /></div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#menureport").addClass("active");
             $('#ContentPlaceHolder1_dealer_ddl').chosen({ allow_single_deselect: true });
            <%=js%>
            $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });
        });
    </script>
    <script src="../js/report.js"></script>

    
</asp:Content>

