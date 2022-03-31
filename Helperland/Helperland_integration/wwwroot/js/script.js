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










    //customer-dashboard part
    $(".rescheduleBtnModal").click(function () {
        $("#customerServiceInfoModal").modal("hide");
    });
    $(".cancelBtnModalMain").click(function () {
        $("#customerServiceInfoModal").modal("hide");
    });

    //customer details part
    //$("#customer-settings").click(function () {
    //    console.log("setting clicked");
    //    $("#customerDashboard").hide();
    //    $("#customerHistory").hide();
    //    $("#customerHistory-Tab").removeClass("activeTab");
    //    $("#customerDashboard-Tab").removeClass("activeTab");
    //    $("#customerDetailsRight").load(`/CustomerDashboard/customerDetails`);
    //});
        

    
});


function customerDashboard() {
    $("#customerDashboard").css("display", "block");
    $("#customerHistory").css("display", "none");
    $(".customer-setting").hide();
    $("#customerDashboard-Tab").addClass("activeTab");
    $("#customerHistory-Tab").removeClass("activeTab");
    
}

function customerHistory() {
    $("#customerDashboard").hide();
    $("#customerHistory").show();
    $(".customer-setting").hide();
    $("#customerHistory-Tab").addClass("activeTab");
    $("#customerDashboard-Tab").removeClass("activeTab");
    console.log("customerhistory in");
    $("#service-history-table").load(`/CustomerDashboard/customerServiceHistory`);
}
function customerSetting() {
    console.log("setting clicked");
    $("#customerDashboard").hide();
    $("#customerHistory").hide();
    $("#customerHistory-Tab").removeClass("activeTab");
    $("#customerDashboard-Tab").removeClass("activeTab");
    $("#customerDetailsRight").load(`/CustomerDashboard/customerDetails`);
}

function customerDetails() {
    $("#customerAddress").hide();
    $("#customerPassword").hide();
    $("#customerDetails").show();
    $("#customerDetails-tab").addClass("activeTab");
    $("#customerAddress-tab").removeClass("activeTab");
    $("#customerPassword-tab").removeClass("activeTab");
}

function customerAddress() {
    $("#customerDetails").hide().removeClass("activeTab");
    $("#customerPassword").hide();
    $("#customerAddress").show();
    $("#customerAddress-tab").addClass("activeTab");
    $("#customerDetails-tab").removeClass("activeTab");
    $("#customerPassword-tab").removeClass("activeTab");
    $("#customerAddress").load(`/CustomerDashboard/customerAddress`);
}

function customerPassword() {
    $("#customerDetails").hide();
    $("#customerAddress").hide();
    $("#customerPassword").show();
    $("#customerPassword-tab").addClass("activeTab");
    $("#customerDetails-tab").removeClass("activeTab");
    $("#customerAddress-tab").removeClass("activeTab");
    $("#customerPassword").load(`/CustomerDashboard/customerPassword`);
}


function addEditAddress(addressId) {
    console.log(addressId);
    //var id = addressId;
    $("#EditAddressModal").load(`/CustomerDashboard/addOrEditAddress/` + addressId);
    //$("#EditAddressModal").modal('show');
}


function displayServiceDetails(serviceId)
{

    console.log(serviceId);
    $("#customerServiceInfoModal").load(`/CustomerDashboard/serviceDetails/` + serviceId);
}



function reschedule(serviceId) {
    console.log(serviceId);
    
    $("#serviceDateTimeModal").load(`/CustomerDashboard/rescheduleService/` + serviceId);
    $("#customerServiceInfoModal").modal("hide");
}

function cancelService(serviceId) {
    console.log(serviceId);
    $("#serviceCancelModal").load(`/CustomerDashboard/cancelService/` + serviceId);
    $("#customerServiceInfoModal").modal("hide");
}

function deleteAddress(AddressId) {
    $("#addressDeleteModal").load(`/CustomerDashboard/deleteAddress/` + AddressId);
}


//---------------------------Service Provider----------------------------------

function newService() {
    $("#newService").show();
    $("#upcomingService").hide();
    $("#serviceHistory").hide();
    $("#blockCustomer").hide();
    $("#myRatings").hide();
    $("#newService-tab").addClass("activeTab");
    $("#upcomingService-tab").removeClass("activeTab");
    $("#serviceHistory-tab").removeClass("activeTab");
    $("#blockCustomer-tab").removeClass("activeTab");
    $("#myRatings-tab").removeClass("activeTab");
    $("#spDetailsRight").hide();
}

