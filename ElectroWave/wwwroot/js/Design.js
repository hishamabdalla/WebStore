$(document).ready(function () {
    $('.product-card').hover(function () {
        $(this).find('.product-image img').css('transform', 'scale(1.1)');
    }, function () {
        $(this).find('.product-image img').css('transform', 'scale(1)');
    });
});
