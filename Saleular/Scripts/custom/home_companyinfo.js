$(document).ready(function () {

    var salesRep = $('.sales-rep-img');
    salesRep.on('mouseover', function () {
        var salesRepText = $('.sales-rep-text');

        salesRepText.animate({
            opacity: .5
        }, 100, 'swing');

        salesRepText.animate({
            opacity: 1
        }, 1000, 'swing');
    });

    var iphoneMavens = $('.iphone-img-text');
    iphoneMavens.on('mouseover', function () {
        var iPhoneText = $('#iphoneText');

        iPhoneText.animate({
            opacity: .5
        }, 100, 'swing');

        iPhoneText.animate({
            opacity: 1
        }, 1000, 'swing');
    });

    var bridge = $('#nl-img-text');
    bridge.on('mouseover', function () {
        var nlTextId = $('#nlText');        

        nlTextId.animate({
            opacity: .5
        }, 100, 'swing');        

        nlTextId.animate({
            opacity: 1
        }, 1000, 'swing');        
    });
});