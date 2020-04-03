var items_per_page = 10;
var page_index = 0;

$(document).ready(function () {
    GetFeedbackList(0);
});
function GetFeedbackList(page_index) {

    $("#tbcon").html('');

    var params = { Action: "GetFeedbackList",Page: page_index,Item:items_per_page };

    $.ajax({
        type: "POST",
        url: "../interface/Feedback.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data[0] != null && msg.data[0].length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data[0].length; i++) {
                        var li = '<tr><td><div class="btn-group"><a name="deletefeedback" class="btn btn-xs btn-danger"  onclick="DeleteFeedback(' + msg.data[0][i].FeedBackId + ')"><i class="icon-trash bigger-120"></i></a></div></td><td>' + ChangeDateFormat(msg.data[0][i].CreateTime) + '</td>';
                        li = li + '<td><a target="_blank" href="feedback.aspx?id=' + msg.data[0][i].FeedBackId + '">' + msg.data[0][i].Title + '</a></td>';
                        li=li+'<td>' + msg.data[0][i].Name + '</td>';
                        li=li+'<td>' + msg.data[0][i].Mobile + '</td>';
                        li=li+'<td>' + msg.data[0][i].Email + '</td>';
                        li=li+'<td>' + msg.data[0][i].Content + '</td>';
                        li=li+'</tr>';
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    var lino = '<tr><td colspan="5">暂时没有任何反馈</td></tr>';
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
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }

            if ($("#ContentPlaceHolder1_deletepermission").val() != "true") {
                $('a[name="deletefeedback"]').each(function () {
                    $(this).remove();
                });
            }
        }
    });
};
function pageselectCallbackVideo(page_index, jq) {
    GetFeedbackList(page_index);
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
function DeleteFeedback(id)
{

    if (confirm("是否确认删除")) {

        var params = { Action: "DeleteFeedback", ID: id };

        $.ajax({
            type: "POST",
            url: "../interface/Feedback.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('删除成功！');
                    $("#tbcon").html('');
                    page_index = 0;
                    $("#Pagination").html('');
                    GetFeedbackList(page_index);
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}