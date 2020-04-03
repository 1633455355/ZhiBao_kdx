var typeone = "";
var typetwo = "";
var status = "";
var code = "";
var dealer = "";
var store = "";
var dealer_flag = "";
var store_flag = "";

var items_per_page = 10;
var page_index = 0;
if ($("#ContentPlaceHolder1_userstatus").val() == "store") {
    $("#ADealer").hide();
    $("#tbheader").html('<tr><th>操作</th><th>类别</th><th>品牌型号</th><th>状态</th><th>卷轴号</th><th>门店名称</th><th>门店认证时间</th><th>质保年限</th><th>门店是否审核通过</th>');
}
else if ($("#ContentPlaceHolder1_userstatus").val() == "dealer") {
    $("#tbheader").html('<tr><th>操作</th><th>类别</th><th>品牌型号</th><th>状态</th><th>卷轴号</th><th>经销商名称</th><th>经销商认证时间</th><th>门店名称</th><th>门店认证时间</th><th>质保年限</th><th>经销商是否审核通过</th><th>门店是否审核通过</th><th>门店审核操作（<input type="checkbox" name="all_Store" onclick="AllStorecheck();" Id="all_Store"/>全选   <select  id="AudStore" name="AudStore"><option value=""></option><option value="1">认证审核通过</option><option value="2">认证审核未通过</option></select><input type="button"  value="批量审核" onclick="AllAuditStoreProduct()"/>）</th></tr>');
}
else{ 
    $("#tbheader").html('<tr><th>操作</th><th>类别</th><th>品牌型号</th><th>状态</th><th>卷轴号</th><th>经销商名称</th><th>经销商认证时间</th><th>门店名称</th><th>门店认证时间</th><th>质保年限</th><th>是否审核通过</th><th>经销商审核操作（<input type="checkbox" name="all_dealer" onclick="AllDealercheck();" Id="a_dealer"/>全选   <select  id="AudDealer" name="AudDealer"><option value=""></option><option value="1">认证审核通过</option><option value="2">认证审核未通过</option></select><input type="button"  value="批量审核" onclick="AllAuditDealerProduct()"/>）</th><th>门店是否审核通过</th><th>门店审核操作（<input type="checkbox" name="all_Store" onclick="AllStorecheck();" Id="all_Store"/>全选   <select  id="AudStore" name="AudStore"><option value=""></option><option value="1">认证审核通过</option><option value="2">认证审核未通过</option></select><input type="button"  value="批量审核" onclick="AllAuditStoreProduct()"/>）</th></tr>');
}

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
                        $("#ContentPlaceHolder1_typetwo_ddl").trigger("chosen:updated");
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
    var type=$("#ContentPlaceHolder1_userstatus").val();
    if (type == "store") {
        $("#tbheader").html('<tr><th>操作</th><th>类别</th><th>品牌型号</th><th>状态</th><th>卷轴号</th><th>门店名称</th><th>门店认证时间</th><th>质保年限</th><th>门店是否审核通过</th></tr>');
    }
    else if (type == "dealer") {
        $("#tbheader").html('<tr><th>操作</th><th>类别</th><th>品牌型号</th><th>状态</th><th>卷轴号</th><th>经销商名称</th><th>经销商认证时间</th><th>门店名称</th><th>门店认证时间</th><th>质保年限</th><th>经销商是否审核通过</th><th>门店是否审核通过</th><th>门店审核操作（<input type="checkbox" name="all_Store" onclick="AllStorecheck();" Id="all_Store"/>全选   <select  id="AudStore" name="AudStore"><option value=""></option><option value="1">认证审核通过</option><option value="2">认证审核未通过</option></select><input type="button"  value="批量审核" onclick="AllAuditStoreProduct()"/>）</th></tr>');
    }
    else {
        $("#tbheader").html('<tr><th>操作</th><th>类别</th><th>品牌型号</th><th>状态</th><th>卷轴号</th><th>经销商名称</th><th>经销商认证时间</th><th>门店名称</th><th>门店认证时间</th><th>质保年限</th><th>经销商是否审核通过</th><th>经销商审核操作（<input type="checkbox" name="all_dealer" onclick="AllDealercheck();" Id="all_dealer"/>全选   <select  id="AudDealer" name="AudDealer"><option value=""></option><option value="1">认证审核通过</option><option value="2">认证审核未通过</option></select><input type="button"  value="批量审核" onclick="AllAuditDealerProduct()"/>）</th><th>门店是否审核通过</th><th>门店审核操作（<input type="checkbox" name="all_Store" onclick="AllStorecheck();" Id="all_Store"/>全选   <select  id="AudStore" name="AudStore"><option value=""></option><option value="1">认证审核通过</option><option value="2">认证审核未通过</option></select><input type="button"  value="批量审核" onclick="AllAuditStoreProduct()"/>）</th></tr>');
    }
    var params = {
        Action: "SearchProduct",
        Page: encodeURIComponent(page_index),
        Item: encodeURIComponent(items_per_page),
        TypeOne: encodeURIComponent(typeone),
        TypeTwo: encodeURIComponent(typetwo),
        Status: encodeURIComponent(status),
        Code: encodeURIComponent(code),
        Dealer: dealer,
        Store: store,
        dealer_flag: dealer_flag,
        store_flag: store_flag
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
                        if ((type == "dealer" && msg.data[i].Dealer_Flag == 2) || (type == "store" && msg.data[i].Store_Flag == 2))
                        {

                            li = li + '<td><a class="btn btn-xs btn-danger"  onclick="DeleteProduct(\'' + msg.data[i].ProductCode + '\')"><i class="icon-trash bigger-120"></i></a><a name="upproduct" class="btn btn-xs btn-info" href="productverify.aspx?code=' + msg.data[i].ProductCode + '"><i class="icon-edit bigger-120"></i></a></td>';
                        }
                        else
                        {
                            li = li + '<td></td>';
                        }
                        li = li + '<td>' + msg.data[i].ProductFirstLevelName + '</td>';
                        li = li + '<td>' + msg.data[i].ProductSecondLevelName + '</td>';

                        if (msg.data[i].Status == "0")
                        {
                            li = li + '<td>未认证</td>';
                        }
                        else if (msg.data[i].Status == "1")
                        {
                            li = li + '<td>经销商认证</td>';
                        }
                        else if (msg.data[i].Status == "2")
                        {
                            li = li + '<td>门店认证</td>';
                        }
                        else if (msg.data[i].Status == "3") {
                            li = li + '<td>使用完毕</td>';
                        }
                        
                        li = li + '<td>' + msg.data[i].ProductCode + '</td>';


                        if (type != "store")
                        {
                            if (msg.data[i].DealerName == null || msg.data[i].DealerName == "null")
                            {
                                li = li + '<td></td>';
                            }
                            else
                            {
                                li = li + '<td>' +msg.data[i].DealerName + '</td>';
                            }
                        
                            li = li + '<td>' + ChangeDateFormat(msg.data[i].Dealer_CreateTime) + '</td>';
                        }

                        if (msg.data[i].StoreName == null || msg.data[i].StoreName == "null") {
                            li = li + '<td></td>';
                        } else {
                            li = li + '<td>' + msg.data[i].StoreName + '</td>';
                        }
                        li = li + '<td>' + ChangeDateFormat(msg.data[i].Store_CreateTime) + '</td>';
                        li = li + '<td>' + msg.data[i].ProductDes + '</td>';
                        if (type != 'store') {
                            if (msg.data[i].Dealer_Flag == 1) {
                                li = li + '<td>经销商认证审核通过</td>';
                            }
                            else if (msg.data[i].Dealer_Flag == 2) {
                                li = li + '<td>经销商认证审核未通过</td>';
                            }
                            else {
                                li = li + '<td>等待审核</td>';
                            }
                        }
                        if (type == 'managers') {
                            if (msg.data[i].Status == "1" || msg.data[i].Status == "2") {
                                li = li + '<td><input type="checkbox" name="a_dealer"  value="' + msg.data[i].ProductCode + '"/><select  id="Dealer_' + msg.data[i].ProductCode + '" name="Dealer_' + msg.data[i].ProductCode + '">';
                                li = li + '<option value=""></option>'
                                li = li + '<option value="1">认证审核通过</option>';
                                li = li + '<option value="2">认证审核未通过</option>';
                                li = li + '</select><input type="button"  value="审核" onclick="AuditProduct(\'' + msg.data[i].ProductCode + '\',\'dealer\')"/></td>';
                            }
                            else {
                                li = li + '<td></td>';
                            }
                        }
                        if (msg.data[i].Store_Flag == 1) {
                            li = li + '<td>门店认证审核通过</td>';
                        }
                        else if (msg.data[i].Store_Flag == 2) {
                            li = li + '<td>门店认证审核未通过</td>';
                        }
                        else {
                            li = li + '<td>等待审核</td>';
                        }
                        if (type == 'managers'|| type == 'dealer') {
                            if (msg.data[i].Status == "2") {
                                li = li + '<td><input type="checkbox" name="a_store"  value="' + msg.data[i].ProductCode + '"/><select  id="Store_' + msg.data[i].ProductCode + '" name="Store_' + msg.data[i].ProductCode + '">';
                                li = li + '<option value=""></option>'
                                li = li + '<option value="1">认证审核通过</option>';
                                li = li + '<option value="2">认证审核未通过</option>';
                                li = li + '</select><input type="button"  value="审核" onclick="AuditProduct(\'' + msg.data[i].ProductCode + '\',\'store\')"/></td>';
                            }
                            else {
                                li = li + '<td></td>';
                            }
                        }
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    
                    var lino = '<tr><td colspan="14">没有搜索到任何的数据</td></tr>';
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
                     //   $(this).remove();
                    });
                }
                if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                    $('a[name="upproduct"]').each(function () {
                       // $(this).remove();
                    });
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

    typeone = $("#ContentPlaceHolder1_typeone_ddl").val();
    typetwo = $("#ContentPlaceHolder1_typetwo_ddl").val();
    status = $("#ContentPlaceHolder1_status_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    dealer = $("#ContentPlaceHolder1_dealer_ddl").val();
    store = $("#ContentPlaceHolder1_store_ddl").val();

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

        var params = { Action: "DelProductVerify", Code: id };

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
                else if (msg.errorcode == "-1") {
                    alert('参数有异常！');
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
        if (action == 'dealer')
        {
            flag = $("#Dealer_" + id).val();
        }
        else
        {
            flag = $("#Store_" + id).val();
        }
        if (flag == "")
        {
            alert("请选择审核状态");
            return false;
        }
        var params = { Action: action, Code: id,Status:flag };

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
function AllDealercheck() {
    if ($(':input[type="checkbox"][name="all_dealer"]').prop("checked")) {
        $(':input[type="checkbox"][name="a_dealer"]').prop("checked", true);
    }
    else {
        $(':input[type="checkbox"][name="a_dealer"]').prop("checked", false);
    }
}

function AllStorecheck() {
    if ($(':input[type="checkbox"][name="all_Store"]').prop("checked")) {
        $(':input[type="checkbox"][name="a_store"]').prop("checked", true);
    }
    else {
        $(':input[type="checkbox"][name="a_store"]').prop("checked", false);
    }
}
function AllAuditDealerProduct() {

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

function AllAuditStoreProduct() {

    if (confirm("是否确认审核")) {
        var flag;
        flag = $("#AudStore").val();

        if (flag == "") {
            alert("请选择审核状态");
            return false;
        }
        var Code = ""
        $(':input[type="checkbox"][name="a_store"]').each(function () {
            if ($(this).prop("checked")) {
                Code = Code + $(this).val() + ",";
            }
        });
        if (Code == "")
        {
            alert("请选择审核项");
            return false;
        }
        var params = { Action: 'AllAud_store', Code: Code, Status: flag };

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
function ImportProduct() {
    typeone = $("#ContentPlaceHolder1_typeone_ddl").val();
    typetwo = $("#ContentPlaceHolder1_typetwo_ddl").val();
    status = $("#ContentPlaceHolder1_status_ddl").val();
    code = $("#ContentPlaceHolder1_code_txt").val();
    dealer = $("#ContentPlaceHolder1_dealer_ddl").val();

    store = $("#ContentPlaceHolder1_store_ddl").val();
    dealer_flag = $("#ContentPlaceHolder1_Aud_Dealer").val();
    store_flag = $("#ContentPlaceHolder1_Aud_Store").val();

    window.open("productexport.aspx?TypeOne=" + encodeURIComponent(typeone) + "&TypeTwo=" + encodeURIComponent(typetwo) + "&Status=" + encodeURIComponent(status) + "&Code=" + encodeURIComponent(code) + "&Dealer=" + encodeURIComponent(dealer) + "&Store=" + encodeURIComponent(store) + "&dealer_flag=" + encodeURIComponent(dealer_flag) + "&store_flag=" + encodeURIComponent(store_flag));
}