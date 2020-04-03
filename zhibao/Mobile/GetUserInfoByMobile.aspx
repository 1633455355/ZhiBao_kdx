<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetUserInfoByMobile.aspx.cs" Inherits="Mobile_GetUserInfoByMobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width,initial-scale=1.0">
 <meta http-equiv="Expires" CONTENT="0"> 
<meta http-equiv="Cache-Control" CONTENT="no-cache"> 
<meta http-equiv="Pragma" CONTENT="no-cache"> 

    <title></title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <%=style%>
    <script src='../js/jquery-1.7.1.min.js'></script>

     <script>
         function getUrlParam(name) {
             var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
             var r = window.location.search.substr(1).match(reg);//匹配目标参数
             if (r != null) return r[2]; return null; //返回参数值
         }
         function validData() {
             var moblie = $("#mobile").val().trim();
             var car = $("#car").val().trim();
             if (moblie == '' && car == '') {
                 alert("搜索条件不能全部为空");
                 return false;
             }
             $("#form1").submit();
         }
         $(document).ready(function () {
             var s = getUrlParam('s');
             if (s!= null && s != '')
             {
                 $("#s0").removeClass("crr");
                 if(s==0)
                 {
                     $("#s0").addClass("crr");
                 }
                 else if(s==1)
                 {
                     $("#s1").addClass("crr");
                 }
                 else if(s==2)
                 {
                     $("#s2").addClass("crr");
                 }
             }
             
         });
    </script>
</head>
<body>
    <form id="form1" action="GetUserList.aspx">
     <div class="re_page page3" >
	<h1>电子质保查询</h1>
    <p class="txt">输入您的手机号码或车牌号码，查询在此的消费记录。</p>
    <ul>
    	<li class="txt1"><label>手机号码：</label><input type="text"  name="mobile" id="mobile"/></li>
        <li class="txt2"><label>车牌号码：</label><input type="text" name="car" id="car" /></li>
        <li class="btn"><input type="button" value="搜索"  onclick="validData()" /></li>
        <%=type %>
        <%=s %>
    </ul>
    <div class="sm">
    	<i></i>
    	<h3>说明</h3>
        <p>凡是消费过的用户，输入您的手机号码或车牌号码，<br>就能查询到相关消费记录。</p>
    </div>
    </div>
      
    </form>
   
     <%=nav %>
</body>
  
</html>
