function Login()
{
    $("#usernamediv").removeClass('has-error');
    $("#pwddiv").removeClass('has-error');
    $("#username_err").html('');
    $("#pwd_err").html('');
    var flag = true;
    var username=$("#username_txt").val().Trim();
    var pwd=$("#pwd_txt").val().Trim();
    if (username == "")
    {
        flag = false;
        $("#username_err").html('请输入用户名');
        $("#usernamediv").addClass('has-error');
    }
    if (pwd == "")
    {
        flag = false;
        $("#pwd_err").html('请输入密码');
        $("#pwddiv").addClass('has-error');
    }
    if (flag) {
        return true;
    }
    else {
        return false;
    }
}