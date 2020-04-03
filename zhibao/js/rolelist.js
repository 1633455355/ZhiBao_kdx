$(document).ready(function () {
    GetRole();
});

function GetRole()
{
    $("#tbcon").html('');
    var params = { Action: "GetRoleList" };

    $.ajax({
        type: "POST",
        url: "../interface/Role.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data.length > 0) {
                    total = msg.total;
                    for (var i = 0; i < msg.data.length; i++) {
                        //msg.data[i].RoleName
                        //msg.data[i].Permissions.length
                        var li = '';
                        li = li + '<tr><td><div class="btn-group"><a name="uprole" class="btn btn-xs btn-info" href="roleupdate.aspx?id=' + msg.data[i].RoleId + '"><i class="icon-edit bigger-120"></i></a><a name="deleterole" class="btn btn-xs btn-danger"  onclick="DeleteRole(' + msg.data[i].RoleId + ')"><i class="icon-trash bigger-120"></i></a></div></td>';
                        li = li + '<td>' + msg.data[i].RoleName + '</td>';

                        //用户管理
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++)
                        {
                            if (msg.data[i].Permissions[j].ModuleKey == "YHGL" && msg.data[i].Permissions[j].PermissionsId == "1")
                            {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "YHGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "YHGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "YHGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';
                        //资讯 ZXGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "ZXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "ZXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "ZXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "ZXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //反馈 FKXXGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "FKXXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "FKXXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "FKXXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "FKXXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';
                        //促销 CXHDGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "CXHDGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CXHDGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CXHDGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CXHDGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //消息 XXGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "XXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "XXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "XXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "XXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //产品 CPDMGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "CPDMGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPDMGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPDMGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPDMGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //角色 QXGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "QXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "QXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "QXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "QXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //车型 CXGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "CXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //报表 TJBBGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "TJBBGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "TJBBGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "TJBBGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "TJBBGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';
                        //客户 KHGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "KHGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "KHGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "KHGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "KHGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        //产品类型 CPLXGL
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "CPLXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPLXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPLXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPLXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';
                        

                        //产品认证管理
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "CPRZGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPRZGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPRZGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "CPRZGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';



                        //工厂产品类型
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "GCCPLXGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "GCCPLXGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "GCCPLXGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "GCCPLXGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }

                        //理赔管理
                        li = li + '<td><div class="btn-group">';
                        for (var j = 0; j < msg.data[i].Permissions.length; j++) {
                            if (msg.data[i].Permissions[j].ModuleKey == "LPGL" && msg.data[i].Permissions[j].PermissionsId == "1") {
                                li = li + '<span class="btn btn-xs btn-success"><i class="icon-plus bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "LPGL" && msg.data[i].Permissions[j].PermissionsId == "2") {
                                li = li + '<span class="btn btn-xs btn-info"><i class="icon-edit bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "LPGL" && msg.data[i].Permissions[j].PermissionsId == "3") {
                                li = li + '<span class="btn btn-xs btn-danger"><i class="icon-trash bigger-120"></i></span>';
                            }
                            if (msg.data[i].Permissions[j].ModuleKey == "LPGL" && msg.data[i].Permissions[j].PermissionsId == "4") {
                                li = li + '<span class="btn btn-xs btn-warning"><i class="icon-list bigger-120"></i></span>';
                            }
                        }
                        li = li + '</div></td>';

                        $("#tbcon").append(li);
                    }
                }

                if (total == 0) {
                    var lino = '<tr><td colspan="4">暂时没有任何权限列表</td></tr>';
                    $("#tbcon").append(lino);
                }
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }

            if ($("#ContentPlaceHolder1_deletepermission").val() != "true") {
                $('a[name="deleterole"]').each(function () {
                    $(this).remove();
                });
            }
            if ($("#ContentPlaceHolder1_updatepermission").val() != "true") {
                $('a[name="uprole"]').each(function () {
                    $(this).remove();
                });
            }
        }
    });
}

function DeleteRole(id) {

    if (confirm("是否确认删除")) {

        var params = { Action: "DeleteRole", ID: id };

        $.ajax({
            type: "POST",
            url: "../interface/Role.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                var total = 0;
                if (msg.errorcode == "0") {
                    alert('删除成功！');
                    GetRole();
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    }

}