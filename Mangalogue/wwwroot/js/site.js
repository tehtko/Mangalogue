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
            document.getElementById("navbar").style.backgroundColor = "#232123"
        document.getElementById("page-body").style.opacity = "0.5";
        state = "opened"
        return;
    }

    if (state == "opened") {
        document.getElementById("content-sidebar").style.width = "0";
        document.getElementById("navbar").style.border = "none";
        setTimeout(function () {
            document.getElementById("navbar").style.backgroundColor = "transparent"
            document.getElementById("page-body").style.opacity = "1";
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