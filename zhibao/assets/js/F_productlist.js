var typeone = "";
var code = "";
var dealer_flag = "";
var store_flag = "";


var items_per_page = 10;
var page_index = 0;

$("#tbheader").html('<tr><th>操作</th><th>卷轴号</th><th>质保年限</th><th>长度</th><th>厂家内部型号</th><th>状态</th><th>经销商是否审核通过</th><th>门店是否审核通过</th></tr>');

$(document).ready(function () {
   
    $('#ContentPlaceHolder1_typeone_ddl').bind('change', function () {
        $("#ContentPlaceHolder1_typetwo_ddl").val("");
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




function DoSearch(page_index) {
    $("#tbcon").html('');

    $("#tbheader").html('<tr><th>操作</th><th>卷轴号</th><th>质保年限</th><th>长度</th><th>厂家内部型号</th><th>状态</th><th>经销商是否审核通过</th><th>门店是否审核通过</th></tr>');

    var params = { Action: "F_SearchProduct", Page: encodeURIComponent(page_index), Item: encodeURIComponent(items_per_page), TypeOne: encodeURIComponent(typeone), Code: encodeURIComponent(code), dealer_flag: encodeURIComponent(dealer_flag), store_flag: encodeURIComponent(store_flag) };

    $.ajax({
        type: "POST",
        url: "../interface/Product.ashx",
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
                        li = '<tr><td><div class="btn-group">';
                        if (msg.data[i].Status == "0") {
                            li = li + '<a name="upproduct" class="btn btn-xs btn-info" href="member_F_productadd.aspx?code=' + msg.data[i].ProductCode + '"><i class="icon-edit bigger-120"></i>';
                            li = li + '</a><a name="deleteproduct" class="btn btn-xs btn-danger"  onclick="DeleteProduct(\'' + msg.data[i].ProductCode + '\')"><i class="icon-trash bigger-120"></i></a></div></td>';
                        }
                        else {
                            li = li + '已经认证不能更新删除操作</div></td>';
                        }
                        li = li + '<td>' + msg.data[i].ProductCode + '</td>';
                        li = li + '<td>' + msg.data[i].ProductDes + '</td>';
                        li = li + '<td>' + msg.data[i].Length + 'M</td>';
                        li = li + '<td>' + msg.data[i].FactoryTypeName + '</td>';
                        if (msg.data[i].Status == "0") {
                            li = li + '<td>未认证</td>';
                        }
                        else if (msg.data[i].Status == "1") {
                            li = li + '<td>经销商认证</td>';
                        }
                        else if (msg.data[i].Status == "2") {
                            li = li + '<td>门店认证</td>';
                        }
                        else if (msg.data[i].Status == "3") {
                            li = li + '<td>使用完毕</td>';
                        }
                        if (msg.data[i].Dealer_Flag == 1) {
                            li = li + '<td>经销商认证审核通过</td>';
                        }
                        else if (msg.data[i].Dealer_Flag == 2) {
                            li = li + '<td>经销商认证审核未通过</td>';
                        }
                        else {
                            li = li + '<td>等待审核</td>';
                        }
                      /*  if (msg.data[i].Status == "1" || msg.data[i].Status == "2") {
                            li = li + '<td><input type="checkbox" name="a_dealer"  value="' + msg.data[i].ProductCode + '"/><select  id="Dealer_' + msg.data[i].ProductCode + '" name="Dealer_' + msg.data[i].ProductCode + '">';
                            li = li + '<option value=""></option>'
                            li = li + '<option value="1">认证审核通过</option>';
                            li = li + '<option value="2">认证审核未通过</option>';
                            li = li + '</select><input type="button"  value="审核" onclick="AuditProduct(\'' + msg.data[i].ProductCode + '\',\'dealer\')"/></td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        */
                        if (msg.data[i].Store_Flag == 1) {
                            li = li + '<td>门店认证审核通过</td>';
                        }
                        else if (msg.data[i].Store_Flag == 2) {
                            li = li + '<td>门店认证审核未通过</td>';
                        }
                        else {
                            li = li + '<td>等待审核</td>';
                        }

                    /*    if (msg.data[i].Status == "2") {
                            li = li + '<td><select  id="Store_' + msg.data[i].ProductCode + '" name="Store_' + msg.data[i].ProductCode + '">';
                            li = li + '<option value=""></option>'
                            li = li + '<option value="1">认证审核通过</option>';
                            li = li + '<option value="2">认证审核未通过</option>';
                            li = li + '</select><input type="button"  value="审核" onclick="AuditProduct(\'' + msg.data[i].ProductCode + '\',\'store\')"/></td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        */
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {

                    var lino = '<tr><td colspan="10">没有搜索到任何的数据</td></tr>';
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

                if ($("#ContentPlaceHolder1_deletepermission").val() != "true") {
                    $('a[name="deleteproduct"]').each(function () {
                        $(this).remove();
                    });
                }
                if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                    $('a[name="upproduct"]').each(function () {
                        $(this).remove();
                    });
                }
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
        }
    });
}
function SearchProduct() {
    $("#Pagination").html('');

    typeone = $("#ContentPlaceHolder1_typeone_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    dealer_flag = $("#ContentPlaceHolder1_Aud_Dealer").val();
    store_flag = $("#ContentPlaceHolder1_Aud_Store").val();
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


function DeleteProduct(id) {

    if (confirm("是否确认删除")) {

        var params = { Action: "F_DeleteProduct", Code: id };

        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
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
                else if (msg.errorcode == "1") {
                    alert('卷轴号已经认证，不能删除');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });

    }
}

function AuditProduct(id, action) {

    if (confirm("是否确认审核")) {
        var flag;
        if (action == 'dealer') {
            flag = $("#Dealer_" + id).val();
        }
        else {
            flag = $("#Store_" + id).val();
        }
        if (flag == "") {
            alert("请选择审核状态");
            return false;
        }
        var params = { Action: action, Code: id, Status: flag };

        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('审核成功！');
                    page_index = 0;
                    DoSearch(page_index);
                }
                else if (msg.errorcode == "-1") {
                    alert('参数传递不正确');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });

    }
}

function Allcheck()
{
    if ($(':input[type="checkbox"][name="all_dealer"]').prop("checked"))
    {
        $(':input[type="checkbox"][name="a_dealer"]').prop("checked", true);
    }
    else
    {
        $(':input[type="checkbox"][name="a_dealer"]').prop("checked", false);
    }
}
function AllAuditProduct() {

    if (confirm("是否确认审核")) {
        var flag;
        flag = $("#AudDealer").val();
    
        if (flag == "") {
            alert("请选择审核状态");
            return false;
        }
        var Code = ""
        $(':input[type="checkbox"][name="a_dealer"]').each(function () {
            if ($(this).prop("checked")) {
                Code = Code + $(this).val() + ",";
            }
        });
        if (Code == "") {
            alert("请选择审核项");
            return false;
        }
        var params = { Action: 'AllAud_dealer', Code: Code, Status: flag };

        $.ajax({
            type: "POST",
            url: "../interface/Product.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('审核成功！');
                    page_index = 0;
                    DoSearch(page_index);
                }
                else if (msg.errorcode == "-1") {
                    alert('参数传递不正确');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });

    }
}