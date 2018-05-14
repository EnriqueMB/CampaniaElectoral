var NuevoAfiliado = function () {

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
                ctl00$cph_MasterBody$txtNombreAfiliado: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtApePatAfiliado: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtApeMatAfiliado: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaAfiliacion: {
                    required: true
                },
                cmbEstado: {
                    required: true
                },
                ctl00$cph_MasterBody$cmbMunicipio: {
                    required: true,
                    min: 1
                },
                ctl00$cph_MasterBody$txtDireccion: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtColonia: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtCodigoP: {
                    minlength: 4,
                    required: true,
                    number: true
                },
                ctl00$cph_MasterBody$txtClavElector: {
                    required: true
                },
                ctl00$cph_MasterBody$txtCorreoElectronico: {
                    required: true
                },
                ctl00$cph_MasterBody$cmbGenero: {
                    required: true
                },
                ctl00$cph_MasterBody$txtCelular: {
                    number: true
                },
                ctl00$cph_MasterBody$txtNumeroExt: {
                    number: true
                },
                ctl00$cph_MasterBody$txtNumeroInt: {
                    number: true
                },
                ctl00$cph_MasterBody$cmbSeccion: {
                    required: true,
                    min: 1
                },
                ctl00$cph_MasterBody$cmbOperador: {
                    required: true,
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtNombreAfiliado: "Por favor, ingrese el nombre del afiliado.",
                ctl00$cph_MasterBody$txtApePatAfiliado: "Por favor, ingrese el apellido paterno del afiliado.",
                ctl00$cph_MasterBody$txtApeMatAfiliado: "ingrese el apellido materno del afiliado.",
                ctl00$cph_MasterBody$txtFechaAfiliacion: "Por favor, selecciones un fecha de afiliaci&oacute;n.",
                ctl00$cph_MasterBody$cmbEstado: "Por favor, selecciones un estado.",
                ctl00$cph_MasterBody$cmbMunicipio: {
                    required: "Por favor, selecciones un municipio.",
                    min: "Por favor, selecciones un municipio."
                },
                ctl00$cph_MasterBody$txtDireccion: "Por favor, ingrese la direcci&oacute;n del afiliado.",
                ctl00$cph_MasterBody$txtColonia: "Por favor, ingrese la colonia del afiliado.",
                ctl00$cph_MasterBody$txtCodigoP:
                    {
                        minlength: "Por favor, introduzca al menos 4 caracteres.",
                        required: "Por favor, ingrese un c&oacute;digo postal",
                        number: "Por favor, ingrese un c&oacute;digo postal valido"
                    },
                ctl00$cph_MasterBody$txtClavElector: "Por favor, ingrese la clave de elector",
                ctl00$cph_MasterBody$txtCorreoElectronico: "Por favor, ingrese el correo electr&oacute;nico",
                ctl00$cph_MasterBody$cmbGenero: "Por favor, seleciones un g&eacute;nero",
                ctl00$cph_MasterBody$txtCelular: "Por favor, ingrese un n&uacute;mero valido",
                ctl00$cph_MasterBody$txtNumeroExt: "Por favor, ingrese un n&uacute;mero exterior valido",
                ctl00$cph_MasterBody$txtNumeroInt: "Por favor, ingrese un n&uacute;mero interior valido",
                ctl00$cph_MasterBody$cmbSeccion: {
                    required: "Por favor, seleccione una secci&oacute;n.",
                    min: "Por favor, seleccione una secci&oacute;n."
                },
                ctl00$cph_MasterBody$cmbOperador: {
                    required: "Por favor, seleccione un operador.",
                    min: "Por favor, seleccione un operador."
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
    var carrucel = function () {
        $("#myCarousel img").css("height", $("#myCarousel").height());
        $("#myCarousel img").css("width", $("#myCarousel").width());
        $(document).ready(function () {
            $("#myCarousel").carousel("pause");
        });
        $(window).resize(function () {
            $("#myCarousel img").css("height", $("#myCarousel").height());
            $("#myCarousel img").css("width", $("#myCarousel").width());
        });
    };
    return {
        //main function to initiate template pages
        init: function () {
            runValidator26();
            carrucel();
            //rumImagenes();
        }
    };
}();