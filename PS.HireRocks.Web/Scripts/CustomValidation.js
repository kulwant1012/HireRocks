(function ($) {
    $.validator.addMethod("boolvalidator",
        function (value, element) {
            return !value ? false : true;
        });
    $.validator.unobtrusive.adapters.addBool("boolvalidator");
}(jQuery));