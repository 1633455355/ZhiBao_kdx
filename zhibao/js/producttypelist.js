$(document).ready(function () {
    GetProductTypeList();
});


function GetProductTypeList() {

    $("#tbcon").html('');

    var params = { Action: "GetProductTypeList"};

    $.ajax({
        type: "POST",
        url: "../interface/Product.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data != null && msg.data.length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data.length; i++) {
                        var li = '<tr><td><div class="btn-group"><a name="upproducttype" class="btn btn-xs btn-info" href="producttypeupdate.aspx?id=' + msg.data[i].S_ProductTypeId + '"><i class="icon-edit bigger-120"></i></a><a name="deleteproducttype" class="btn btn-xs btn-danger"  onclick="DeleteProductType(' + msg.data[i].S_ProductTypeId + ')"><i class="icon-trash bigger-120"></i></a></div></td><td>' + msg.data[i].F_ProductTypeName + '</td><td>' + msg.data[i].S_ProductTypeName + '</td><td>' + msg.data[i].FactoryTypeName + '</td></tr>';
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    var lino = '<tr><td colspan="4">暂时没有任何类型</td></tr>';
                    $("#tbcon").append(lino);
                }
               
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }

            if ($("#ContentPlaceHolder1_deletepermission").val() != "true") {
                $('a[name="deleteproducttype"]').each(function () {
                    $(this).remove();
                });
            }
            if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                $('a[name="upproducttype"]').each(function () {
                    $(this).remove();
                });
            }
        }
    });
};

function DeleteProductType(id)
{

    if (confirm("是否确认删除")) {
        var params = { Action: "DeleteProductType", ID: id };

        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('删除成功！');
                    $("#tbcon").html('');
                    GetProductTypeList();
                }
                else if (msg.errorcode == "-2") {
                    alert('已经被使用了，不能删除');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}