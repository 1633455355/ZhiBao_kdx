$(document).ready(function () {

    $('#frontcode_ddl').bind('change', function () {
        $('#frontProductcode_ddl').empty();
        $("<option value=''></option>").appendTo("#frontProductcode_ddl");
        if ($('#frontcode_ddl').val() != "") {
            var params = { Action: "GetProductCode", FId: $('#frontcode_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            for (var i = 0; i < msg.data.length; i++) {
                                var li = msg.data[i].newsid;
                                $('<option value="' + msg.data[i] + '">' + msg.data[i] + '</option>').appendTo('#frontProductcode_ddl');
                            }
                        }
                    }
                }
            });
        }
    });

    $('#backcode_ddl').bind('change', function () {
        $('#backProductcode_ddl').empty();
        $("<option value=''></option>").appendTo("#backProductcode_ddl");
        if ($('#backcode_ddl').val() != "") {
            var params = { Action: "GetProductCode", FId: $('#backcode_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            for (var i = 0; i < msg.data.length; i++) {
                                var li = msg.data[i].newsid;
                                $('<option value="' + msg.data[i] + '">' + msg.data[i] + '</option>').appendTo('#backProductcode_ddl');
                            }
                        }
                    }
                }
            });
        }
    });


    $('#brand_ddl').bind('change', function () {
        GetSysytemFromUs();
    });

    $('#system_ddl').bind('change', function () {
        GetTypeFromUs();
    });

    $('#province_ddl').bind('change', function () {
        $('#city_ddl').empty();
        $("<option value=''></option>").appendTo("#city_ddl");
        if ($('#province_ddl').val() != "") {
            var params = { Action: "GetCityByProvince", ProvinceID: $('#province_ddl').val() };
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
                                $('<option value="' + msg.data[i].CityId + '">' + msg.data[i].CityName + '</option>').appendTo('#city_ddl');
                            }
                        }
                    }
                }
            });
        }
    });
   

});

