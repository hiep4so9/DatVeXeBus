validateForm = (id_element) => {
    var value = $('#' + id_element).val();
    if (!(value.length > 0)) {
        $('#' + id_element + '_validate').css('display', 'block');
        $('#' + id_element + '_validate').html(`Field ${id_element} is required !`);
    }
    else {
        $('#' + id_element + '_validate').css('display', 'none');
    }
}