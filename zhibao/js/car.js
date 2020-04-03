
$(document).ready(function () {

    GetBrandFromUs();

    $('#ContentPlaceHolder1_brand_ddl').bind('change', function () {
        GetSysytemFromUs();
    });

    $('#ContentPlaceHolder1_system_ddl').bind('change', function () {
        GetTypeFromUs();
    });
});

function GetBrandFromUs()
{
    $('<option value=""></option>').appendTo('#ContentPlaceHolder1_brand_ddl');
    var params = { Action: "GetBrandFromUs" };
    $.ajax({
        type: "POST",
        url: "../interface/Car.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data.length > 0) {
                    for (var i = 0; i < msg.data.length; i++) {
                        var li = msg.data[i].newsid;
                        $('<option value="' + msg.data[i].CarBrandCode + '">' + msg.data[i].CarBrandName + '</option>').appendTo('#ContentPlaceHolder1_brand_ddl');
                    }
                }
            }
            else {
                alert('异常，请重新获取');
            }
            GetTypeFromUs();
        }
    });
}
function GetSysytemFromUs()
{
    $("#ContentPlaceHolder1_system_ddl").empty();
    if ($("#ContentPlaceHolder1_brand_ddl").val() != "")
    {
        var params = { Action: "GetSysytemFromUs", ID: $("#ContentPlaceHolder1_brand_ddl").val() };
        $.ajax({
            type: "POST",
            url: "../interface/Car.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {

                if (msg.errorcode == "0") {
                    if (msg.data != null && msg.data.length > 0) {
                        for (var i = 0; i < msg.data.length; i++) {
                            var li = msg.data[i].newsid;
                            $('<option value="' + msg.data[i].CarSystemCode + '">' + msg.data[i].CarSystemName + '</option>').appendTo('#ContentPlaceHolder1_system_ddl');
                        }
                    }
                }
                else {
                    alert('异常，请重新获取');
                }
                GetTypeFromUs();
            }
        });
    }
}
function GetTypeFromUs() {
    $("#ContentPlaceHolder1_type_ddl").empty();
    if ($("#ContentPlaceHolder1_system_ddl").val() != "") {
        var params = { Action: "GetTypeFromUs", ID: $("#ContentPlaceHolder1_system_ddl").val() };
        $.ajax({
            type: "POST",
            url: "../interface/Car.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {

                if (msg.errorcode == "0") {
                    if (msg.data != null && msg.data.length > 0) {
                        for (var i = 0; i < msg.data.length; i++) {
                            var li = msg.data[i].newsid;
                            $('<option value="' + msg.data[i].CarTypeCode + '">' + msg.data[i].CarTypeName + '</option>').appendTo('#ContentPlaceHolder1_type_ddl');
                        }
                    }
                }
                else {
                    alert('异常，请重新获取');
                }
            }
        });
    }
}
function GetBrandFromAotohome()
{
    $("#brand_btn").addClass("disabled");

    var params = { Action: "GetBrandFromAotohome"};
    $.ajax({
        type: "POST",
        url: "../interface/Car.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            $("#brand_btn").removeClass("disabled");
            if (msg.errorcode == "0") {
                alert('成功');
            }
            else if(msg.errorcode == "-10")
            {
                alert('无权限');
            }
            else {
                alert('异常，请重新获取');
            }
        }
    });
}

function GetCarSystemFromAotohome() {
    $("#system_btn").addClass("disabled");
    var params = { Action: "GetCarSystemFromAotohome" };
    $.ajax({
        type: "POST",
        url: "../interface/Car.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            $("#system_btn").removeClass("disabled");
            if (msg.errorcode == "0") {
                alert('成功');
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
            else {
                alert('异常，请重新获取');
            }
        }
    });
}

function GetCarTypeFromAotohome() {
    $("#type_btn").addClass('disabled');
    var params = { Action: "GetCarTypeFromAotohome" };
    $.ajax({
        type: "POST",
        url: "../interface/Car.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            $("#type_btn").removeClass('disabled');
            if (msg.errorcode == "0") {
                alert('成功');
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
            else {
                alert('异常，请重新获取');
            }
        }
    });
}