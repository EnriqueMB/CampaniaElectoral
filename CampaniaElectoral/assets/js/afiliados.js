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

        $("table").delegate("a.deleteRow", "click", function (e) {
            e.preventDefault();
            console.log('deleteRow');
            var row = $(this).closest("tr");
            console.log("click delete");
            table.rows(row).remove().draw(false)
        });

    };

    var runDelete = function () {

        //$('a.deleteRow').on('click', function (e) {
        $("table").delegate("a.deleteRow", "click", function (e) {
            contacts.rows($('#contacts tr.active')).remove().draw();
            //e.preventDefault();
            //var url = $(this).attr('href');
            //var box = $('#mb-remove-row');
            //var row = $(this).attr('data-sku');
            //box.addClass('open');
            //console.log(url + ' - ' + row);
            //box.find('.mb-control-yes').off('click').on('click', function (e) {
            //    e.preventDefault();
            //    box.removeClass('open');
            //    $.ajax({
            //        url: url,
            //        type: 'POST',
            //        dataType: 'json',
            //        success: function (result) {
            //            if (result == 'true') {
            //                $("#" + row).hide("slow", function () {
            //                    box.find(".mb-control-yes").prop('onclick', null).off('click');
            //                    $("#" + row).remove();
            //                    //Mensaje("Registro Eliminado Correctamente", "1");
            //                });
            //            }
            //            else {
            //                //Mensaje("Error al eliminar el registro", "2");
            //            }
            //        },
            //        error: function () {
            //            //$('#Error').html('<h3>Ocurrio un error al eliminar este registro<h3>');
            //            //$('#Error').css("display", "block");
            //            //$('#Error').delay(400).slideDown(400).delay(2000).slideUp(400);
            //            //$('#Error').css("display", "block");
            //        }
            //    });

            //});
        });

    };

    return {
        //main function to initiate template pages
        init: function (band) {
            runTable(band);
            //runDelete();
        }
    };
}();