<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetStoreUserList.aspx.cs" Inherits="Mobile_GetStoreUserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,initial-scale=1.0">
<meta http-equiv="Expires" CONTENT="0"> 
<meta http-equiv="Cache-Control" CONTENT="no-cache"> 
<meta http-equiv="Pragma" CONTENT="no-cache"> 

    <title></title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
   <link href="../images/mobiscroll.css" rel="stylesheet" type="text/css" />
    <link href="../images/mobiscroll_002.css" rel="stylesheet" type="text/css" />
   <link href="../images/mobiscroll_003.css" rel="stylesheet" type="text/css" />
      <%=style%>
    <script src='../js/jquery-1.7.1.min.js'></script>
    <script src="../js/mobiscroll_001.js" type="text/javascript"></script>
    <script src="../js/mobiscroll_002.js" type="text/javascript"></script>
    <script src="../js/mobiscroll_003.js" type="text/javascript"></script>
    <script src="../js/mobiscroll_004.js" type="text/javascript"></script>
    <script src="../js/mobiscroll_005.js" type="text/javascript"></script>
    <script>
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);//匹配目标参数
            if (r != null) return r[2]; return null; //返回参数值
        }
        function Seach()
        {
            var start = $("#start").val();
            var end = $("#end").val();
            if(start=="")
            {
                alert("请输入开始时间");
                return false;
            }
            if(end=="")
            {
                alert("请输入结束时间");
                return false;
            }
            $(".resultBox").html('');
            $("#count").html('');
            var params = { Action: "MobileSearchUser", start: start, end: end };

            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    var total = 0;
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            $("#count").html("搜索到" + msg.total + "条记录");
                            for (var i = 0; i < msg.data.length; i++) {
                                var li = '<ul class=\"cf\">';
                                li = li + '<li class=\"txt2\">贴膜类型:' + msg.data[i].F_ProductTypeName + '-----' + msg.data[i].S_ProductTypeName + '</li>';
                                li = li + '<li class=\"txt2\">卷轴号:' + msg.data[i].ProductCode + '</li>';
                                li = li + '<li class=\"txt1\">姓名:' + msg.data[i].UserName + '</li>';
                                li = li + '<li class=\"txt1\">手机:' + msg.data[i].Mobile + '</li>';
                                li = li + '<li class=\"txt2\">邮箱:' + msg.data[i].Email + '</li>';
                                li = li + '<li class=\"txt1\">车品牌:' + msg.data[i].CarBrandCodeName + '</li>';
                                li = li + '<li class=\"txt1\">车系:' + msg.data[i].CarSysteName + '</li>';
                                if (msg.data[i].CarTypeName != null) {
                                    li = li + '<li class=\"txt2\">车型:' + msg.data[i].CarTypeName + '</li>';
                                }
                                else {
                                    li = li + '<li class=\"txt2\">车型:</li>';
                                }


                                //   li = li + '<li class=\"txt2\">技师:' + msg.data[i].MechanicName + '</li>';
                                li = li + '<li class=\"txt2\">车牌号:' + msg.data[i].Lincence + '</li>';
                                if (msg.data[i].ProvinceName != null) {
                                    li = li + '<li class=\"txt1\">省:' + msg.data[i].ProvinceName + '</li>';
                                }
                                else {
                                    li = li + '<li class=\"txt1\">省:</li>';
                                }
                                if (msg.data[i].CityName != null) {
                                    li = li + '<li class=\"txt1\">市:' + msg.data[i].CityName + '</li>';
                                }
                                else {
                                    li = li + '<li class=\"txt1\">市:</li>';
                                }
                                li = li + '<li class=\"txt2\">价格:' + msg.data[i].Price + '</li>';
                                li = li + '</ul>';
                                $(".resultBox").append(li);
                            }
                        }
                        else
                        {
                            $("#count").html("没有搜索到记录");
                        }
                    }

                    else if (msg.errorcode == "-10") {
                        alert('无权限');
                        location.href = "MobileLogin.aspx?type=app";
                    }
                }
            });
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

          //  $("#start").datepicker();
            var currYear = (new Date()).getFullYear();
            var opt = {};
            opt.date = { preset: 'date' };
            //opt.datetime = { preset : 'datetime', minDate: new Date(2012,3,10,9,22), maxDate: new Date(2014,7,30,15,44), stepMinute: 5  };
            opt.datetime = { preset: 'datetime' };
            opt.time = { preset: 'time' };
            opt.default = {
                theme: 'android-ics light', //皮肤样式
                display: 'modal', //显示方式 
                mode: 'scroller', //日期选择模式
                lang: 'zh',
                startYear: 1950, //开始年份currYear - 10
                endYear: currYear + 10,//结束年份
                width: 76,
                height: 38
            };

            $("#start").val('').scroller('destroy').scroller($.extend(opt['date'], opt['default']));
            $("#end").val('').scroller('destroy').scroller($.extend(opt['date'], opt['default']));


        });
</script>

</head>
<body>
    <form id="form1" runat="server">
   <div class="re_page pageSearch">
	<h1>填写信息</h1>
    <div class="searchBox">
    	<label>从</label><input type="text" class="txt1" id="start" value="2014-01-08"  readonly="true"/><label>到</label><input type="text" class="txt1" value="2015-01-08"    id="end" readonly="true"/>
        <input type="button" class="btn" value="搜索" onclick="Seach()" />
        <p id="count"></p>
    </div>
    <div class="resultBox">
    	
       
    </div>
</div>
        </form>
      <%=nav %>
</body>
</html>
