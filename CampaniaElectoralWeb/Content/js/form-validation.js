var FormValidator = function () {
	"use strict";
    // function to initiate Validation Sample 1
    var runValidator1 = function () {
        var form1 = $('#contact-form');
        var errorHandler1 = $('.errorHandler', form1);
        var successHandler1 = $('.successHandler', form1);
        $.validator.addMethod("NombreVal", function () {
            var urlAux = document.getElementById("Nombre").value;
            var expReg = /^(?!\s+$)[A-Za-z\u00E1\u00E9\u00ED\u00F3\u00FA\u00C1\u00C9\u00CD\u00D3\u00DA\u00DC\u00FC\u00f1\u00d1\s]+$/;
             if (expReg.test(urlAux))
                {
                    return true;
                }
                else {
                    return false;
                }
        }, 'Por favor, Escriba un nombre correcto');
        $.validator.addMethod("phoneNumbers", function () {
            var AuxTelefono = document.getElementById("Telefono").value;
            var expReg = /^[0-9]{10}$/;
            if (expReg.test(AuxTelefono)) {
                return true;
            }
            else {
                return false;
            }
        }, 'Verifique que n&uacute;mero telef&oacute;nico cuente con el formato a 10 d&iacute;gitos.');

        $('#contact-form').validate({
            errorElement: "span", // contain the error msg in a span tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "dd" || element.attr("name") == "mm" || element.attr("name") == "yyyy") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                Telefono: "phoneNumbers",
                Correo: {
                    required: true,
                    email: true
                },
                Nombre: "NombreVal",
                Asunto: {
                    required: true,
                    minlength: 50
                },
                Mensaje: {
                    required: true,
                    minlength: 100
                }
                
                },
            messages: {
                Correo: {
                    required: "Por favor, Ingrese un correo Electronico",
                    email: "EL formato del correo electrono es Nombre@dominio.com"
                },
                Asunto: {
                    required: "Por favor, Ingrese el asunto del mensaje",
                    minlength: "Por favor, El asunto tiene un minimo de 50 carcateres"
                },
                Mensaje: {
                    required: "Por favor, Ingrese el mensaje",
                    minlength: "Por favor, El mensaje tiene un minimo de 100 carcateres"
                }

            },
            groups: {
                DateofBirth: "dd mm yyyy",
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                successHandler1.hide();
                errorHandler1.show();
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
            submitHandler: function (form) {
                successHandler1.show();
                errorHandler1.hide();
                // submit form
                //$('#form').submit();
                this.submit();
            }
        });
    };
    // function to initiate Validation Sample 2
    return {
        //main function to initiate template pages
        init: function () {
            runValidator1();
        }
    };
}();