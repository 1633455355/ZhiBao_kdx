var ue = UE.getEditor('editor');
ue.ready(function () {
    GetNews();
});
$(document).ready(function () {
     
});
function GetNews()
{
    var id = $.query.get('id');

    var params = { Action: "GetNews", ID: id };

    $.ajax({
        type: "POST",
        url: "../interface/News.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data[0] != null) {
                    $("#title_txt").val(msg.data[0].Title);
                    UE.getEditor('editor').setContent(msg.data[0].Content, false);
                }
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
            else if (msg.errorcode == "0") {

            }
            else {

            }
        }
    });
}
function UpdateNews() {

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
    if (title == "") {
        $("#divtitle").addClass("has-error");
        $("#titleerr").html("请输入标题");
        flag = false;
    }

    var content = UE.getEditor('editor').getContent();

    if (content == "") {
        $("#divcontent").addClass("has-error");
        $("#editor").css("border", "1px solid #f09784");
        $("#contenterr").html('请输入内容');
        flag = false;
    }
    if (flag)
    { 
        var params = { Action: "NewsUpdate", Title: encodeURIComponent(title), Content: encodeURIComponent(content), ID: encodeURIComponent($.query.get('id')) };

        $.ajax({
            type: "POST",
            url: "../interface/News.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('更新成功！');
                    location.href = "newslist.aspx?r="+Math.random();
                }
                else if (msg.errorcode == "3") {

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