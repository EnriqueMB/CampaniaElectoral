var Maps = function () {
    "use strict";
    var runMaps = function (estado, municipio) {

        var map = new GMaps({
            el: '#map1',
            lat: -12.043333,
            lng: -77.028333,
            zoom: 12,
            dragend: function (e) {
            }
        });

        GMaps.geocode({
            address: municipio + ' ' + estado,
            callback: function (results, status) {
                console.log(status);
                if (status == 'OK') {
                    var latlng = results[0].geometry.location;
                    map.setCenter(latlng.lat(), latlng.lng());
                }
            }
        });

        // Set the global configs to synchronous 
        $.ajaxSetup({ async: false });
        var IDPregunta = document.getElementById("cph_MasterBody_hf").value;
        var IDEncuesta = document.getElementById("cph_MasterBody_hfIDEncuesta").value;
        //console.log("id_pregunta= " + IDPregunta);
        //console.log("id_encuesta= " + IDEncuesta);
        $.getJSON('sfrmResultadosEncuesta.aspx?IDEncuesta=' + IDEncuesta + '&IDPregunta=' + IDPregunta, function (data) 
        {            
            //Se obtienen los polígonos de las encuestas
            var infowindow = new google.maps.InfoWindow({
                size: new google.maps.Size(150, 50)
            });
            $.each(data, function (key, value) {
                console.log("idpoligono" + value.IDPoligono);
                $.getJSON('sfrmPuntosPoligono.aspx?id=' + value.IDPoligono, function (data2) {
                    //console.log(data2);
                    console.log("lenght: " + data2.length);
                    var path = [data2.length];
                    $.each(data2, function (key2, value2) {
                        var ArrayNew = [value2.lat, value2.lng];
                        console.log("indice:" + key2);
                        path[key2] = ArrayNew;
                    });
                    console.log(value.Color);
                        var CustomPol = map.drawPolygon({
                            paths: path, // pre-defined polygon shape
                            strokeColor: value.Color,
                            strokeOpacity: 1,
                            strokeWeight: 1,
                            fillColor: value.Color,
                            fillOpacity: 0.6
                        });

                });
            });
        });
        //// Set the global configs back to asynchronous 
        $.ajaxSetup({ async: true });

    };
    return {
        //main function to initiate template pages
        init: function (estado, municipio) {
            runMaps(estado, municipio);
        }
    };
}();