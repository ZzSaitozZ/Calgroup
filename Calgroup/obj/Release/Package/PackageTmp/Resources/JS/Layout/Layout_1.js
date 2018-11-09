$(document).ready(function () {
    'use strict';
    var c, currentScrollTop = 0;
    var h = window.innerHeight;
    $("#carouselTitle").height(h - 155)
    $(".Baner-img").height($("#carouselTitle").height())
    $("#map").height($("#ContactUs").height())
    $("#logo").height($("#Company").height())
    $("#top").height($("#logo").height())
    $(".row1son").height($("#row1").height())
    $(".row3son").height($("#row3").height())
    var k = 1;

    //$(window).scroll(function () {
    //    var a = $(window).scrollTop();
    //    currentScrollTop = a;
    //    if (c < currentScrollTop) {
    //    }
    //    else if (c > currentScrollTop) {
    //    }
    //    c = currentScrollTop;
    //})
});

window.onscroll = function () { myFunction() };
window.onresize = function () { Resize() };
var navbar = document.getElementById("navbar");
var sticky = navbar.offsetTop;
var body = document.getElementById("Body");

function myFunction() {
    $(".row1son").height($("#row1").height())
    $(".row3son").height($("#row3").height())
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky");
        var h = $("#navbar").height() + 30;
        $("#Body").css('margin-top', h );
    } else {
        navbar.classList.remove("sticky");

        $("#Body").css('margin-top', 'unset');
    }
}

function Resize() {
    $("#top").height($("#logo").height())
    $("#logo").height($("#Company").height())
    $(".row1son").height($("#row1").height())
    $(".row3son").height($("#row3").height())
}