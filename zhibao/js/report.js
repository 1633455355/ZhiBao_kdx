
$(document).ready(function () {
    $('#ContentPlaceHolder1_typeone_ddl').bind('change', function () {
        $('#ContentPlaceHolder1_typetwo_ddl').empty();
        $("<option value=''></option>").appendTo("#ContentPlaceHolder1_typetwo_ddl");
        if ($('#ContentPlaceHolder1_typeone_ddl').val() != "") {
            var params = { Action: "GetProductTypeList", ID: $('#ContentPlaceHolder1_typeone_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            for (var i = 0; i < msg.data.length; i++) {
                                $('<option value="' + msg.data[i].S_ProductTypeId + '">' + msg.data[i].S_ProductTypeName + '</option>').appendTo('#ContentPlaceHolder1_typetwo_ddl');
                            }
                        }
                        $('#ContentPlaceHolder1_typetwo_ddl').chosen({ allow_single_deselect: true });
                        $("#ContentPlaceHolder1_typetwo_ddl").trigger("chosen:updated");
                    }
                }
            });
        }
    });

    $('#ContentPlaceHolder1_dealer_ddl').bind('change', function () {
        $('#ContentPlaceHolder1_store_ddl').empty();
        $("<option value=''></option>").appendTo("#ContentPlaceHolder1_store_ddl");
        if ($('#ContentPlaceHolder1_dealer_ddl').val() != "") {
            var params = {
                Action: "GetStoreList",
                ID: $('#ContentPlaceHolder1_dealer_ddl').val()
            };
            $.ajax({
                type: "POST",
                url: "../interface/Product.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            for (var i = 0; i < msg.data.length; i++) {
                                $('<option value="' + msg.data[i].AdminId + '">' + msg.data[i].StoreName + '</option>').appendTo('#ContentPlaceHolder1_store_ddl');
                            }
                        }
                        $('#ContentPlaceHolder1_store_ddl').chosen({ allow_single_deselect: true });
                        $("#ContentPlaceHolder1_store_ddl").trigger("chosen:updated");
                    }
                }
            });
        }
    });
});
function GetReport()
{
 
    $("#tbcon").html('');
    var firsttype = $("#ContentPlaceHolder1_typeone_ddl").val();
    var secondtype = $("#ContentPlaceHolder1_typetwo_ddl").val();
    var dealer = $("#ContentPlaceHolder1_dealer_ddl").val();
    var store = $("#ContentPlaceHolder1_store_ddl").val();

    var start = $("#start_dt").val().Trim();
    var end = $("#end_dt").val().Trim();
    var params = {
        Action: "GetReport",
        FirstType: firsttype,
        SecondType: secondtype,
        Dealer: dealer,
        Store: store,
        Start: start,
        End: end
    };
    $("#diplayId").show();
    $.ajax({
        type: "POST",
        url: "../interface/Report.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            var total = 0;
            if (msg.errorcode == "0") {
                if (msg.type == "Managers")
                {
                    if (msg.data != null && msg.data.length > 0) {
                        total = msg.total;
                        for (var i = 0; i < msg.data.length; i++) {

                            var li = '<tr><td>' + msg.data[i].ProductFirstLevelName + '</td><td>' + msg.data[i].ProductSecondLevelName + '</td><td>' + msg.data[i].DealerCompanyName + '</td><td>' + msg.data[i].StoreName+'</td><td>' + msg.data[i].Total + '</td><td>' + msg.data[i].DealerTotal + '</td><td>' + msg.data[i].StoreTotal + '</td><td>' + msg.data[i].UserTotal + '</tr>';
                            $("#tbcon").append(li);
                        }
                    }
                    else {
                        $("#tbcon").append('<tr><td colspan="8">没有查询到任何信息</td></tr');
                    }
                }
                else if (msg.type == "Dealer")
                {
                    if (msg.data != null && msg.data.length > 0) {
                        total = msg.total;
                        for (var i = 0; i < msg.data.length; i++) {

                            var li = '<tr><td>' + msg.data[i].ProductFirstLevelName + '</td><td>' + msg.data[i].ProductSecondLevelName + '</td></td><td>' + msg.data[i].StoreName+'<td>' + msg.data[i].DealerTotal + '</td><td>' + msg.data[i].StoreTotal + '</td><td>' + msg.data[i].UserTotal + '</tr>';
                            $("#tbcon").append(li);
                        }
                    }
                    else {
                        $("#tbcon").append('<tr><td colspan="6">没有查询到任何信息</td></tr');
                    }
                }
                else if (msg.type == "Stores")
                {
                    if (msg.data != null && msg.data.length > 0) {
                        total = msg.total;
                        for (var i = 0; i < msg.data.length; i++) {

                            var li = '<tr><td>' + msg.data[i].ProductFirstLevelName + '</td><td>' + msg.data[i].ProductSecondLevelName + '</td><td>' + msg.data[i].StoreTotal + '</td><td>' + msg.data[i].UserTotal + '</tr>';
                            $("#tbcon").append(li);
                        }
                    }
                    else {
                        $("#tbcon").append('<tr><td colspan="5">没有查询到任何信息</td></tr');
                    }
                }
              
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
            }
            $("#diplayId").hide();
        },
        error: function () {
            $("#diplayId").hide();
        }
    });
    

}

function ExportReport() {
    typeone = $("#ContentPlaceHolder1_typeone_ddl").val();
    typetwo = $("#ContentPlaceHolder1_typetwo_ddl").val();

    dealer = $("#ContentPlaceHolder1_dealer_ddl").val();

    store = $("#ContentPlaceHolder1_store_ddl").val();
    starttime = $("#start_dt").val();
    endtime = $("#end_dt").val();

    window.open("reportexport.aspx?FirstType=" + encodeURIComponent(typeone) + "&SecondType=" + encodeURIComponent(typetwo) + "&Dealer=" + encodeURIComponent(dealer) + "&Store=" + encodeURIComponent(store) + "&Start=" + encodeURIComponent(starttime) + "&End=" + encodeURIComponent(endtime));
}