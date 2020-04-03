$(document).ready(function () {

    $('#ContentPlaceHolder1_province_ddl').bind('change', function () {
        $('#ContentPlaceHolder1_city_ddl').empty();
        $("<option value=''></option>").appendTo("#ContentPlaceHolder1_city_ddl");
        if ($('#ContentPlaceHolder1_province_ddl').val() != "") {
            var params = { Action: "GetCityByProvince", ProvinceID: $('#ContentPlaceHolder1_province_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Admin.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            for (var i = 0; i < msg.data.length; i++) {
                                var li = msg.data[i].newsid;
                                $('<option value="' + msg.data[i].CityId + '">' + msg.data[i].CityName + '</option>').appendTo('#ContentPlaceHolder1_city_ddl');
                            }
                        }
                    }
                }
            });
        }
    });
});

function PwdReset()
{
    var id = $.query.get('id');
    
    var params = { Action: "PwdRet", ID: encodeURIComponent(id) };

    $.ajax({
        type: "POST",
        url: "../interface/Admin.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                alert('密码重置成功！');
            }
        }
    });
}

function AdminUpdate() {

    $("#divusername").removeClass("has-error");
    $("#usernameerr").html("");
    $("#divpwd").removeClass("has-error");
    $("#pwderr").html("");
    $("#divrole").removeClass("has-error");
    $("#roleerr").html("");
    $("#divname").removeClass("has-error");
    $("#nameerr").html("");
    $("#divmobile").removeClass("has-error");
    $("#mobilerr").html("");
    $("#divzip").removeClass("has-error");
    $("#ziperr").html("");
    $("#divemail").removeClass("has-error");
    $("#emailerr").html("");
    $("#divdealer").removeClass("has-error");
    $("#dealererr").html("");


    var flag = true;
    
    var relastion = $('#ContentPlaceHolder1_relastion_ddl').val();

    var role = $('#ContentPlaceHolder1_role_ddl').val();
    if (role == "" || role == undefined) {
        flag = false;
        $("#divrole").addClass("has-error");
        $("#roleerr").html("请选择角色");
    }
    var name = "";
    var contact ="";
    var position ="";
    var phone = "";
    var mobile ="";
    var fax ="";
    var province ="";
    var city ="";
    var address ="";
    var zip = "";
    var email ="";
    var dealer ="";

    if (relastion == "admin") {

    }
    else if (relastion == "dealer" || relastion == "store") {
        var name = $("#ContentPlaceHolder1_name_txt").val().Trim();
        var contact = $("#ContentPlaceHolder1_contact_txt").val().Trim();
        var position = $("#ContentPlaceHolder1_position_txt").val().Trim();
        var phone = $("#ContentPlaceHolder1_phone_txt").val().Trim();
        var mobile = $("#ContentPlaceHolder1_mobile_txt").val().Trim();
        var fax = $("#ContentPlaceHolder1_fax_txt").val();
        var province = $("#ContentPlaceHolder1_province_ddl").val();
        var city = $("#ContentPlaceHolder1_city_ddl").val();
        var address = $("#ContentPlaceHolder1_address_txt").val().Trim();
        var zip = $("#ContentPlaceHolder1_zip_txt").val().Trim();
        var email = $("#ContentPlaceHolder1_email_txt").val().Trim();
        var dealer = $("#ContentPlaceHolder1_dealer_ddl").val();
      
        if (name == "") {
            flag = false;
            $("#divname").addClass("has-error");
            $("#nameerr").html("请输入名称");
        }


        if (mobile != "") {
            var regPartton = /1[3-8]+\d{9}/;
            if (!regPartton.test(mobile)) {
                $("#divmobile").addClass("has-error");
                $("#mobilerr").html("手机号码格式不正确");
                flag = false;
            }
        }

        if (zip != "") {
            var re = /^[1-9][0-9]{5}$/;
            if (!re.test(zip)) {
                $("#divzip").addClass("has-error");
                $("#ziperr").html("邮政编码格式不正确");
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

        if (relastion == "store") {
            if (dealer == "" || dealer == undefined) {
                $("#divdealer").addClass("has-error");
                $("#dealererr").html("请选择经销商");
                flag = false;
            }
        }
    }
    if (flag) {
        var params = { Action: "AdminUpdate", ID:encodeURIComponent($.query.get('id')), Role: encodeURIComponent(role), Name: encodeURIComponent(name), Contact: encodeURIComponent(contact), Position: encodeURIComponent(position), Phone: encodeURIComponent(phone), Mobile: encodeURIComponent(mobile), Fax: encodeURIComponent(fax), Province: encodeURIComponent(province), City: encodeURIComponent(city), Address: encodeURIComponent(address), Zip: encodeURIComponent(zip), Email: encodeURIComponent(email), Dealer: encodeURIComponent(dealer) };
        $.ajax({
            type: "POST",
            url: "../interface/Admin.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    Reset();
                }
                else if(msg.errorcode == "-10")
                {
                    alert('无权限');
                }
            }
        });
    }
}