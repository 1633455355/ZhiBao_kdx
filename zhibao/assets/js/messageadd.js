$(document).ready(function () {

    $(".chosen-select").chosen({ allow_single_deselect: true });
    $("#dealer_store_div").hide();


    $('#modal-form').on('shown.bs.modal', function () {
        $(this).find('.chosen-container').each(function () {
            $(this).find('a:first-child').css('width', '210px');
            $(this).find('.chosen-drop').css('width', '210px');
            $(this).find('.chosen-search input').css('width', '200px');
        });
    })


    $('#form-field-select-1').bind('change', function () {

        if ($('#form-field-select-1').val() == "all") {
            $("#dealer_store_div").hide();
        }
        else if ($('#form-field-select-1').val() == "dealer") {
            $("#dealer_store_div").hide();
        }
        else if ($('#form-field-select-1').val() == "dealer") {
            $("#dealer_store_div").hide();
        }
        else if ($('#form-field-select-1').val() == "self")
        {
            $("#dealer_store_div").show();
        }
    });
});

function MessageAdd()
{
    $("#divtitle").removeClass("has-error");
    $("#titleerr").html("");

    $("#divcontent").removeClass("has-error");
    $("#contenterr").html("");

    $("#dealerdiv").removeClass("has-error");
    $("#dealerdiv .chosen-choices").css("border-color", "#aaa");
    $("#dealerdiv .chosen-choices .default").css("color", "#666")
    $("#storediv").removeClass("has-error");
    $("#storediv .chosen-choices").css("border-color", "#aaa");
    $("#storediv .chosen-choices .default").css("color", "#666")


    var flag = true;
    var title = $("#title_txt").val().Trim();
    if (title == "") {
        flag = false;
        $("#divtitle").addClass("has-error");
        $("#titleerr").html("请输入标题");
    }

    var dealer = "";
    var store = "";
    if ($('#form-field-select-1').val() == "self") {
        
        $("#ContentPlaceHolder1_dealer_ddl_chosen .search-choice a").each(function () {
            
            var tempindex = $(this).attr("data-option-array-index");
            $("#ContentPlaceHolder1_dealer_ddl option").each(function (i, val) {
                
                if (tempindex == i)
                {
                    dealer = dealer + "," + $(this).val();
                }
            });
        });


        $("#ContentPlaceHolder1_store_ddl_chosen .search-choice a").each(function () {

            var tempindex = $(this).attr("data-option-array-index");
            $("#ContentPlaceHolder1_store_ddl option").each(function (i, val) {

                if (tempindex == i) {
                    store = store + "," + $(this).val();
                }
            });
        });

        if (dealer == "" && store == "") {
            flag = false;
            $("#dealerdiv").addClass("has-error");
            $("#dealerdiv .chosen-choices").css("border-color", "#f09784");
            $("#dealerdiv .chosen-choices .default").css("color", "#d68273")

            $("#storediv").addClass("has-error");
            $("#storediv .chosen-choices").css("border-color", "#f09784");
            $("#storediv .chosen-choices .default").css("color", "#d68273")
        }
    }

    var content = $("#content_txt").val().Trim();
    if(content=="")
    {
        flag = false;
        $("#divcontent").addClass("has-error");
        $("#contenterr").html("请输入内容");
    }

    if(flag)
    {
        var params = { Action: "SendMEssage", Type: encodeURIComponent($('#form-field-select-1').val()), Dealer: encodeURIComponent(dealer), Store: encodeURIComponent(store), Title: encodeURIComponent(title), Content: encodeURIComponent(content) }

        $.ajax({
            type: "POST",
            url: "../interface/Message.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    Reset();
                }
            }
        });
    }
}

function Reset()
{
    location.href = "messageadd.aspx?r=" + Math.random();
}