function AddPost(o) {
  
    //var surl = GetURL('newpost'); //  arr.join('/') + 'layouthtml/newpost.aspx';
    //$.ajax({
    //    url: surl,
    //    type: "GET",
    //    cache: false,
    //    success: function (content) {
    //        var opt = [{
    //            name: "Tiếp tục", fClick: function () {
    //                ClosePopup();
    //            }
    //        },{
    //            name: "Hủy", fClick: function () {
    //                ClosePopup();
    //                }, className: "button-light"
    //        }];
    //        ShowPopup('Đăng tin', content, opt);
    //        // dang ky event
    //        $('#txtDiachi').blur(function () { alert();});
    //    },
    //    error: function (e) {

    //    }
    //});
    //alert($(o).attr('actiondata'));
    window.location = $(o).attr('actiondata');

   
}

function ChonLoai(iloadi) {

 
    var surl = GetURL('newpost')+'?step=2&type=' + iloadi;
    $.ajax({
        url: surl,
        type: "GET",
        cache: false,
        success: function (content) {
            var opt = [{
                name: "Tiếp tục", fClick: function () {
                    ClosePopup();
                }
            }, {
                    name: "Hủy", fClick: function () {
                        ClosePopup();
                    }, className: "button-light"
                }];
            ShowPopup('Đăng tin', content, opt);
           
        },
        error: function (e) {
            alert(e);
        }
    });
}