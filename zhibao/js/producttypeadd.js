$(document).ready(function () {

    $('#ContentPlaceHolder1_typefac_ddl').bind('change', function () {
        if ($('#ContentPlaceHolder1_typefac_ddl').val() != "") {
            var params = { Action: "GetF_ProductTypeList", ID: $('#ContentPlaceHolder1_typefac_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            $("#name_txt").val(msg.data[0].ProductSecondLevelNameDefalut);
                        }
                    }
                }
            });
        }
    });

});







function Reset()
{
    $("#divname").removeClass("has-error");
    $("#nameerr").html("");
    $("#name_txt").val('');
}

function ProductTypeAdd()
{

    

    var flag = true;

    var typefac = $("#ContentPlaceHolder1_typefac_ddl").val();
    if (typefac == "" || typefac == undefined || typefac==null)
    {
        flag = false;
        $("#divtypefac").addClass("has-error");
        $("#typefacerr").html("请选择工厂产品类型");
    }

    var name = $("#name_txt").val().Trim();
    if(name=="")
    {
        flag = false;
        $("#divname").addClass("has-error");
        $("#nameerr").html("请输入产品类型名称");
    }

    if(flag)
    {
        var params = { Action: "ProductTypeAdd", Name: encodeURIComponent(name), First: encodeURIComponent($("#ContentPlaceHolder1_typeone_ddl").val()),FacType:encodeURIComponent(typefac) };

        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('添加成功！');
                    Reset();
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
                else if (msg.errorcode == "-2") {
                    $("#divname").addClass("has-error");
                    $("#nameerr").html("产品类型已被使用");
                }
                else if (msg.errorcode == "-5") {
                    $("#divtypefac").addClass("has-error");
                    $("#typefacerr").html("工厂类型已经被使用了，请更换");
                }
            }
        });
    }
}