function GetSysytemFromUs() {
    $("#system_ddl").empty();
    $("<option value=''></option>").appendTo("#system_ddl");
    if ($("#brand_ddl").val() != "") {
        var params = { Action: "GetSysytemFromUs", ID: $("#brand_ddl").val() };
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
                            $('<option value="' + msg.data[i].CarSystemCode + '">' + msg.data[i].CarSystemName + '</option>').appendTo('#system_ddl');
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
    $("#type_ddl").empty();
    $("<option value=''></option>").appendTo("#type_ddl");
    if ($("#system_ddl").val() != "") {
        var params = { Action: "GetTypeFromUs", ID: $("#system_ddl").val() };
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
                            $('<option value="' + msg.data[i].CarTypeCode + '">' + msg.data[i].CarTypeName + '</option>').appendTo('#type_ddl');
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


function UserAdd() {
    $("#divtfrontcode").removeClass('has-error');
    $("#divtbackcode").removeClass('has-error');
    $("#frontcodeerr").html('');
    $("#backcodeerr").html('');
    $("#divname").removeClass('has-error');
    $("#nameerr").html('');
    $("#divmobile").removeClass('has-error');
    $("#mobileerr").html('');
    $("#divemail").removeClass("has-error");
    $("#emailerr").html("");
    $("#divbrand").removeClass("has-error");
    $("#branderr").html("");
    $("#divsystem").removeClass("has-error");
    $("#systemerr").html("");

    var codeone = $("#ContentPlaceHolder1_frontcode_ddl").val();
 
    var codetwo = $("#ContentPlaceHolder1_backcode_ddl").val();
    
    var name = $("#name_txt").val().Trim();
    var mobile = $("#mobile_txt").val().Trim();
    var email = $("#email_txt").val().Trim();
    var brand = $("#ContentPlaceHolder1_brand_ddl").val();
    var system = $("#ContentPlaceHolder1_system_ddl").val();
    var type = $("#ContentPlaceHolder1_type_ddl").val();
    var license = $("#license_txt").val().Trim();
    var province = $("#ContentPlaceHolder1_province_ddl").val();
    var city = $("#ContentPlaceHolder1_city_ddl").val();
    var price = $("#price_txt").val().Trim();
    var imagelist = $("#tempImage").val().Trim();

    var flag = true;
    if (codeone == "" && codetwo == "") {
        flag = false;
        $("#divtfrontcode").addClass('has-error');
        $("#divtbackcode").addClass('has-error');
        $("#frontcodeerr").html('请至少选择一个产品型号');
        $("#backcodeerr").html('请至少选择一个产品型号');
    }
  
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
        var regPartton = /1[3-8]+\d{9}/;
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

    if (brand == "") {
        $("#divbrand").addClass("has-error");
        $("#branderr").html("请选择品牌信息");
        flag = false;
    }

    if (system == "") {
        $("#divsystem").addClass("has-error");
        $("#systemerr").html("请选择车系信息");
        flag = false;
    }

    if (flag) {
        var params = { Action: "UserAdd", Codeone: encodeURIComponent(codeone), Codetwo: encodeURIComponent(codetwo), Name: encodeURIComponent(name), Mobile: encodeURIComponent(mobile), Email: encodeURIComponent(email), Brand: encodeURIComponent(brand), System: encodeURIComponent(system), Type: encodeURIComponent(type), License: encodeURIComponent(license), Province: encodeURIComponent(province), City: encodeURIComponent(city), Price: encodeURIComponent(price), ImageList: encodeURIComponent(imagelist) };
        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    //Reset();
                    location.href = "useradd.aspx";
                }
                else if (msg.errorcode == "5") {
                    $("#divtfrontcode").addClass('has-error');
                    $("#frontcodeerr").html('产品型号已超出使用范围');
                }
                else if (msg.errorcode == "6") {
                    $("#divtbackcode").addClass('has-error');
                    $("#backcodeerr").html('产品型号已超出使用范围');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}

function AddInputFile()
{
    var f = $('#fileHtml').find('div').length;
    if (f < 5) {
        var addhtmlfile = "<div> <label>    </label><input class=\"txt3\" type=\"file\" name=\"ImageList\"/><a href=\"#\" class=\"img\" onclick=\"AddInputFile()\"></a> <a href=\"#\" class=\"img2\"  onclick=\"DelnputFile(this)\"></a></div>";
        $('#fileHtml').append(addhtmlfile);
    }
    else
    {
        alert("最多能传五张图片");
    }
}
function DelnputFile(num)
{
    $(num).parent("div").remove();
}
function reset()
{
    location.href = "mobileadduser.aspx";
}

function MobileUserAdd() {

    var codeone = $("#frontcode_ddl").val();
    var Productcodeone = $("#frontProductcode_ddl").val();

    var codetwo = $("#backcode_ddl").val();
    var Productcodetwo = $("#backProductcode_ddl").val();

    var name = $("#name_txt").val().trim();
    var mobile = $("#mobile_txt").val().trim();
    var email = $("#email_txt").val().trim();
    var brand = $("#brand_ddl").val();
    var system = $("#system_ddl").val();
    var type = $("#type_ddl").val();
    var js = $("#js_ddl").val();
    var license = $("#license_txt").val().trim();
    var province = $("#province_ddl").val();
    var city = $("#city_ddl").val();
    var price = $("#price_txt").val().trim();

    if (codeone == "" && codetwo == "") {
        alert("请至少选择一个产品型号")
        return false;
    }
    if (Productcodeone == "" && Productcodetwo == "") {
        alert("请至少选择卷轴号");
        return false;
    }
    if (Productcodeone ==null && Productcodetwo == null) {
        alert("请至少选择卷轴号");
        return false;
    }
    if (Productcodeone == null && Productcodetwo == "") {
        alert("请至少选择卷轴号");
        return false;
    }
    if (Productcodeone == "" && Productcodetwo == null) {
        alert("请至少选择卷轴号");
        return false;
    }
    if (name == "") {
        alert("请输入姓名");
        return false;
    }

    if (mobile == "") {
        alert("请输入手机号码");
        return false;
    }
    else {
        var regPartton = /1[3-8]+\d{9}/;
        if (!regPartton.test(mobile)) {
            alert("手机号码格式不正确");
            return false;
        }
    }

    if (email != "") {
        var pattern = /^(?:[a-zA-Z0-9]+[_\-\+\.]?)*[a-zA-Z0-9]+@(?:([a-zA-Z0-9]+[_\-]?)*[a-zA-Z0-9]+\.)+([a-zA-Z]{2,})+$/;
        if (!pattern.exec(email)) {
            alert("请输入正确格式的邮箱地址");
            return false;
        }
    }

    if (brand == "") {
        alert("请选择品牌信息");
        return false;
    }

   /* if (system == "") {
        alert("请选择车系信息");
        return false;
    }*/
    var params = { Codeone: encodeURIComponent(codeone), ProductCodeone: encodeURIComponent(Productcodeone), Codetwo: encodeURIComponent(codetwo),ProductCodetwo:encodeURIComponent(Productcodetwo), Name: encodeURIComponent(name), Mobile: encodeURIComponent(mobile), Email: encodeURIComponent(email), Brand: encodeURIComponent(brand), System: encodeURIComponent(system), Type: encodeURIComponent(type), Js: encodeURIComponent(js), License: encodeURIComponent(license), Province: encodeURIComponent(province), City: encodeURIComponent(city), Price: encodeURIComponent(price) };
        var form = $('#form1');
        form.ajaxSubmit({
            url: '../interface/MobileProductHandler.ashx',
            type: 'Post',
            cache: false,
            dataType: 'json',
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    reset();
                }
                else if (msg.errorcode == "5") {
                    alert('产品型号已超出使用范围');
                }
                else if (msg.errorcode == "6") {
                    alert('产品型号已超出使用范围');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
}