$(document).ready(function () {
    var caption = $('.iphone-caption');
    var caption2 = $('.iphone-caption2');
    var caption3 = $('.iphone-caption3');

    caption.animate({
        opacity: 1,
        top: 20
    }, 3000, 'swing');

    var interval = setInterval(function () {
        caption2.animate({
            opacity: 1
        }, 1000, 'swing');
    }, 3000);

    var interval2 = setInterval(function () {
        caption3.animate({
            opacity: 1
        }, 1000, 'swing');
    }, 4000);    
});