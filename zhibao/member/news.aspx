<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="member_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs" id="breadcrumbs"> 
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
    </script>
        <ul class="breadcrumb">
            <li> <i class="icon-home home-icon"></i> <a href="home.aspx">首页</a> </li>
            <li class="active">新闻管理</li>
        </ul>
        <!-- .breadcrumb --> 
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>新闻详细</h1>
        </div>
        <div class="row">
        	<div class="col-xs-12"> 
                <h3 class="blue"><asp:Label ID="title_txt" runat="server" Text=""></asp:Label></h3>
                <p class="text-muted"><asp:Label ID="date_txt" runat="server" Text=""></asp:Label></p>
                <div class="well well-lg">
                    <asp:Label ID="content_txt" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
       <script type="text/javascript">
           $(document).ready(function () {
               $("#meunnews").addClass("active open");
           });
    </script>
</asp:Content>

