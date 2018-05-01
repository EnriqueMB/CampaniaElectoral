var FormValidator = function () {
    "use strict";  
    var validateCheckRadio = function (val) {
        $("input[type='radio'], input[type='checkbox']").on('ifChecked', function(event) {
            $(this).parent().closest(".has-error").removeClass("has-error").addClass("has-success").find(".help-block").hide().end().find('.symbol').addClass('ok');
        });
    };

    var runValidator = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);
        $.validator.addMethod("getEditorValue", function () {
            $("#editor1").val($('#form2 .summernote').code());
            if ($("#editor1").val() != "" && $("#editor1").val().replace(/(<([^>]+)>)/ig, "") != "") {
                $('#editor1').val('');
                return true;
            } else {
                return false;
            }
        }, 'This field is required.');
        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtGenero: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtLetra: {
                    minlength: 1,
                    required: true
                }

            },
            messages: {
                ctl00$cph_MasterBody$txtGenero: "Por favor, ingrese el g&eacutenero.",
                ctl00$cph_MasterBody$txtLetra: "Por favor, ingrese la sigla del g&eacutenero"
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

    var runValidator2 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtDescripcion: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtEdadInicial: {
                    minlength: 1,
                    number: true,
                    required: true
                },
                ctl00$cph_MasterBody$txtEdadFin: {
                    minlength: 1,
                    number: true,
                    required: true
                }

            },
            messages: {
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacuten.",
                ctl00$cph_MasterBody$txtEdadInicial: "Por favor, ingrese una edad minima",
                ctl00$cph_MasterBody$txtEdadFin: "Por favor, ingrese una edad maxima"
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

    var runValidator3 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                //ctl00$cph_MasterBody$txtAños: {
                //    minlength: 2,
                //    required: true
                //},
                ctl00$cph_MasterBody$txtDescripcion: {
                    maxlength: 150,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtGraEst: "Por favor, ingrese la descripcion de grado de estudios"
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

    var runValidator4 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtDescripcion: {
                    minlength: 2,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacuten."
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

    var runValidator5 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtColorStatus") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtDescripcion: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtColorStatus: {
                    minlength: 2,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacuten.",
                ctl00$cph_MasterBody$txtColorStatus: "Por favor, ingrese un color de status"
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

    var runValidator6 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtDescripcion: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtUsuario: {
                    minlength: 2,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacuten.",
                ctl00$cph_MasterBody$txtColorStatus: "Por favor, seleccione un tipo de usuario"
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

    var runValidator7 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);
       
        $.validator.addMethod("formatoImg", function (value, element, params) {
            //Checamos que tenga un archivo el input file
            var bandera = document.getElementById('inputImgServer').value;
            if (element.value.length != 0) {
                //Si hay obtenemos la extensión
                var arrayString = element.value.split(".");
                var longitud = arrayString.length;
                var extension = arrayString[longitud - 1];
                var valido = false;

                for (var i = 0 ; i < params.length ; i++) {
                    if (params[i] == extension)
                        valido = true;
                }
            }
            else {
                if (bandera == "True")
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            }
            return valido;
        }, 'Formato no valido.');

        $.validator.addMethod("validarImg", function (value, element, params) {
            //Bandera que me indica si hay o no imagen en el servidor
            var bandera = document.getElementById(params[0]).value;
            //Hay imagen en el servidor?
            if (bandera == "True") {
                return true;
            }
            else {
                //No Hay un elemento en el file input
                if (element.value.length == 0 || element === undefined) {
                    return false;
                }
                else {
                    return true;
                }
            }

        }, 'Debe seleccionar una imagen.');

        $.validator.addMethod("passwordCSL", function (value, element, params) {
            //Bandera que me indica si hay o no imagen en el servidor
            var password = document.getElementById(params[0]).value;
            var passwordAgain = document.getElementById(params[1]).value;
            var bandera = document.getElementById(params[2]).value;
            var valido = false;
            var maxCaracteres = 15, minCaracteres = 6;
            //console.log(password);
            //console.log(passwordAgain);

            //Estan vacios
            if (password.length == 0 && passwordAgain == 0) {
                //Hay password en la bd
                if (bandera == "True") {
                    valido = true;
                }
            }
            else
            {
                //Caracteres min: 6 y max: 15                                                                                     Mismos passwords=?
                if ((minCaracteres <= password.length <= maxCaracteres && minCaracteres <= passwordAgain <= maxCaracteres) && (password == passwordAgain))
                {
                    valido = true;
                }
            }
            return valido;
        }, 'Por favor ingrese un password de con una longitud m&iacute;nima de: 6 y  m&aacute;xima de 15, adem&aacute;s ambos campos deben coincider: Password y Confirmar password.');

        $('#frmMaster').validate({
            //debug:true,
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaNac") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                }else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtClavElector: {
                    required: true,
                    minlength: 18
                },
                ctl00$cph_MasterBody$txtNombre: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtApPaterno: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtApMaterno: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtCorreo: {
                    minlength: 1,
                    required: true,
                    email: true
                },
                ctl00$cph_MasterBody$txtTelefono: {
                    minlength: 1,
                    number: true,
                    required: true
                },
                ctl00$cph_MasterBody$id_password: {
                    passwordCSL: true, passwordCSL: ["cph_MasterBody_id_password", "cph_MasterBody_id_password_again", "inputPassServer"]
                },
                ctl00$cph_MasterBody$id_password_again: {
                    passwordCSL: true, passwordCSL: ["cph_MasterBody_id_password", "cph_MasterBody_id_password_again", "inputPassServer"]
                },
                ctl00$cph_MasterBody$txtFechaNac: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtCodigoPostal: {
                    minlength: 5,
                    number: true,
                    required: true
                },
                ctl00$cph_MasterBody$txtCuidad: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtColonia: {
                    required: true
                },
                ctl00$cph_MasterBody$imgImagen: {
                    validarImg: true, validarImg:["inputImgServer"],
                    formatoImg: true, formatoImg: ["png"]
                },
                ctl00$cph_MasterBody$txtDireccion: {
                    required: true,
                    minlength: 5
                },
                txtGenero: {
                    required: true,
                    min: true
                },
                ctl00$cph_MasterBody$cmbSeccion: {
                    required: true,
                    min: true
                },
                ctl00$cph_MasterBody$cmbMunicipio: {
                    required: true,
                    min: true
                },
                ctl00$cph_MasterBody$cmbAsignado: {
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtClavElector: {
                    required: "Por favor, ingrese la clave de elector",
                    minlength: "La longitud debe ser m&iacute;nimo de 18 caracteres"
                },
                ctl00$cph_MasterBody$txtNombre: "Por favor, ingrese el nombre del colaborador",
                ctl00$cph_MasterBody$txtApPaterno: "Por favor, ingrese el apellido paterno del colaborador",
                ctl00$cph_MasterBody$txtApMaterno: "Por favor, ingrese el apellido materno del colaborador",
                ctl00$cph_MasterBody$txtCorreo: {
                    required: "Por favor, ingrese un correo del colaborador",
                    email: "Su direcci&oacute;n de correo electr&oacute;nico debe tener el formato de nombre@dominio.com"
                },
                ctl00$cph_MasterBody$txtTelefono: "Por favor, ingrese el t&eacute;lefono del colaborador",
                ctl00$cph_MasterBody$txtFechaNac: "Por favor, selecciones un fecha de nacimiento",
                ctl00$cph_MasterBody$txtCodigoPostal: "Por favor, ingrese su c&oacute;digo postal",
                ctl00$cph_MasterBody$txtCuidad: "Por favor, ingrese su cuidad",
                ctl00$cph_MasterBody$txtDireccion: "Por favor, ingrese una direcci&oacute;n",
                ctl00$cph_MasterBody$txtColonia: {
                    required: "Por favor, ingrese una colonia"
                },
                txtGenero: {
                    required: "Por favor, seleccion un g&eacute;nero",
                    min: "Por favor, seleccion un g&eacute;nero"
                },
                ctl00$cph_MasterBody$cmbSeccion: {
                    required: "Por favor, seleccion una secci&oacute;n",
                    min: "Por favor, seleccion una secci&oacute;n"
                },
                ctl00$cph_MasterBody$cmbMunicipio: {
                    required: "Por favor, seleccion un municipio",
                    min: "Por favor, seleccion un municipio"
                },
                ctl00$cph_MasterBody$cmbAsignado: {
                    required: "Por favor, asigne un jefe inmediato."
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

    var runValidator10 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        //$.validator.addMethod("TieneImagen", function () {
        //    //if ($('#cph_MasterBody_imgLogo').value == undefined)
        //    var file = $('#cph_MasterBody_imgLogo').value;
        //    if(file)
        //        return true;
        //    else
        //        return false;
        //}, 'Debe subir una imagen.');

        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                }
                else if (element.attr("name") == "ctl00$cph_MasterBody$txtColor") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtNombre: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtSigla: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtColor: {
                    minlength: 1,
                    required: true
                }
                //,
                //ctl00$cph_MasterBody$imgLogo: "TieneImagen"
            },
            messages: {
                ctl00$cph_MasterBody$txtNombre: "Por favor, ingrese el nombre del partido pol&iacute;tico.",
                ctl00$cph_MasterBody$txtSigla: "Por favor, ingrese la sigla del partido pol&iacute;tico.",
                ctl00$cph_MasterBody$txtColor: "Por favor, seleccione un color."
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

    var runValidator11 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("hfRequired", function () {
            //if ($("#cph_MasterBody$hfLatitud").val() != "" && $("#cph_MasterBody$hfLongitud").val() != "") {
            if ((document.getElementById("cph_MasterBody_hfLongitud").value == "")
                || (document.getElementById("cph_MasterBody_hfLongitud").value == undefined)) {
                return false;
            } else {
                return true;
            }
        }, 'Seleccione un punto en el mapa.');

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                }
                else if (element.attr("name") == "ctl00$cph_MasterBody$hfLatitud" || element.attr("name") == "ctl00$cph_MasterBody$hfLongitud") {
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaInicio") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtHoraInicio") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaTermino") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtHoraTermino") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaEvento") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtHoraEvento") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                }
                 else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$hfLongitud: "hfRequired",
                ctl00$cph_MasterBody$txtNombreEvento:
                {
                    minlength: 2,
                    required: true
                },
                cmbEncargado:
                {
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaInicio:
                {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtHoraInicio:
                {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaTermino:
                {
                    required: true
                },
                ctl00$cph_MasterBody$txtHoraTermino:
                {
                    required: true
                },
                //ctl00$cph_MasterBody$txtMeta:
                //{
                //    number: true
                //},
                ctl00$cph_MasterBody$txtTituloPagina:
                {
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaEvento:
                {
                    required: true
                },
                ctl00$cph_MasterBody$txtHoraEvento:
                {
                    required: true
                },
                cmbEstado:
                {
                    required: true
                },
                cmbMunicipio:
                {
                    required: true
                },
                ctl00$cph_MasterBody$address:
                {
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtNombreEvento: "Por favor, ingrese el nombre del evento.",
                cmbEncargado: "Por favor, selecciones un encargador del evento",
                ctl00$cph_MasterBody$txtFechaInicio: "Por favor, seleccione una fecha de inicio del evento",
                ctl00$cph_MasterBody$txtHoraInicio: "Por favor, seleccione la hora de inicio del evento",
                ctl00$cph_MasterBody$txtFechaTermino: "Por favor, seleccione la fecha termino del evento ",
                ctl00$cph_MasterBody$txtHoraTermino: "Por favor, seleccione la hora de termino del evento",
                //ctl00$cph_MasterBody$txtMeta:
                //{
                //    number:"Por favor, ingrese un n&uacute;mero de la meta"
                //},
                ctl00$cph_MasterBody$txtTituloPagina: "Por favor, ingrese un titulo de p&aacute;gina ",
                ctl00$cph_MasterBody$txtFechaEvento: "Por favor, seleccione una fecha del evento",
                ctl00$cph_MasterBody$txtHoraEvento: "Por favor, seleccione la hora del evento",
                cmbEstado: "Por favor, seleccione un estado",
                cmbMunicipio: "Por favor, seleccione un municipio",
                ctl00$cph_MasterBody$address: "Por favor, ingrese la direcci&oacute;n del evento",
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                successHandler2.hide();
                errorHandler2.show();
                console.log("Valor: " + document.getElementById("cph_MasterBody_hfLongitud").value);
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
               // successHandler2.show();
                errorHandler2.hide();
                this.submit();
            }
        });
    };
    
    var runValidator12 = function () {
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
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaInicio") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtHoraInicio") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaTermino") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtHoraTermino") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtNombreActividad: {
                    minlength: 1,
                    required: true
                },
                cmbEncargado: {
                    required: true
                },
                txtEvento: {
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaInicio: {
                    required: true
                },
                ctl00$cph_MasterBody$txtHoraInicio: {
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaTermino: {
                    required: true
                },
                ctl00$cph_MasterBody$txtHoraTermino: {
                    required: true
                },
                ctl00$cph_MasterBody$txtObservaciones: {
                    minlength: 2,
                    required: true
                },
                cmbTipoActividad: {
                    required: true
                }

            },
            messages: {
                ctl00$cph_MasterBody$txtNombreActividad: "Por favor, ingrese el nombre del evento.",
                txtEvento: "Por favor, seleccione un tipo de evento.",
                cmbEncargado: "Por favor, seleccione un encargado para el evento.",
                ctl00$cph_MasterBody$txtFechaInicio: "Por favor, ingrese una fecha de inicio.",
                ctl00$cph_MasterBody$txtHoraInicio: "Por favor, ingrese una hora de inicio.",
                ctl00$cph_MasterBody$txtFechaTermino: "Por favor, ingrese una fecha final.",
                ctl00$cph_MasterBody$txtHoraTermino: "Por favor, ingrese una hora final.",
                ctl00$cph_MasterBody$txtObservaciones: "Por favor, ingrese una observaci&oacute;n.",
                cmbTipoActividad: "Por favor, selecciones un tipo de actividad."
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

    var runValidator13 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);
        $.validator.addMethod("Youtube", function () {
            var urlAux = document.getElementById("cph_MasterBody_txtUrl").value;
            var expReg = /^(?:https?:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v=|watch\?.+&v=))((\w|-){11})(?:\S+)?$/;
            if (urlAux.match(expReg)){
                var embed = 'https://www.youtube.com/embed/' + RegExp.$1;
                $('#frameName').attr('src', embed);
                return true;
            }else{
                return false;
            }}),
         
          $('#frmMaster').validate({
              errorElement: "span", // contain the error msg in a small tag
              errorClass: 'help-block',
              errorPlacement: function (error, element) { // render error placement for each input type
                  if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                      error.insertAfter($(element).closest('.form-group').children('div').children().last());
                  }else {
                      error.insertAfter(element);
                  }
              }, 
              ignore: "",
              rules: {
                  ctl00$cph_MasterBody$txtAlt: {
                      required: true
                  },
                  ctl00$cph_MasterBody$txtUrl: "Youtube"
              },
              messages: {

                  ctl00$cph_MasterBody$txtUrl: "Por favor inserte una Url ",
                  ctl00$cph_MasterBody$txtAlt: "Inserte el texto alternativo"
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

    var runValidator14 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtTituloGeneral: {
                    minlength: 10,
                    required: true
                },
                ctl00$cph_MasterBody$txtNombreEncuesta: {
                    minlength: 10,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtTituloGeneral: "Por favor, ingrese el t&iacute;tulo general de la encuesta.",
                ctl00$cph_MasterBody$txtNombreEncuesta: "Por favor, ingrese el nombre de la encuesta."
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

    var runValidator15 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtPregunta: {
                    minlength: 2,
                    required: true
                },
                cmb_TipoPregunta: {

                    required: true
                },
                ctl00$cph_MasterBody$txtOrden: {
                    required: true,
                    number: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtPregunta: "Por favor, Ingrese la pregunta",
                cmb_TipoPregunta: "Por favor, Seleccione un tipo de pregunta",
                ctl00$cph_MasterBody$txtOrden: "Por favor, Ingrese el orden de la pregunta"
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

    var runValidator16 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtClaveRespuesta: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtRespuesta: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtOrden:
               {
                   required: true,
                   number: true
               }
            },
            messages: {
                ctl00$cph_MasterBody$txtIndiceRespuesta: "Por favor, ingrese una clave de respuesta",
                ctl00$cph_MasterBody$txtRespuesta: "Por favor, ingrese una respuesta",
                ctl00$cph_MasterBody$txtOrden:
                   {
                       required: "Por favor, ingrese un orden",
                       number: "Por favor, solo puede ingresar numero"
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

    var runValidator17 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtTituloRespuesta: {
                    minlength: 5,
                    required: true
                },
                ctl00$cph_MasterBody$txtPeriodoDatos: {
                    minlength: 5,
                    required: true
                },
                ctl00$cph_MasterBody$txtTituloPorcentaje: {
                    minlength: 5,
                    required: true
                },
                txtExplicacion:
                    {
                        requiered:true
                    }
            },
            messages: {
                ctl00$cph_MasterBody$txtTituloRespuesta: "Por favor, Ingrese el t&iacute;tulo de la respuesta",
                ctl00$cph_MasterBody$txtPeriodoDatos: "Por favor, Ingrese el periodo de datos",
                ctl00$cph_MasterBody$txtTituloPorcentaje: "Por favor, Ingrese el t&iacute;tulo del porcentaje",
                txtExplicacion: "Por favor, Ingrese una explicaci&oacute;n"
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

    var runValidator17Web = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtNombre: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtApePat: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtApeMat: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtPartido: {
                    maxlength: 50,
                    required: true
                },
                cmbPartido: {
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtGraEst: "Por favor, ingrese el nombre del candidato",
                ctl00$cph_MasterBody$txtApePat: "Por favor, ingrese el apellido paterno del candidato",
                ctl00$cph_MasterBody$txtApeMat: "Por favor, ingrese el apellido materno del candidato",
                ctl00$cph_MasterBody$txtPartido: "Por favor, ingrese el partido politico del candidato",
                cmbPartido: "Por favor, seleccione un partido politico"
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

    var runValidator18 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtRespuestas: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtOrdens:
                {
                    required: true,
                    number: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtRespuesta1: "Por favor, ingrese una respuesta",
                ctl00$cph_MasterBody$txtOrdens:
                    {
                        required: "Por favor, ingrese un orden",
                        number: "Por favor, solo puede ingresar numero"
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

    var runValidator18Web = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtCuenta: {
                    maxlength: 50,
                    required: true
                },
                cmbRedSocial:
                    {
                        required : true
                    }
            },
            messages: {
                ctl00$cph_MasterBody$txtCuenta: "Por favor, ingrese la cuenta",
                cmbRedSocial : "Seleccione un tipo de red social"
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

    var runValidator19Web = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_hf").value === '') {
                if ((document.getElementById("cph_MasterBody_imgLogo").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');
        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtTituloBlog: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtNombreImagen: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtAlt: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtDescripcion: {
                    required: true
                },
                ctl00$cph_MasterBody$imgLogo: "validarImagen"
            }, 
            messages: {
                ctl00$cph_MasterBody$txtTituloBlog: "Por favor, ingrese el titulo del blog",
                ctl00$cph_MasterBody$txtNombreImagen: "Por favor, ingrese el nombre de la imagen",
                ctl00$cph_MasterBody$txtAlt: "Por favor, ingrese un texto para la imagen",
                ctl00$cph_MasterBody$txtDescripcion: "Por favor ingrese una descripcion de la imagen",
                txtBlog: "Por favor, ingrese el texto del blog"
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

    var runValidator20Web = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                cmbCandidatos: {
                    required: true
                },
                ctl00$cph_MasterBody$txtNombre: {
                    maxlength: 50,
                    required: true
                }
            },
            messages: {
                cmbCandidatos: "Por favor, seleccione el candidato",
                ctl00$cph_MasterBody$txtNombre: "Por favor, ingrese el nombre de la propuesta",               
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

    var runValidator21Web = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtDireccion: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtCorreo: {
                    maxlength: 50,
                    required: true
                },
                ctl00$cph_MasterBody$txtNum: {
                    maxlength: 50,
                    required: true
                },                
                cmbCandidatos: {
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtDireccion: "Por favor, ingrese una direccion",
                ctl00$cph_MasterBody$txtCorreo: "Por favor, ingrese un correo",
                ctl00$cph_MasterBody$txtNum: "Por favor, ingrese un numero de telefono",
                cmbPartido: "Por favor, seleccione un partido politico"
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

    var runValidator22Web = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_hf").value === '') {
                if ((document.getElementById("cph_MasterBody_imgImagen").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');

        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                }else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtNombre: {
                    maxlength: 80,
                    required: true
                },
                ctl00$cph_MasterBody$txtApePat: {
                    maxlength: 70,
                    required: true
                },
                ctl00$cph_MasterBody$txtApeMat: {
                    maxlength: 70,
                    required: true
                },
                ctl00$cph_MasterBody$txtOcupacion: {
                    maxlength: 100,
                    required: true
                },
                ctl00$cph_MasterBody$imgImagen: "validarImagen"
            },
            messages: {
                ctl00$cph_MasterBody$txtNombre: "Por favor, ingrese el nombre",
                ctl00$cph_MasterBody$txtApePat: "Por favor, ingrese el apellido parterno",
                ctl00$cph_MasterBody$txtApeMat: "Por favor, ingrese el apellido materno",
                ctl00$cph_MasterBody$txtOcupacion: "Por favor, ingrese la ocupacion"                
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

    var runValidator23Web = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtQueHacemos: {
                    maxlength: 100,
                    required: true
                },
                ctl00$cph_MasterBody$txtAfiliate: {
                    maxlength: 150,
                    required: true
                },
                ctl00$cph_MasterBody$txtProxEventos: {
                    maxlength: 150,
                    required: true
                },
                ctl00$cph_MasterBody$txtEquipoTrabajo: {
                    maxlength: 150,
                    required: true
                },
                ctl00$cph_MasterBody$txtContacto: {
                    maxlength: 150,
                    required: true
                },
            },
            messages: {
                ctl00$cph_MasterBody$txtQueHacemos: "Por favor, ingrese el texto",
                ctl00$cph_MasterBody$txtAfiliate: "Por favor, ingrese el texto",
                ctl00$cph_MasterBody$txtProxEventos: "Por favor, ingrese el texto",
                ctl00$cph_MasterBody$txtEquipoTrabajo: "Por favor, ingrese el texto",
                ctl00$cph_MasterBody$txtContacto : "Por favor, ingrese el texto"
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

    var runValidator24Web = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtPropuesta: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtDescProp: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtGestionProp: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtPresupuestoProp: {
                    minlength: 1,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtPropuesta: "Por favor, ingrese el nombre de la propuesta",
                ctl00$cph_MasterBody$txtDescProp: "Por favor, ingrese la descripci&oacute;n de la propuesta",
                ctl00$cph_MasterBody$txtGestionProp: "Por favor, ingrese la gesti&oacute;n de la propuesta",
                ctl00$cph_MasterBody$txtPresupuestoProp: "Por favor, ingrese el presupuesto de la propuesta"
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

    var runValidator23 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);
        $.validator.addMethod("Youtube", function () {
            var urlAux = document.getElementById("cph_MasterBody_txtUrl").value;
            var expReg = /^(?:https?:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v=|watch\?.+&v=))((\w|-){11})(?:\S+)?$/;
            if (urlAux.match(expReg)) {
                var embed = 'https://www.youtube.com/embed/' + RegExp.$1;
                $('#frameName').attr('src', embed);
                return true;
            } else {
                return false;
            }
        }),

          $('#frmMaster').validate({
              errorElement: "span", // contain the error msg in a small tag
              errorClass: 'help-block',
              errorPlacement: function (error, element) { // render error placement for each input type
                  if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                      error.insertAfter($(element).closest('.form-group').children('div').children().last());
                  } else {
                      error.insertAfter(element);
                  }
              },
              ignore: "",
              rules: {
                  ctl00$cph_MasterBody$txtAlt: {
                      required: true
                  },
                  ctl00$cph_MasterBody$txtUrl: "Youtube"
              },
              messages: {

                  ctl00$cph_MasterBody$txtUrl: "Por favor inserte una Url ",
                  ctl00$cph_MasterBody$txtAlt: "Inserte el texto alternativo"
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
                cmbMunicipio: {
                    required: true
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
                txtGenero: {
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
                cmbSeccion: {
                    required: true,
                    min: 1 
                },
                cmbOperador: {
                    required: true,
                    min: 1
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtNombreAfiliado: "Por favor, ingrese el nombre del afiliado.",
                ctl00$cph_MasterBody$txtApePatAfiliado: "Por favor, ingrese el apellido paterno del afiliado.",
                ctl00$cph_MasterBody$txtApeMatAfiliado: "ingrese el apellido materno del afiliado.",
                ctl00$cph_MasterBody$txtFechaAfiliacion: "Por favor, selecciones un fecha de afiliaci&oacute;n.",
                cmbEstado: "Por favor, selecciones un estado.",
                cmbMunicipio: "Por favor, selecciones un municipio.",
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
                txtGenero: "Por favor, seleciones un g&eacute;nero",
                ctl00$cph_MasterBody$txtCelular: "Por favor, ingrese un n&uacute;mero valido",
                ctl00$cph_MasterBody$txtNumeroExt: "Por favor, ingrese un n&uacute;mero exterior valido",
                ctl00$cph_MasterBody$txtNumeroInt: "Por favor, ingrese un n&uacute;mero interior valido",
                cmbSeccion: {
                    required: "Por favor, seleccione una secci&oacute;n.",
                    min: "Por favor, seleccione una secci&oacute;n."
                },
                cmbOperador: {
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

    var runValidator27 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                }else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtEstado: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtSigla: {
                    minlength: 2,
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtEstado: "Por favor, ingrese el nombre del estado",
                ctl00$cph_MasterBody$txtSigla: "Por favor, ingrese las siglas del estado"
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
                errorHandler2.hide();
                this.submit();
            }
        });
    };

    var runValidator28 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                cmbEstado: {
                    required: true
                },
                ctl00$cph_MasterBody$txtMunicipio: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtSigla: {
                    minlength: 2,
                    required: true
                }
            },
            messages: {
                cmbEstado: "Por favor, selecciones un estado",
                ctl00$cph_MasterBody$txtMunicipio: "Por favor, ingrese el nombre del municipio",
                ctl00$cph_MasterBody$txtSigla: "Por favor, ingrese las siglas del municipio"
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
                errorHandler2.hide();
                this.submit();
            }
        });
    };

    var runValidator29 = function () {
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
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtColor") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtDescripcion: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtColor: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtOrden: {
                    required: true,
                    number:true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacuten.",
                ctl00$cph_MasterBody$txtOrden: {
                    required: "Por favor, ingrese un orden del porcentaje",
                    number:"Por favor, ingrese un dato valido"
                },
                ctl00$cph_MasterBody$txtColor: "Por favor, ingrese un color del porcentaje"
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

    var runValidator30 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_hf").value === '') {
                if ((document.getElementById("cph_MasterBody_imgLogo").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');
        //var campo = $('#id_del_input').val();
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtTitle: {
                    required: true
                },
                ctl00$cph_MasterBody$txtAlt: {
                    required: true
                },
                ctl00$cph_MasterBody$txtDescripcion: {
                    required: true
                },
                ctl00$cph_MasterBody$imgLogo: "validarImagen"
                //,
                //ctl00$cph_MasterBody$imgLogo: "TieneImagen"
            },
            messages: {
                ctl00$cph_MasterBody$txtTitle: "Por favor, ingrese el t&iacute;tulo.",
                ctl00$cph_MasterBody$txtAlt: "Por favor, ingrese el texto alternativo.",
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacute;n."
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

    var runValidator31 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("MapRequired", function () {
            if ((document.getElementById("cph_MasterBody_txtLongitud").value === '') || (document.getElementById("cph_MasterBody_txtLatitud").value === '')) {
                return false;
            }
            else {
                return true;
            }
        }, 'Seleccione un punto en el mapa.');

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                }
                else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtNombrePoligono: { minlength: 2, required: true },
                ctl00$cph_MasterBody$txtClave: { required: true },
                cmbEstado: { required: true },
                cmbMunicipio: { required: true },
                ctl00$cph_MasterBody$txtLongitud: "MapRequired",
                ctl00$cph_MasterBody$txtLatitud: "MapRequired",
                ctl00$cph_MasterBody$txtColonia: { required: true },
            },
            messages: {
                ctl00$cph_MasterBody$txtNombrePoligono: "Por favor, ingrese el nombre del pol&iacute;gono.",
                ctl00$cph_MasterBody$txtClave: "Por favor, ingrese la clave del pol&iacute;gono.",
                cmbEstado: "Por favor, seleccione un estado",
                cmbMunicipio: "Por favor, seleccione un municipio",
                ctl00$cph_MasterBody$txtColonia: "Por favor, ingrese una colonia"
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
                successHandler2.show();
                errorHandler2.hide();
                this.submit();
            }
        });
    };

    var runValidator32 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("MapRequired", function () {
            if ((document.getElementById("hfLongitud").value === '') || (document.getElementById("hfLatitud").value === '')) {
                return false;
            }
            else {
                return true;
            }
        }, 'Seleccione un punto en el mapa.');

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("map")) {
                    error.appendTo($(element).closest('.map'));
                } else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                //hfLongitud: "MapRequired",
                hfLatitud: "MapRequired"
            },
            messages: {
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
                successHandler2.show();
                errorHandler2.hide();
                form.submit();
            }
        });
    };

    var runValidator34 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("MapRequired", function () {
            if ((document.getElementById("cph_MasterBody_txtLatitud").value === '') || (document.getElementById("cph_MasterBody_txtLongitud").value === '')) {
                return false;
            }
            else {
                return true;
            }
        }, 'Seleccione un punto en el mapa.');

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtLatitud: "MapRequired",
                ctl00$cph_MasterBody$txtLongitud: "MapRequired"
            },
            messages: {
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
                successHandler2.show();
                errorHandler2.hide();
                this.submit();
            }
        });
    };

    var runValidator35 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaNac") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtNombre: {
                    minlength: 2,
                    required: true
                },
                ctl00$cph_MasterBody$txtApPaterno: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtApMaterno: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtCorreo: {
                    minlength: 1,
                    required: true,
                    email: true
                },
                ctl00$cph_MasterBody$txtTelefono: {
                    minlength: 1,
                    number: true,
                    required: true
                },
                ctl00$cph_MasterBody$id_password: {
                    minlength: 6,
                    required: true
                },
                ctl00$cph_MasterBody$id_password_again: {
                    required: true,
                    minlength: 5,
                    equalTo: "#cph_MasterBody_id_password"
                },
                ctl00$cph_MasterBody$txtFechaNac: {
                    minlength: 1,
                    required: true
                },
                ctl00$cph_MasterBody$txtCodigoPostal: {
                    minlength: 5,
                    number: true,
                    required: true
                },
                ctl00$cph_MasterBody$txtCuidad: {
                    minlength: 1,
                    required: true
                },
                cmbEncargado: {
                    required: true
                }
                //txtTipoUsuario: {
                //    required: true
                //}
                //,
                //ctl00$cph_MasterBody$imgLogo: "TieneImagen"
            },
            messages: {
                ctl00$cph_MasterBody$txtNombre: "Por favor, ingrese el nombre del auxiliar",
                ctl00$cph_MasterBody$txtApPaterno: "Por favor, ingrese el apellido paterno del auxiliar",
                ctl00$cph_MasterBody$txtApMaterno: "Por favor, ingrese el apellido materno del auxiliar",
                ctl00$cph_MasterBody$txtCorreo: {
                    required: "Por favor, ingrese un correo del auxiliar",
                    email: "Su direcci&oacute;n de correo electr&oacute;nico debe tener el formato de nombre@dominio.com"
                },
                ctl00$cph_MasterBody$txtTelefono: "Por favor, ingrese el t&eacute;lefono del auxiliar",
                ctl00$cph_MasterBody$id_password:
                    {
                        required: "Por favor, ingrese un password",
                        minlength: "Por favor, ingrese al menos 6 caracteres"
                    },
                ctl00$cph_MasterBody$id_password_again:
                    {
                        required: "Por favor, ingrese de nuevo su password",
                        minlength: "Por favor, ingrese al menos 6 caracteres",
                        equalTo: "Por favor, confirme su password"
                    },
                ctl00$cph_MasterBody$txtFechaNac: "Por favor, selecciones un fecha de nacimiento",
                ctl00$cph_MasterBody$txtCodigoPostal: "Por favor, ingrese su c&oacute;digo postal",
                ctl00$cph_MasterBody$txtCuidad: "Por favor, ingrese su cuidad",
                cmbEncargado: "Por favor, seleccione un colaborador"
                //txtTipoUsuario: "Por favor, selecciones un tipo de usuario"
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

    var runValidator36 = function (){
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_hf").value === '') {
                if ((document.getElementById("cph_MasterBody_imgLogo").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');
        $.validator.addMethod("Url", function () {
            var urlAux = document.getElementById("cph_MasterBody_txtUrlBanner").value;
            var expReg = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/gi;
            if (urlAux.match(expReg))
              
                return true;
            else{
                return false;
            }
        }),
       
	    $('#cph_MasterBody_txtverMas').change(function () {
	        var Aux = document.getElementById("cph_MasterBody_txtverMas").value;
	        if (document.getElementById('cph_MasterBody_txtverMas').checked) {
	            $('#cph_MasterBody_mostrar').show();
	            $('#cph_MasterBody_txtverMas').prop('value', true);
	        } else {
	            $('#cph_MasterBody_mostrar').hide();
	            $('#cph_MasterBody_txtverMas').prop('value',false);

	        }
	});      
          $('#frmMaster').validate({
            errorElement: "span", 
            errorClass: 'help-block',
            errorPlacement: function (error, element) { 
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { 
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtTitle: {
                    required: true
                },
                ctl00$cph_MasterBody$txtAlt: {
                    required: true
                },
                ctl00$cph_MasterBody$txtDescripcion: {
                    required: true
                },
                ctl00$cph_MasterBody$txtNombreInicial: {
                    required: true
                },
                ctl00$cph_MasterBody$txtNombreBanner: {
                    required: true
                },
               // ctl00$cph_MasterBody$txtUrlBanner: "Url",
                //ctl00$cph_MasterBody$txtButton: {
                //    required: true
                //},
                ctl00$cph_MasterBody$imgLogo: "validarImagen"
              },
            messages: {
                ctl00$cph_MasterBody$txtTitle: "Por favor, ingrese el t&iacute;tulo.",
                ctl00$cph_MasterBody$txtAlt: "Por favor, ingrese el texto alternativo.",
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacute;n.",
                ctl00$cph_MasterBody$txtNombreInicial:"Nombre inicial",
                ctl00$cph_MasterBody$txtNombreBanner:"Escriba nombre del banner",
                ctl00$cph_MasterBody$txtUrlBanner:"Escriba una url"
            },
            invalidHandler: function (event, validator) {
                successHandler2.hide();
                errorHandler2.show();
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
            },
            unhighlight: function (element) { 
                $(element).closest('.form-group').removeClass('has-error');
              },
            success: function (label, element) {
                label.addClass('help-block valid');
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
            },
            submitHandler: function (form2) {
                errorHandler2.hide();
                this.submit();
            }
        });
     };

    var runValidator37 = function () {
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
                 } else if (element.hasClass("ckeditor")) {
                     error.appendTo($(element).closest('.form-group'));
                 } else {
                     error.insertAfter(element);
                     // for other inputs, just perform default behavior
                 }
             },
             ignore: "",
             rules: {
                 ctl00$cph_MasterBody$txtGastos: {
                     minlength: 5,
                     required: true
                 },
                 ctl00$cph_MasterBody$txtDescripcion: {
                     minlength: 10,
                     required: true
                 },
                 ctl00$cph_MasterBody$txtMonto: {
                     required: true,
                     number: true
                 },
                 cmbEncargado: {
                     required: true
                 }
                 },
             messages: {
                 ctl00$cph_MasterBody$txtGastos: "Por favor, ingrese el nombre del gasto.",
                 ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacute;n del gasto.",
                 ctl00$cph_MasterBody$txtMonto: {
                     required: "Por favor, ingrese el monto del gasto",
                     number:"Por favor, inserse solo numeros"
                 },
                 cmbEncargado:"Por favor, selecciones el responsable del gasto"
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

    var runValidator41 = function () {
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
                    minlength: 5,
                    required: true
                },
                ctl00$cph_MasterBody$txtDescripcion: {
                    required: true
                },
                ctl00$cph_MasterBody$txtMision: {
                    required: true
                },
                ctl00$cph_MasterBody$txtVision: {
                    required: true
                },
                ctl00$cph_MasterBody$txtAltM: {
                    required: true
                },
                ctl00$cph_MasterBody$txtNombreImagenM: {
                    required: true
                },
                ctl00$cph_MasterBody$txtNombreImagenV: {
                    required: true
                },
                ctl00$cph_MasterBody$txtAltV: {
                    required: true
                },
                ctl00$cph_MasterBody$txtValores: {
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtTitulo: "Por favor, ingrese el titulo.",
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacute;n.",
                ctl00$cph_MasterBody$txtMision: "Por favor, ingrese la misi&oacute;n",
                ctl00$cph_MasterBody$txtVision: "Por favor, ingrese la visi&oacute;n",
                ctl00$cph_MasterBody$txtAltM: "Por favor, ingrese el texto alternativo.",
                ctl00$cph_MasterBody$txtNombreImagenM: "Por favor, ingrese el texto alternativo.",
                ctl00$cph_MasterBody$txtNombreImagenV: "Por favor, ingrese el texto alternativo.",
                ctl00$cph_MasterBody$txtAltV: "Por favor, ingrese el texto alternativo.",
                ctl00$cph_MasterBody$txtValores: "Por favor, ingrese los valores"

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

    var runValidator42 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_hf").value === '') {
                if ((document.getElementById("cph_MasterBody_imgLogo").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');
        //var campo = $('#id_del_input').val();
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                } else if (element.attr("name") == "ctl00$cph_MasterBody$txtFechaRealizado") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$txtTitulo: {
                    required: true
                },
                ctl00$cph_MasterBody$txtDescripcion: {
                    required: true
                },
                ctl00$cph_MasterBody$txtFechaRealizado: {
                    required: true
                },
                ctl00$cph_MasterBody$imgLogo: "validarImagen"

            },
            messages: {
                ctl00$cph_MasterBody$txtTitle: "Por favor, ingrese el t&iacute;tulo.",
                ctl00$cph_MasterBody$txtFechaRealizado: "Por favor, ingrese una fecha.",
                ctl00$cph_MasterBody$txtDescripcion: "Por favor, ingrese la descripci&oacute;n."
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

    var runValidator43 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_hf").value === '') {
                if ((document.getElementById("cph_MasterBody_imgLogo").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');
        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));

                }
                else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                ctl00$cph_MasterBody$txtNombreProyecto: {                    
                    required: true
                },
                ctl00$cph_MasterBody$txtProy1: {                    
                    required: true
                },
                ctl00$cph_MasterBody$txtProy2: {                    
                    required: true
                },
                ctl00$cph_MasterBody$txtProy3: {                    
                    required: true
                },
                ctl00$cph_MasterBody$txtPropP: {                    
                    required: true
                }
            },
            messages: {
                ctl00$cph_MasterBody$txtNombreProyecto: "Por favor, ingrese el nombre de la propuesta",
                ctl00$cph_MasterBody$txtProy1: "Por favor, ingrese la primera parte de la propuesta",
                ctl00$cph_MasterBody$txtProy2: "Por favor, ingrese la segunda parte de la propuesta",
                ctl00$cph_MasterBody$txtProy3: "Por favor, ingrese la tercera parte de la propuesta",
                ctl00$cph_MasterBody$txtPropP: "Por favor, ingrese el pie de pagina"
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

    var runValidator44 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("MapRequired", function () {
            if ((document.getElementById("cph_MasterBody_hfLongitud").value === '') || (document.getElementById("cph_MasterBody_hfLatitud").value === '')) {
                return false;
            }
            else {
                return true;
            }
        }, 'Seleccione un punto en el mapa.');

        $.validator.addMethod("phoneNumbers", function () {
            var dataTxt = document.getElementById("cph_MasterBody_txtTelefonos").value;
            if (dataTxt === '') {
                return false;
            }
            else {
                var tagslist = dataTxt.split(",");
                if (tagslist.length < 3) {
                    var band = true;
                    for (var i = 0; i < tagslist.length; i++) {
                        console.log(tagslist[i])
                        if (!tagslist[i].match(/^[0-9]{10}$/)) {
                            band = false;
                            break;
                        }
                    }
                    return band;
                }
                else {
                    return false;
                }
            }
        }, 'Verifique que cada n&uacute;mero telef&oacute;nico cuente con el formato a 10 d&iacute;gitos. Solo se pueden agregar 3 n&uacute;meros telef&oacute;nicos.');

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("map")) {
                    error.appendTo($(element).closest('.map'));
                } else if (element.hasClass("map")) {
                    error.appendTo($(element).closest('.map'));
                } else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                ctl00$cph_MasterBody$hfLatitud: "MapRequired",
                ctl00$cph_MasterBody$address: { required: true },
                ctl00$cph_MasterBody$txtTitulo: { required: true },
                ctl00$cph_MasterBody$txtTexto: { required: true },
                ctl00$cph_MasterBody$txtTelefonos: "phoneNumbers",
                ctl00$cph_MasterBody$txtCorreo: { required: true, email: true }
            },
            messages: {
                //ctl00$cph_MasterBody$txtTelefonos: { required: "Debe ingresar al menos un n&uacute;mero de tel&eacute;fono." },
                ctl00$cph_MasterBody$address: { required: "Debe ingresar la direcci&oacute;n de contacto." },
                ctl00$cph_MasterBody$txtTitulo: { required: "Debe ingresar el t&iacute;tulo a mostrar en la p&aacute;gina de contacto." },
                ctl00$cph_MasterBody$txtTexto: { required: "Debe ingresar el texto a mostrar en la p&aacute;gina de contacto." },
                ctl00$cph_MasterBody$txtCorreo: {
                    required: "Debe ingresar una direcci&oacute;n de correo electr&oacute;nico de contacto.",
                    email: "Su direcci&oacute;n de correo electr&oacute;nico debe tener el formato de nombre@dominio.com"
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
                successHandler2.show();
                errorHandler2.hide();
                this.submit();
            }
        });
    };

    var runValidator45 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("ItemsRequired", function () {
            if ((document.getElementById("chkTodos").checked == 'false') || (document.getElementById("chkTodos").checked == '')) {
                console.log(document.getElementById("cmbColaborador").value);
                if (document.getElementById("cmbColaborador").value === '')
                    return false;
                else
                    return true;
            }
            else {
                return true;
            }
        }, 'Debe seleccionar al menos un elemento.');

        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else {
                    error.insertAfter(element);
                }
            },
            ignore: "",
            rules: {
                cmbColaborador: "ItemsRequired",
                ctl00$cph_MasterBody$txtNombre: { required: true },
                ctl00$cph_MasterBody$txtTitulo: { required: true },
                ctl00$cph_MasterBody$txtTexto: { required: true }
            },
            messages: {
                ctl00$cph_MasterBody$txtNombre: "Campo requerido. Ingrese un nombre.",
                ctl00$cph_MasterBody$txtTitulo: "Campo requerido. Ingrese un t&iacute;tulo.",
                ctl00$cph_MasterBody$txtTexto: "Campo requerido. Ingrese un texto."
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
                successHandler2.show();
                errorHandler2.hide();
                this.submit();
            }
        });
    };

    var runValidator100V2 = function () {
        var form2 = $('#frmMaster');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);

        $.validator.addMethod("validarImagen", function () {
            if (document.getElementById("cph_MasterBody_fuploadImagen").value === '') {
                if ((document.getElementById("cph_MasterBody_fuploadImagen").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');
        //form2.validate({
        $('#frmMaster').validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else if (element.hasClass("fileupload")) {
                    error.appendTo($(element).closest('.form-group'));
                }
                else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {

                CmbPoligonos: {
                    required: true
                },
               CmbCasilla:
                    {
                        required: true
                    },
               cmbColaboradores:
                   {
                       required: true
                   },
                ctl00$cph_MasterBody$fuploadImagen: "validarImagen"
            },
            messages: {
               CmbPoligonos: "Por favor, seleccione el poligono",
               CmbCasilla: "Por favor, selecciones la casilla",
               cmbColaboradores: "Por favor, selecciones un colaborador",
                ctl00$cph_MasterBody$fuploadImagen: "Por favor, seleccione una imagen"
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
        init: function (aux) {
            //runValidator();
            switch(aux)
            {
                case 1: runValidator();
                    break;
                case 2: runValidator2();
                    break;
                case 3: runValidator3();
                    break;
                case 4: runValidator4();
                    break;
                case 5: runValidator5();
                    break;
                case 6: runValidator6();
                    break;
                case 7: runValidator7();
                    break;
                case 10: runValidator10();
                    break;
                case 11: runValidator11();
                    break;
                case 12: runValidator12();
                    break;
                case 13: runValidator13();
                    break;
                case 14: runValidator14();
                    break;
                case 15: runValidator15();
                    break;
                case 16: runValidator16();
                     break;
                case 17: runValidator17();
                    break;                
                case 18: runValidator18();
                    break;
                case 19: runValidator19Web();
                    break;
                case 20: runValidator20Web();
                    break;
                case 21: runValidator21Web();
                    break;
                case 23: runValidator23();
                    break;
                case 24: runValidator17Web();
                    break;
                case 25: runValidator18Web();
                    break;
                case 26: runValidator26();
                    break;
                case 27: runValidator27();
                    break;
                case 28: runValidator28();
                    break;
                case 29: runValidator29();
                    break;
                case 30: runValidator30();
                    break;
                case 31: runValidator31();
                    break;
                case 32: runValidator32();
                    break;
                case 34: runValidator34();
                    break;
                case 35: runValidator35();
                    break;
                case 36: runValidator36();
                    break;
                case 37: runValidator37();
                    break;
                case 38: runValidator22Web();
                    break;
                case 39: runValidator23Web();
                    break;
                case 40: runValidator24Web();
                    break;
                case 41: runValidator41();
                    break;
                case 42: runValidator42();
                    break;
                case 43: runValidator43();
                    break;
                case 44: runValidator44();
                    break;
                case 45: runValidator45();
                    break;
                case 100: runValidator100V2();
                    break;
            }
        }
    };
}();
