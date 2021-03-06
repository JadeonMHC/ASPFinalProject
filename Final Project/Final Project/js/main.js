﻿'use strict'

var liveaddr = null;
var livetimer = null;
var adb;

var currmar;

$(document).ready(function () {
    GetDBNames();

    $("#gphLabel .ColBox").on('click', function () {
        var index = $(this).index() / 2;
        show[index] = !show[index];

        DrawGraph(adb);
    });

    $("#gphHolder canvas").mouseout(function () {
        var gphcan = $("#gphOverlay");
        var ct = gphcan[0].getContext("2d");
        ct.clearRect(0, 0, $(this).width(), $(this).height());
    });

    $("#gphHolder canvas").mousemove(function (event) {
        if (ctx) {
            var offset = $(this).offset();

            var x = event.pageX - offset.left;
            var y = (event.pageY - offset.top);

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

    $("#gphOverlay").on('click', function (event) {
        if (ctx) {
            var offset = $(this).offset();
            var x = event.pageX - offset.left;

            x /= $(this).width();
            
            x -= 0.15 * 0.5;
            x /= 0.85;

            x = Math.min(1.0, Math.max(x, 0.0));

            var tt = adb.points.length - 1;
            tt *= x;
            tt = Math.floor(tt);

            map.removeMarker(currmar);

            currmar = map.addMarker({
                lat: adb.points[tt][0],
                lng: adb.points[tt][1],
                title: '',
                click: function (e) { }
            });

            
        }
    });

    $("#btnLive").on("click", function () {
        var gphcan = $("#gphMain");
        var ct = gphcan[0].getContext("2d");
        ct.clearRect(0, 0, gphcan.width(), gphcan.height());

        gphcan = $("#gphOverlay");
        ct = gphcan[0].getContext("2d");
        ct.clearRect(0, 0, gphcan.width(), gphcan.height());

        $("#gphLabel").css('display', 'none');

        if (livetimer == null) {
            $("#btnLive").val("Disconnect");
            liveaddr = $("#txtLiveAddr").val();

            map.removeMarkers();
            map.cleanRoute();

            livetimer = setInterval(function () {
                $.post('/CarData.aspx', { addr: liveaddr, car: 2 }, function (data) {
                    var sp = data.split(',');
                    const fn = 5;

                    $("#txtCurr").html(
                        '<div style="margin-left: 11px; font-size: 11px;">' + sp[0] + ' ' + vv(sp[1]) + ' ' + vv(sp[2]) + '</div>' +
                        '<div style="margin-left: 11px; font-size: 11px;">' + sp[3] + ' ' + vv(sp[4]) + ' ' + vv(sp[5]) + '</div>' +
                        '<div style="margin-left: 11px; font-size: 11px;">' + sp[6] + ' ' + vv(sp[7]) + ' ' + vv(sp[8]) + '</div>'
                    );

                    function vv(f) {
                        var v = parseFloat(f);
                        return v.toFixed(fn);
                    }
                    
                    map.removeMarkers();
                    map.addMarker({
                        lat: parseFloat(sp[1]),
                        lng: parseFloat(sp[2]),
                        icon: '/img/PinBike.png',
                        click: function (e) { }
                    });

                    map.addMarker({
                        lat: parseFloat(sp[4]),
                        lng: parseFloat(sp[5]),
                        icon: '/img/PinTruck.png',
                        click: function (e) { }
                    });

                    map.addMarker({
                        lat: parseFloat(sp[7]),
                        lng: parseFloat(sp[8]),
                        icon: '/img/PinCorv.png',
                        click: function (e) { }
                    });
                });
            }, 500);
        }
        else {
            CancelLive();
        }
    });
});

function CancelLive() {
    if (livetimer != null)
        clearInterval(livetimer);

    livetimer = null;
    $("#btnLive").val("Connect");
    map.removeMarkers();
}

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

function CalcFuelEcon(speed, maf)
{
    var econ = maf * 0.00325267;
    if (econ > 0)
        econ = speed / econ;
    if (econ > 0)
        econ = 100 / econ;

    return econ;
}

function DBSelected() {
    var name = $(this).text();

    CancelLive();
    show = [true, true, true];

    $.post("/DBData.aspx", { action: 'get_db', name: name }, function (data) {
        var db = {
            points: [],
            fuel: [],
            max: [0, 0, 0]
        };

        var raw = [];

        $("#gphLabel").css('display', 'inherit');

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

                var speed = parseFloat(pts[1]);
                var rpm = parseFloat(pts[2]);
                var maf = parseFloat(pts[3]);

                var fef = CalcFuelEcon(speed, maf);

                db.max[0] = Math.max(db.max[0], speed);
                db.max[1] = Math.max(db.max[1], rpm);
                db.max[2] = Math.max(db.max[2], fef);

                db.fuel.push([
                    ParseTime(item[1]),
                    speed,
                    rpm,
                    fef
                ]);
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