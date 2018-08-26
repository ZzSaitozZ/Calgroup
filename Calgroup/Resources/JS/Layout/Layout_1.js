$(document).ready(function () {
    'use strict';
    var c, currentScrollTop = 0;
    var h = window.innerHeight;
    $("#carouselTitle").height(h - 155)
    $(".Baner-img").height($("#carouselTitle").height())
    $("#map").height($("#ContactUs").height())
    $("#Another").height($("#Origin").height())
    $("#logo").height($("#Company").height())
    $("#top").height($("#logo").height())
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
    $("#Another").height($("#Origin").height())
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
    $("#Another").height($("#Origin").height())
}