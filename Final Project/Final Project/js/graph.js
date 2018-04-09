var gphcan;
var ctx;

var show = [true, true, true];

function DrawGraph(db) {
    var st = db.fuel[0][0];
    var et = db.fuel[db.fuel.length - 1][0];

    var tt = et - st;

    gphcan = $("#gphMain");
    ctx = gphcan[0].getContext("2d");

    gphcan[0].width = gphcan.width();
    gphcan[0].height = gphcan.height();

    $("#lblKMH").text('Km/H (' + db.max[0].toFixed(0) + ')');
    $("#lblRPM").text('RPM (' + db.max[1].toFixed(0) + ')');
    $("#lblFEF").text('Fuel Economy (' + db.max[2].toFixed(0) + ')');

    for (var i = 0; i <= 10; i++) {
        var v = i / 10.0;

        v *= 0.8;
        v += 0.1;

        v *= gphcan.height();
        v = gphcan.height() - v;

        ctx.beginPath();
        ctx.moveTo(30, v);
        ctx.lineTo(gphcan.width(), v);
        ctx.lineWidth = 1;
        ctx.strokeStyle = '#CCC';
        ctx.stroke();

        ctx.font = "10px Arial";
        ctx.textAlign = "right";
        ctx.fillText((i * 10) + '%', 27, v + 4);
    }

    for (var i = 0; i <= 10; i++) {
        var x = i / 10.0;

        x *= 0.85;
        x += 0.15 * 0.5;

        x *= gphcan.width();

        ctx.beginPath();
        ctx.moveTo(x, 20);
        ctx.lineTo(x, gphcan.height() - 25);
        ctx.lineWidth = 1;
        ctx.strokeStyle = '#DDD';
        ctx.stroke();

        ctx.font = "10px Arial";
        ctx.textAlign = "center";
        ctx.fillText(((i * 0.1) * tt).toFixed(0), x, gphcan.height() - 15);
    }

    if (show[0])
        DrawLine(1, "green", db.max[0]);
    if (show[1])
        DrawLine(2, "red", db.max[1]);
    if (show[2])
        DrawLine(3, "black", db.max[2]);

    ctx.font = "10px Arial";
    ctx.textAlign = "center";
    ctx.fillText("time (seconds)", gphcan.width() * 0.5, gphcan.height());

    function DrawLine(index, col, top) {
        ctx.beginPath();
        for (var i = 0; i < db.fuel.length; i++) {
            var x = db.fuel[i][0] - st;
            x /= (et - st);

            x *= 0.85;
            x += 0.15 * 0.5;

            x *= gphcan.width();

            var y = db.fuel[i][index];
            y /= top;

            y *= 0.8;
            y += 0.1;

            y *= gphcan.height();
            y = gphcan.height() - y;
            ctx[(i == 0) ? 'moveTo' : 'lineTo'](x, y);
        }
        ctx.strokeStyle = col;
        ctx.stroke();
    }
}

