var Secciones = function () {
    "use strict";
    var runTable = function () {

        var table = $('#sample_1').DataTable({
            "processing": true,
            "serverSide": true,
            "language": {
                "url": "/assets/json/Spanish.json"
            },
            "ajax": {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/seccionesService.asmx/Data",
                data: function (d) {
                    return JSON.stringify({ parameters: d });
                }
            }
        });

    };
    return {
        //main function to initiate template pages
        init: function () {
            runTable();
        }
    };
}();