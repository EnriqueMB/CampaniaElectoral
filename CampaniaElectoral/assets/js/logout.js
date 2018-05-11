
var Logout = function () {
    "use strict";
    var runLogout = function () {
        $("#btnlogout").click(function (event) {
            event.preventDefault();
            $.ajax({
                type: 'POST',
                url: '/sfrmLogout.aspx',
                contentType: false,
                processData: false,
                cache: false,
                success: function () {
                    location.href = "/Login.aspx";
                },
                error: function () {
                    //Mostrar mensaje de error
                }
            });
            return false;
        });


    };
    return {
        //main function to initiate template pages
        init: function () {
            runLogout();
        }
    };
}();