<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html lang="zh-cn">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- basic styles -->

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <!-- fonts -->

    <!--<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />-->

    <!-- ace styles -->

    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
</head>
<body class="login-layout">
    <form id="form1" runat="server">
        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                            <!--    <h1>
                                    <i class="icon-leaf green"></i>
                                    <span class="red">质量</span>
                                    <span class="white">认证系统</span>
                                </h1>
                                <h4 class="blue" style="display:block">&copy;
                                    <asp:Label ID="companyname_lb" runat="server" Text=""></asp:Label></h4>-->
                                 <br /><br /><br /><br /><br />
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="login-box" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header blue lighter bigger">
                                                <i class="icon-coffee green"></i>
                                                请登录
                                            </h4>

                                            <div class="space-6"></div>
                                            <fieldset>
                                                <asp:Panel ID="usernamediv" runat="server" class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="username_txt" runat="server" placeholder="用户名" class="form-control" MaxLength="50"></asp:TextBox>
                                                        <i class="icon-user"></i>
                                                    </span>
                                                    <div class="help-block col-xs-12 col-sm-reset inline">
                                                        <asp:Label ID="username_err" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="pwddiv" runat="server" class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="pwd_txt" runat="server" TextMode="Password" class="form-control" MaxLength="50" placeholder="密码"></asp:TextBox>
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                    <div class="help-block col-xs-12 col-sm-reset inline">
                                                        <asp:Label ID="pwd_err" runat="server" Text=""></asp:Label></div>

                                                </asp:Panel>
                                                <div class="space"></div>

                                                <div class="clearfix">
                                                    <label class="inline">
                                                        <asp:CheckBox ID="remember_cb" runat="server" class="ace" />
                                                        <span class="lbl">记住我</span>
                                                    </label>
                                                    <asp:Button ID="login_btn" OnClientClick="return Login();" runat="server" Text="登陆" class="width-35 pull-right btn btn-sm btn-primary" OnClick="login_btn_Click"></asp:Button>
                                                </div>
                                                <div class="space-4"></div>
                                            </fieldset>
                                        </div>
                                        <!-- /widget-main -->

                                        <div class="toolbar clearfix" style="display: none">
                                            <div>
                                                <a href="#" onclick="show_box('forgot-box'); return false;" class="forgot-password-link">
                                                    <i class="icon-arrow-left"></i>
                                                    忘记密码
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /widget-body -->
                                </div>
                                <!-- /login-box -->
                                <!-- /forgot-box -->
                                <!-- /signup-box -->
                            </div>
                            <!-- /position-relative -->
                        </div>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
        </div>
        <!-- /.main-container -->

        <!-- basic scripts -->

        <!--[if !IE]> -->

        <!--<script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>-->
        <script src="assets/js/jquery-2.0.3.min.js"></script>

        <!-- <![endif]-->

        <!--[if IE]>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<![endif]-->

        <!--[if !IE]> -->

        <script type="text/javascript">
            window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
        </script>

        <!-- <![endif]-->

        <!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
</script>
<![endif]-->

        <script type="text/javascript">
            if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
        </script>

        <!-- inline scripts related to this page -->

        <script type="text/javascript">
            function show_box(id) {
                jQuery('.widget-box.visible').removeClass('visible');
                jQuery('#' + id).addClass('visible');
            }
        </script>
        <script src="js/common.js"></script>
        <script src="js/login.js"></script>
    </form>
</body>
</html>
