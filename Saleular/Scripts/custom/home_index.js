$(document).ready(DocumentIsReady);

function DocumentIsReady() {

    var c = $('#carousel');
    c.carousel();

    c.on('slid', function () {
        var index = $(this).find('.active').index();
        var cdiv = $('#carouselDiv');

        cdiv.animate({
            opacity: 0
        }, 10, 'swing', function () {
            $('#carouselCaption').text(GetCarouselCaption(index));
        });

        cdiv.animate({
            opacity: 1
        }, 1000, 'swing');
    });
}

function GetCarouselCaption(index) {
    if (index == 0) {
        return "Step 1: Get a Quick Offer For Your iPhone";
    }

    if (index == 1) {
        return "Step 2: Get a Free Shipping Label";
    }

    if (index == 2) {
        return "Step 3: Get Paid Fast!";
    }
}