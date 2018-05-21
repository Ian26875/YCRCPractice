$(function () {
    var format = $("[data-datetimepicker]").data('date_format');
    $("[data-datetimepicker]").datetimepicker({
        
        format: format
    });

});