﻿var processing, bgpopup_processing;

var ie = navigator.userAgent.indexOf("MSIE") > -1;
var ie6 = navigator.userAgent.indexOf("MSIE 6") > -1;
var ie7 = navigator.userAgent.indexOf("MSIE 7") > -1;
var safari = navigator.userAgent.indexOf("Safari") > -1;
var macintosh = navigator.userAgent.indexOf("Macintosh") > -1;
var fireFox = navigator.userAgent.indexOf("Firefox") > -1;
function getPageSize() {
    var iebody = document.compatMode && document.compatMode != "BackCompat"
        ? document.documentElement : document.body;
    var b = document.body;
    var xScroll = (window.innerWidth && window.scrollMaxX)
            ? window.innerWidth + window.scrollMaxX :
                (b.scrollWidth > b.offsetWidth ? b.scrollWidth : b.offsetWidth),
        yScroll = (window.innerHeight && window.scrollMaxY)
            ? window.innerHeight + window.scrollMaxY :
                (b.scrollHeight > b.offsetHeight ? b.scrollHeight : b.offsetHeight),
        pageWidth = ie || ie6 || ie7 ? iebody.scrollWidth :
            (document.documentElement.clientWidth || self.innerWidth);
    pageHeight = ie || ie6 || ie7 ? iebody.clientHeight :
            (document.documentElement.clientHeight || self.innerHeight);

    var width = ie || ie6 || ie7 ? iebody.clientWidth :
            (document.documentElement.clientWidth || self.innerWidth),
        height = ie || ie6 || ie7 ? iebody.clientHeight : self.innerHeight;

    return {
        pageWidth: xScroll < pageWidth ? pageWidth : xScroll,
        pageHeight: yScroll < pageHeight ? pageHeight : yScroll,
        width: width,
        height: height,
        scrollLeft: ie || ie6 || ie7 ? iebody.scrollLeft : pageXOffset,
        scrollTop: ie || ie6 || ie7 ? iebody.scrollTop : pageYOffset
    }
}


$(document).ready(function () {
    //ShowPopup('dfsdf', 'dsfdsf');
    //ShowProcessing();
    $(window).resize(function () {
        SetPositionShowPopup();
        ShowBackgroundPopup();
    });
});
function ShowProcessing() {
    Pagesize = getPageSize();
    windowHeight = Pagesize.height;
    windownWidth = Pagesize.width;

    if ($('.ProcessingIcon').length == 0) {
        var str = '<div class="clsPopupBG_Processing"></div>'
            + '<div class="ProcessingIcon">'
                + '<i class="fa fa-spinner fa-spin a-3x fa-fw fa-2x"></i>'
                + '<p onclick="HideProcessing();">Cancel</p>'
            + '</div>';
        $('body').append(str);
    }
    processing = $('.ProcessingIcon');

    var processingHeight = parseInt(processing.css('height'), 10);
    var processingWidth = parseInt(processing.css('width'), 10);
    var pTop = (windowHeight - processingHeight) / 2;
    var pLeft = (windownWidth - processingWidth) / 2;
    processing.css('top', pTop + 'px');
    processing.css('left', pLeft + 'px');

    bgpopup_processing = $('.clsPopupBG_Processing');
    bgpopup_processing.css('width', windownWidth + 'px');
    bgpopup_processing.css('height', windowHeight + 'px');

    bgpopup_processing.show();
    processing.show();
}
function HideProcessing() {
    if (processing != null && bgpopup_processing != null) {
        processing.hide();
        bgpopup_processing.hide();
    }
}
var popup, bgpopup;
function ShowPopup(tilte, content, option) {
    ClosePopup();
    var str = '<div class="clsPopupPannel"><div class="popup-logo"><img src="images/logo.png" /></div><h2 class="clsClosePopup"><i class="fas fa-window-close"></i></h2>';
    if (tilte != '')
        str += '<h1 class="lblColor clsTitlePopup">' + tilte + '</h1>';
    str += '<div><table class="clsPopupContentDefault">';
    str += ' <tr><td align="center"><div class="clsSrollContent">' + content + '</div></td>  </tr>';
    str += '</table></div>';

    str += '<div id="tdControlButton" class="popup-content-button">';
    if (option == null) {
        str += '<input type="button" value="Đóng"  name="btnCancel" class="button-dark"/>';
    }
    str += '</div></div>';

    str += '<div class="clsPopupBG"></div>';
    $('body').append(str);
    if (option != null && option.length > 0) {
        try {
            var Ctrl = null;
            for (var i = 0; i < option.length; i++) {
                Ctrl = document.createElement('input');
                Ctrl.type = "button";
                Ctrl.value =  option[i].name;
                Ctrl.id = option[i].id == null ? 'btnImgControl_' + i : option[i].id;
                Ctrl.onclick = option[i].fClick;
                if (option[i].className != null)
                    Ctrl.className = option[i].className;
                else
                    Ctrl.className = "button-dark";

                $('#tdControlButton').append(Ctrl);
                $('#tdControlButton').append(' ');
            }
        }
        catch (e) { }
    }
    popup = $('.clsPopupPannel');
    bgpopup = $('.clsPopupBG');

    SetPositionShowPopup();

    popup.show();
    ShowBackgroundPopup();

    //drag
    $(popup).draggable({ handle: '.clsTitlePopup' });
    Pagesize = getPageSize();
    var windowHeight = Pagesize.height;
    var maxheightcontent = windowHeight - parseInt($('.clsTitlePopup').innerHeight()) - parseInt($('#tdControlButton').innerHeight()) - 90;
    $('.clsSrollContent').css({ 'overflow': 'auto', 'max-height': maxheightcontent });

    $('.clsClosePopup').unbind("click");
    $('.clsClosePopup').click(function () {
        ClosePopup();
    });

    $('input[name=btnCancel]').unbind();
    $('input[name=btnCancel]').click(function () {
        ClosePopup();
    });
}
function ClosePopup() {
    if (popup != null && bgpopup != null) {
        $(popup).remove();
        $(bgpopup).remove();
    }
}
function SetPositionShowPopup() {//SHOW POPUP FULL Screen
    if (popup != null) {
        var popupHeight, popupWidth;
        var pTop, pLeft;
        Pagesize = getPageSize();
        var windowHeight = Pagesize.height;
        var windownWidth = Pagesize.width;

        popup.addClass('CurPopupShow');

        //Lay dai rong       
        popupHeight = parseInt(popup.css('height'), 10);
        popupWidth = parseInt(popup.css('width'), 10);

        //popup.css('width', popupWidth + 'px');
        //popup.css('height', popupHeight + 'px');

        //canh giua
        pTop = (windowHeight - popupHeight) / 2;
        pLeft = (windownWidth - popupWidth) / 2;
        popup.css('top', pTop + 'px');
        popup.css('left', pLeft + 'px');
        //show		


        $(popup).unbind("draggable");
        //$(popup).draggable({ handle: '.clsTitlePopup' });

    }

}
function ShowBackgroundPopup() {
    if (bgpopup != null) {
        Pagesize = getPageSize();
        var windowHeight = Pagesize.height;
        var windownWidth = Pagesize.width;

        bgpopup.addClass('CurBgPopupShow');

        bgpopup.css('width', windownWidth + 'px');
        bgpopup.css('height', windowHeight + 'px');
        bgpopup.show();
    }
}


