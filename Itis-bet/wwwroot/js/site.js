$(document).ready(function () {
    $('.select').select2({
        placeholder:"asds",
    });

});
function coloriseSignInIcon(iconClass, textClass) {
    $('#sign-in-icon').removeClass(textClass);
    $('#sign-in-text').removeClass(iconClass);
    $('#sign-in-icon').addClass(iconClass);
    $('#sign-in-text').addClass(textClass);
}