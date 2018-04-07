'use strict'

$(document).ready(function () {
    GetDBNames();
});

function GetDBNames() {
    var dbl = $("#DBList");

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

        data.forEach(function (item) {
            if (item[2].startsWith('$GPRMC')) {
                var time = item[1];
                var dparts = item[2].split(',');
                //db.points.push(dparts);
                db.points.push([parseFloat(dparts[3]), dparts[4], parseFloat(dparts[5]), dparts[6]]);
            }
        });

        console.log(db);
    });
}