var Maps = function () {
    "use strict";
    var runMaps = function (nuevo, latitud, longitud) {

        var map = new GMaps({
            el: '#map1',
            lat: latitud,
            lng: longitud,
            dragend: function (e) {
            }
        });        

        // Set the global configs to synchronous 
        $.ajaxSetup({ async: false });
        var id = document.getElementById("cph_MasterBody_hfIDPoligono").value;
        console.log("id_poligono= " + id);
        $.getJSON('sfrmPuntosPoligono.aspx?id=' + id, function (data) {
            var path = [data.length];
            console.log(path);
            $.each(data, function (key, value) {
                var ArrayNew = [value.lat, value.lng];
                path[key] = ArrayNew;
            });
            var CustomPol = map.drawPolygon({
                paths: path, // pre-defined polygon shape
                strokeColor: '#BBD8E9',
                strokeOpacity: 1,
                strokeWeight: 3,
                fillColor: '#BBD8E9',
                fillOpacity: 0.6
            });


            CustomPol.addListener('click', DibujarPunto);

            function DibujarPunto(event) {
                map.removeMarkers();
                var index = map.markers.length;
                var lat = event.latLng.lat();
                var lng = event.latLng.lng();
                document.getElementById("cph_MasterBody_txtLatitud").value = lat;
                document.getElementById("cph_MasterBody_txtLongitud").value = lng;
                map.addMarker({
                    lat: lat,
                    lng: lng
                });
            }
        });
        console.log(nuevo);
        if (nuevo == 'false')
        {
            map.addMarker({
                lat: latitud,
                lng: longitud
            });
        }
        // Set the global configs back to asynchronous 
        $.ajaxSetup({ async: true });

    };
    return {
        //main function to initiate template pages
        init: function (nuevo, latitud, longitud) {
            runMaps(nuevo, latitud, longitud);
        }
    };
}();