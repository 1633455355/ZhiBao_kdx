var dealer = "";
var code = "";
var store = "";
var total = 0;

$(document).ready(function () {
    $('#ContentPlaceHolder1_dealer_ddl').bind('change', function () {
        $('#ContentPlaceHolder1_store_ddl').empty();
        $("<option value=''></option>").appendTo("#ContentPlaceHolder1_store_ddl");
        if ($('#ContentPlaceHolder1_dealer_ddl').val() != "") {
            var params = {
                Action: "GetStoreList",
                ID: $('#ContentPlaceHolder1_dealer_ddl').val()
            };
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
                                $('<option value="' + msg.data[i].AdminId + '">' + msg.data[i].StoreName + '</option>').appendTo('#ContentPlaceHolder1_store_ddl');
                            }
                        }
                        $('#ContentPlaceHolder1_store_ddl').chosen({ allow_single_deselect: true });
                        $("#ContentPlaceHolder1_store_ddl").trigger("chosen:updated");
                    }
                }
            });
        }
    });
});


function DoSearch() {
    $("#tbcon").html('');
    var params = {
        Action: "Search",
        Store: store,
        Dealer: dealer
    };

    $.ajax({
        type: "POST",
        url: "../interface/mechanic.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data.length > 0) {
                    total = msg.data.length;
                    for (var i = 0; i < msg.data.length; i++) {
                        var li = '<tr>';
                        var li = li + '<td><div class="btn-group"><a class="btn btn-xs btn-danger"  onclick="Deletemechanic(' + msg.data[i].MechanicId + ')"><i class="icon-trash bigger-120"></i></a><a href="mechanicadd.aspx?id=' + msg.data[i].MechanicId + '" class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></a></div></td>';
                        if (msg.type == "Managers") {
                            li = li + '<td>' + msg.data[i].DealerName + '</td>';
                            li = li + '<td>' + msg.data[i].StoreName + '</td>';
                        }
                        else if (msg.type == "Dealer") {
                           
                            li = li + '<td>' + msg.data[i].StoreName + '</td>';
                        }

                        li = li + '<td>' + msg.data[i].Name + '</td>';
                        if (msg.data[i].Introduction != null && msg.data[i].Introduction != "null"){
                            li = li + '<td>' + msg.data[i].Introduction + '</td>';
                        }
                        else  {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].Type == 1) {
                            li = li + '<td>电工</td>';
                        }
                        else if (msg.data[i].Type == 2){
                            li = li + '<td>机修</td>';
                        }
                        else if (msg.data[i].Type == 3) {
                            li = li + '<td>钣金</td>';
                        }
                        else if (msg.data[i].Type == 4) {
                            li = li + '<td>涂装</td>';
                        }
                        if (msg.data[i].Mobile != null && msg.data[i].Mobile != "null") {
                            li = li + '<td>' + msg.data[i].Mobile + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].Email != null && msg.data[i].Email != "null") {
                            li = li + '<td>' + msg.data[i].Email + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].Address != null && msg.data[i].Address != "null") {
                            li = li + '<td>' + msg.data[i].Address + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }

                        li = li + '<td>' + ChangeDateFormat(msg.data[i].CreateTime) + '</td>';

                        li = li + '</tr>';
                        $("#tbcon").append(li);
                    }
                }
                if (total == 0) {

                    var lino = '';
                    if (msg.type == "Managers") {
                        lino = '<tr><td colspan="8">没有搜索到任何的数据</td></tr>';
                    }
                    else {
                        lino = '<tr><td colspan="7">没有搜索到任何的数据</td></tr>';
                    }

                    $("#tbcon").append(lino);
                }
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
        }
    });
}
function SearchMechanic() {
    $("#Pagination").html('');
    code = $("#ContentPlaceHolder1_code_txt").val();
    dealer = typeof ($("#ContentPlaceHolder1_dealer_ddl").val()) == 'undefined' ? "" : $("#ContentPlaceHolder1_dealer_ddl").val();
    store = typeof ($("#ContentPlaceHolder1_store_ddl").val()) == 'undefined' ? "" : $("#ContentPlaceHolder1_store_ddl").val();
    DoSearch();
}
function pageselectCallbackVideo(page_index, jq) {
    DoSearch(page_index);
};
function ChangeDateFormat(time) {
    if (time != null) {
        var strs = new Array();
        strs = time.split("T");
        if (strs[0] == "0001-01-01") {
            return "";
        }
        else {
            return strs[0];
        }
    }
    return "";
};


function Deletemechanic(id) {

    var params = { Action: "Del", Id: id };
    $.ajax({
        type: "POST",
        url: "../interface/mechanic.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                alert('删除成功！');
                page_index = 0;
                DoSearch();
            }
            else if (msg.errorcode == "-1") {
                alert('缺失必要的参数');
            }
            else if (msg.errorcode == "-2") {
                alert('已经有用户质保卡选择此技师，所以不能删除');
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
        }
    });
}