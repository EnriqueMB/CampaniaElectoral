var Maps = function () {
    "use strict";
    var runMaps = function () {

        var estado = document.getElementById("cmbEstado");
        var municipio = document.getElementById("cmbMunicipio");
        var poligono = document.getElementById("cmbPoligono");
        var selectedEstado = estado.options[estado.selectedIndex];
        var selectedMunicipio = municipio.options[municipio.selectedIndex];
        var selectedPoligono = poligono.options[poligono.selectedIndex];

        $.ajaxSetup({ async: false });

        //Si no hay nada seleccionado, el mapa se inicializa con los datos de geolocalización
        if (selectedEstado.text.trim() === '' && selectedMunicipio.text.trim() === '' && selectedPoligono.text.trim() === '') {
            //console.log("1");
            var map = new GMaps({
                el: '#map1',
                lat: -12.043333,
                lng: -77.028333,
                zoom: 8,
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

        else {
            //Si hay un estado seleccionado, se busca en el mapa el estado y se centra
            if (selectedMunicipio.text.trim() === '' && selectedPoligono.text.trim() === '') {
                //console.log("2");
                var map = new GMaps({
                    el: '#map1',
                    lat: -12.043333,
                    lng: -77.028333,
                    zoom: 8,
                    dragend: function (e) {
                    }
                });

                GMaps.geocode({
                    address: selectedEstado.text,
                    callback: function (results, status) {
                        //console.log(status);
                        if (status == 'OK') {
                            var latlng = results[0].geometry.location;
                            map.setCenter(latlng.lat(), latlng.lng());
                        }
                    }
                });


            }
            else {
                //Si hay un estado y un municipio seleccionado, se buscan en el mapa estado y municipio y se centra
                if (selectedPoligono.text.trim() === '') {
                    //console.log("3");
                    var map = new GMaps({
                        el: '#map1',
                        lat: -12.043333,
                        lng: -77.028333,
                        zoom: 12,
                        dragend: function (e) {
                        }
                    });
                    //console.log(selectedMunicipio.text + ' ' + selectedEstado.text)
                    GMaps.geocode({
                        address: selectedMunicipio.text + ' ' + selectedEstado.text,
                        callback: function (results, status) {
                            //console.log(status);
                            if (status == 'OK') {
                                var latlng = results[0].geometry.location;
                                map.setCenter(latlng.lat(), latlng.lng());
                            }
                        }
                    });
                }
                    //Está seleccionado un polígono, conseguir coordenadas, centrar el mapa y dibujar el polígono
                else {
                    //console.log("4");
                    $.ajaxSetup({ async: false });
                    var myLatlng;
                    $.getJSON('sfrmDetallePoligono.aspx?IDPoligono=' + selectedPoligono.value, function (data) {
                        //console.log(data);
                        myLatlng = { lat: data.Latitud, lng: data.Longitud };
                    });
                    //console.log(myLatlng);
                    var map = new GMaps({
                        el: '#map1',
                        lat: myLatlng.lat,
                        lng: myLatlng.lng,
                        zoom: 15,
                        dragend: function (e) {
                        }
                    });

                    $.getJSON('sfrmPuntosPoligono.aspx?id=' + selectedPoligono.value, function (data) {
                        var path = [data.length];
                        $.each(data, function (key, value) {
                            var ArrayNew = [value.lat, value.lng];
                            path[key] = ArrayNew;
                        });
                        var CustomPol = map.drawPolygon({
                            paths: path, // pre-defined polygon shape
                            strokeColor: '#BBD8E9',
                            strokeOpacity: 1,
                            strokeWeight: 2,
                            fillColor: '#BBD8E9',
                            fillOpacity: 0.6
                        });
                        console.log(path);
                    });
                    $.ajaxSetup({ async: true });
                }
            }
        }

        //Se obtienen las zonas de riesgo
        $.getJSON('sfrmZonasRiesgoXIDs.aspx?IDEstado=' + selectedEstado.value + '&IDMunicipio=' + selectedMunicipio.value
            + '&IDPoligono=' + selectedPoligono.value, function (data) {
                $.each(data, function (key, value) {
                    var image = {
                        url: value.UrlIcon,
                        size: new google.maps.Size(40, 60),
                        anchor: new google.maps.Point(0, 32),
                        scaledSize: new google.maps.Size(25, 25)
                    };
                    map.addMarker({
                        lat: value.Lat,
                        lng: value.Lng,
                        title: value.Titulo,
                        icon: image,
                        infoWindow: {
                            content: '<p>' + value.Titulo + '</p>'
                                    + '<p>' + value.Descripcion + '</p>'
                                    + '<a clas="fa-external-link" href="frmNuevaZonaRiesgo.aspx?op=2&id=' + value.IDRiesgo + '">Editar</a>'
                        }
                    });

                });
            });
        
        $.ajaxSetup({ async: true });

    };
    return {
        //main function to initiate template pages
        init: function () {
            runMaps();
        }
    };
}();