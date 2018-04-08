var transTime = 150;

var AccordianSelected = null;
var HeaderHidden = false;

function pad(num, size) {
    var s = "000000000" + num;
    return s.substr(s.length - size);
}

function SetTime() {
    var timer = $('#Timer span');
    var d = new Date();

    timer.html(pad(d.getHours(), 2) + ':' + pad(d.getMinutes(), 2) + ':' + pad(d.getSeconds(), 2));
}

function HeaderTrans() {
    if ($(window).scrollTop() >= 100) {
        if (!HeaderHidden) {
            $('#Header').animate({
                backgroundColor: '#333',
                height: '25px'
            }, transTime);

            $('#Header a').animate({
                color: 'white',
                fontSize: '13px'
            }, transTime);

            $('#Timer').animate({
                //width: '90px',
                height: '25px',

                borderWidth: '0px',
                color: '#DDD',
                fontSize: '12px'
            }, transTime);

            HeaderHidden = true;
        }
    }
    else if (HeaderHidden) {
        $('#Header').animate({
            backgroundColor: 'white',
            height: '70px'
        }, transTime);

        $('#Header a').animate({
            color: '#777',
            fontSize: '16px'
        }, transTime);

        $('#Timer').animate({
            //width: '300px',
            height: '40px',

            borderWidth: '2px',
            color: '#777',
            fontSize: '16px'
        }, transTime);

        HeaderHidden = false;
    }
}

$(document).ready(function () {
    SetTime();
    setInterval(SetTime, 1000);
    
    HeaderTrans();
    $(window).on('scroll', HeaderTrans);

    $("#Header a").mouseover(function () {
        $(this).animate({
            color: HeaderHidden ? '#999' : '#333'
        }, 80);
    });

    $("#Header a").mouseout(function () {
        $(this).animate({
            color: HeaderHidden ? 'white' : '#777'
        }, 80);
    });

    $(".Accordian .Title").on('click', function () {
        if (AccordianSelected != $(this))
            $(this).nextAll('.Slice:first').animate({
                height: '300px'
            }, 500);

        if (AccordianSelected != null)
            AccordianSelected.animate({
                height: '0px'
            }, 500);

        AccordianSelected = $(this).nextAll('.Slice:first');
    });
});