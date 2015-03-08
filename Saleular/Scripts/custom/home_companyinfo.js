$(document).ready(function () {    
    var salesRep = $('#salesRep');
    salesRep.on('mouseover', function () {
        var salesRepText = $('.sales-rep-text');

        salesRepText.animate({
            opacity: .2
        }, 100, 'swing');

        salesRepText.animate({
            opacity: 1
        }, 1000, 'swing');
    });       
});