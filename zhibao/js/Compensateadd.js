$(document).ready(function () {

    $('#ContentPlaceHolder1_ProductSecondLevelName_ddl').bind('change', function () {
        $('#ContentPlaceHolder1_ProductCode_ddl').empty();
        $("<option value=''></option>").appendTo("#ContentPlaceHolder1_ProductCode_ddl");
        if ($('#ContentPlaceHolder1_ProductSecondLevelName_ddl').val() != "") {
            var params = { Action: "GetProductCode", FId: $('#ContentPlaceHolder1_ProductSecondLevelName_ddl').val() };
            $.ajax({
                type: "POST",
                url: "../interface/Compensate.ashx",
                cache: false,
                dataType: "json",
                data: jQuery.param(params, true),
                success: function (msg) {
                    if (msg.errorcode == "0") {
                        if (msg.data != null && msg.data.length > 0) {
                            for (var i = 0; i < msg.data.length; i++) {
                                var li = msg.data[i].newsid;
                                $('<option value="' + msg.data[i] + '">' + msg.data[i] + '</option>').appendTo('#ContentPlaceHolder1_ProductCode_ddl');
                            }
                        }
                    }
                }
            });
        }
    });
  
    $("#uploadify").uploadify({
        //指定swf文件
        'swf': '../assets/js/uploadify/uploadify.swf',
        //后台处理的页面
        'uploader': '../interface/UpLoading.ashx',
        'cancelImg': '../assets/js/uploadify/uploadify-cancel.png',
        'queueSizeLimit': '5',
        //按钮显示的文字
        'buttonText': '选择图片',
        // 'folder': 'UpLoadImage',
        //显示的高度和宽度，默认 height 30；width 120
        //'height': 15,
        //'width': 80,
        //上传文件的类型  默认为所有文件    'All Files'  ;  '*.*'
        //在浏览窗口底部的文件类型下拉菜单中显示的文本
        'fileTypeDesc': 'Image Files',
        //允许上传的文件后缀
        'fileTypeExts': '*.gif; *.jpg; *.png',
        //发送给后台的其他参数通过formData指定
        //'formData': { 'someKey': 'someValue', 'someOtherKey': 1 },
        //上传文件页面中，你想要用来作为文件队列的元素的id, 默认为false  自动生成,  不带#
        // 'queueID': 'fileQueue',
        //选择文件后自动上传
        'auto': true,
        //设置为true将允许多文件上传
        'multi': true,
        'onUploadSuccess': function (file, data, response) {
            var temp = $("#tempImage").val();
            var htmltemp = "<img src=\"../UpLoadImage/" + data + "\"  width=\"80px\"/>";
            if (temp == "") {
                $("#tempImage").val(data);
            }
            else {
                $("#tempImage").val(temp + "," + data);
            }
            $('#' + file.id).find('.data').html(' 上传完毕');
            $("#ImageResult").append(htmltemp);
        }
    });
    $("#uploadify1").uploadify({
        //指定swf文件
        'swf': '../assets/js/uploadify/uploadify.swf',
        //后台处理的页面
        'uploader': '../interface/UpLoading.ashx',
        'cancelImg': '../assets/js/uploadify/uploadify-cancel.png',
        'queueSizeLimit': '5',
        //按钮显示的文字
        'buttonText': '选择附件',
        // 'folder': 'UpLoadImage',
        //显示的高度和宽度，默认 height 30；width 120
        //'height': 15,
        //'width': 80,
        //上传文件的类型  默认为所有文件    'All Files'  ;  '*.*'
        //在浏览窗口底部的文件类型下拉菜单中显示的文本
        'fileTypeDesc': 'All Files',
        //允许上传的文件后缀
        'fileTypeExts': '*.*',
        //发送给后台的其他参数通过formData指定
        //'formData': { 'someKey': 'someValue', 'someOtherKey': 1 },
        //上传文件页面中，你想要用来作为文件队列的元素的id, 默认为false  自动生成,  不带#
        // 'queueID': 'fileQueue',
        //选择文件后自动上传
        'auto': true,
        //设置为true将允许多文件上传
        'multi': true,
        'onUploadSuccess': function (file, data, response) {
            var temp = $("#tempImage1").val();
            var htmltemp = "<a href=\"../UpLoadImage/" + data + "\"  target=\"_blank\">"+data+"</a>";
            if (temp == "") {
                $("#tempImage1").val(data);
            }
            else {
                $("#tempImage1").val(temp + "," + data);
            }
            $('#' + file.id).find('.data').html(' 上传完毕');
            $("#AtchmentList").append(htmltemp);
        }
    });

    var No = $.query.get('No');
    if(No!=null &&No!='')
    {
        $("#divStatus").show();
        GetCompensateAdd(No);
    }
});

function validateInt(o) {
    var pice = o.value.replace(/^[1-9][0-9]{0,2}|[0-9]$/, '');
    if (pice.length > 0) {
        o.value = o.value.substring(0, o.value.length - 1);
        validateInt(o);
    }
}

