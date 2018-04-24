var Maps = function () {
    "use strict";
    //function to initiate GMaps
    //Gmaps.js allows you to use the potential of Google Maps in a simple way.
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
                    //$('#cph_MasterBody_hfLatitud').value = lat;
                    document.getElementById("cph_MasterBody_txtLatitud").value = lat;
                    //$('#cph_MasterBody_hfLongitud').value = lng;
                    document.getElementById("cph_MasterBody_txtLongitud").value = lng;
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
                    document.getElementById("cph_MasterBody_txtLatitud").value = lat;
                    document.getElementById("cph_MasterBody_txtLongitud").value = lng;
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

        //$(document).on('click', '#btnSearchDir', function (e) {
        //    e.preventDefault();
        //    var estado = document.getElementById("cmbEstado");
        //    var municipio = document.getElementById("cmbMunicipio");

        //    var selectedEstado = estado.options[estado.selectedIndex];
        //    var selectedMunicipio = municipio.options[municipio.selectedIndex];

        //    GMaps.geocode({
        //        address: $('#cph_MasterBody_address').val().trim() + ' ' + selectedMunicipio.text + ' ' + selectedEstado.text,
        //        callback: function (results, status) {
        //            if (status == 'OK') {
        //                var latlng = results[0].geometry.location;
        //                map.setCenter(latlng.lat(), latlng.lng());
        //                document.getElementById("cph_MasterBody_txtLatitud").value = latlng.lat();
        //                document.getElementById("cph_MasterBody_txtLongitud").value = latlng.lng();
        //                map.removeMarkers();
        //                map.addMarker({
        //                    lat: latlng.lat(),
        //                    lng: latlng.lng()
        //                });
        //            }
        //        }
        //    });
        //});

        $("#cmbEstado").change(function () {
            $("#cmbEstado option:selected").each(function () {
                var estado = document.getElementById("cmbEstado");
                var selectedEstado = estado.options[estado.selectedIndex];
                GMaps.geocode({
                    address: $('#cph_MasterBody_txtColonia').val().trim() + ' ' + selectedEstado.text,
                    callback: function (results, status) {
                        document.getElementById("cph_MasterBody_txtLatitud").value = "";
                        document.getElementById("cph_MasterBody_txtLongitud").value = "";
                        map.removeMarkers();
                        if (status == 'OK') {
                            var latlng = results[0].geometry.location;
                            map.setCenter(latlng.lat(), latlng.lng());
                        }
                    }
                });

            });
        });

        $("#cmbMunicipio").change(function () {
            $("#cmbMunicipio option:selected").each(function () {
                var estado = document.getElementById("cmbEstado");
                var municipio = document.getElementById("cmbMunicipio");
                var selectedEstado = estado.options[estado.selectedIndex];
                var selectedMunicipio = municipio.options[municipio.selectedIndex];
                GMaps.geocode({
                    address: $('#cph_MasterBody_txtColonia').val().trim() + ' ' + selectedMunicipio.text + ' ' + selectedEstado.text,
                    callback: function (results, status) {
                        document.getElementById("cph_MasterBody_txtLatitud").value = "";
                        document.getElementById("cph_MasterBody_txtLongitud").value = "";
                        map.removeMarkers();
                        if (status == 'OK') {
                            var latlng = results[0].geometry.location;
                            map.setCenter(latlng.lat(), latlng.lng());                            
                        }
                    }
                });

            });
        });

        $("#cph_MasterBody_txtColonia").blur(function () {
            var estado = document.getElementById("cmbEstado");
            var municipio = document.getElementById("cmbMunicipio");
            var selectedEstado = estado.options[estado.selectedIndex];
            var selectedMunicipio = municipio.options[municipio.selectedIndex];
            GMaps.geocode({
                address: $('#cph_MasterBody_txtColonia').val().trim() + ' ' + selectedMunicipio.text + ' ' + selectedEstado.text,
                callback: function (results, status) {
                    document.getElementById("cph_MasterBody_txtLatitud").value = "";
                    document.getElementById("cph_MasterBody_txtLongitud").value = "";
                    map.removeMarkers();
                    if (status == 'OK') {
                        var latlng = results[0].geometry.location;
                        map.setCenter(latlng.lat(), latlng.lng());
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