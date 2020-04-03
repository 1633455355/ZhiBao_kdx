function PasswordChange()
{
    $("#divoldpwd").removeClass("has-error");
    $("#oldpwderr").html("");
    $("#divnewpwd").removeClass("has-error");
    $("#newpwderr").html("");
    $("#divconpwd").removeClass("has-error");
    $("#conpwderr").html("");

    var oldpwd = $("#old_pwd_txt").val().Trim();
    var newpwd = $("#new_pwd_txt").val().Trim();
    var conpwd = $("#con_pwd_txt").val().Trim();
    var flag = true;
    if (oldpwd == "")
    {
        flag = false;
        $("#divoldpwd").addClass("has-error");
        $("#oldpwderr").html("请输入旧密码");
    }

    if (newpwd == "") {
        flag = false;
        $("#divnewpwd").addClass("has-error");
        $("#newpwderr").html("请输入新密码");
    }

    if (conpwd == "") {
        flag = false;
        $("#divconpwd").addClass("has-error");
        $("#conpwderr").html("请输入确认密码");
    }

    if (flag && newpwd.length < 5)
    {
        flag = false;
        $("#divnewpwd").addClass("has-error");
        $("#newpwderr").html("密码长度至少6位");
    }

    if (flag &&  conpwd.length < 5) {
        flag = false;
        $("#divconpwd").addClass("has-error");
        $("#conpwderr").html("密码长度至少6位");
    }

    if (flag && newpwd != "" && conpwd != "")
    {
        if (newpwd != conpwd)
        {
            flag = false;
            $("#divnewpwd").addClass("has-error");
            $("#newpwderr").html("新密码和确认密码不相同");

            $("#divconpwd").addClass("has-error");
            $("#conpwderr").html("新密码和确认密码不相同");
        }
    }

    if (flag)
    {
        var params = { Action: "PasswordChange", Old: encodeURIComponent(oldpwd), New: encodeURIComponent(newpwd), Con: encodeURIComponent(conpwd) };

        $.ajax({
            type: "POST",
            url: "../interface/Admin.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('更新成功！');
                    $("#divoldpwd").removeClass("has-error");
                    $("#oldpwderr").html("");
                    $("#divnewpwd").removeClass("has-error");
                    $("#newpwderr").html("");
                    $("#divconpwd").removeClass("has-error");
                    $("#conpwderr").html("");
                }
                else if (msg.errorcode == "-2") {
                    $("#divoldpwd").addClass("has-error");
                    $("#oldpwderr").html("旧密码不对");
                }
                else {
                    alert('异常！');
                }
            }
        });
    }
}