// 只能真金钱格式
function validatePices(o) {
    var pice = o.value.replace(/^([1-9][0-9]{0,5}|[0-9])((\.[0-9]{0,2}){0,1})$/, '');
    if (pice.length > 0) {
        o.value = o.value.substring(0, o.value.length - 1);
        validatePices(o);
    }
}


function CompensateAdd() {
    $("#divCompensateType").removeClass('has-error');
    $("#CompensateTyp_txt_err").html('');

    $("#divCompensatePeson").removeClass('has-error');
    $("#CompensatePeson_txt_err").html('');

    $("#divTel").removeClass('has-error');
    $("#Tel_txt_err").html('');

    $("#divProductSecondLevelName").removeClass('has-error');
    $("#ProductSecondLevelName_dll_err").html('');

    $("#divProductCode").removeClass("has-error");
    $("#ProductCode_ddl_err").html("");

    $("#divSpecifications").removeClass("has-error");
    $("#Specifications_err").html("");


   

    var compensatename = $("#DealerName_txt").val();
    var compensateType = $('input[name="CompensateType"]:checked').val();
    var compensatePeson = $("#CompensatePeson_txt").val().Trim();
 
    var tel = $("#Tel_txt").val().Trim();
    var fax = $("#Fax_txt").val().Trim();
    var productSecondLevelId = $("#ContentPlaceHolder1_ProductSecondLevelName_ddl").val();
    var productSecondLevelName = $("#ContentPlaceHolder1_ProductSecondLevelName_ddl").find("option:selected").text();
    var productCode = $("#ContentPlaceHolder1_ProductCode_ddl").val();


    var specifications = $('input[name="Specifications"]:checked').val();

    var lengthnum = $("#Length_txt").val();
    var compensateStore = $("#CompensateStore_txt").val().Trim();
    var compensateDate = $("#CompensateDate_txt").val();

    var position=""
    $(':input[type="checkbox"][name="Position"]').each(function () {
        if ($(this).prop("checked")) {
            position = position + $(this).val() + ",";
        }
    });
    var problemDes = ""
    $(':input[type="checkbox"][name="ProblemDes"]').each(function () {
        if ($(this).prop("checked")) {
            problemDes = problemDes + $(this).val() + ",";
        }
    });
    var findTime = $('input[name="FindTime"]:checked').val();
    var installationTime=$("#InstallationTime").val();
    var otherDes=$("#OtherDes_txt").val()
    var imagelist = $("#tempImage").val().Trim();
    var AtchmentList = $("#tempImage1").val().Trim();
    var statusValue = $("#statusValue").val()

    if (typeof(compensateType) == 'undefined' || compensateType == "") {
        $("#divCompensateType").addClass('has-error');
        $("#CompensateTyp_txt_err").html('请选择经销商级别');
        return;
    }
    if (compensatePeson == "") {
        $("#divCompensatePeson").addClass('has-error');
        $("#CompensatePeson_txt_err").html('请输入申请人');
        return;
    }

    if (tel == "") {
        $("#divTel").addClass('has-error');
        $("#Tel_txt_err").html('请输入联系电话');
        return;
    }
    if (tel == "") {
        $("#divTel").addClass('has-error');
        $("#Tel_txt_err").html('请输入联系电话');
        return;
    }
 

    if (productSecondLevelId == "") {
        $("#divProductSecondLevelName").addClass("has-error");
        $("#ProductSecondLevelName_dll_err").html("请选择品牌索赔窗膜型号");
        return;
      
    }
    if (productCode == "") {
        $("#divProductCode").addClass("has-error");
        $("#ProductCode_ddl_err").html("请选择索赔窗膜卷轴号");
        return;
        
    }
    if (typeof (specifications) == 'undefined' || specifications == "") {
        $("#divSpecifications").addClass("has-error");
        $("#Specifications_err").html("请选择幅宽/规格(英寸)");
        return;
        
    }
    if (typeof (position) == 'undefined')
    {
        position = "";
    }
    if (typeof (problemDes) == 'undefined') {
        problemDes = "";
    }
    if (typeof (findTime) == 'undefined') {
        findTime = "";
    }
    var No = $.query.get('No');
    var params;
    if (No != null && No != '') {
        if (statusValue == "")
        {
            $("#divStatus").addClass("has-error");
            $("#status_ddl_err").html("请选择状态");
            return;
        }
        params = {
            Action: "CompensateUpdate",
            compensateno: encodeURIComponent(No),
            compensatename: encodeURIComponent(compensatename),
            compensateType: encodeURIComponent(compensateType),
            compensatePeson: encodeURIComponent(compensatePeson),
            tel: encodeURIComponent(tel),
            fax: encodeURIComponent(fax),
            productSecondLevelId: encodeURIComponent(productSecondLevelId),
            productCode: encodeURIComponent(productCode),
            specifications: encodeURIComponent(specifications),
            lengthnum: encodeURIComponent(lengthnum),
            compensateStore: encodeURIComponent(compensateStore),
            compensateDate: encodeURIComponent(compensateDate),
            position: encodeURIComponent(position),
            problemDes: encodeURIComponent(problemDes),
            findTime: encodeURIComponent(findTime),
            installationTime: encodeURIComponent(installationTime),
            otherDes: encodeURIComponent(otherDes),
            imagelist: encodeURIComponent(imagelist),
            AtchmentList: encodeURIComponent(AtchmentList),
            productSecondLevelName: encodeURIComponent(productSecondLevelName),
            status: statusValue
        };
    }
    else {
        params = {
            Action: "CompensateAdd",
            compensatename: encodeURIComponent(compensatename),
            compensateType: encodeURIComponent(compensateType),
            compensatePeson: encodeURIComponent(compensatePeson),
            tel: encodeURIComponent(tel),
            fax: encodeURIComponent(fax),
            productSecondLevelId: encodeURIComponent(productSecondLevelId),
            productCode: encodeURIComponent(productCode),
            specifications: encodeURIComponent(specifications),
            lengthnum: encodeURIComponent(lengthnum),
            compensateStore: encodeURIComponent(compensateStore),
            compensateDate: encodeURIComponent(compensateDate),
            position: encodeURIComponent(position),
            problemDes: encodeURIComponent(problemDes),
            findTime: encodeURIComponent(findTime),
            installationTime: encodeURIComponent(installationTime),
            otherDes: encodeURIComponent(otherDes),
            imagelist: encodeURIComponent(imagelist),
            AtchmentList: encodeURIComponent(AtchmentList),
            productSecondLevelName: encodeURIComponent(productSecondLevelName),
            status: 0
        };
    }
        $.ajax({
            type: "POST",
            url: "../interface/Compensate.ashx",
            cache: false,
            dataType: "json",
            data: jQuery.param(params, true),
            success: function (msg) {
                if (msg.errorcode == "0") {
                    alert('成功');
                    //Reset();
                    location.href = "CompensateList.aspx";
                }
                else if (msg.errorcode == "-1") {
                    alert('参数传递不正确');
                }
                else if (msg.errorcode == "-5") {
                    alert('系统有异常，请联系管理员');
                }
                else if (msg.errorcode == "-10") {
                    alert('无权限');
                }
            }
        });
    
}

