$(document).ready(function () {
    
    $('#salesRep').hover(function () {
        $('#salesRepText').toggleClass("ci-text-shadow");
    });

    $('#iphones').hover(function () {        
        $('#iphoneText').toggleClass("ci-text-shadow");
    });

    $('#location').hover(function () {
        $('#locationText').toggleClass("ci-text-shadow");
        $('#bridgeText').toggleClass("ci-text-shadow-white");
    });
});