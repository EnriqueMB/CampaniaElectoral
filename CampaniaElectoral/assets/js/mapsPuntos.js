var Maps = function () {
    "use strict";
    //function to initiate GMaps
    //Gmaps.js allows you to use the potential of Google Maps in a simple way.
    //For more information, please visit http://hpneo.github.io/gmaps/documentation.html
    var runMaps = function (latitud, longitud) {
        // Basic Map 
            var map = new GMaps({
                el: '#map1',
                lat: latitud,
                lng: longitud,
                click: function (e) {
                    //Borrar Markets y crear uno nuevo
                    map.removeMarkers();
                    var index = map.markers.length;
                    var lat = e.latLng.lat();
                    var lng = e.latLng.lng();
                    document.getElementById("hfLatitud").value = lat;
                    document.getElementById("hfLongitud").value = lng;
                    map.addMarker({
                        lat: lat,
                        lng: lng
                    });
                },
                dragend: function (e) {
                }
            });



        // Set the global configs to synchronous 
            $.ajaxSetup({ async: false });
            var id = document.getElementById("cph_MasterBody_hf").value;

            $.getJSON('sfrmPuntosPoligono.aspx?id=' + id, function (data) {
                var path = [data.length];
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
                    document.getElementById("hfLatitud").value = lat;
                    document.getElementById("hfLongitud").value = lng;
                    map.addMarker({
                        lat: lat,
                        lng: lng
                    });
                }
            });
        // Set the global configs back to asynchronous 
            $.ajaxSetup({ async: true });



            

    };
    return {
        //main function to initiate template pages
        init: function (latitud, longitud) {
            runMaps(latitud, longitud);
        }
    };
}();