function GetCompensateAdd(No)
{
    var params = { Action: "GetCompensate", no: encodeURIComponent(No) };
    $.ajax({
        type: "POST",
        url: "../interface/Compensate.ashx",
        cache: false,
        dataType: "json",
        data: jQuery.param(params, true),
        success: function (msg) {
            if (msg.errorcode == "0") {
                $("#DealerName_txt").val(msg.data.CompensateName);
                $(':input[type="radio"][name="CompensateType"][value="' + msg.data.CompensateType + '"]').prop("checked", true);
                $("#CompensatePeson_txt").val(msg.data.CompensatePeson);

                $("#Tel_txt").val(msg.data.Tel);
                $("#Fax_txt").val(msg.data.Fax);
                $("#ContentPlaceHolder1_ProductSecondLevelName_ddl").val(msg.data.ProductSecondLevelId);
        
              
                $("#ContentPlaceHolder1_ProductCode_ddl").append('<option value="' + msg.data.ProductCode + '">' + msg.data.ProductCode + '</option>');
                $("#ContentPlaceHolder1_ProductCode_ddl").val(msg.data.ProductCode);

                $(':input[type="radio"][name="Specifications"][value="' + msg.data.Specifications + '"]').prop("checked", true);

               $("#Length_txt").val(msg.data.Length);
               $("#CompensateStore_txt").val(msg.data.CompensateStore);
               $("#CompensateDate_txt").val(msg.data.CompensateDate);
               for (var i = 0; i < msg.data.PositionList.length; i++) {
                   $(':input[type="checkbox"][name="Position"][value="' + msg.data.PositionList[i] + '"]').prop("checked", true);
               }
         
               for (var j = 0; j < msg.data.ProblemDesList.length; j++) {
                   $(':input[type="checkbox"][name="ProblemDes"][value="' + msg.data.ProblemDesList[j] + '"]').prop("checked", true);
               }
               $(':input[type="radio"][name="FindTime"][value="' + msg.data.FindTime + '"]').prop("checked", true);
               $("#InstallationTime").val(msg.data.InstallationTime);
               $("#OtherDes_txt").val(msg.data.OtherDes)
               for (var n=0;n<msg.data.ImageArray.length;n++)
               {
                   var htmltemp = "<img src=\"../UpLoadImage/" + msg.data.ImageArray[n] + "\"  width=\"80px\"/>";
                   $("#ImageResult").append(htmltemp);
               }
               for (var m = 0; m < msg.data.AtchmentArray.length; m++) {
                   var htmltemp = "<a href=\"../UpLoadImage/" + msg.data.AtchmentArray[m] + "\"  target=\"_blank\">" + msg.data.AtchmentArray[m] + "</a>";
                   $("#AtchmentList").append(htmltemp);
               }
               $("#tempImage").val(msg.data.ImageList);
               $("#tempImage1").val(msg.data.AtchmentList);
            }
            else if (msg.errorcode == "-10") {
                alert('无权限');
                location.href = "CompensateList.aspx";
            }
        }
    });
}