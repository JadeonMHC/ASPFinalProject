var gphcan;
var ctx;

function DrawGraph(db) {
    var st = db.fuel[0][0];
    var et = db.fuel[db.fuel.length - 1][0];

    gphcan = $("#gphMain");
    ctx = gphcan[0].getContext("2d");

    gphcan[0].width = gphcan.width();
    gphcan[0].height = gphcan.height();

    DrawLine(3, "#000", 4000.0);
    DrawLine(2, "red", 2000.0);
    DrawLine(1, "green", 100);


    function DrawLine(index, col, top) {
        ctx.beginPath();
        for (var i = 0; i < db.fuel.length; i++) {
            var x = db.fuel[i][0] - st;
            x /= (et - st);

            x *= 0.9;
            x += 0.05;

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

