$(document).ready(function () {
    ClickMenuMaster();

    HideShowMenuBarMaster();
});
function ClickMenuMaster() {
    $('.MasterBody > div').hide();
    $('.MasterBody > div[name="content-tim-kiem"]').show();
    $('.menu-master-list > div:not([name="content-dang-tin"])').click(function () {
        $('.MasterBody > div').hide();
        $('.MasterBody > div[name="' + $(this).attr('name') + '"]').show();
    });
}

function OpenSearchContent() {
    $('.menu-master-list > div[name="content-tim-kiem"]').click();
}


function HideShowMenuBarMaster() {
    var position = $('body').scrollTop();

    $('body').scroll(function () {        
        var scroll = $('body').scrollTop();
        if (scroll > position) {
           
            $('.menu-master-list').height('10px');
        } else {
            $('.menu-master-list').height('');
        }
        position = scroll;
    });
}

function GetURL(key) {
    var arr = window.location.href.split('/');
    arr[arr.length - 1] = '';
    return arr.join('/') + 'layouthtml/'+key+'.aspx';
}