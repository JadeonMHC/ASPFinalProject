$(document).ready(function () {
    var AccordianSelected = null;
    $(".Accordian .Title").on('click', function () {
        if (AccordianSelected != $(this))
            $(this).nextAll('.Slice:first').animate({
                height: '200px'
            }, 500);

        if (AccordianSelected != null)
            AccordianSelected.animate({
                height: '0px'
            }, 500);

        AccordianSelected = $(this).nextAll('.Slice:first');
    });
});