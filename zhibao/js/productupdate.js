$(document).ready(function () {

  

    $('#ContentPlaceHolder1_typeone_ddl').bind('change', function () {
        $('#ContentPlaceHolder1_typetwo_ddl').empty();
        $("<option value=''></option>").appendTo("#ContentPlaceHolder1_typetwo_ddl");
        if ($('#ContentPlaceHolder1_typeone_ddl').val() != "") {
            var params = { Action: "GetProductTypeList", ID: $('#ContentPlaceHolder1_typeone_ddl').val() };
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
                                $('<option value="' + msg.data[i].S_ProductTypeId + '">' + msg.data[i].S_ProductTypeName + '</option>').appendTo('#ContentPlaceHolder1_typetwo_ddl');
                            }
                        }
                    }
                }
            });
        }
    });
});

function ProductUpdate()
{

    $("#divtypeone").removeClass("has-error");
    $("#typeoneerr").html('');
    $("#divtypetwo").removeClass("has-error");
    $("#typetwoerr").html('');
    $("#divcode").removeClass("has-error");
    $("#codeerr").html('');


    var typeone = $('#ContentPlaceHolder1_typeone_ddl').val();
    var typetwo = $('#ContentPlaceHolder1_typetwo_ddl').val();
    var code = $('#ContentPlaceHolder1_code_txt').val();
    var memo = $('#ContentPlaceHolder1_memo_txt').val();
    var flag = true;
    if(typeone=="")
    {
        flag = false;
        $("#divtypeone").addClass("has-error");
        $("#typeoneerr").html('请选择一级分类');
    }

    if (typetwo == "") {
        flag = false;
        $("#divtypetwo").addClass("has-error");
        $("#typetwoerr").html('请选择二级分类');
    }

    if (code == "") {
        flag = false;
        $("#divcode").addClass("has-error");
        $("#codeerr").html('请填写商品编码');
    }

    var oldcode = $.query.get('code');

    if(flag)
    {
        var params = { Action: "ProductUpdate", OldCode:oldcode,TypeOne: encodeURIComponent(typeone), TypeTwo: encodeURIComponent(typetwo), Code: encodeURIComponent(code), Memo: encodeURIComponent(memo) };
        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                }
                else if(msg.errorcode == "-2")
                {
                    $("#divcode").addClass("has-error");
                    $("#codeerr").html('商品编码重复');
                }
            }
        });
    }
}
