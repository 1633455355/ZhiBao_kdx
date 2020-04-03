var fId = "";
var code = "";
var status = "";

var items_per_page = 10;
var page_index = 0;

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
    DoSearch(page_index);
});


function DoSearch(page_index,fid,code,status) {
    $("#tbcon").html('');
    fId = $("#ContentPlaceHolder1_typeone_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    status = $("#ContentPlaceHolder1_status").val();
    if (typeof (fId) == "undefined") {
        fId = "";
    }
    if (typeof (code) == "undefined") {
        code = "";
    }
    if (typeof (status) == "undefined") {
        status = "";
    }
    var params = { Action: "GetList", Page: encodeURIComponent(page_index), Item: encodeURIComponent(items_per_page), Code: encodeURIComponent(code), FId: encodeURIComponent(fId), Status: encodeURIComponent(status) };

    $.ajax({
        type: "POST",
        url: "../interface/Compensate.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data.length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data.length; i++) {
                        var li = '<tr>';
                        if (msg.type != "Managers")
                        {
                            if (msg.data[i].Status == 0) {
                                li = li + '<td><div class="btn-group"><a class="btn btn-xs btn-danger"  onclick="DeleteCompensate(\'' + msg.data[i].CompensateNo + '\')"><i class="icon-trash bigger-120"></i></a><a href="CompensateAdd.aspx?No=' + msg.data[i].CompensateNo + '" class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></a></div></td>';
                            }
                            if (msg.data[i].Status == 2 || msg.data[i].Status == 3) {
                                li = li + '<td><div class="btn-group"><a href="CompensateAdd.aspx?No=' + msg.data[i].CompensateNo + '" class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></a></div></td>';
                            }
                            if (msg.data[i].Status == 1 || msg.data[i].Status == 4) {
                                li = li + '<td></td>';
                            }
                        }
                     

                      //  li = li + '<td>' + msg.data[i].CompensateNo + '</td>';
                        li = li + '<td>' + msg.data[i].ProductSecondLevelName + '</td>';
                        li = li + '<td>' + msg.data[i].ProductCode + '</td>';
                        li = li + '<td>' + msg.data[i].CompensatePeson + '</td>';
                        if (msg.data[i].Status == 0){
                            li = li + '<td>未处理</td>';
                        }
                        else if (msg.data[i].Status == 1) {
                            li = li + '<td>正在处理</td>';
                        }
                        else if (msg.data[i].Status == 2) {
                            li = li + '<td>需要补充资料</td>';
                        }
                        else if (msg.data[i].Status == 3) {
                            li = li + '<td>已经补充资料</td>';
                        }
                        else if (msg.data[i].Status == 4) {
                            li = li + '<td>已经处理完成</td>';
                        }
                        if (msg.type == "Managers") {
                            if (msg.data[i].DealerName == null) {
                                li = li + '<td></td>';
                            }
                            else {
                                li = li + '<td>' + msg.data[i].DealerName + '</td>';
                            }
                            if (msg.data[i].StoreName == null) {
                                li = li + '<td></td>';
                            }
                            else {
                                li = li + '<td>' + msg.data[i].StoreName + '</td>';
                            }
                        }
                        else if (msg.type == "Dealer") {
                            if (msg.data[i].DealerName ==null){
                                li = li + '<td></td>';
                            }
                            else {
                                li = li + '<td>' + msg.data[i].DealerName + '</td>';
                            }
                           
                        }
                        else if (msg.type == "Stores") {
                            if (msg.data[i].StoreName == null) {
                                li = li + '<td></td>';
                            }
                            else {
                                li = li + '<td>' + msg.data[i].StoreName + '</td>';
                            }
                        }
                        if (msg.data[i].ImageArray!=null && msg.data[i].ImageArray.length > 0) {
                            li = li + '<td>';
                            for(var j=0;j<msg.data[i].ImageArray.length;j++)
                            {
                                li = li + '<div><a href="/UpLoadImage/' + msg.data[i].ImageArray[j] + '" target="_blank">' + msg.data[i].ImageArray[j] + '</a></div>';
                            }
                            li = li + '</td>';
                        }
                        else  {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].AtchmentArray != null && msg.data[i].AtchmentArray.length > 0) {
                            li = li + '<td>';
                            for (var m = 0; m < msg.data[i].AtchmentArray.length; m++) {
                                li = li + '<div><a href="/UpLoadImage/' + msg.data[i].AtchmentArray[m] + '" target="_blank">' + msg.data[i].AtchmentArray[m] + '</a></div>';
                            }
                            li = li + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }

                        li = li + '<td>' + ChangeDateFormat(msg.data[i].CreateTime) + '</td>';
                        li = li + '<td><a href="/Template/Compensate/Order/' + msg.data[i].CompensateNo + '.html" target="_blank">详细信息</a></td>';
                        if (msg.type == 'Managers')
                        {
                            li = li + '<td><select class="form-control" id="' + msg.data[i].CompensateNo + '" name="' + msg.data[i].CompensateNo + '">';
                            li=li+'<option value=""></option>'
                          //  li = li + '<option value="0">未处理</option>';
                            li=li+'<option value="1">正在处理</option>';
                            li=li+'<option value="2">需要补充资料</option>';
                          //  li=li+'<option value="3">已经补充资料</option>';
                            li=li+'<option value="4">已经处理完成</option>';
                            li = li + '</select>  <input type="button"  value="处理" onclick="SetCompensateNoStatus(\'' + msg.data[i].CompensateNo + '\')"/></td>';
                        }
                        li = li + '</tr>';
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {

                    var lino = '';
                    if (msg.type == "Managers") {
                        lino = '<tr><td colspan="12">没有搜索到任何的数据</td></tr>';
                    }
                    else {
                        lino = '<tr><td colspan="9">没有搜索到任何的数据</td></tr>';
                    }

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
        }
    });
}

function CompensateSearch() {
    $("#Pagination").html('');
    fId = $("#ContentPlaceHolder1_typetwo_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    status = $("#ContentPlaceHolder1_status").val();
    DoSearch(page_index);
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


function SetCompensateNoStatus(No)
{
    var status = $("#" + No).val();
    if(status=="")
    {
        alert("请选择处理订单现在状态");
        return
    }
    var params = { Action: "SetStatus", no: encodeURIComponent(No), status: encodeURIComponent(status) };
    $.ajax({
        type: "POST",
        url: "../interface/Compensate.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                alert('理赔单处理成功！');
                page_index = 0;
                DoSearch(page_index);
            }
            else if (msg.errorcode == "-5") {
                alert('传递参数有错误，请联系管理员');
            }
            else if (msg.errorcode == "-5") {
                alert('理赔单号传递参数有错误，请联系管理员');
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
        }
    });
}

function DeleteCompensate(No) {

    var params = { Action: "DeleteCompensate", no: encodeURIComponent(No) };
    $.ajax({
        type: "POST",
        url: "../interface/Compensate.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                alert('删除成功！');
                page_index = 0;
                DoSearch(page_index);
            }
            else if (msg.errorcode == "-5") {
                alert('传递参数有错误，请联系管理员');
            }
            else if (msg.errorcode == "-5") {
                alert('理赔单号传递参数有错误，请联系管理员');
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
        }
    });
}

