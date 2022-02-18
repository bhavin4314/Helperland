function hide_policy(){
    console.log("heloo");
    document.querySelector('.cookie-footer').style.display = "none";
}
function loginError(data, status, xhr) {
    console.log(data);
    console.log(status);
    console.log(xhr);
    console.log("Bhavin");
    alert("Invalid username and password");
}

$(document).ready(function(){

    // sticky navbar behaviour when scrolling
    $(window).scroll(function(){
        if(this.scrollY > 20 ){
            $(".navbar-sticky").addClass("sticky-header");
        }
        else{
            $(".navbar-sticky").removeClass("sticky-header");
        }   
    });

    
    // add event for mobile navbar
    $('.menu-toggler').click(function(){
        $(this).toggleClass("active");
        $('.main-menu').toggleClass("active");
    });
    
    
    // add event for dropdown of nav-item in left side menu in service request page
    $('.leftmenu-click').click(function(){
        $(this).toggleClass("collapsable-bg");
    });

    // add event on register page
    $('.forgot-password-click').click(function () {
        $('.login-hide').modal('hide');
    });
    $('.login-click').click(function () {
        $('.forgot-hide').modal('hide');
    });
    $('.close-click').click(function () {
        $('.login-hide').modal('hide');
    });
    $('.close-click').click(function () {
        $('.forgot-hide').modal('hide');
    });

    //login-error

    
});
