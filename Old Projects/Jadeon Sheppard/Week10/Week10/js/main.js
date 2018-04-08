const months = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
];

const icons = [
    '🎂',
    '🛌',
    '🎈',
    '💼',
    '🍴',
    '🚗',
    '🚲',
    '🛬',
    '⚓',
    '🏥',
    '⛪',
    '🌅'               
];

var allDates;
var selectedDate = null;
var now = new Date();
var events = [];

var selectedevent = null;


$(document).ready(function () {
    allDates = $('#MainCalendar tr:not(:first-of-type) td');

    $('#MainCalendar tr:first-of-type td[align="center"]').addClass('Title');

    allDates.children('a').removeAttr('href style');
    allDates.children('a').addClass('noselect');
    
    allDates.on('click', function () {
        selectedevent = null;

        if (selectedDate != null)
            selectedDate.removeClass('selected');

        if (selectedDate == null || selectedDate[0] != this) {
            $("#Sidebar").html('<div class="Title"></div>\
                <h2>Events</h2>\
                <div id="Events"></div>\
                <div id="btnAddEvent">Add</div>\
                <div id="btnEditEvent">Edit</div>\
                <div id="btnDeleteEvent">Delete</div>');


            $("#btnAddEvent").on('click', function () {
                if ($("#Sidebar .Title").text().trim() != "")
                    addEventBox(null);
            });

            $("#btnEditEvent").on('click', function () {
                if (selectedevent != null)
                    addEventBox(selectedevent.data('eventobj'));
            });

            $("#btnDeleteEvent").on('click', function () {
                if (selectedevent != null) {
                    $.post('/API.aspx', { action: 'deleteEvent', id: selectedevent.data('eventobj').id }, function (data, success) {
                        location.reload(true);
                    });
                }
            });

            $(this).addClass('selected');

            var d = boxDate(this);

            selectedDate = $(this);
            $("#Sidebar .Title").text(d[0] + ' ' + d[1] + ', ' + currentMonth()[1]);

            $("#Events").html("");

            events.forEach(function (event) {
                if (event.date == $("#Sidebar .Title").text()) {
                    var ev = $('<div class="listevent"><h4>' + event.time + event.icon + event.title + '</h4><div>' + event.description + '</div></div>');
                    ev.data('eventobj', event);
                    $("#Events").append(ev);

                    ev.on('click', function () {
                        if (selectedevent != null)
                            selectedevent.removeAttr('style');

                        $(this).css('background-color', '#007fff');
                        selectedevent = $(this);
                    });
                }
            });
        }
        else {
            selectedDate = null;
            $("#Sidebar").html("");
        }
    });

    allDates.each(function () {
        $(this).addClass('day');

        if (boxDate(this)[0] != currentMonth()[0])
            $(this).addClass('notmonth');
    });

    dateBox(months[now.getMonth()] + ' ' + now.getDate()).addClass('today');

    $.post('/API.aspx', { action: 'getDB' }, function (data, success) {
        events = data.events;

        console.log(events);

        events.forEach(function (event) {
            var box = dateBox(event.date.split(',')[0]);

            if (box.children('.icons').length == 0) {
                box.append('<div class="icons"></div>');
            }

            box.children('.icons').append(event.icon);
        });
    });
});

function addEventBox(event) {
    $('.popup').remove();

    var selicon = null;

    var holder = $('<div class="popup">');
    var box = $('<div class="box">');

    box.append('<div class="inputLabel">Title</div><input id="eventTitle" type="text" />');
    box.append('<div class="inputLabel">Icon</div>');

    var iconArea = $('<div class="iconArea">');
    box.append(iconArea);

    icons.forEach(function (icon) {
        var ic = $('<div>' + icon + '</div>');
        iconArea.append(ic);

        if (event != null) {
            if (icon == event.icon) {
                selicon = ic;
                ic.addClass('iconSelected');
            }
        }

        ic.on('click', function () {
            if (selicon != null)
                selicon.removeClass('iconSelected');

            selicon = ic;
            selicon.addClass('iconSelected');
        });
    });

    box.append('<div class="inputLabel">Description</div><textarea id="eventDesc"></textarea>');
    box.append('<div class="inputLabel">Time</div><input id="eventTime" type="time" value="12:00" />');

    var bsave = $('<div id="btnSaveEvent">Save</div>');

    box.append(bsave);

    holder.append(box);
    $('body').append(holder);

    if (event != null) {
        $('#eventTitle').val(event.title);
        $('#eventDesc').val(event.description);
        $('#eventTime').val(event.time);
    }

    holder.on('click', function () { $('.popup').remove(); });
    box.on('click', function (e) { e.stopPropagation(); });

    bsave.on('click', function () {
        var eo = {
            action: event == null ? 'addEvent' : 'editEvent',
            title: $('#eventTitle').val(),
            icon: selicon.text(),
            desc: $('#eventDesc').val(),
            time: $('#eventTime').val(),
            date: $("#Sidebar .Title").text()
        };

        if (event != null)
            eo.id = event.id;

        console.log(eo);

        $.post('/API.aspx', eo, function (data, error) {
            console.log(data, error);
            location.reload(true);
        });
    });
}

function dateBox(date) {
    return $('a[title="' + date + '"]').parent();
}

function boxDate(box) {
    return $(box).children('a').attr('title').trim().split(' ');
}

function currentMonth() {
    return $('#MainCalendar tr:first-of-type td[align="center"]').text().trim().split(' ');
}