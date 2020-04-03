var firstType = "";
var brand = "";
var code = "";
var dealer = "";
var store = "";

var items_per_page = 10;
var page_index = 0;



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
                        $('#ContentPlaceHolder1_typetwo_ddl').chosen({ allow_single_deselect: true });
                    }
                }
            });
        }
    });

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

function DoSearch(page_index)
{
    $("#tbcon").html('');

    var params = {
        Action: "SearchUser",
        Page: encodeURIComponent(page_index),
        Item: encodeURIComponent(items_per_page),
        Code: encodeURIComponent(code),
        FirstType: encodeURIComponent(firstType),
        Brand: encodeURIComponent(brand),
        Dealer: encodeURIComponent(dealer),
        Store: encodeURIComponent(store)
    };

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
                        var li = '<tr>';
                        if (msg.type == "Managers") {
                            li = li + '<td><div class="btn-group"><a name="deleterole" class="btn btn-xs btn-danger"  onclick="DeleteProduct(' + msg.data[i].UserId + ')"><i class="icon-trash bigger-120"></i></a></div></td>';
                            li = li + '<td>' + msg.data[i].DealerName + '</td>';

                            li = li + '<td>' + msg.data[i].StoreName + '</td>';

                        }
                        else if (msg.type == "Dealer") {
                        
                            li = li + '<td>' + msg.data[i].StoreName + '</td>';
                        }
                      
                        li = li + '<td>' + msg.data[i].F_ProductTypeName + '</td>';
                        li = li + '<td>' + msg.data[i].S_ProductTypeName + '</td>';
                        li = li + '<td>' + msg.data[i].ProductCode + '</td>';

                        if (msg.data[i].F_ProductTypeId == 1) {
                            if (msg.data[i].IsQuanCare == 1) {
                                li = li + '<td>全车</td>';
                            }
                            else if (msg.data[i].IsQuanCare == 2) {
                                li = li + '<td>单车</td>';
                            }
                            else if (msg.data[i].IsQuanCare == 3) {
                                li = li + '<td>单车含侧挡</td>';
                            }
                            else {
                                li = li + '<td>否</td>';
                            }
                        }
                        else {
                            li = li + '<td></td>';
                        }
                    
                        li = li + '<td>' + msg.data[i].UserName + '</td>';
                        li = li + '<td>' + msg.data[i].Mobile + '</td>';
                        if (msg.data[i].Email != null && msg.data[i].Email != "null") {
                            li = li + '<td>' + msg.data[i].Email + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        

                        if (msg.data[i].CarBrandCodeName != null && msg.data[i].CarBrandCodeName != "null") {
                            li = li + '<td>' + msg.data[i].CarBrandCodeName + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].CarSysteName != null && msg.data[i].CarSysteName != "null") {
                            li = li + '<td>' + msg.data[i].CarSysteName + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].CarTypeName != null && msg.data[i].CarTypeName != "null") {
                            li = li + '<td>' + msg.data[i].CarTypeName + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        
                        
                        li = li + '<td>' + msg.data[i].Lincence + '</td>';


                        if (msg.data[i].ProvinceName != null && msg.data[i].ProvinceName != "null") {
                            li = li + '<td>' + msg.data[i].ProvinceName + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }
                        if (msg.data[i].CityName != null && msg.data[i].CityName != "null") {
                            li = li + '<td>' + msg.data[i].CityName + '</td>';
                        }
                        else {
                            li = li + '<td></td>';
                        }

                        li = li + '<td>' + msg.data[i].Price + '</td>';
                        if (msg.data[i].Type == "1") { li = li + '<td>机头盖</td>'; }
                        else if (msg.data[i].Type == "2") { li = li + '<td>单侧前（左/右）叶子板</td>'; }
                        else if (msg.data[i].Type == "3") { li = li + '<td>单侧后（左/右）叶子板</td>'; }
                        else if (msg.data[i].Type == "4") { li = li + '<td>单车门（左前/左后/右前/右后）</td>'; }
                        else if (msg.data[i].Type == "5") { li = li + '<td>车顶</td>'; }
                        else if (msg.data[i].Type == "6") { li = li + '<td>车后备箱</td>'; }
                        else if (msg.data[i].Type == "7") { li = li + '<td>群边（左下/右下）</td>'; }
                        else if (msg.data[i].Type == "8") { li = li + '<td>保险杠（前杠/后杠）</td>'; }
                        else if (msg.data[i].Type == "9") { li = li + '<td>B柱 </td>'; }
                        else if (msg.data[i].Type == "10") { li = li + '<td>倒后镜</td>'; }
                        else if (msg.data[i].Type == "11") { li = li + '<td>整车</td>'; }
                        else { li = li + '<td></td>'; }
                        if (msg.data[i].Remark == null) {
                            li = li + '<td></td>';
                        }
                        else {
                            li = li + '<td>' + msg.data[i].Remark + '</td>';
                        }
                        li = li + '<td>' + ChangeDateFormat(msg.data[i].CreateTime) + '</td>';
                        
                        li = li+'</tr>';                        
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    
                    var lino = '';
                    if (msg.type == "Managers") {
                        lino = '<tr><td colspan="18">没有搜索到任何的数据</td></tr>';
                    }
                    else {
                        lino = '<tr><td colspan="18">没有搜索到任何的数据</td></tr>';
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
            else if(msg.errorcode == "-10")
            {
                alert('无权限');
            }
        }
    });
}
function SearchProduct()
{
    $("#Pagination").html('');
    firstType = $("#ContentPlaceHolder1_typeone_ddl").val();
    brand = $("#ContentPlaceHolder1_typetwo_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    dealer = typeof($("#ContentPlaceHolder1_dealer_ddl").val()) == 'undefined' ? "" : $("#ContentPlaceHolder1_dealer_ddl").val();
    store = typeof ($("#ContentPlaceHolder1_store_ddl").val()) == 'undefined' ? "" : $("#ContentPlaceHolder1_store_ddl").val();
    DoSearch(page_index);
}
function pageselectCallbackVideo(page_index, jq) {
    DoSearch(page_index);
};
function ChangeDateFormat(time) {
    if (time != null) {
        var strs = new Array();
        strs = time.split("T");
        if (strs[0] == "0001-01-01")
        {
            return "";
        }
        else
        {
            return strs[0];
        }
    }
    return "";
};


function DeleteProduct(id) {
    if (confirm("是否确认删除")) {
        var params = { Action: "DeleteUser", ID: id };

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
                else if (msg.errorcode == "-2") {
                    alert('参数不正确，请联系管理员！');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
                else {
                    alert('系统异常，请联系管理员！');
                }
            }
        });
    }
}

function ImportUser() {
    firstType = $("#ContentPlaceHolder1_typeone_ddl").val();
    brand = $("#ContentPlaceHolder1_typetwo_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    dealer = typeof ($("#ContentPlaceHolder1_dealer_ddl").val()) == 'undefined' ? "" : $("#ContentPlaceHolder1_dealer_ddl").val();
    store = typeof ($("#ContentPlaceHolder1_store_ddl").val()) == 'undefined' ? "" : $("#ContentPlaceHolder1_store_ddl").val();

    
    window.open("userexport.aspx?Code=" + encodeURIComponent(code) + "&FirstType=" + encodeURIComponent(firstType) + "&Brand=" + encodeURIComponent(brand) + "&Dealer=" + encodeURIComponent(dealer) + "&Store=" + encodeURIComponent(store));
}