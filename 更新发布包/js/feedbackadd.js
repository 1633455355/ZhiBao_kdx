var ue = UE.getEditor('editor');

$(document).ready(function () {

});

function Reset()
{
    $("#divtitle").removeClass('has-error');
    $("#divcontact").removeClass('has-error');
    $("#divmobile").removeClass('has-error');
    $("#divemail").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divcontent").removeClass('has-error');

    $("#titleerr").html('');
    $("#contacterr").html('');
    $("#mobileerr").html('');
    $("#emailerr").html('');
    $("#contenterr").html('');

    
    $("#title_txt").val('');
    UE.getEditor('editor').setContent('', false);
    $("#contact_txt").val('');
    $("#mobile_txt").val('');
    $("#email_txt").val('');

    $("#dealer_cb").prop("checked", false);

}
function FeeedbackAdd()
{

    $("#divtitle").removeClass('has-error');
    $("#divcontact").removeClass('has-error');
    $("#divmobile").removeClass('has-error');
    $("#divemail").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divtitle").removeClass('has-error');
    $("#divcontent").removeClass('has-error');

    $("#titleerr").html('');
    $("#contacterr").html('');
    $("#mobileerr").html('');
    $("#emailerr").html('');
    $("#contenterr").html('');

    $("#editor").css("border", "0px");


    var flag = true;
    var title = $("#title_txt").val().Trim();
    if (title == "") {
        $("#divtitle").addClass("has-error");
        $("#titleerr").html("请输入标题");
        flag = false;
    }


    var contact = $("#contact_txt").val().Trim();


    var mobile = $("#mobile_txt").val().Trim();
    if (mobile != "") {
        var regPartton = /1[3-9]+\d{9}/;
        if (!regPartton.test(mobile)) {
            $("#divmobile").addClass("has-error");
            $("#mobileerr").html("手机号码格式不正确");
            flag = false;
        } 
    }


    var email = $("#email_txt").val().Trim();
    if (email != "") {

        var pattern = /^(?:[a-zA-Z0-9]+[_\-\+\.]?)*[a-zA-Z0-9]+@(?:([a-zA-Z0-9]+[_\-]?)*[a-zA-Z0-9]+\.)+([a-zA-Z]{2,})+$/;
        if (!pattern.exec(email)) {
            $("#divemail").addClass("has-error");
            $("#emailerr").html("请输入正确格式的邮箱地址");
            flag = false;
        }
    }

    var content = UE.getEditor('editor').getContent();
    if (content == "")
    {
        $("#divcontent").addClass("has-error");
        $("#editor").css("border", "1px solid #f09784");
        $("#contenterr").html('请输入内容');
        flag = false;
    }


    var dealer = false;
    if ($("#dealer_cb").prop("checked"))
    {
        dealer = true;
    }

    if (flag)
    {
        var params = { Action: "FeedbackAdd", Title: encodeURIComponent(title), Contact: encodeURIComponent(contact), Mobile: encodeURIComponent(mobile), Email: encodeURIComponent(email), Title: encodeURIComponent(title), Content: encodeURIComponent(UE.getEditor('editor').getContent()), Dealer: encodeURIComponent(dealer) };

        $.ajax({
            type: "POST",
            url: "../interface/Feedback.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('保存成功！');
                    Reset();
                }
                else if(msg.errorcode == "-10")
                {
                    alert('无权限');
                }
                else if (msg.errorcode == "3") {

                }
                else if (msg.errorcode == "0") {

                }
                else {

                }
            }
        });
    }
}