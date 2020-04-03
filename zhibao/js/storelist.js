var items_per_page = 3;
var page_index = 0;

$(document).ready(function () {

    DoSearch(page_index);
});

function DoSearch(page_index)
{
    $("#tbcon").html('');

    var params = { Action: "StoreList", Page: encodeURIComponent(page_index), Item: encodeURIComponent(items_per_page)};

    $.ajax({
        type: "POST",
        url: "../interface/Admin.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data.length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data.length; i++) {
                        var li = '';
                        li = '<tr>';
  
                        li = li + '<td>' + msg.data[i].Store.StoreName + '</td>>';
                        li = li + '<td>' + msg.data[i].Store.Contacts + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Position + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Phone + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Mobile + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Fax + '</td>';
                        li = li + '<td>' + msg.data[i].Store.ProvinceName + '</td>';
                        li = li + '<td>' + msg.data[i].Store.CityName + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Address + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Zip + '</td>';
                        li = li + '<td>' + msg.data[i].Store.Email + '</td>';
                        li = li + '</tr>';
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    var lino = '<tr><td colspan="10">目前没有任何所属门店</td></tr>';
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
        }
    });
}

function pageselectCallbackVideo(page_index, jq) {
    DoSearch(page_index);
};
function ChangeDateFormat(time) {
    if (time != null) {
        var strs = new Array();
        strs = time.split("T");
        return strs[0];
    }
    return "";
};