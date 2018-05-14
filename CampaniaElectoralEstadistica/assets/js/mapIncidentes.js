var Maps = function () {
    "use strict";
    var runMapaVoto = function () {
        var latitud = 16.6634247;
        var longitud = -92.551164;
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 7,
            center: new google.maps.LatLng(latitud, longitud),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true,
            zoomControl: true
        });
        var points = document.getElementById("puntos-riesgos").value;
        var arrayPoints2d = JSON.parse(points);
        console.log(arrayPoints2d.length);
        //var oms = new OverlappingMarkerSpiderfier(map, {
        //    markersWontMove: true,
        //    markersWontHide: true,
        //    keepSpiderfied: true,
        //    circleSpiralSwitchover: 40
        //});
        var infowindows = new google.maps.InfoWindow();
        var marker;
        for (var k = 0; k < arrayPoints2d.length; k++) {
           

            marker = new google.maps.Marker({
                position: new google.maps.LatLng(arrayPoints2d[k][3], arrayPoints2d[k][4]),
                map: map,
                title: arrayPoints2d[k][0]
            });

            google.maps.event.addListener(marker, 'click', (function (marker, k) {
                return function () {
                    var contentString =
                        '<h2>' + arrayPoints2d[k][0] + '</h2>'
                             + '<p> Tipo de Riesgo: ' + arrayPoints2d[k][1] + '</p>'
                            + '<p> Casilla: ' + arrayPoints2d[k][2] + '</p>'
                             + '<p> Dirección: ' + arrayPoints2d[k][5] + '</p>'
                            + '<p> Referencia: ' + arrayPoints2d[k][6] + '</p>';
                    infowindows.setContent(contentString);
                    infowindows.open(map, marker);
                }
            })(marker, k));
            //oms.addMarker(marker)
        }
    }

    return {
        init: function () {
            runMapaVoto();
        }
    };
}();