function ThanhPhoFilter_Focus(o) {

    $('#divPartialThanhPhoFilter').load('/DAK/ListCity');
    $(o).closest('.input-list-checkbox').find('.list-checkbox-defaut').show();

 }