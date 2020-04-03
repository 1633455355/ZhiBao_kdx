<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="member_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>

        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon  active"></i>
                首页
            </li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>信息汇总</h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
        
            <asp:Panel ID="promopl" runat="server">
                <div class="col-sm-6">
            	    <div class="page-header">
                        <h1>
                            促销
                            <small>
                                <i class="icon-double-angle-right"></i>
                                列表
                            </small>
                        </h1>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="table-responsive">
                                <table  class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <%=promohead %>
                                    </thead>

                                    <tbody>
                                        <%=promobody %>
                                    </tbody>
                                </table>
                            </div><!-- /.table-responsive -->
                        </div><!-- /span -->
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="newspl" runat="server">
                <div class="col-sm-6">
            	    <div class="page-header">
                        <h1>
                            资讯
                            <small>
                                <i class="icon-double-angle-right"></i>
                                列表
                            </small>
                        </h1>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="table-responsive">
                                <table  class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr><th>日期</th><th>标题</th></tr>
                                    </thead>

                                    <tbody>
                                        <%=newsbody %>
                                    </tbody>
                                </table>
                            </div><!-- /.table-responsive -->
                        </div><!-- /span -->
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="feedbackpl" runat="server">
                <div class="col-sm-6">
            	    <div class="page-header">
                        <h1>
                            反馈
                            <small>
                                <i class="icon-double-angle-right"></i>
                                列表
                            </small>
                        </h1>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="table-responsive">
                                <table id="" class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr><th>日期</th><th>标题</th></tr>
                                    </thead>

                                    <tbody>
                                        <%=fbbody %>
                                    </tbody>
                                </table>
                            </div><!-- /.table-responsive -->
                        </div><!-- /span -->
                    </div>
                </div>
            </asp:Panel>
        </div>

        <!-- /.row -->
    </div>


 
</asp:Content>

