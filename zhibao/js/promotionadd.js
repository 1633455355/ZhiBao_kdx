var ue = UE.getEditor('editor');

$(document).ready(function () {
    GetDealer();
});
function GetDealer()
{
    var params = { Action: "GetDealerList"};

    $.ajax({
        type: "POST",
        url: "../interface/Admin.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                
                if (msg.data != null && msg.data.length > 0)
                {
                    for(var i=0;i<msg.data.length;i++)
                    {
                        var li = '<label><input type="checkbox" class="ace" name="form-field-checkbox" id="' + msg.data[i].AdminId + '"><span class="lbl">' + msg.data[i].DealerCompanyName + '</span></label>';
                        $("#dealerlist").append(li);
                    }
                }
            }
        }
    });
}
function PromotionAdd() {

    $("#divtitle").removeClass("has-error");
    $("#titleerr").html("");
    $("#divdealer").removeClass("has-error");
    $("#dealererr").html('');
    $("#dealerlist").css("border", "0px");
    $("#divcontent").removeClass("has-error");
    $("#editor").css("border", "0px");
    $("#contenterr").html('');

    var flag = true;

    var title = $("#title_txt").val().Trim();
    if (title == "") {
        flag=false;
        $("#divtitle").addClass("has-error");
        $("#titleerr").html("请输入标题");
    }


    var dealer="";
    $(':input[name="form-field-checkbox"]').each(function () {
        if ($(this).prop("checked")) {
            dealer=dealer+","+$(this).attr("id");
        }
    });

    if(dealer=="")
    {
        flag=false;
        $("#divdealer").addClass("has-error");
        $("#dealererr").html('请至少选择一个经销商');
        $("#dealerlist").css("border", "1px solid #f09784");
    }

    var content = UE.getEditor('editor').getContent();

    if (content == "") {
        $("#divcontent").addClass("has-error");
        $("#editor").css("border", "1px solid #f09784");
        $("#contenterr").html('请输入内容');
    }
   
    if (flag)
    {
        var params = { Action: "PromotionAdd", Title: encodeURIComponent(title), Content: encodeURIComponent(content), Dealer: dealer };

        $.ajax({
            type: "POST",
            url: "../interface/Promotion.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('保存成功！');
                    Reset();

                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
                else {
                    alert("异常");
                }
            }
        });
    }
}
function Reset()
{
    $("#title_txt").val('');
    UE.getEditor('editor').setContent('', false);

    $(':input[name="form-field-checkbox"]').each(function () {
        if ($(this).prop("checked")) {
            $(this).prop('checked', false);
        }
    });
}