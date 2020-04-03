String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
$(document).ready(function () {
    SetMenu();
});
function SetMenu()
{
    $('.menucheck > li').each(function () {
        
        var ull = $(this).find('ul').length;
        var ulli = $(this).find('ul').find('li').length;
        //if(ull>0 && ulli==0)
        //{
            //$(this).remove();
        //}
        if (ull > 0 && ulli > 0)
        {
            $(this).show();
        }

    });

}