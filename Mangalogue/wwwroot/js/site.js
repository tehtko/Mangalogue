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
        state = "opened"
        return;
    }

    if (state == "opened") {
        document.getElementById("content-sidebar").style.width = "0";
        setTimeout(function () {
            document.getElementById("page-body").style.opacity = "1";
        }, 200);
        state = "closed"
        return;
    }
}
