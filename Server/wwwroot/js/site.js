$(function () {

    $('form').submit(function(e) {

        if ($(this).valid()) {

            $('button').prop('disabled', true);
            $('input[type=button]').prop('disabled', true);

        }

    });

    //Config PersianDate Picker
    $('.persian-date').pDatepicker({
        observer: true,
        format: 'YYYY/MM/DD',
        initialValue: false,
    });

})
