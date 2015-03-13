$(document).ready(function () {
    
    var c = $('#carousel');
    c.carousel();    

    var customerService = $('#customerServiceText');
    var testimonialsTextHeader = $('#testimonialsTextHeader');
    var testimonialsText = $('#testimonialsText');

    var specializesText = $('#specializesText');
    var businessTextHeader = $('#businessTextHeader');
    var businessText = $('#businessText');

    var locationText = $('#locationText');
    var growthTextHeader = $('#growthTextHeader');
    var growthText = $('#growthText');
    
    swingCustomerServiceText();

    c.on('slid', function () {
        var index = $(this).find('.active').index();
        
        if (index == 0) {
            swingCustomerServiceText();

            resetLocationText();
            resetSpecializesText();
        }

        if (index == 1) {
            swingSpecializesText();

            resetLocationText();
            resetCustomerServiceText();
        }

        if (index == 2) {
            swingLocationText();

            resetSpecializesText();
            resetCustomerServiceText();
        }
    });

    function resetCustomerServiceText() {
        customerService.css({ 'left': '500px', opacity: 0 });
        testimonialsTextHeader.css({ 'left': '500px', opacity: 0 });
        testimonialsText.css({ 'left': '500px', opacity: 0 });        
    }

    function resetSpecializesText() {
        specializesText.css({ 'left': '500px', opacity: 0 });
        businessTextHeader.css({ 'left': '500px', opacity: 0 });
        businessText.css({ 'left': '500px', opacity: 0 });
    }

    function resetLocationText() {
        locationText.css({ 'left': '500px', opacity: 0 });
        growthTextHeader.css({ 'left': '500px', opacity: 0 });
        growthText.css({ 'left': '500px', opacity: 0 });
    }

    function swingCustomerServiceText()
    {        
        customerService.animate({
            opacity: 1,
            left: '35px'
        }, 1000, 'swing');
        
        testimonialsTextHeader.animate({
            opacity: 1,
            left: '35px'
        }, 2000, 'swing');
        
        testimonialsText.animate({
            opacity: 1,
            left: '35px'
        }, 3000, 'swing');                
    }

    function swingSpecializesText() {
        specializesText.animate({
            opacity: 1,
            left: '35px'
        }, 1000, 'swing');

        businessTextHeader.animate({
            opacity: 1,
            left: '35px'
        }, 2000, 'swing');
        
        businessText.animate({
            opacity: 1,
            left: '35px'
        }, 3000, 'swing');
    }

    function swingLocationText() {
        locationText.animate({
            opacity: 1,
            left: '35px'
        }, 1000, 'swing');

        growthTextHeader.animate({
            opacity: 1,
            left: '35px'
        }, 2000, 'swing');

        growthText.animate({
            opacity: 1,
            left: '35px'
        }, 3000, 'swing');
    }
});