function upcomingService() {
    $("#newService").hide();
    $("#upcomingService").show();
    $("#serviceHistory").hide();
    $("#blockCustomer").hide();
    $("#myRatings").hide();
    $("#newService-tab").removeClass("activeTab");
    $("#upcomingService-tab").addClass("activeTab");
    $("#serviceHistory-tab").removeClass("activeTab");
    $("#blockCustomer-tab").removeClass("activeTab");
    $("#myRatings-tab").removeClass("activeTab");
    $("#spDetailsRight").hide();
    $("#upcomingService").load(`/ServiceProvider/upcomingService`);
}

function serviceHistory() {
    $("#newService").hide();
    $("#upcomingService").hide();
    $("#serviceHistory").show();
    $("#blockCustomer").hide();
    $("#myRatings").hide();
    $("#newService-tab").removeClass("activeTab");
    $("#upcomingService-tab").removeClass("activeTab");
    $("#serviceHistory-tab").addClass("activeTab");
    $("#blockCustomer-tab").removeClass("activeTab");
    $("#myRatings-tab").removeClass("activeTab");
    $("#spDetailsRight").hide();
    $("#serviceHistory").load(`/ServiceProvider/serviceHistory`);
}

function blockCustomer() {
    $("#newService").hide();
    $("#upcomingService").hide();
    $("#serviceHistory").hide();
    $("#blockCustomer").show();
    $("#myRatings").hide();
    $("#newService-tab").removeClass("activeTab");
    $("#upcomingService-tab").removeClass("activeTab");
    $("#serviceHistory-tab").removeClass("activeTab");
    $("#blockCustomer-tab").addClass("activeTab");
    $("#myRatings-tab").removeClass("activeTab");
    $("#spDetailsRight").hide();
    $("#blockCustomer").load(`/ServiceProvider/blockCustomer`);
}

function myRating() {
    $("#newService").hide();
    $("#upcomingService").hide();
    $("#serviceHistory").hide();
    $("#blockCustomer").hide();
    $("#myRatings").show();
    $("#newService-tab").removeClass("activeTab");
    $("#upcomingService-tab").removeClass("activeTab");
    $("#serviceHistory-tab").removeClass("activeTab");
    $("#blockCustomer-tab").remove("activeTab");
    $("#myRatings-tab").addClass("activeTab");
    $("#spDetailsRight").hide();
    $("#myRatings").html("loading....").load(`/ServiceProvider/myRatingSP`);
}

function spSetting() {
    $("#newService").hide();
    $("#upcomingService").hide();
    $("#serviceHistory").hide();
    $("#blockCustomer").hide();
    $("#myRatings").hide();
    $("#newService-tab").removeClass("activeTab");
    $("#upcomingService-tab").removeClass("activeTab");
    $("#serviceHistory-tab").removeClass("activeTab");
    $("#blockCustomer-tab").removeClass("activeTab");
    $("#myRatings-tab").removeClass("activeTab");
    $("#spDetailsRight").show();
    $("#spDetailsRight").load(`/ServiceProvider/spDetails`);
}

function acceptRequest(serviceId) {

    $("#customerServiceDetailModal").load("/ServiceProvider/serviceDetailsModal/" + serviceId);
}

function cancelServiceSp(serviceId) {
    $("#customerServiceDetailModal").hide();
    $("#serviceCancelModal").load(`/ServiceProvider/cancelServiceBySp/` + serviceId);
}

function spDetails() {
    $("#spDetails").show();
    $("#spPassword").hide();
    $("#spPassword-tab").removeClass("activeTab");
    $("#spDetails-tab").addClass("activeTab");
}
function spPassword() {
    $("#spDetails").hide();
    $("#spPassword").show();
    $("#spPassword-tab").addClass("activeTab");
    $("#spDetails-tab").removeClass("activeTab");
    $("#spPassword").load(`/ServiceProvider/spPassword`);
}

// Admin
function editModalBtn(serviceId) {
    $("#editServiceModal").load("/Admin/editServiceRequest/" + serviceId);
}

function allService() {
    console.log("tab1");
    $("#adminTab1").addClass("adminActiveTab");
    $("#adminTab2").removeClass("adminActiveTab");
}
function userManagement() {
    console.log("tab2");
    $("#adminTab1").removeClass("adminActiveTab");
    $("#adminTab2").addClass("adminActiveTab");

}
//function adminServiceList() {
//    $("#adminService").show();
//    $("#management").hide();
//}

//function userManagement() {
//    $("#adminService").show();
//    $("#management").hide();
//    $("#management").load(`/Admin/UserManagement`);
//}
