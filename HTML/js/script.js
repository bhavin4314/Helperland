function hide_policy(){
    console.log("heloo");
    document.querySelector('.cookie-footer').style.display = "none";
}

$(document).ready(function(){
    $(window).scroll(function(){
        if(this.scrollY > 20 ){
            $(".navbar-sticky").addClass("sticky-header");
        }
        else{
            $(".navbar-sticky").removeClass("sticky-header");
        }   
    });

    $('.menu-toggler').click(function(){
        $(this).toggleClass("active");
        $('.main-menu').toggleClass("active");
    });

    $('.menu-toggler').click(function(){
        $(this).toggleClass("active");
        $('.main-menu').toggleClass("active");
    });
});
