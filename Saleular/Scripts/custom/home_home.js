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

    var twitterLink = $('#twitterLink');
    var msLink = $('#msLink');
    var fbLink = $('#fbLink');

    twitterLink.on('click', function() {
        var twitterWindow = window.open('http://www.twitter.com/saleular', 'twitterWindow');
        twitterWindow.focus();
        return false;
    });

    msLink.on('click', function () {
        var msWindow = window.open('http://www.twitter.com/saleular', 'msWindow');
        msWindow.focus();
        return false;
    });

    fbLink.on('click', function () {
        var fbWindow = window.open('http://www.twitter.com/saleular', 'fbWindow');
        fbWindow.focus();
        return false;
    });
});