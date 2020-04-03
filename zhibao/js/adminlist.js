var username = "";
var relation = "";
var role = "";
var name = "";
var dealer = "";

var items_per_page = 10;
var page_index = 0;

$(document).ready(function () {

    $('#ContentPlaceHolder1_relastion_ddl').bind('change', function () {

        if ($('#ContentPlaceHolder1_relastion_ddl').val() == "admin") {
            $("#dealerdiv").hide();
            $("#storediv").hide();
        }
        else if ($('#ContentPlaceHolder1_relastion_ddl').val() == "dealer")
        {
            $("#dealerdiv").show();
            $("#storediv").hide();
            $("#ContentPlaceHolder1_name_txt").val('');
            $("#ContentPlaceHolder1_dealer_ddl").val('');
        }
        else if ($('#ContentPlaceHolder1_relastion_ddl').val() == "store")
        {
            $("#dealerdiv").show();
            $("#storediv").show();
            $("#ContentPlaceHolder1_name_txt").val('');
            $("#ContentPlaceHolder1_dealer_ddl").val('');
        }
    });
});

function DoSearch(page_index)
{
    $("#tbheader").empty();
    if (relation == "admin")
    {
        $("#tbheader").append('<tr><th>操作</th><th>用户名</th><th>用户类型</th><th>角色</th><th>状态</th></tr>');
    }
    else if (relation == "dealer")
    {
        $("#tbheader").append('<tr><th>操作</th><th>用户名</th><th>用户类型</th><th>角色</th><th>状态</th><th>名称</th><th>联系人</th><th>职位</th><th>电话</th><th>手机</th><th>传真</th><th>省</th><th>市</th><th>地址</th><th>邮编</th><th>邮箱</th></tr>');
    }
    else if (relation == "store")
    {
        $("#tbheader").append('<tr><th>操作</th><th>用户名</th><th>用户类型</th><th>角色</th><th>状态</th><th>名称</th><th>联系人</th><th>职位</th><th>电话</th><th>手机</th><th>传真</th><th>省</th><th>市</th><th>地址</th><th>邮编</th><th>邮箱</th><th>所属经销商</th></tr>');
    }

    $("#tbcon").html('');

    var params = { Action: "SearchAdmin", Page: encodeURIComponent(page_index), Item: encodeURIComponent(items_per_page), Username: encodeURIComponent(username), Relastion: encodeURIComponent(relation), Role: encodeURIComponent(role), Name: encodeURIComponent(name), Dealer: encodeURIComponent(dealer) };

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
                        if (relation == "admin") {
                            li = '<tr><td><div class="btn-group"><a class="btn btn-xs btn-info" href="adminupdate.aspx?id=' + msg.data[i].AdminId + '"><i class="icon-edit bigger-120"></i></a>';
                            
                            if (msg.data[i].Status == true) {
                                li = li + '<a class="btn btn-xs btn-danger"  onclick="DeleteAdmin(' + msg.data[i].AdminId + ')"><i class="icon-trash bigger-120"></i></a>';
                            }

                            li=li+'</div></td>';
                            li = li + '<td>' + msg.data[i].AdminName + '</td>';
                            li = li + '<td>管理员</td>';
                            li = li + '<td>' + msg.data[i].Role.RoleName + '</td>';

                            if (msg.data[i].Status == true)
                            {
                                li = li + '<td>正常</td>';
                            }
                            else
                            {
                                li = li + '<td style="color:red">禁止登陆</td>';
                            }
                            

                        }
                        else if (relation == "dealer") {
                            li = '<tr><td><div class="btn-group"><a class="btn btn-xs btn-info" href="adminupdate.aspx?id=' + msg.data[i].AdminId + '"><i class="icon-edit bigger-120"></i></a>';

                            if (msg.data[i].Status == true) {
                                li = li + '<a class="btn btn-xs btn-danger"  onclick="DeleteAdmin(' + msg.data[i].AdminId + ')"><i class="icon-trash bigger-120"></i></a>';
                            }

                            li = li + '</div></td>';


                            li = li + '<td>' + msg.data[i].AdminName + '</td>';
                            li = li + '<td>经销商</td>';
                            li = li + '<td>' + msg.data[i].Role.RoleName + '</td>';

                            if (msg.data[i].Status == true) {
                                li = li + '<td>正常</td>';
                            }
                            else {
                                li = li + '<td style="color:red">禁止登陆</td>';
                            }

                            li = li + '<td>' + msg.data[i].Dealer.DealerCompanyName + '</td>>';
                            li = li + '<td>' + msg.data[i].Dealer.Contacts + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Position + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Phone + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Mobile + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Fax + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.ProvinceName + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.CityName + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Address + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Zip + '</td>';
                            li = li + '<td>' + msg.data[i].Dealer.Email + '</td></tr>';
                        }
                        else if (relation == "store") {
                            li = '<tr><td><div class="btn-group"><a class="btn btn-xs btn-info" href="adminupdate.aspx?id=' + msg.data[i].AdminId + '"><i class="icon-edit bigger-120"></i></a>';

                            if (msg.data[i].Status == true) {
                                li = li + '<a class="btn btn-xs btn-danger"  onclick="DeleteAdmin(' + msg.data[i].AdminId + ')"><i class="icon-trash bigger-120"></i></a>';
                            }

                            li = li + '</div></td>';

                            li = li + '<td>' + msg.data[i].AdminName + '</td>';
                            li = li + '<td>门店</td>';
                            li = li + '<td>' + msg.data[i].Role.RoleName + '</td>';

                            if (msg.data[i].Status == true) {
                                li = li + '<td>正常</td>';
                            }
                            else {
                                li = li + '<td style="color:red">禁止登陆</td>';
                            }
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
                            li = li + '<td>' + msg.data[i].Store.DealerCompanyName + '</td></tr>';
                        }

                        
                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    if (relation == "admin") {
                        var lino = '<tr><td colspan="5">没有搜索到任何的数据</td></tr>';
                    }
                    else if (relation == "dealer") {
                        var lino = '<tr><td colspan="16">没有搜索到任何的数据</td></tr>';
                    }
                    else if (relation == "store") {
                        var lino = '<tr><td colspan="17">没有搜索到任何的数据</td></tr>';
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
function SearchAdmin()
{
    $("#Pagination").html('');
    username = $("#ContentPlaceHolder1_username_txt").val().Trim();
    relation = $("#ContentPlaceHolder1_relastion_ddl").val();
    role = $("#ContentPlaceHolder1_role_ddl").val();
    name = $("#ContentPlaceHolder1_name_txt").val();
    dealer = $("#ContentPlaceHolder1_dealer_ddl").val();

    DoSearch(page_index);
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

function DeleteAdmin(id)
{
    if (confirm("是否确认删除")) {

        var params = { Action: "DeleteAdmin", ID: id };

        $.ajax({
            type: "POST",
            url: "../interface/Admin.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('禁止登陆成功！');
                    $("#tbcon").html('');
                    DoSearch(page_index);
                    $("#Pagination").html('');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }
}

function ImportAdmin() {
    username = $("#ContentPlaceHolder1_username_txt").val().Trim();
    relation = $("#ContentPlaceHolder1_relastion_ddl").val();
    role = $("#ContentPlaceHolder1_role_ddl").val();
    name = $("#ContentPlaceHolder1_name_txt").val();
    dealer = $("#ContentPlaceHolder1_dealer_ddl").val();
    window.open("adminexport.aspx?Username=" + username + "&Relastion=" + relation + "&Role=" + role + "&Name=" + name + "&Dealer=" + dealer);
}