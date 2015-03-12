$(document).ready(function () {
    
    var c = $('#carousel');
    c.carousel();

    swingInCustomerServiceText();

    c.on('slid', function () {
        var index = $(this).find('.active').index();
        
        if (index == 0) {
            
        }

        if (index == 1) {
            swingInCustomerServiceText();
        }
    });

    function swingInCustomerServiceText()
    {
        var customerService = $('#customerServiceText');
        customerService.animate({
            opacity: 1,
            left: '35px'
        }, 1000, 'swing');

        var testimonialsTextHeader = $('#testimonialsTextHeader');
        testimonialsTextHeader.animate({
            opacity: 1,
            left: '35px'
        }, 2000, 'swing');

        var testimonialsText1 = $('#testimonialsText1');
        testimonialsText1.animate({
            opacity: 1,
            left: '35px'
        }, 3000, 'swing');

        var testimonialsText2 = $('#testimonialsText2');
        testimonialsText2.animate({
            opacity: 1,
            left: '145px'
        }, 3000, 'swing');
    }

    //$('#salesRep').hover(function () {
    //    $('#salesRepText').toggleClass("ci-text-shadow");
    //});

    //$('#iphones').hover(function () {        
    //    $('#iphoneText').toggleClass("ci-text-shadow");
    //});

    //$('#location').hover(function () {
    //    $('#locationText').toggleClass("ci-text-shadow");
    //    $('#bridgeText').toggleClass("ci-text-shadow-white");
    //});
});