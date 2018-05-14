var Estadisticos = function () {
    "use strict";

    var runMaps = function (secciones) {
        var latitud = 16.7520118411463;
        var longitud = -93.10650222939148;
        var map = new google.maps.Map(document.getElementById('map1'), {
            zoom: 12,
            center: new google.maps.LatLng(latitud, longitud),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true,
            zoomControl: true
        });

        function mapToLatLng(source, index, array) {
            return new google.maps.LatLng(source[0], source[1])   
        }

        function toLatLng(array) {

            return array.map(mapToLatLng);
        }

        function obtenerColor(avance)
        {
            var color = "#f05050";
            if (avance <= 40) {
                color = "#f05050";
            }
            else if (avance <= 80) {
                color = "#fad733";
            }
            else {
                color = "#27c24c";
            }
            return color;
        }

        function CargarMapa() {
            //console.log(secciones.length);
            for (var i = 0; i < secciones.length; i++) {
                //console.log(i);
                //console.log(secciones[i].id_seccion);
                //$.ajaxSetup({ async: false });
                //var jqxhr = $.ajax('sfrmObtenerPoligono.aspx?id=' + secciones[i].id_seccion)
                //  .done(function (data) {
                try {
                    //var arrayResult = JSON.parse(secciones[i].poligono);
                    var color = obtenerColor(secciones[i].avance);
                    var hasHole = false;
                    var paths = secciones[i].poligono;
                    if (paths.length > 0) {
                        var array2d = JSON.parse(paths);
                        if (array2d.length > 0) {
                            if (array2d[0].length > 0) {
                                if (Array.isArray(array2d[0][0])) {
                                    if (array2d[0][0].length > 0) {
                                        hasHole = true;
                                    }
                                }
                            }
                        }
                        if (!hasHole) {
                            var arrayJson = toLatLng(array2d);
                            var casilla = new google.maps.Polygon({
                                paths: arrayJson,
                                strokeColor: color,
                                strokeOpacity: 1,
                                strokeWeight: 2,
                                fillColor: color,
                                fillOpacity: 0.6
                            });
                            casilla.setMap(map);                            
                        }
                        else {
                            var arrayJson = new Array(array2d.length);
                            for (var n = 0; n < array2d.length; n++) {
                                arrayJson[n] = toLatLng(array2d[n]);
                            }
                            var casilla = new google.maps.Polygon({
                                paths: arrayJson,
                                strokeColor: color,
                                strokeOpacity: 1,
                                strokeWeight: 2,
                                fillColor: color,
                                fillOpacity: 0.6
                            });
                            casilla.setMap(map);
                        }
                    }
                } catch (err) {
                    console.log("Error" + err);
                }

                //})
                //.fail(function (jqXHR, textStatus) {
                //    console.log("Error: " + textStatus);
                //});

                //$.ajaxSetup({ async: true });
            }
        }

        CargarMapa();
    };

    
    return {
        //main function to initiate template pages
        init: function (secciones) {            
            runMaps(secciones);
            //runMaps2();
        }
    };
}();