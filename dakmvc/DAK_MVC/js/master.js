$(document).ready(function () {
   // ClickMenuMaster();

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
    //$('.menu-master-list > div[name="content-tim-kiem"]').click();

    window.location = "DAK/searchreturn";
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
 

    return getBaseURL() + key;
}
function getBaseURL() {
    var url = location.href;  // entire url including querystring - also: window.location.href;
    var baseURL = url.substring(0, url.indexOf('/', 14));


    if (baseURL.indexOf('http://localhost') != -1) {
        // Base Url for localhost
        var url = location.href;  // window.location.href;
        var pathname = location.pathname;  // window.location.pathname;
        var index1 = url.indexOf(pathname);
        var index2 = url.indexOf("/", index1 + 1);
        var baseLocalUrl = url.substr(0, index2);

        return baseLocalUrl + "/";
    }
    else {
        // Root Url for domain name
        return baseURL + "/";
    }

}
function BacktoTop_click() {
    $("html, body").animate({ scrollTop: 0 }, 500);
}
$(window).scroll(function () {
    if ($(this).scrollTop()) {
        $('.back-to-top').fadeIn();
    } else {
        $('.back-to-top').fadeOut();
    }
});