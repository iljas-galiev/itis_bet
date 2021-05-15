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
window.addEventListener('scroll', function () {
    elem = this.document.getElementById('fixibleHeader');
    y = elem.getBoundingClientRect().top;
    console.log(y)
    console.log(pageYOffset)
    if (y == 0 & pageYOffset < 130) {
        $('#fixibleHeader').removeClass('header-fixed')
    }
    if (y <= 0 & this.pageYOffset>130) {
        $('#fixibleHeader').addClass('header-fixed')
    }
});
document.getElementById('navbarToggler').addEventListener('click', function () {
    if ($('#navbarToggler').hasClass('active')) {
        $('#navbarToggler').removeClass('active');
        $('#headerMain').removeClass('active');
        $('#navbar-main-container').removeClass('active');
        $('#navbar-main-top').removeClass('active');
        $('#fixibleHeader').removeClass('active');
    }
    else {
        $('#navbarCollapseToggler').removeClass('active');
        $('#headerRight').removeClass('active');
        $('#navbarToggler').addClass('active');
        $('#headerMain').addClass('active');
        $('#navbar-main-container').addClass('active');
        $('#navbar-main-top').addClass('active');
        $('#fixibleHeader').addClass('active');
    }
});
document.getElementById('navbarCollapseToggler').addEventListener('click', function () {
    if ($('#navbarCollapseToggler').hasClass('active')) {
        $('#navbarCollapseToggler').removeClass('active');
        $('#headerRight').removeClass('active');
        
    }
    else {
        $('#navbarToggler').removeClass('active');
        $('#headerMain').removeClass('active');
        $('#navbar-main-container').removeClass('active');
        $('#navbar-main-top').removeClass('active');
        $('#fixibleHeader').removeClass('active');
        $('#navbarCollapseToggler').addClass('active');
        $('#headerRight').addClass('active');

    }
});
document.getElementById('logRegSwitch').addEventListener('click', function () {
    if ($('#logRegSwitchCircle').hasClass('switch-pos-right')) {
        $('#logRegSwitchCircle').removeClass('switch-pos-right')
    }
    else {
        $('#logRegSwitchCircle').addClass('switch-pos-right')
    }
    if ($('login').hasClass('active')) {
        $('login').removeClass('active');
        $('registration').addClass('active');
        $('#regLogHeader').text('Регистрация')
        $('#regLogSubText').text('Вход')
    }
    else {
        $('registration').removeClass('active');
        $('login').addClass('active');
        $('#regLogSubText').text('Регистрация')
        $('#regLogHeader').text('Вход')
    }
});
function checkCustomCheckBox() {
    if ($('#rememberMeCheckBox').hasClass('checked')) {
        $('#hiddenCheckbox').prop('checked', false);
        $('#rememberMeCheckBox').removeClass('checked')
        console.log('1')
    }
    else {
        $('#hiddenCheckbox').prop('checked', true);
        $('#rememberMeCheckBox').addClass('checked');
        console.log('2')
    }
}
document.getElementById('rememberMeCheckBox').addEventListener('click', function () { checkCustomCheckBox() });
document.getElementById('rememberMeText').addEventListener('click', function () { checkCustomCheckBox() });
