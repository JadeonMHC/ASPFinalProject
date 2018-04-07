function initMap() {
    var map = new GMaps({
        div: '#MainMap',
        lat: 50.017573, 
        lng: -110.686609
    });

    DrawPath(map, [
            [50.017573, -110.686609],
            [50.02, -110.686609]
        ]);
}

function DrawPath(map, path) {
    map.drawPolyline({
        path: path,
        strokeColor: '#131540',
        strokeOpacity: 0.6,
        strokeWeight: 3
    });
}