var popup2, bgpopup2;
function ShowPopup2(tilte, content, option) {
    ClosePopup2();
    var str = '<div class="clsPopupPannel2"><div class="popup-logo"><img src="images/logo.png" /></div><h2 class="clsClosePopup2"><i class="fas fa-window-close"></i></h2>';
    if (tilte != '')
        str += '<h1 class="lblColor clsTitlePopup2">' + tilte + '</h1>';
    str += '<div><table class="clsPopupContentDefault">';
    str += ' <tr><td align="center"><div class="clsSrollContent">' + content + '</div></td>  </tr>';   
    str += '</table></div></div>';

    str += '<div id="tdControlButton2" class="popup-content-button">';
    if (option == null) {
        str += '<input type="button" value="Đóng"  name="btnCancel2" class="button-dark"/>';
    }
    str += '</div></div>';

    str += '<div class="clsPopupBG2"></div>';
    $('body').append(str);
    if (option != null && option.length > 0) {
        try {
            var Ctrl = null;
            for (var i = 0; i < option.length; i++) {
                Ctrl = document.createElement('input');
                Ctrl.type = "button";
                Ctrl.value = option[i].name;
                Ctrl.id = 'btnImgControl2_' + i;
                Ctrl.onclick = option[i].fClick;
                Ctrl.className = "button-dark";
                $('#tdControlButton2').append(Ctrl);
                $('#tdControlButton2').append(' ');
            }
        }
        catch (e) { }
    }
    popup2 = $('.clsPopupPannel2');
    bgpopup2 = $('.clsPopupBG2');

    SetPositionShowPopup2();

    popup2.show();
    ShowBackgroundPopup2();

    //drag
    $(popup2).draggable({ handle: '.clsTitlePopup2' });
    Pagesize = getPageSize();
    var windowHeight = Pagesize.height;
    var maxheightcontent = windowHeight - parseInt($('.clsTitlePopup2').innerHeight()) - parseInt($('#tdControlButton2').innerHeight()) - 90;
    $('.clsSrollContent2').css({ 'overflow': 'auto', 'max-height': maxheightcontent });

    $('.clsClosePopup2').unbind("click");
    $('.clsClosePopup2').click(function () {
        ClosePopup2();
    });

    $('input[name=btnCancel2]').unbind();
    $('input[name=btnCancel2]').click(function () {
        ClosePopup2();
    });
}
function ClosePopup2() {
    if (popup2 != null && bgpopup2 != null) {
        $(popup2).remove();
        $(bgpopup2).remove();
    }
}


function SetPositionShowPopup2() {//SHOW POPUP FULL Screen
    if (popup2 != null)
    {
        var popupHeight, popupWidth;
        var pTop, pLeft;
        Pagesize = getPageSize();
        var windowHeight = Pagesize.height;
        var windownWidth = Pagesize.width;

        popup2.addClass('CurPopupShow2');

        //Lay dai rong       
        popupHeight = parseInt(popup2.css('height'), 10);
        popupWidth = parseInt(popup2.css('width'), 10);

        //popup.css('width', popupWidth + 'px');
        //popup.css('height', popupHeight + 'px');

        //canh giua
        pTop = (windowHeight - popupHeight) / 2;
        pLeft = (windownWidth - popupWidth) / 2;
        popup2.css('top', pTop + 'px');
        popup2.css('left', pLeft + 'px');
        //show		


        $(popup2).unbind("draggable");
        //$(popup).draggable({ handle: '.clsTitlePopup' });

    }

}
function ShowBackgroundPopup2() {
    if (bgpopup2 != null) {
        Pagesize = getPageSize();
        var windowHeight = Pagesize.height;
        var windownWidth = Pagesize.width;

        bgpopup2.addClass('CurBgPopupShow2');

        bgpopup2.css('width', windownWidth + 'px');
        bgpopup2.css('height', windowHeight + 'px');
        bgpopup2.show();
    }
}
