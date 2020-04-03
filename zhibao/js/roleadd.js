
$(document).ready(function () {

    
});

function RoleAdd()
{
    $("#divtitle").removeClass("has-error");
    $("#titleerr").html("");
    $("#divcontent").removeClass("has-error");
    $("#contenterr").html('');

    var flag = true;
    var title = $("#title_txt").val().Trim();
    if (title == "")
    {
        flag = false;
        $("#divtitle").addClass("has-error");
        $("#titleerr").html("请输入角色名称");
    }

    var XXGL = ""; //消息
    $(':input[type="checkbox"][name="XXGL"]').each(function () {
        if($(this).prop("checked") )
        {
            XXGL = XXGL + $(this).val() + ",";
        }
    });

    var ZXGL = "";//资讯
    $(':input[type="checkbox"][name="ZXGL"]').each(function () {
        if ($(this).prop("checked")) {
            ZXGL = ZXGL + $(this).val() + ",";
        }
    });

    var CXHDGL = "";//促销
    $(':input[type="checkbox"][name="CXHDGL"]').each(function () {
        if ($(this).prop("checked")) {
            CXHDGL = CXHDGL + $(this).val() + ",";
        }
    });
    
    var YHGL = "";//用户
    $(':input[type="checkbox"][name="YHGL"]').each(function () {
        if ($(this).prop("checked")) {
            YHGL = YHGL + $(this).val() + ",";
        }
    });

    var FKXXGL = "";//反馈
    $(':input[type="checkbox"][name="FKXXGL"]').each(function () {
        if ($(this).prop("checked")) {
            FKXXGL = FKXXGL + $(this).val() + ",";
        }
    });

    var QXGL = "";//角色
    $(':input[type="checkbox"][name="QXGL"]').each(function () {
        if ($(this).prop("checked")) {
            QXGL = QXGL + $(this).val() + ",";
        }
    });

    var CXGL = "";//车型管理
    $(':input[type="checkbox"][name="CXGL"]').each(function () {
        if ($(this).prop("checked")) {
            CXGL = CXGL + $(this).val() + ",";
        }
    });

    var CPDMGL = "";//产品管理
    $(':input[type="checkbox"][name="CPDMGL"]').each(function () {
        if ($(this).prop("checked")) {
            CPDMGL = CPDMGL + $(this).val() + ",";
        }
    });


    var GCCPLXGL = "";//工厂产品管理
    $(':input[type="checkbox"][name="GCCPLXGL"]').each(function () {
        if ($(this).prop("checked")) {
            GCCPLXGL = GCCPLXGL + $(this).val() + ",";
        }
    });


    var TJBBGL = "";//报表管理
    $(':input[type="checkbox"][name="TJBBGL"]').each(function () {
        if ($(this).prop("checked")) {
            TJBBGL = TJBBGL + $(this).val() + ",";
        }
    });

    var KHGL = "";//用户管理
    $(':input[type="checkbox"][name="KHGL"]').each(function () {
        if ($(this).prop("checked")) {
            KHGL = KHGL + $(this).val() + ",";
        }
    });

    var CPLXGL = ""; //产品类型管理
    $(':input[type="checkbox"][name="CPLXGL"]').each(function () {
        if ($(this).prop("checked")) {
            CPLXGL = CPLXGL + $(this).val() + ",";
        }
    });

    var CPRZGL = ""; //产品认证管理
    $(':input[type="checkbox"][name="CPRZGL"]').each(function () {
        if ($(this).prop("checked")) {
            CPRZGL = CPRZGL + $(this).val() + ",";
        }
    });

    var LPGL = ""; //理赔管理
    $(':input[type="checkbox"][name="LPGL"]').each(function () {
        if ($(this).prop("checked")) {
            LPGL = LPGL + $(this).val() + ",";
        }
    });


    if (XXGL == "" && ZXGL == "" && CXHDGL == "" && YHGL == "" && FKXXGL == "" && QXGL == "" && CXGL == "" && CPDMGL == "" && TJBBGL == "" && KHGL == "" && CPLXGL == "" && CPRZGL == "" && GCCPLXGL == "" && LPGL=="")
    {
        flag = false;
        $("#divcontent").addClass("has-error");
        $("#contenterr").html('请至少选择一个权限');
    }
    if (flag) {

        var params = { Action: "RoleAdd", Title: $("#title_txt").val(), XXGL: XXGL, ZXGL: ZXGL, CXHDGL: CXHDGL, YHGL: YHGL, FKXXGL: FKXXGL, QXGL: QXGL, CXGL: CXGL, CPDMGL: CPDMGL, TJBBGL: TJBBGL, KHGL: KHGL, CPLXGL: CPLXGL, CPRZGL: CPRZGL, GCCPLXGL: GCCPLXGL, LPGL: LPGL };

        $.ajax({
            type: "POST",
            url: "../interface/Role.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('添加成功！');
                    Reset();
                }
                else if (msg.errorcode == "-10")
                {
                    alert('无权限');
                }
            }
        });
    }   
}
function Reset()
{
    $("#title_txt").val('');
    $(':input[type="checkbox"]').each(function () {
        $(this).prop("checked", false);
    });
}