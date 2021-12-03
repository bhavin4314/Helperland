function hide_policy(){
    console.log("heloo");
    document.querySelector('.cookie-footer').style.display = "none";
}

$(document).ready(function(){
    $(window).scroll(function(){
        if(this.scrollY > 20 ){
            $(".navbar").addClass("sticky-header");
        }
        else{
            $(".navbar").removeClass("sticky-header");
        }
    });

    // $('.menu-toggler').click(function(){
    //     $(this).toggleClass("active");
    //     $('.custom-navbar-menu').toggleClass("active");
    // });
});