/// <reference path="E:\bitbucket\travel\src\Travelling.UI\Scripts/jquery-1.9.0.min.js" />
/// <reference path="E:\bitbucket\travel\src\Travelling.UI\Scripts/jquery-migrate-1.2.1.min.js" />
/// <reference path="E:\bitbucket\travelling\src\Travelling.UI\Scripts/jquery.form.min.js" />


$(function () {
    $("#hotelSearchBtn").click(function () {
        
        var cityid = $("#HotelCityID").val();
        var areaid = $("#hidCityAreaID").val();
        var locationid = $("#hidLocationID").val();
        var brandid = $("#hidHotelBrandID").val();
        var start = $("#HotelInRoomDate").val();
        var end = $("#HotelLeaveRoomDate").val();
        var hotelstar = $("#HotelStarLevel").val();
        var price = $("#HotelPriceLevel").val();
        var keywords = $("#address").val() == "" ? "search" : $("#address").val();
        var page = 1;
        var order = 0;

        
        //var postUrl = "/hotelsearch_" + cityid + "_" + areaid + "_" + locationid + "_" + brandid + "_" + start + "_" + end + "_" + hotelstar + "_" + price + "_" + page + "_" + order + "_" + keywords + ".html";
        var postUrl = "/hotelsearchlist_" + cityid + ".html";
        //alert(postUrl);
        var formData = $("#HotelSearchForm").formSerialize();
        //alert(formData);
        $("#HotelSearchForm").attr("action", postUrl);
        $("#HotelSearchForm").submit();
    });

    

    $("#scenery_searchBtn").click(function () {
        var keyWords = $("#txtSceneryKeyWords").val();
        if ($.trim(keyWords) == "") {
            keyWords = "search";
            $("#int_search").css('border-color', 'red');
            $("#txtSceneryKeyWords").attr("placeholder", "请输入景区名称或者城市名称");
            return;
        }
        var page = 1;
        var themeid = 0;
        var star = 0;
        var provinceid = 0;
        var cityId = 0;
        var orderby = 0;

        //var postUrl = "/ticketsearch_" + provinceid + "_" + cityId + "_" + themeid + "_" + star + "_" + page + "_" + orderby + "_" + encodeURI(keyWords) + ".html";
        var postUrl = "/ticketsearchlist.html?keywords=" + keyWords;
       
        $("#scenerysearchform").attr("action", postUrl);
        $("#scenerysearchform").submit();
    });

    
    $("#HotelCityName").focusout(function () {
        
        $.ajax({
            url: '/Travel/AjaxHelper/CityAreaInfo',
            type: 'POST',
            data: { "cityid": $("#HotelCityID").val() },
            success: function (rep) {
                $("#tanchu_address").html(rep);
            },
            error: function (error) { }

        });
    });

   
    $.ajax({
        url: '/Travel/AjaxHelper/CityAreaInfo',
        type: 'POST',
        data: { "cityid": $("#HotelCityID").val() },
        success: function (rep) {
            $("#tanchu_address").html(rep);
        },
        error: function (error) { }

    });

  
});

function getHotelAreaInfo(select, value) {
    
    $("#address").val(value);
    $("#hidCityAreaID").val(select);
    $("#tanchu_address").hide();
    hotelsearchSubmit();
}

function getHotelBrandInfo(select, value) {
    $("#address").val(value);
    $("#hidHotelBrandID").val(select);
    $("#tanchu_address").hide();
    hotelsearchSubmit();
}

function getHoteCityLocation(select, value) {
    $("#address").val(value);
    $("#hidLocationID").val(select);
    $("#tanchu_address").hide();
    hotelsearchSubmit();

}

function hotelsearchSubmit() {
    var cityid = $("#HotelCityID").val();
    var postUrl = "/hotelsearchlist_" + cityid + ".html";
    var formData = $("#HotelSearchForm").formSerialize();
    $("#HotelSearchForm").attr("action", postUrl);
    $("#HotelSearchForm").submit();
}

//==========================================
//==========================================

var hotelsearchConfig = function (cityid,locationid) {

};

function getSceneryInfosByCity(cityId) {
    var page = 1;
    var themeid = 0;
    var star = 0;
    var provinceid = 0;
    

    var postUrl = "/ticketsearch_" + provinceid + "_" + cityId + "_" + themeid + "_" + star + "_" + page + "_" + encodeURI("search") + ".html";
    $("#scenerysearchform").attr("action", postUrl);
    $("#scenerysearchform").submit();
}

function getScneryInfosByTheme(themeid) {
    var page = 1;
    
    var star = 0;
    var provinceid = 0;
    var cityId = 0;

    var postUrl = "/ticketsearch_" + provinceid + "_" + cityId + "_" + themeid + "_" + star + "_" + page + "_" + encodeURI("search") + ".html";
    $("#scenerysearchform").attr("action", postUrl);
    $("#scenerysearchform").submit();
}

function getHotelCityInfos(cityId) {
    //alert(cityId);

}

function getHotelCityInfosByBrand(brandId) {
    alert(brandId);
}

function scenerymap(sceneryid) {

}

