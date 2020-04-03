$(document).ready(function () {
    //LoadProductAvailable()
});
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);//匹配目标参数
    if (r != null)
        return r[2];
    return null; //返回参数值
}
function ProductVerify()
{
    $("#divcode").removeClass('has-error');
    $("#codeerr").html('');
    $("#divtypeone").removeClass('has-error');
    $("#typeoneerr").html('');
    $("#divtypetwo").removeClass('has-error');
    $("#typetwoerr").html('');

    var flag = true;
    var code = $("#ContentPlaceHolder1_code_txt").val().Trim();
    if (code == "") {
        $("#divcode").addClass('has-error');
        $("#codeerr").html('请输入产品卷轴号');
        flag = false;
    }

    var typeone = $("#ContentPlaceHolder1_typeone_ddl").val();
    if (typeone == "")
    {
        $("#divtypeone").addClass('has-error');
        $("#typeoneerr").html('请选择一级分类');
        flag = false;
    }


    var typetwo = $("#ContentPlaceHolder1_typetwo_ddl").val();
    if (typetwo == "") {
        $("#divtypetwo").addClass('has-error');
        $("#typetwoerr").html('请选择品牌型号');
        flag = false;
    }
    if (flag) {
        var oldcode = getUrlParam('code');
        var params;
        if (oldcode == null && oldcode == "") {
           params = { Action: "ProductVerify", Code: encodeURIComponent(code), Typeone: encodeURIComponent(typeone), Typetwo: encodeURIComponent(typetwo)};
        }
        else
        {
            params = { Action: "UpProductVerify", Code: encodeURIComponent(code), Typeone: encodeURIComponent(typeone), Typetwo: encodeURIComponent(typetwo), upCode: encodeURIComponent(oldcode) };
        }
        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('认证成功，请等待审核');
                    //$("#ContentPlaceHolder1_code_txt").val('');
                    location.href = "productverify.aspx";
                }
                else if (msg.errorcode == "-2") {
                    $("#divcode").addClass('has-error');
                    $("#codeerr").html('产品卷轴号不正确');
                }
                else if (msg.errorcode == "-3") {
                    $("#divtypeone").addClass('has-error');
                    $("#typeoneerr").html('或产品类型不正确');
                    $("#divtypetwo").addClass('has-error');
                    $("#typetwoerr").html('或品牌型号不正确');
                }
                else if (msg.errorcode == "-5") {
                    $("#divcode").addClass('has-error');
                    $("#codeerr").html('产品卷轴号已被认证');
                }
                else if (msg.errorcode == "-6") {
                    $("#divtypeone").addClass('has-error');
                    $("#typeoneerr").html('产品类别不正确');
                    $("#divtypetwo").addClass('has-error');
                    $("#typetwoerr").html('产品类别不正确');
                }
                else if (msg.errorcode == "-7") {
                    $("#divcode").addClass('has-error');
                    $("#codeerr").html('产品卷轴号经销商还没有认证或者认证还没有审核通过');
                }
                else if (msg.errorcode == "-8") {
                    $("#divcode").addClass('has-error');
                    $("#codeerr").html('此产品卷轴号被经销商认证，而此经销商不是你的上级经销商，因此此卷轴不能认证');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
    
}

function ProductClear()
{
    $("#divcode2").removeClass('has-error');
    $("#code2err").html('');

    var code = $("#ContentPlaceHolder1_code_ddl").val();
    if (code == "" || code == null) {
        $("#divcode2").addClass('has-error');
        $("#code2err").html('请至少选择一个产品编码');
    }
    else {
        var params = { Action: "ProductClear", Code: encodeURIComponent(code) };
        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    LoadProductAvailable();
                }
            }
        });
    }
}

function LoadProductAvailable()
{
    $('#ContentPlaceHolder1_code_ddl').empty();
    $('<option value=""></option>').appendTo('#ContentPlaceHolder1_code_ddl');
    var params = { Action: "LoadProductAvailable" };
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
                        $('<option value="' + msg.data[i].ProductCode + '">' + msg.data[i].ProductCode + '</option>').appendTo('#ContentPlaceHolder1_code_ddl');
                    }
                }
            }
        }
    });
}