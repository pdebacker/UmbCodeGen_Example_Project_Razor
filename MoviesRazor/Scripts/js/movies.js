
$(document).ready(function () {

    $('.filteritem').click(function (e) {

        e.preventDefault();

        var elem = $(this).parent();

        $.ajax({
            type: "POST",
            url: document.location + '?genreId=' + $(this).attr('data-item'),
            contentType: "application/json; charset=utf-8",
            success: function (responseData) {
                if (responseData != null) {
        
                    //var template = $('[data-template="movies.mustache"]').html();
                    //var partials = [];
                    //$('[data-template]').each(function () {
                    //    partials[$(this).data('template')] = $(this).html();
                    //});

                    //var html = Mustache.render(template, JSON.parse(responseData), partials);
                    //$('#movies').html(html);

                    $('#movies').html(responseData);

                    $('.filteritem').parent().removeClass('active');
                    $(elem).addClass('active');

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorCode = xhr.status;
                alert('Filter Error');
            }
          });

    });

});