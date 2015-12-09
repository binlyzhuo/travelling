$(document).ready(function () {
    //
    $("#txtSearch").click(function () {

        var left = $("#txtSearch").offset().left;
        var top = $("#txtSearch").offset().top + $("#txtSearch").height() + 6;


        $("#container").width($("#txtSearch").width() + 10);


        $("#container").css("top", "0");
        $("#container").css("left", "0");
        $("#container").offset({ top: top, left: left });
        $("#container").show();



    });

    $("#txtSearch").blur(function () {
        $("#container").hide();

        // $("#txtSearch").unbind();
    });
});