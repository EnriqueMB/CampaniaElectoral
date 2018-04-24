var Maps = function () {
    "use strict";
    //For more information, please visit http://hpneo.github.io/gmaps/documentation.html
    var runMaps = function (nuevo, latitud, longitud) {
        // Basic Map 
        if (nuevo) {
            var map = new GMaps({
                el: '#map1',
                lat: -12.043333,
                lng: -77.028333,
                click: function (e) {
                    //Borrar Markets y crear uno nuevo
                    map.removeMarkers();
                    var index = map.markers.length;
                    var lat = e.latLng.lat();
                    var lng = e.latLng.lng();
                    document.getElementById("cph_MasterBody_hfLatitud").value = lat;
                    document.getElementById("cph_MasterBody_hfLongitud").value = lng;
                    map.addMarker({
                        lat: lat,
                        lng: lng
                    });
                },
                dragend: function (e) {
                }
            });

            GMaps.geolocate({
                success: function (position) {
                    map.setCenter(position.coords.latitude, position.coords.longitude);
                },
                error: function (error) {
                },
                not_supported: function () {
                },
                always: function () {
                }
            });
        }
        else
        {
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
                    document.getElementById("cph_MasterBody_hfLatitud").value = lat;
                    document.getElementById("cph_MasterBody_hfLongitud").value = lng;
                    map.addMarker({
                        lat: lat,
                        lng: lng
                    });
                },
                dragend: function (e) {
                }
            });
            console.log(latitud + ", " + longitud)
            map.setCenter(latitud, longitud);

            map.addMarker({
                lat: latitud,
                lng: longitud
            });
        }
        $(document).on('click', '#btnSearchDir', function (e) {
            e.preventDefault();
            GMaps.geocode({
                address: $('#cph_MasterBody_address').val().trim(),
                callback: function (results, status) {
                    if (status == 'OK') {
                        var latlng = results[0].geometry.location;
                        map.setCenter(latlng.lat(), latlng.lng());
                        map.removeMarkers();
                        document.getElementById("cph_MasterBody_hfLatitud").value = latlng.lat();
                        document.getElementById("cph_MasterBody_hfLongitud").value = latlng.lng();
                        map.addMarker({
                            lat: latlng.lat(),
                            lng: latlng.lng()
                        });
                    }
                }
            });
        });
    };
    return {
        //main function to initiate template pages
        init: function (nuevo, latitud, longitud) {
            runMaps(nuevo, latitud, longitud);
        }
    };
}();