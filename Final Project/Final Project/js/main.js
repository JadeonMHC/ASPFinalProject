'use strict'

var liveaddr = "";
var adb;

$(document).ready(function () {
    GetDBNames();

    /*$($("#gphHolder canvas")[0]).width('500px');
    $($("#gphHolder canvas")[1]).width('500px');*/

    $("#gphHolder canvas").mousemove(function (event) {
        if (ctx) {
            var offset = $(this).offset();

            var x = event.pageX - offset.left;
            var y = (event.pageY - offset.top);

            //DrawGraph(adb);

            var gphcan = $("#gphOverlay");
            var ct = gphcan[0].getContext("2d");

            gphcan[0].width = gphcan.width();
            gphcan[0].height = gphcan.height();

            ct.clearRect(0, 0, $(this).width(), $(this).height());

            ct.beginPath();
            ct.moveTo(x, 0);
            ct.lineTo(x, $(this).height());
            ct.strokeStyle = '#777';
            ct.stroke();

            ct.beginPath();
            ct.arc(x, y, 5, 0, 2 * Math.PI);
            ct.fillStyle = 'white';
            ct.strokeStyle = '#CCC';
            ct.fill();
            ct.stroke();
        }
    });

    $("#btnLive").on("click", function () {
        liveaddr = $("#txtLiveAddr").val();
        
        setInterval(function () {
            $.post('/CarData.aspx', { addr: liveaddr, car: 2 }, function (data) {
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
    });
});

function GetDBNames() {
    var dbl = $("#pnlFiles");

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
            points: [],
            fuel: [],
            cut: []
        };

        var raw = [];

        data.forEach(function (item) {
            if (item[2].startsWith('$GPRMC')) {
                var dparts = item[2].split(',');

                if (dparts[4] == 'N' && dparts[6] == 'W' && parseFloat(dparts[3]) > 0 && parseFloat(dparts[5]) > 0) {
                    db.points.push([
                        parseFloat(GetDeg(dparts[3], dparts[4]).toFixed(7)),
                        parseFloat(GetDeg(dparts[5], dparts[6]).toFixed(7)),
                        ParseTime(item[1])
                    ]);
                    raw.push(item);
                    //raw.push([dparts[3], dparts[4], dparts[5], dparts[6]]);
                }
            }
            else if (item[2].startsWith('$Fuel')) {
                var pts = item[2].split(',');

                for (var i = 1; i < 4; i++) {
                    if (pts[i] == "")
                        pts[i] = "0";
                }

                db.fuel.push([
                    ParseTime(item[1]),
                    parseFloat(pts[1]),
                    parseFloat(pts[2]),
                    parseFloat(pts[3])
                ]);
            }
            else {
                db.cut.push(item);
            }
        });

        DrawPath(map, db.points, $("input[name=lineStyle]:checked").val() == 'dashed');

        map.removeMarkers();
        SetEndMarkers(db.points);

        var c = CalcCenter(db.points);

        map.setCenter(c[0], c[1]);
        map.setZoom(13);

        console.log(db);

        adb = db;
        DrawGraph(db);
    });
}

function ParseTime(t) {
    var time = t.split('T')[1].split(':');
    time[0] = parseInt(time[0]);
    time[1] = parseInt(time[1]);
    time[2] = parseInt(time[2]);

    return time[2] + (time[1] * 60) + (time[0] * 60 * 60);
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