$(document).ready(function () {
    var caption = $('.iphone-caption');
    var caption2 = $('.iphone-caption2');
    var caption3 = $('.iphone-caption3');

    caption.animate({
        opacity: 1,
        top: '20px'
    }, 1000, 'swing');

    caption2.animate({
        opacity: 1
    }, 3000, 'swing');

    caption3.animate({
        opacity: 1
    }, 3000, 'swing');   
});