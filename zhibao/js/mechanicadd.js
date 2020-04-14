
function validateInt(o) {
    var pice = o.value.replace(/^[1-9][0-9]{0,2}|[0-9]$/, '');
    if (pice.length > 0) {
        o.value = o.value.substring(0, o.value.length - 1);
        validateInt(o);
    }
}

// 只能真金钱格式
function validatePices(o) {
    var pice = o.value.replace(/^([1-9][0-9]{0,5}|[0-9])((\.[0-9]{0,2}){0,1})$/, '');
    if (pice.length > 0) {
        o.value = o.value.substring(0, o.value.length - 1);
        validatePices(o);
    }
}
function MechanicAdd() {
    $("#divname").removeClass('has-error');
    $("#nameerr").html('');
    $("#divIntroduction").removeClass('has-error');
    $("#Introductionerr").html('');

    $("#divmobile").removeClass('has-error');
    $("#mobileerr").html('');
    $("#divemail").removeClass("has-error");
    $("#emailerr").html("");

    $("#diveAddress").removeClass("has-error");
    $("#Addresserr").html("");
  
    var name = $("#name_txt").val().Trim();
    var intro = $("#Introduction_txt").val().Trim();
    var mobile = $("#mobile_txt").val().Trim();
    var email = $("#email_txt").val().Trim();
    var address = $("#Address_txt").val().Trim();
    var type = $("#ContentPlaceHolder1_Type").val();
 
    var flag = true;
    if (name == "") {
        flag = false;
        $("#divname").addClass('has-error');
        $("#nameerr").html('请输入姓名');
    }
  
    if (mobile == "") {
        flag = false;
        $("#divmobile").addClass('has-error');
        $("#mobileerr").html('请输入手机号码');
    }
    else {
        var regPartton = /1[3-9]+\d{9}/;
        if (!regPartton.test(mobile)) {
            $("#divmobile").addClass("has-error");
            $("#mobileerr").html("手机号码格式不正确");
            flag = false;
        }
    }

    if (email != "") {
        var pattern = /^(?:[a-zA-Z0-9]+[_\-\+\.]?)*[a-zA-Z0-9]+@(?:([a-zA-Z0-9]+[_\-]?)*[a-zA-Z0-9]+\.)+([a-zA-Z]{2,})+$/;
        if (!pattern.exec(email)) {
            $("#divemail").addClass("has-error");
            $("#emailerr").html("请输入正确格式的邮箱地址");
            flag = false;
        }
    }
    var id = getUrlParam('id');
    if (flag) {
        var params;
        if (id != null && id != '')
        {
            params = { Action: "Set", Id: encodeURIComponent(id), Name: encodeURIComponent(name), Intro: encodeURIComponent(intro), Mobile: encodeURIComponent(mobile), Email: encodeURIComponent(email), Address: encodeURIComponent(address), Type: encodeURIComponent(type) };
        }
        else
        {
            params = { Action: "Add", Name: encodeURIComponent(name), Intro: encodeURIComponent(intro), Mobile: encodeURIComponent(mobile), Email: encodeURIComponent(email), Address: encodeURIComponent(address), Type: encodeURIComponent(type) };
        }
     
        $.ajax({
            type: "POST",
            url: "../interface/mechanic.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    //Reset();
                    location.href = "mechanicadd.aspx";
                }
                else if (msg.errorcode == "-1") {
                    alert('缺失必要的参数');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);//匹配目标参数
    if (r != null) return r[2]; return null; //返回参数值
}
function GetMechanicInfo(id)
{
    var params = { Action: "Get", Id: id};
    $.ajax({
        type: "POST",
        url: "../interface/mechanic.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                $("#name_txt").val(msg.data.Name);
                $("#Introduction_txt").val(msg.data.Introduction)
                $("#mobile_txt").val(msg.data.Mobile);
                $("#email_txt").val(msg.data.Email);
                $("#Address_txt").val(msg.data.Address);
                $("#ContentPlaceHolder1_Type").val(msg.data.Type);
            }
            else if(msg.errorcode=="-1")
            {
                alert('缺失必要的参数');
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
                location.href = "mechaniclist.aspx";
            }
        }
    });
}

$(document).ready(function () {
    var id = getUrlParam('id');
    if (id != null && id != '')
    {
        GetMechanicInfo(id);
    }
   
});