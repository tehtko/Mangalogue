var state = "closed";
function scrollToLeft(divToScroll) {
    document.getElementById(divToScroll).scrollLeft -= 200;
};
function scrollToRight(divToScroll) {
    document.getElementById(divToScroll).scrollLeft += 200;
};


function toggleNav() {
    if (state == "closed") {
        document.getElementById("content-sidebar").style.width = "200px";
        state = "opened"
        return;
    }

    if (state == "opened") {
        document.getElementById("content-sidebar").style.width = "0px";
        state = "closed"
        return;
    }
}

$(document).ready(function () {
    $('.navbar-light .dmenu').hover(function () {
        $(this).find('.sm-menu').first().stop(true, true).slideDown(150);
    }, function () {
        $(this).find('.sm-menu').first().stop(true, true).slideUp(105)
    });
});