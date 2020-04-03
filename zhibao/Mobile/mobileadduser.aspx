<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mobileadduser.aspx.cs" Inherits="member_mobileadduser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width,initial-scale=1.0">
 <meta http-equiv="Expires" CONTENT="0"> 
<meta http-equiv="Cache-Control" CONTENT="no-cache"> 
<meta http-equiv="Pragma" CONTENT="no-cache"> 

<title></title>
<link rel="stylesheet" type="text/css" href="../images/style.css" />
     <%=style%>
<script src='../js/jquery-1.7.1.min.js'></script>
<!--<script src="../js/viewport.js"></script>-->
<script src="../js/jquery.form.js"></script>
<script src="../js/mobileuseradd.js"></script>
<script>
    function getUrlParam(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);//匹配目标参数
        if (r != null) return r[2]; return null; //返回参数值
    }
    $(document).ready(function () {
        var s = getUrlParam('s');
        if (s != null && s != '') {
            $("#s0").removeClass("crr");
            if (s == 0) {
                $("#s0").addClass("crr");
            }
            else if (s == 1) {
                $("#s1").addClass("crr");
            }
            else if (s == 2) {
                $("#s2").addClass("crr");
            }
        }

    });
</script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
      <div class="re_page page2">
	   <h1>填写信息</h1>
    <ul>
    	<li><label>前档（<span>*</span>）：</label><asp:DropDownList ID="frontcode_ddl" runat="server" CssClass="txt2" ></asp:DropDownList></li>
        <li><label>卷轴号（<span>*</span>）：</label><asp:DropDownList ID="frontProductcode_ddl" runat="server" CssClass="txt2" ></asp:DropDownList></li>
        <li><label>侧/后档（<span>*</span>）：</label><asp:DropDownList ID="backcode_ddl" runat="server" CssClass="txt2"></asp:DropDownList></li>
        <li><label>卷轴号<span>*</span>）：</label><asp:DropDownList ID="backProductcode_ddl" runat="server" CssClass="txt2"></asp:DropDownList></li>
        <li><label>姓名（<span>*</span>）：</label><input type="text" id="name_txt" placeholder="姓名" class="txt1" maxlength="50" name="name_txt" /></li>
        <li><label>手机号码（<span>*</span>）：</label><input type="text" id="mobile_txt" placeholder="手机" class="txt1" maxlength="11" name="mobile_txt" /></li>
        <li><label>邮箱：</label><input type="text" id="email_txt" placeholder="邮箱" class="txt1" name="email_txt" /></li>
        <li><label>品牌（<span>*</span>）：</label><asp:DropDownList ID="brand_ddl" runat="server"  CssClass="txt2"></asp:DropDownList></li>
        <li><label>车系：</label><asp:DropDownList ID="system_ddl" runat="server"  CssClass="txt2"><asp:ListItem Value=""></asp:ListItem></asp:DropDownList></li>
        <li><label>车型：</label><asp:DropDownList ID="type_ddl" runat="server"  CssClass="txt2"><asp:ListItem Value=""></asp:ListItem></asp:DropDownList></li>
        <li><label>技师：</label><asp:DropDownList ID="js_ddl" runat="server"  CssClass="txt2"><asp:ListItem Value=""></asp:ListItem></asp:DropDownList></li>
        <li><label>车牌号：</label><input type="text" id="license_txt" placeholder="车牌号" class="txt2" maxlength="50" name="license_txt"/></li>
        <li><label>省：</label><asp:DropDownList ID="province_ddl" runat="server" CssClass="txt2"></asp:DropDownList></li>
        <li><label>市：</label><asp:DropDownList ID="city_ddl" runat="server" CssClass="txt2"><asp:ListItem Value=""></asp:ListItem></asp:DropDownList></li>
        <li><label>价格：</label><input type="text" id="price_txt" placeholder="价格" class="txt1" onkeyup="validatePices(this);" onblur="validatePices(this);" name="price_txt"/></li>
        <li>
            <div id="fileHtml">
            <div><label>上传图片：</label><input class="txt3" type="file"name="ImageList"/><a href="#" class="img"  onclick="AddInputFile()"></a></div>
             </div>
        </li>
        <li><input class="btn" type="button" value="提交信息"  onclick="MobileUserAdd()"></li>
        <li><button class="fh" type="reset"  onclick="reset()">重置 </button></li>
    </ul>
</div>

    </form>
   <%=nav %>
    </body>
</html>