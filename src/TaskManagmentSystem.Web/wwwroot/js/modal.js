$(document).ready(function () {
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        event.preventDefault();
        this.blur(); // Manually remove focus from clicked link.
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('.modal').remove();
            $(data).appendTo('body').modal();

            $('button[data-save="modal"]').click(function (event) {
                event.preventDefault();
                var form = $(this).parents('.modal').find('form');
                var url = form.attr('action');
                var data = form.serialize();

                $.post(url, data).done(function (data) {
                    var valSummary = $(data).find('#valSummary');
                    console.log(valSummary);
                    if (valSummary.length === 0) {
                        console.log('created');
                        $.modal.close();
                        $('.taskList').empty();
                        $('.taskList').append(data);
                    }
                    else {               
                        $('.modal form #valSummary').empty();
                        $('.modal form #valSummary').append(valSummary);
                    }
                });
            });
        });
    });
});