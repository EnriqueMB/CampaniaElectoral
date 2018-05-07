var MensajeError = function (shortCutFunction, msg, title, showDuration,
    hideDuration, timeOut, extendedTimeout,
    showEasing, hideEasing, showMethod, hideMethod,
    toastIndex, btnCerrar, position) {

    if (shortCutFunction != 'shortCutFunction') {
        toastr.options = {
            closeButton: btnCerrar,
            debug: false,
            positionClass: position,//'toast-top-right',
            onclick: null
        };

        toastr.options.showDuration = showDuration;
        toastr.options.hideDuration = hideDuration;
        toastr.options.timeOut = timeOut;
        toastr.options.extendedTimeOut = extendedTimeout;
        toastr.options.showEasing = showEasing;
        toastr.options.hideEasing = hideEasing;
        toastr.options.showMethod = showMethod;
        toastr.options.hideMethod = hideMethod;
        var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
    }
};