/// <reference path="E:\bitbucket\travelling\src\Travelling.UI\Scripts/jquery-1.9.0.min.js" />
/// <reference path="E:\bitbucket\travelling\src\Travelling.UI\Scripts/jquery.lazyload.min.js" />

var hotelsearchsetting = {
    cityid: 0,
    areaid: 0,
    locationid: 0,
    brandid: 0,
    startdate: Date.now(),
    endate: Date.now(),
    hotelstar: '0-5',
    price: '1-9999',
    page: 1,
    order: 0,
    keywords:'search'
};

function hotelsearchConfig(cityid, areaid, locationid, brandid, startdate, enddate, hotelstar, price, page, order, keywords) {
    var searchUrl = "hotelsearch_" + cityid + "_" + areaid + "_" + locationid + "_" + brandid + "_" + startdate + "_" + enddate + "_" + hotelstar + "_" + price + "_" + page + "_" + order + "_" + keywords + ".html";
    return searchUrl;
};

//==============================
function getHotelAreaInfo(select, value) {
    $("#address").val(value);
    $("#hidCityAreaID").val(select);
    $("#tanchu_address").hide();
}

function getHotelBrandInfo(select, value) {
    $("#address").val(value);
    $("#hidHotelBrandID").val(select);
    $("#tanchu_address").hide();
}

function getHoteCityLocation(select, value) {
    $("#address").val(value);
    $("#hidLocationID").val(select);
    $("#tanchu_address").hide();
}
//=====================================

//===============================
$(function () {

    $("body").on("click", function (e) {
        $("#tanchu_address").hide();
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

    $("#hotelSearchBtn").click(function () {

        var cityid = $("#HotelCityID").val();
        var areaid = $("#hidCityAreaID").val();
        var locationid = $("#hidLocationID").val();
        var brandid = $("#hidHotelBrandID").val();
        var start = $("#HotelInRoomDate").val();
        var end = $("#HotelInRoomDate").val();
        var hotelstar = $("#HotelStarLevel").val();
        var price = $("#HotelPriceLevel").val();
        var keywords = $("#address").val() == "" ? "search" : $("#address").val();
        var page = 1;
        var order = 0;


        var postUrl = "/hotelsearch_" + cityid + "_" + areaid + "_" + locationid + "_" + brandid + "_" + start + "_" + end + "_" + hotelstar + "_" + price + "_" + page + "_" + order + "_" + keywords + ".html";

        $("#HotelSearchForm").attr("action", postUrl);
        $("#HotelSearchForm").submit();
    });

    //=============================
    $("#brandHot li a").each(function (e) {
        //e.stopPropagation();
        $(this).click(function () {
            var id = $(this).attr("data");
            $(".brandClass").hide();
            $("#brand_" + id).show();
            $("#brandHot li").removeClass("TabDefault");
            $(this).parent("li").addClass("TabDefault");
        });
    });
    //==================================
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
    //================================
    $("#address").click(function (e) {
        e.stopPropagation();
        $("#tanchu_address").show();
    });
    
    //================================
    $("#HotelQuickFindList li a").each(function () {
        $(this).click(function () {
            var dataCityID = $(this).attr("data");
            $("#hiddenHotelQuickCityID").val(dataCityID);
            $(this).parent("li").siblings().removeClass("TabDefault");
            $(this).parent("li").addClass("TabDefault ");
        });
    });
    //=================================
    $("#hotelfindtagslist a").each(function () {
        $(this).click(function () {

            var hotelCityID = $("#hiddenHotelQuickCityID").val();
            var areaType = $(this).attr("data-id");
            var dataindex = $(this).attr("data-index");
            var islocation = $(this).attr("datatype");

            $.post("/Home/CityAreaInfos", { cityid: hotelCityID, areaCode: areaType, dataindex: dataindex, islocation: islocation }, function (rep) {
                $("#areainfocontainer").html(rep);
            });
        });
    });
    //=================================
    $("ul#recommendhotelcities li a").each(function () {
        $(this).click(function () {
            $(".HotelHotelList").hide();
            $("#block_city" + $(this).attr("data")).show();
            $("#recommendhotelcities li").removeClass("TabDefault GetTabDefault");
            $(this).parent("li").addClass("TabDefault GetTabDefault");
        });
    });
    //=====================================
    $("#recommendhotelcitylist li a").each(function () {
        $(this).click(function () {
            $(".recommendhotels").hide();
            $("#RecommendCityHotelList" + $(this).attr("data")).show();
            $("#recommendhotelcitylist li").removeClass("CommChTagCur");
            $(this).parent("li").addClass("CommChTagCur");
        });
    });
    //============================================
});