function ValidSubmit()
{
    var file = $('#importfile').val().toLowerCase();
    var pos = file.indexOf('.');
    var ext = file.substr(pos+1, 4);
    if (file == '')
    {
        alert("请选择导入文件");
        return false;
    }
    if (ext!= 'xlsx')
    {
        alert("选择导入的文件不是模板文件格式，请下载正确模板");
        return false;
    }
    $('#form1').submit();

}