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

function showPreview(event) {
    for (var i = 0; i < event.target.files.length; i++) {
        var image = URL.createObjectURL(event.target.files[i]);
        var imageContainer = document.getElementById('preview');
        var imagePreview = document.createElement('img');
        imagePreview.src = image;
        imagePreview.width = 200;
        imageContainer.appendChild(imagePreview);
    }
}
