var state = "closed";
function scrollToLeft(divToScroll) {
    document.getElementById(divToScroll).scrollLeft -= 200;
};
function scrollToRight(divToScroll) {
    document.getElementById(divToScroll).scrollLeft += 200;
};


function toggleNav() {
    if (state == "closed") {
        document.getElementById("content-sidebar").style.width = "220px";
        document.getElementById("page-body").style.opacity = "0.5";
        document.getElementById("front-page").style.opacity = "0.5";
        state = "opened"
        return;
    }

    if (state == "opened") {
        document.getElementById("content-sidebar").style.width = "0";
        setTimeout(function () {
            document.getElementById("page-body").style.opacity = "1";
            document.getElementById("front-page").style.opacity = "1";
        }, 200);
        
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