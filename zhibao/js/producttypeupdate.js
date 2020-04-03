function Reset()
{
    $("#divname").removeClass("has-error");
    $("#nameerr").html("");
    $("#ContentPlaceHolder1_name_txt").val('');
}

function ProductTypeUpdate()
{
    var flag = true;

    var typefac = $("#ContentPlaceHolder1_typefac_ddl").val();
    if (typefac == "" || typefac == undefined || typefac == null) {
        flag = false;
        $("#divtypefac").addClass("has-error");
        $("#typefacerr").html("请选择工厂产品类型");
    }

    var name = $("#ContentPlaceHolder1_name_txt").val().Trim();
    if(name=="")
    {
        flag = false;
        $("#divname").addClass("has-error");
        $("#nameerr").html("请输入产品类型名称");
    }
    var id = $.query.get('id');


    if(flag)
    {
        var params = { Action: "ProductTypeUpdate", Name: encodeURIComponent(name), ID: id, FacType: encodeURIComponent(typefac) };

        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('更新成功！');
                    location.href = 'producttypelist.aspx';
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
                else if (msg.errorcode == "-2") {
                    $("#divname").addClass("has-error");
                    $("#nameerr").html("产品类型名称重复");
                }
                else if (msg.errorcode == "-5") {
                    $("#divtypefac").addClass("has-error");
                    $("#typefacerr").html("工厂类型已经被使用了，请更换");
                }
            }
        });
    }
}