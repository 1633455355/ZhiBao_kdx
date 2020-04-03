var items_per_page = 10;
var page_index = 0;

$(document).ready(function () {
    GetPromotionList(0);
});
function GetPromotionList(page_index) {

    $("#tbcon").html('');

    var params = { Action: "GetPromotionList", Page: page_index, Item: items_per_page };

    $.ajax({
        type: "POST",
        url: "../interface/Promotion.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data[0] != null && msg.data[0].length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data[0].length; i++) {
                        var li = '<tr><td><div class="btn-group"><a name="uppromotion" class="btn btn-xs btn-info" href="promotionupdate.aspx?id=' + msg.data[0][i].PromotionId + '"><i class="icon-edit bigger-120"></i></a><a name="deletepromotion" class="btn btn-xs btn-danger"  onclick="DeletePromotion(' + msg.data[0][i].PromotionId + ')"><i class="icon-trash bigger-120"></i></a></div></td><td>' + ChangeDateFormat(msg.data[0][i].CreateTime) + '</td><td><a href="promotion.aspx?id=' + msg.data[0][i].PromotionId + '" target="_blank">' + msg.data[0][i].Title + '</td></a></tr>';
                            $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    var lino = '<tr><td colspan="4">暂时没有任何促销信息</td></tr>';
                    $("#tbcon").append(lino);
                }
                else {
                    if ($("#Pagination a").length == 0) {
                        $("#Pagination").pagination(total, {
                            'items_per_page': items_per_page,
                            'num_display_entries': 10,
                            'num_edge_entries': 2,
                            'prev_text': "上一页",
                            'next_text': "下一页",
                            'callback': pageselectCallbackVideo
                        });
                    }
                }
            }
            else if(msg.errorcode == "-10")
            {
                alert('无权限');
            }

            if ($("#ContentPlaceHolder1_deletepermission").val() != "true") {
                $('a[name="deletepromotion"]').each(function () {
                    $(this).remove();
                });
            }
            if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                $('a[name="uppromotion"]').each(function () {
                    $(this).remove();
                });
            }
        }
    });
};
function pageselectCallbackVideo(page_index, jq) {
    GetPromotionList(page_index);
    return false;
};
function ChangeDateFormat(time) {
    if (time != null) {
        var strs = new Array();
        strs = time.split("T");
        return strs[0];

    }
    return "";
};
function DeletePromotion(id)
{

    if (confirm("是否确认删除")) {

        var params = { Action: "DeletePromotion", ID: id };

        $.ajax({
            type: "POST",
            url: "../interface/Promotion.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('删除成功！');
                    $("#tbcon").html('');
                    $("#Pagination").html('');
                    GetPromotionList(page_index);
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}