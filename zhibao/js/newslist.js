var items_per_page = 10;
var page_index = 0;

$(document).ready(function () {
    GetNewsList(0);
});
function GetNewsList(page_index) {

    $("#tbcon").html('');

    var params = { Action: "GetNewsList",Page: page_index,Item:items_per_page };

    $.ajax({
        type: "POST",
        url: "../interface/News.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data[0] != null && msg.data[0].length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data[0].length; i++) {
                        var li = '<tr><td><div class="btn-group"><a name="upnews" class="btn btn-xs btn-info" href="newsupdate.aspx?id=' + msg.data[0][i].NewsId + '"><i class="icon-edit bigger-120"></i></a><a name="deletenews" class="btn btn-xs btn-danger"  onclick="DeleteNews(' + msg.data[0][i].NewsId + ')"><i class="icon-trash bigger-120"></i></a></div></td><td>' + ChangeDateFormat(msg.data[0][i].CreateTime) + '</td><td><a href="news.aspx?id=' + msg.data[0][i].NewsId + '" target="_blank">' + msg.data[0][i].Title + '</td></a></tr>';
                            $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    var lino = '<tr><td colspan="4">暂时没有任何消息</td></tr>';
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
                $('a[name="deletenews"]').each(function () {
                    $(this).remove();
                });
            }
            if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                $('a[name="upnews"]').each(function () {
                    $(this).remove();
                });
            }
        }
    });
};
function pageselectCallbackVideo(page_index, jq) {
    GetNewsList(page_index);
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
function DeleteNews(id)
{

    if (confirm("是否确认删除")) {

        var params = { Action: "DeleteNews", ID: id };
        $.ajax({
            type: "POST",
            url: "../interface/News.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('删除成功！');
                    $("#tbcon").html('');
                    GetNewsList(page_index);
                    $("#Pagination").html('');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}