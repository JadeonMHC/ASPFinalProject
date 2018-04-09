var map;

function initMap() {
    map = new GMaps({
        div: '#MainMap',
        lat: 50.017573, 
        lng: -110.686609
    });

    console.log(Object.keys(map));
}

function DrawPath(map, path, dash) {
    map.cleanRoute();

    var lineSymbol = {
        path: 'M 0,-1 0,1',
        strokeOpacity: 1,
        scale: 4
    };

    var par = {
        path: path,
        strokeColor: '#131540',
        strokeOpacity: dash ? 0.0: 0.6,
        strokeWeight: 3
    };

    if (dash) {
        par.icons = [{
            icon: lineSymbol,
            offset: '0',
            repeat: '20px'
        }];
    }

    map.drawPolyline(par);
}


function GetDeg(s, m) {
    var per = s.indexOf('.');

    var big = parseFloat(s.substr(0, per - 2));
    var small = parseFloat(s.substr(per - 2));

    return (big + (small / 60.0)) * ((m == 'S' || m == 'W') ? -1.0 : 1.0);
}