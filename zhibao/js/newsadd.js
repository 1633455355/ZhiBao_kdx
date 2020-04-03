var ue = UE.getEditor('editor');

$(document).ready(function () {

});

function checkadd()
{

    $("#divtitle").removeClass('has-error');
    $("#divcontact").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divcontent").removeClass('has-error');

    $("#titleerr").html('');
    $("#contacterr").html('');
    $("#contenterr").html('');
    $("#editor").css("border", "0px");


    var flag = true;
    var title = $("#title_txt").val().Trim();
    if (title == "")
    {
        flag = false;
        $("#divtitle").addClass("has-error");
        $("#titleerr").html("请输入标题");
    }

    var content = UE.getEditor('editor').getContent();

    if (content == "")
    {
        $("#divcontent").addClass("has-error");
        $("#editor").css("border", "1px solid #f09784");
        $("#contenterr").html('请输入内容');
        flag = false;
    }
    
    if (flag)
    { 
        var params = { Action: "NewsAdd", Title: encodeURIComponent(title), Content: encodeURIComponent(content) };

        $.ajax({
            type: "POST",
            url: "../interface/News.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('保存成功！');
                    Reset();
                }
                else if (msg.errorcode == "3") {

                }
                else if (msg.errorcode == "0") {

                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
                else {

                }
            }
        });
    }
}

function Reset() {
    $("#divtitle").removeClass('has-error');
    $("#divcontact").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divcontent").removeClass('has-error');

    $("#titleerr").html('');
    $("#contacterr").html('');
    $("#contenterr").html('');


    $("#title_txt").val('');
    UE.getEditor('editor').setContent('', false);
    $("#contact_txt").val('');
    $("#editor").css("border", "0px");
}