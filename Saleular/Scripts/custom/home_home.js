$(document).ready(function () {
    var caption = $('.iphone-caption');
    var caption2 = $('.iphone-caption2');
    var caption3 = $('.iphone-caption3');

    setTooltip($('.pointer-tooltip'));

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
    var liLink = $('#liLink');

    twitterLink.on('click', function() {
        var twitterWindow = window.open('http://www.twitter.com/saleular', 'twitterWindow');
        twitterWindow.focus();
        return false;
    });

    msLink.on('click', function () {
        //alert('Search Skype for Saleular1!');        
        //BootstrapDialog.alert('I want banana!');
    });

    fbLink.on('click', function () {
        var fbWindow = window.open('https://www.facebook.com/saleular', 'fbWindow');
        fbWindow.focus();
        return false;
    });

    liLink.on('click', function () {
        var liWindow = window.open('https://www.linkedin.com/pub/roy-bitran/40/560/359', 'liWindow');
        liWindow.focus();
        return false;
    });


    function setTooltip(addon) {
        addon.tooltip();
        addon.css('cursor', 'pointer');
    }
});