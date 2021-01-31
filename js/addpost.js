function AddPost() {
  
    var surl = GetURL('newpost'); //  arr.join('/') + 'layouthtml/newpost.aspx';
    $.ajax({
        url: surl,
        type: "GET",
        cache: false,
        success: function (content) {
            ShowPopup('Đăng tin', content, null);
            // dang ky event
            $('#txtDiachi').blur(function () { alert();});
        },
        error: function (e) {
       
        }
    });
 
}

function ChonLoai(iloadi) {

 
    var surl = GetURL('newpost')+'?step=2&type=' + iloadi;
    $.ajax({
        url: surl,
        type: "GET",
        cache: false,
        success: function (content) {
            ShowPopup('Đăng tin', content, null);
           
        },
        error: function (e) {
            alert(e);
        }
    });
}