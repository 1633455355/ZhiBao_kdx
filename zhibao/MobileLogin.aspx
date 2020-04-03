<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobileLogin.aspx.cs" Inherits="MobileLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width,initial-scale=1.0">
 <meta http-equiv="Expires" CONTENT="0"> 
<meta http-equiv="Cache-Control" CONTENT="no-cache"> 
<meta http-equiv="Pragma" CONTENT="no-cache"> 

<title></title>
<link rel="stylesheet" type="text/css" href="images/style.css" />
 <%=style%>
   
 <script src='assets/js/jquery-2.0.3.min.js'></script>
 <script src="js/login.js"></script>
 <!--<script src="js/viewport.js"></script>-->  
</head>
<body>
    <form id="form1" runat="server">
        <div class="re_page page1">
	
	<h1>请输入质保系统维护店面用户账号</h1>
    <ul>
    	<li class="txt1"> <asp:TextBox ID="username_txt" runat="server" placeholder="用户名" class="form-control" MaxLength="50"></asp:TextBox></li>
        <li class="txt2"><asp:TextBox ID="pwd_txt" runat="server" TextMode="Password" class="form-control" MaxLength="50" placeholder="密码"></asp:TextBox></li>
        <li class="txt3">  
            <asp:CheckBox ID="remember_cb" runat="server" />
            <span class="lbl">记住我</span>

        </li>
        <li class="btn"> <asp:Button ID="login_btn" OnClientClick="return Login();" runat="server" Text="登陆"  OnClick="login_btn_Click"></asp:Button></li>
    </ul>
  <!--  <div class="sm">
    	<i></i>
    	<h3>说明</h3>
        <p>北极光质保系统维护店面用户账户<br>请向您保养爱车的门店工作人员索取</p>
    </div>-->
      </div>
    </form>
    <script type="text/javascript">
       /* if (navigator.userAgent.indexOf("iPhone") > 0) {
            document.write("<style>body{zoom:0.5;}</style>");
        }
        else {
            document.write("<style>body{zoom:1;}</style>");
        }*/

    </script>

</body>

</html>
