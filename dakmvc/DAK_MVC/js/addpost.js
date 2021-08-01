$(document).ready(function () {
    FixHeight_Content_AddPost();
});

function AddPost(o) {
  
   
    window.location = $(o).attr('actiondata');

   
}

function addpost_back_click() {
    var curContent = $('.add-post .content > div > div.active');   
    var backContent = curContent.prev();
    if (backContent.length > 0) {
        curContent.removeClass('active');
        backContent.addClass('active');
        $('.add-post .title').html(backContent.attr('nametitle'));
        Change_StepSlider();
    }
}
function addpost_next_click() {
    var curContent = $('.add-post .content > div > div.active');
    var nextContent = curContent.next();
    if (nextContent.length > 0) {
        curContent.removeClass('active');
        nextContent.addClass('active');
        $('.add-post .title').html(nextContent.attr('nametitle'));
        Change_StepSlider();
    }
}
function Change_StepSlider() {
    var index = $('.add-post .content > div > div.active').index() + 1;
    var length = $('.add-post .content > div > div').length;
    

    $('.add-post .step-slider > div').css('width',index / length * 100 +'%');
}
function FixHeight_Content_AddPost() {

    var _height = $(window).height() - $('.MasterHeader').height() - $('.add-post .head').height() - $('.add-post .button').height();
   
    if (IsMobile())
        _height = _height - $('.menu-master').height() - 50;

    $('.add-post .content').height(_height);
    Change_StepSlider();
}
function addpost_view_click() {
    OpenDetail();
}