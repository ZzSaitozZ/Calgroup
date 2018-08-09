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
    //var Left = $("#MenuLeft")
    //var Right = $("#MenuRight")
    //var Menu2 = $("#Menubar2")
    //var MenuMain = $("#MenuCenter")
    //var Topnav = $("#Topnav")
    //var Sidebtn = $("#Sidebtn")
    var k = 1;

    $(window).scroll(function () {
        var a = $(window).scrollTop();
        currentScrollTop = a;
        if (c < currentScrollTop) {
            //Left.removeClass("ShowL");            
            //Right.removeClass("ShowR");                       
            //MenuMain.addClass("MenuCenterHide");
            //Topnav.addClass("Tophide");
            //Sidebtn.addClass("Sidebtnhide");
            //Menu2.addClass("Hide");
        } else if (c > currentScrollTop) {
            //Left.addClass("ShowL");
            //Right.addClass("ShowR");
            //MenuMain.removeClass("MenuCenterHide");
            //Topnav.removeClass("Tophide");
            //Sidebtn.removeClass("Sidebtnhide")
            //Menu2.removeClass("Hide")
        }
        c = currentScrollTop;
    })


});

window.onscroll = function () { myFunction() };
window.onresize = function () { Resize() };
var navbar = document.getElementById("navbar");
var sticky = navbar.offsetTop;

function myFunction() {
    $("#Another").height($("#Origin").height())
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky")
    } else {
        navbar.classList.remove("sticky");
    }
}

function Resize() {
    $("#top").height($("#logo").height())
    $("#logo").height($("#Company").height())
    $("#Another").height($("#Origin").height())
}