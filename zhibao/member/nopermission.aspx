<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="nopermission.aspx.cs" Inherits="member_nopermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="breadcrumbs" id="breadcrumbs"> 
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
    </script>
        <ul class="breadcrumb">
            <li> <i class="icon-home home-icon"></i> <a href="home.aspx">首页</a> </li>
            <li class="active">其它页面</li>
        </ul>
        <!-- .breadcrumb --> 
    </div>

    <div class="page-content">
        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->

                <div class="error-container">
                    <div class="well">
                        <h1 class="grey lighter smaller">
                            <span class="blue bigger-125">
                                <i class="icon-random"></i>
                                非常抱歉
                            </span>
                            您没有权限浏览此页面
                        </h1>

                        <hr>


                        <div class="space"></div>

                        <div>
                            <h4 class="lighter smaller">如果您有任何问题，您可以:</h4>

                            <ul class="list-unstyled spaced inline bigger-110 margin-15">
                                <li>
                                    <i class="icon-hand-right blue"></i>
                                    联络管理员
                                </li>

                            </ul>
                        </div>

                        <hr>
                        <div class="space"></div>

                        <div class="center">
                            <a class="btn btn-grey" href="home.aspx">
                                <i class="icon-arrow-left"></i>
                                返回首页
                            </a>
                        </div>
                    </div>
                </div>

                <!-- PAGE CONTENT ENDS -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.page-content -->
</asp:Content>

