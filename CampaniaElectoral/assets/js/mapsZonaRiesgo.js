var Maps = function () {
    "use strict";
    var runMaps = function (id_estado, estado) {
        var municipio = document.getElementById("cmbMunicipio");
        var poligono = document.getElementById("cmbSeccion");

        var selectedPoligono = poligono.options[poligono.selectedIndex];   
        var selectedMunicipio = municipio.options[municipio.selectedIndex];
        //var selectedPoligono = poligono.options[poligono.selectedIndex];
        console.log(selectedMunicipio.text);
        console.log(selectedPoligono.value);
        $.ajaxSetup({ async: false });

        var map = new GMaps({
            el: '#map1',
            lat: -12.043333,
            lng: -77.028333,
            zoom: 9,
            dragend: function (e) {
            }
        });

        //Si no hay nada seleccionado, el mapa se inicializa con los datos de geolocalización
        if ( estado === '' && selectedMunicipio.text.trim() === '' && selectedPoligono.text.trim() === '') {
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
            if (selectedMunicipio.text.trim() === '') {
                GMaps.geocode({
                    address: estado,
                    callback: function (results, status) {
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
                    console.log("3");
                    GMaps.geocode({
                        address: selectedMunicipio.text + ' ' + estado,
                        callback: function (results, status) {
                            if (status == 'OK') {
                                var latlng = results[0].geometry.location;
                                map.setCenter(latlng.lat(), latlng.lng());
                            }
                        }
                    });
                }
                    //Está seleccionado un polígono, conseguir coordenadas, centrar el mapa y dibujar el polígono
                else {
                    $.ajaxSetup({ async: false });
                    var myLatlng;
                    
                    $.getJSON('sfrmDetalleCasilla.aspx?IDCasilla=' + selectedPoligono.value, function (data) {
                        console.log(data);
                        myLatlng = { lat: data.Latitud, lng: data.Longitud,tit:data.Titulo,desc:data.Descripcion };
                        
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
                    map.addMarker({
                        lat: myLatlng.lat,
                        lng: myLatlng.lng,
                        title:myLatlng.tit,
                        infoWindow: {
                            content: '<p>' + myLatlng.tit + '</p>'
                                    + '<p>' + myLatlng.desc + '</p>'
                                    
                        }
                    });
                   
                }
            }
        }
        //Se obtienen las zonas de riesgo
        $.getJSON('sfrmZonasRiesgoXIDs.aspx?IDEstado=' + id_estado + '&IDMunicipio=' + selectedMunicipio.value
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
                                    + '<a clas="fa-external-link" href="frmNuevaIncidencia.aspx?op=2&id=' + value.IDRiesgo + '">Editar</a>'
                        }
                    });

                });
            });
        
        $.ajaxSetup({ async: true });

    };
    return {
        //main function to initiate template pages
        init: function (id_estado, estado) {
            runMaps(id_estado, estado);
        }
    };
}();