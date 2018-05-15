var NuevaIncidencia = function () {

    var runValidator26 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);
        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaAfiliacion") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtTitulo: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtDescripcion: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$cmbTipoRiesgo: {
                    required: true,
                    min: 1
                },
                ctl00$cph_MasterBody$cmbMunicipio: {
                    required: true,
                    min: 1
                },
                ctl00$cph_MasterBody$cmbPoligono: {
                    required: true,
                    min: 1
                },
                ctl00$cph_MasterBody$cmbSeccion: {
                    required: true,
                    min: 1
                },
                ctl00$cph_MasterBody$cmbColaboradores: {
                    required: true
                }

            },
            messages: {
                ctl00$cph_MasterBody$txtTitulo: "Por favor, ingrese el nombre del afiliado.",
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese el apellido paterno del afiliado.",
                ctl00$cph_MasterBody$cmbTipoRiesgo: {
                    required: "Por favor, seleccione un Tipo de riesgo.",
                    min: "Por favor, seleccione un Tipo de riesgo"
                },
                ctl00$cph_MasterBody$cmbMunicipio: {
                    required: "Por favor, selecciones un municipio.",
                    min: "Por favor, selecciones un municipio."
                },
                ctl00$cph_MasterBody$cmbPoligono: {
                    required: "Por favor, seleccione un poligono.",
                    min: "Por favor, seleccione un polig&oacute;no."
                },
                ctl00$cph_MasterBody$cmbSeccion: {
                    required: "Por favor, seleccione una secci&oacute;n.",
                    min: "Por favor, seleccione una secci&oacute;n."
                },
                ctl00$cph_MasterBody$cmbColaboradores: {
                    required: "Por favor, seleccione un colaborador."
                }
                
                
                
                
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                successHandler2.hide();
                errorHandler2.show();
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
                // add the Bootstrap error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element).closest('.form-group').removeClass('has-error');
                // set error class to the control group
            },
            success: function (label, element) {
                label.addClass('help-block valid');
                // mark the current input as valid and display OK icon
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
            },
            submitHandler: function (form2) {
                //successHandler2.show();
                errorHandler2.hide();
                // submit form
                this.submit();
                //$('#frmMaster').trigger("submit");
            }
        });
    };
   
    return {
        //main function to initiate template pages
        init: function () {
            runValidator26();
        }
    };
}();