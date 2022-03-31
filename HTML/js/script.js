function hide_policy(){
    console.log("heloo");
    document.querySelector('.cookie-footer').style.display = "none";
    // document.querySelector('#login-part').style.display = "none";
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
    $('.forgot-password-click').click(function(){
        $('.login-hide').modal('hide');
    }); 
    $('.login-click').click(function(){
        $('.forgot-hide').modal('hide');
    }); 
    $('.close-click').click(function(){
        $('.login-hide').modal('hide');
    }); 
    $('.close-click').click(function(){
        $('.forgot-hide').modal('hide');
    }); 
    $(".rescheduleBtnModal").click(function(){
        $("#customerServiceInfoModal").modal("hide");    
    });
    $(".cancelBtnModalMain").click(function(){
        $("#customerServiceInfoModal").modal("hide");    
    });
    
    
});

function customerDashboard()
{
    $("#customerDashboard").css("display","block");
    $("#customerHistory").css("display","none");
    $("#customerDashboard-Tab").addClass("activeTab");
    $("#customerHistory-Tab").removeClass("activeTab");
}

function customerHistory()
{
    $("#customerDashboard").hide();
    $("#customerHistory").show();
    $("#customerHistory-Tab").addClass("activeTab");
    $("#customerDashboard-Tab").removeClass("activeTab");
}

function customerDetails()
{
    $("#customerAddress").hide();
    $("#customerPassword").hide();
    $("#customerDetails").show();
    $("#customerDetails-tab").addClass("activeTab");
    $("#customerAddress-tab").removeClass("activeTab");
    $("#customerPassword-tab").removeClass("activeTab");
}

function customerAddress()
{
    $("#customerDetails").hide().removeClass("activeTab");
    $("#customerPassword").hide();
    $("#customerAddress").show();
    $("#customerAddress-tab").addClass("activeTab");
    $("#customerDetails-tab").removeClass("activeTab");
    $("#customerPassword-tab").removeClass("activeTab");
}

function customerPassword()
{
    $("#customerDetails").hide();
    $("#customerAddress").hide();
    $("#customerPassword").show();
    $("#customerPassword-tab").addClass("activeTab");
    $("#customerDetails-tab").removeClass("activeTab");
    $("#customerAddress-tab").removeClass("activeTab");
}