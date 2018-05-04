var Afiliados = function () {
    "use strict";
    var runTable = function (band) {

        var table = $('#tblafiliados').DataTable({
            "processing": true,
            "serverSide": true,
            "searching": true,
            "language": {
                "url": "/assets/json/Spanish.json"
            },
            "ajax": {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/afiliadosService.asmx/Data",
                data: function (d) {
                    return JSON.stringify({ parameters: d, bandDatosComp: band });
                }
            }
        });

        $(".pbBusqueda a").click(function () {
            event.preventDefault();
            var aux = $(this).attr('id');
            var tipoBusq = 0;
            var Searchtxt = '';
            switch (aux) {
                case 'atxtBuscar':
                    tipoBusq = 0;
                    Searchtxt = document.getElementById("txtBuscar").value;
                    break;
                case 'aform-field-select-3':
                    tipoBusq = 1;
                    Searchtxt = document.getElementById("form-field-select-3").value;
                    break;
                case 'afecha':
                    tipoBusq = 2;
                    Searchtxt = document.getElementById("fecha").value;
                    break;
                case 'aseccion':
                    tipoBusq = 3;
                    Searchtxt = document.getElementById("seccion").value;
                    break;
                case 'aclvElector':
                    tipoBusq = 4;
                    Searchtxt = document.getElementById("clvElector").value;
                    break;
                case 'aoperador':
                    tipoBusq = 5;
                    Searchtxt = document.getElementById("operador").value;
                    break;
            }

            table.columns(tipoBusq)
                 .search(Searchtxt)
                 .draw();

            table.search('').columns()
                     .search('');
        });
    };
    return {
        //main function to initiate template pages
        init: function (band) {
            runTable(band);
        }
    };
}();