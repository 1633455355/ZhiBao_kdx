$(document).ready(function () {
    $('#ContentPlaceHolder1_typeone_ddl').bind('change', function () {
        if ($('#ContentPlaceHolder1_typeone_ddl').val() != "") {
            var params = { Action: "GetF_ProductTypeList", ID: $('#ContentPlaceHolder1_typeone_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            $("#ContentPlaceHolder1_typetwo_ddl").val(msg.data[0].ProductSecondLevelNameDefalut);
                            $("#ContentPlaceHolder1_typetwo_ddl").attr("disabled", "true");
                        }
                    }
                }
            });
        }
    });
});

function setProductInfo()
{
   
    if(Code!=null &&Code!='')
    {
       
    }

}

function ProductAdd() {

    $("#divtypeone").removeClass("has-error");
    $("#typeoneerr").html('');
    $("#divcode").removeClass("has-error");
    $("#codeerr").html('');
    $("#divmemo").removeClass("has-error");
    $("#memoerr").html('');


    var typeone = $('#ContentPlaceHolder1_typeone_ddl').val();
    var code = $('#ContentPlaceHolder1_code_txt').val();
    var memo = $('#ContentPlaceHolder1_memo_txt').val();
    var length_m = $("#ContentPlaceHolder1_mi_ddl").val();
    var flag = true;
    if (typeone == "") {
        flag = false;
        $("#divtypeone").addClass("has-error");
        $("#typeoneerr").html('请厂家内部型号');
    }

 
    if (code == "") {
        flag = false;
        $("#divcode").addClass("has-error");
        $("#codeerr").html('请填写卷轴号');
    }
    if (memo == "") {
        flag = false;
        $("#memoerr").addClass("has-error");
        $("#memoerr").html('请填写质保年限');
    }
   
    if (flag) {
        var params;
        var idCode = $.query.get('code');
        if (idCode != null && idCode != '') {
            params = {
                Action: "F_ProductUpdate",
                TypeOne: encodeURIComponent(typeone),
                NewsCode: encodeURIComponent(code),
                Code: encodeURIComponent(idCode),
                Memo: encodeURIComponent(memo),
                Length: encodeURIComponent(length_m)
            };
        }
        else
        {
            params = {
                Action: "F_ProductAdd",
                TypeOne: encodeURIComponent(typeone),
                Code: encodeURIComponent(code),
                Memo: encodeURIComponent(memo),
                Length: encodeURIComponent(length_m)
            };
        }
        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    Reset();
                }
                else if (msg.errorcode == "-2") {
                    $("#divcode").addClass("has-error");
                    $("#codeerr").html('卷轴号重复');
                }
                else if (msg.errorcode == "-1") {
                    alert('传递参数错误');
                }
                else if (msg.errorcode == "-5") {
                    alert('厂家内部型号有错误');
                }
                else if(msg.errorcode=="-10")
                {
                    alert("没有权限");
                }
            }
        });
    }
}

function Reset() {
    $("#divtypeone").removeClass("has-error");
    $("#typeoneerr").html('');
    $("#divcode").removeClass("has-error");
    $("#codeerr").html('');
    $('#ContentPlaceHolder1_typeone_ddl').val('');
    $('#ContentPlaceHolder1_code_txt').val('');
    $('#ContentPlaceHolder1_memo_txt').val('');
}
