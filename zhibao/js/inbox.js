
var items_per_page = 3;
var page_index = 1;
var totalpg = 0;
$(document).ready(function () {
    GetMessage(1);
});
function GetMessage(page_index)
{
    
    $("#message-list").html('');

    var params = { Action: "GetMessage", Page: page_index, Item: items_per_page };

    $.ajax({
        type: "POST",
        url: "../interface/Message.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.data != null && msg.data.length > 0) {
                    total = msg.total;
                    $("#total_lb").html('共：' + total + ' 条消息');
                    if (msg.notread != "0" && msg.notread !="0") {
                        $("#unread_lb").html('(' + msg.notread + ' 条未读消息)');
                    }
                    else {
                        $("#unread_lb").html('');
                    }
                    for (var i = 0; i < msg.data.length; i++) {

                        var li = '';
                        if (msg.data[i].IsRead == false) {
                            li = li + '<div class="message-item message-unread">';
                        }
                        else {
                            li = li + '<div class="message-item">';
                        }
                        
                        li=li+'<label class="inline">';
                        li = li + '<input type="checkbox" class="ace" id="' + msg.data[i].MessageId + '">';
                        li=li+'<span class="lbl"></span>';
                        li=li+'</label>';
                        li=li+'<i class="message-star icon-star orange2"></i>';
                        li = li + '<span class="sender">'+msg.data[i].FromName+'</span>';
                        li = li + '<span class="time" style="width:80px">' + ChangeDateFormat(msg.data[i].CreateTime) + '</span>';
                        li=li+'<span class="summary">';
                        li = li + '<span class="text"  msgid="' + msg.data[i].MessageId + '">';
                        li = li + msg.data[i].Title;
                        li=li+'</span>';
                        li=li+'</span>';
                        li = li + '</div>';
                        $("#message-list").append(li);
                    }
                }

                totalpg = Math.ceil(total / items_per_page);

                $("#firstli").removeClass("disabled");
                $("#firstli").html('<a onclick="GoFirst()"  href="javascript:void(0);"><i class="icon-step-backward middle"></i></a>');

                $("#preli").removeClass("disabled");
                $("#preli").html('<a onclick="GoPre()"  href="javascript:void(0);"><i class="icon-caret-left bigger-140 middle"></i></a>');

                $("#nextli").removeClass("disabled");
                $("#nextli").html('<a onclick="GoNext()"  href="javascript:void(0);"><i class="icon-caret-right bigger-140 middle"></i></a>');

                $("#lastli").removeClass("disabled");
                $("#lastli").html('<a onclick="GoLast()"  href="javascript:void(0);"><i class="icon-step-forward middle"></i></a>');

                if (page_index == 1)
                {
                    $("#firstli").addClass("disabled");
                    $("#firstli").html('<span><i class="icon-step-backward middle"></i></span>');

                    $("#preli").addClass("disabled");
                    $("#preli").html('<span><i class="icon-caret-left bigger-140 middle"></i></span>');

                    
                    if (page_index == totalpg) {
                        $("#nextli").addClass("disabled");
                        $("#nextli").html('<span><i class="icon-caret-right bigger-140 middle"></i></span>');


                        $("#lastli").addClass("disabled");
                        $("#lastli").html('<span><i class="icon-step-forward middle"></i></span>');
                    }
                    else {
                        $("#nextli").removeClass("disabled");
                        $("#nextli").html('<a onclick="GoNext()"  href="javascript:void(0);"><i class="icon-caret-right bigger-140 middle"></i></a>');

                        $("#lastli").removeClass("disabled");
                        $("#lastli").html('<a onclick="GoLast()"  href="javascript:void(0);"><i class="icon-step-forward middle"></i></a>');
                    }
                }
                if (page_index != 1 && page_index == totalpg)
                {
                    $("#firstli").removeClass("disabled");
                    $("#firstli").html('<a onclick="GoFirst()"  href="javascript:void(0);"><i class="icon-step-backward middle"></i></a>');
                    $("#preli").removeClass("disabled");
                    $("#preli").html('<a onclick="GoPre()"  href="javascript:void(0);"><i class="icon-caret-left bigger-140 middle"></i></a>');


                    $("#nextli").addClass("disabled");
                    $("#nextli").html('<span><i class="icon-caret-right bigger-140 middle"></i></span>');


                    $("#lastli").addClass("disabled");
                    $("#lastli").html('<span><i class="icon-step-forward middle"></i></span>');
                }

                $("#page_lb").html('第 ' + page_index + ' 页，共 ' + Math.ceil(total / items_per_page) + ' 页');


                $('.message-list  .text').on('click', function () {
                    var message = $(this).closest('.message-item');

                    if (message.hasClass('message-inline-open')) {
                        message.removeClass('message-inline-open').find('.message-content').remove();
                        return;
                    }

                    $('.message-container').append('<div class="message-loading-overlay"><i class="icon-spin icon-spinner orange2 bigger-160"></i></div>');

                    var params = { Action: "SetRead", ID: $(this).attr("msgid") };

                    $.ajax({
                        type: "POST",
                        url: "../interface/Message.ashx",
                        cache: false,
                        dataType: "json",
                        data: jQuery.param(params, true),
                        success: function (msg) {
                            if (msg.errorcode == "0") {

                                $('.message-container').find('.message-loading-overlay').remove();
                                message
                                    .addClass('message-inline-open')
                                    .append('<div class="message-content" >'+msg.data[0].Content+'</div>')
                                var content = message.find('.message-content:last').html($('#id-message-content').html());

                                content.find('.message-body').slimScroll({
                                    height: 200,
                                    railVisible: true
                                });
                            }
                        }
                    });
                });

            }
            else if (msg.errorcode == "-10")
            {
                alert('无权限');
            }

            if ($("#ContentPlaceHolder1_deletepermission").val() != "true")
            {
                $(':input[type="checkbox"]').each(function () {
                    $(this).attr("disabled", true);
                });
            }
        }
    });
}

function pageselectCallbackVideo(page_index, jq) {
    GetMessage(page_index);
    return false;
};
function ChangeDateFormat(time) {
    if (time != null) {
        var strs = new Array();
        strs = time.split("T");
        return strs[0];
    }
    return "";
};

function GoFirst()
{
    page_index = 1;
    GetMessage(page_index);
}
function GoNext() {
    page_index = page_index + 1;
    GetMessage(page_index);
}
function GoPre() {
    page_index = page_index - 1;
    GetMessage(page_index);
}
function GoLast() {
    page_index = totalpg;
    GetMessage(page_index);
}

function DeleteMessage() {

    var flag = false;
    var idlist = "";
    $("#message-list").find("input[type='checkbox']").each(function () {
        
        if($(this).prop("checked") )
        {
            flag = true;
            idlist = idlist + $(this).attr("id")+",";
        }
    });

    if (!flag)
    {
        alert('您还没有选中任何的记录');
    }
    else
    {
        var params = { Action: "DeleteMessage", ID: idlist };

        $.ajax({
            type: "POST",
            url: "../interface/Message.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('删除成功！');
                    page_index = 1;
                    GetMessage(page_index);
                }
            }
        });
    }
}