$(document).ready(function () {
    OnclickMenuTitleFilterSearch();
});
function OnclickMenuTitleFilterSearch() {
    $('.menu-filter-title > div').each(function (index) {
        $(this).click(function () {
            $('.menu-filter-title > div').removeClass('active');
            $('.menu-filter-content > div').removeClass('active');
            $(this).addClass('active');
            $('.menu-filter-content > div:eq(' + index + ')').addClass('active')
        });
    });

    $('.link-detail-more').click(function () {
        OpenDetail();
    });
    $('.list-grid-view > div > div img').click(function () {
        OpenDetail();
    });
    $('.group-icon-content').click(function () {
        ExpandInfo($(this));
    });
}

function OpendViewMoreInfoItem(obj) {
    $(obj).closest('.photo-info-summary').find('.content-view-more-info').show();
    // $('.content-view-more-info').show();

}
function CloseViewMoreInfoItem(obj) {
    $(obj).closest('.content-view-more-info').hide();
    // $('.content-view-more-info').hide();
}

function CloseMenuFilter(button) {   
    //$(button).find('i').toggleClass('fa-caret-up fa-caret-down');
    if ($(button).find('i').attr('class').indexOf('fa-caret-up') >= 0) {
        $(button).html('<i class="fas fa-caret-down"></i> Mở');
        $('.MenuFilter').css({ 'height': '5px', 'overflow': 'hidden' });
    }
    else {
        $(button).html('<i class="fas fa-caret-up"></i> Đóng');
        $('.MenuFilter').css({ 'height': '', 'overflow': '' });
    }

}
function OpenDetail() {
    $('.MasterBody > div[name="content-tin-chi-tiet"]').show();
    $('body').css('overflow', 'hidden');
    $('.detail-info-scrolldiv').css('height', ($('.panel-post-detail').height() - $('.detail-info-fixdiv').height() - 10) + 'px');
    ShowLayoutViewDetail();
}
function CloseDetail() {
    $('.MasterBody > div[name="content-tin-chi-tiet"]').hide();
    $('body').css('overflow', '');

}

function ExpandInfo(obj) {

    var content = $(obj).closest('.detail-info-group-title').next();
    $(obj).find('i').toggle();
    if ($(content).length > 0)
        $(content).toggle();
}
function ResizeHeightItemPhoto(type) {
    if (type == 3)
        $('.post-detail-photo > div:not(:eq(0))').css('height', ($('.post-detail-photo').width() / 3) + 'px');
    else
        $('.post-detail-photo > div').css('height', ($('.post-detail-photo').width() / 5) + 'px');

}
var curlayout = 3;
function ViewChangeLayout() {  
    if (curlayout == 3)
        curlayout = 1;
    else
        curlayout++;

    ShowLayoutViewDetail();
}
function ShowLayoutViewDetail() {
    switch (curlayout) {
        case 1://photo
            $('.post-detail-photo').css('width', '100%').show();            
            $('.post-detail-photo > div').css('width', '33%');
            $('.post-detail-info').hide();
            $('.post-detail-info').css('width', '');
            ResizeHeightItemPhoto(curlayout);
            break;
        case 2://info
            $('.post-detail-photo').hide();
            $('.post-detail-photo').css('width', '');
            $('.post-detail-info').css('width', '70%').show();
            break;
        case 3: //photo + info
            $('.post-detail-photo').css('width', '').show();
            $('.post-detail-info').css('width', '').show();
            $('.post-detail-photo > div').css('width', '');
            ResizeHeightItemPhoto(curlayout);
            break;

    }
}