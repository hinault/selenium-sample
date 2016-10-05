$(function () {
    $("input[name='DateNais']").datepicker({
        dateFormat: 'yy-mm-dd',
        changeMonth: true,
        changeYear: true,
        showTimepicker: false
    });
});