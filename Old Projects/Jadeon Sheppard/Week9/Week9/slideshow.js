var slides = [

];

var numSlide = 0;

function UpdateSlide() {
    var sso = $(".Slideshow .Content");

    while (numSlide < 0)
        numSlide += slides.length;

    while (numSlide >= slides.length)
        numSlide -= slides.length;

    sso.html(slides[numSlide].html);
}

$(document).ready(function () {
    $.post('/API.aspx', null, function (data, error) {
        slides = data;

        UpdateSlide();

        $(".Prev").on('click', function () {
            numSlide--;
            UpdateSlide();
        });

        $(".Next").on('click', function () {
            numSlide++;
            UpdateSlide();
        });
    });

});
 