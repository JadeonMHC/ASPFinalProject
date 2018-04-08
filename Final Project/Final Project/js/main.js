'use strict'

$(document).ready(function () {

    GetDBNames();
});

function GetDBNames() {
    var dbl = $("#pnlFiles");

    setInterval(function () {
        $.post('/CarData.aspx', {car: 2}, function (data) {
            var sp = data.split(',');

            $("#txtCurr").html('<div>' + sp[0] + '</div><div>' + parseFloat(sp[1]) + '</div><div>' + parseFloat(sp[2]) + '</div>');

            map.removeMarkers();
            map.addMarker({
                lat: parseFloat(sp[1]),
                lng: parseFloat(sp[2]),
                title: 'Starting Location',
                click: function (e) { }
            });
        });
    }, 500);

    $.post("/DBData.aspx", { action: 'list_sources' }, function (data) {
        data.forEach(function (db) {
            var ne = $('<div>');
            ne.text(db);

            dbl.append(ne);

            ne.on('click', DBSelected);
        });
    });
}

function DBSelected() {
    var name = $(this).text();

    $.post("/DBData.aspx", { action: 'get_db', name: name }, function (data) {
        var db = {
            points: []
        };

        var raw = [];

        data.forEach(function (item) {
            if (item[2].startsWith('$GPRMC')) {
                var time = item[1].split('T')[1].split(':');
                time[0] = parseInt(time[0]);
                time[1] = parseInt(time[1]);
                time[2] = parseInt(time[2]);

                var dparts = item[2].split(',');

                if (dparts[4] == 'N' && dparts[6] == 'W' && parseFloat(dparts[3]) > 0 && parseFloat(dparts[5]) > 0) {
                    db.points.push([
                        parseFloat(GetDeg(dparts[3], dparts[4]).toFixed(7)),
                        parseFloat(GetDeg(dparts[5], dparts[6]).toFixed(7)),
                        time
                    ]);
                    raw.push(item);
;                    //raw.push([dparts[3], dparts[4], dparts[5], dparts[6]]);
                }
            }
        });

        DrawPath(map, db.points, $("input[name=lineStyle]:checked").val() == 'dashed');

        map.removeMarkers();
        SetEndMarkers(db.points);

        var c = CalcCenter(db.points);

        map.setCenter(c[0], c[1]);
        map.setZoom(13);

        console.log(db);
    });
}

function SetEndMarkers(points) {
    map.addMarker({
        lat: points[0][0],
        lng: points[0][1],
        title: 'Starting Location',
        click: function (e) { }
    });

    map.addMarker({
        lat: points[points.length - 1][0],
        lng: points[points.length - 1][1],
        title: 'Ending Location',
        click: function (e) { }
    });
}

function CalcCenter(points) {
    var min = [points[0][0], points[0][1]];
    var max = [points[0][0], points[0][1]];

    points.forEach(function (p) {
        min[0] = Math.min(min[0], p[0]);
        min[1] = Math.min(min[1], p[1]);

        max[0] = Math.max(max[0], p[0]);
        max[1] = Math.max(max[1], p[1]);
    });

    return [
        (min[0] * 0.5) + (max[0] * 0.5),
        (min[1] * 0.5) + (max[1] * 0.5)
    ];
}