var Representantes = function () {
    "use strict";
    var runTable = function (cssClass, tipo2) {
        console.log(cssClass + " - " + tipo2)
        var table = $('#sample_1').DataTable({
            "processing": true,
            "columns": [
                        { "orderable": false },
                        null,
                        null,
                        null],
            "serverSide": true,
            "language": {
                "url": "../assets/json/Spanish.json"
            },
            "ajax": {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/EvaluacionRep.asmx/Data",
                data: function (d) {
                    return JSON.stringify({ parameters: d, css: cssClass, tipo : tipo2 });
                }
            }
        });

    };
    return {
        //main function to initiate template pages
        init: function (cssClass, tipo2) {
            runTable(cssClass, tipo2);
        }
    };
}();