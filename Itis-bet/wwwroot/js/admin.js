function toggleMenu() {
    let logo = $('#logo');
    let menu = $('#menu');
    let content = $('#content');
    let className = 'toggled'
    console.log(logo)
    console.log(menu)
    console.log(className)
    if (logo.hasClass(className) && menu.hasClass(className) && content.hasClass(className)) {
        logo.removeClass(className);
        menu.removeClass(className);
        content.removeClass(className);
    }
    else {
        logo.addClass(className);
        menu.addClass(className);
        content.addClass(className);
    }
}