/// <reference path="../assets/js/jquery-1.10.2.min.js" />
/// <reference path="../assets/js/jquery-2.0.3.min.js" />



function hotelcityinfosearch(page) {
   
    var provinceid = $("#hotelprovince").val();
    var cityname = $("#hotelcityname").val();
    var isrecommend = $("#isrecommendcity").val();
    var ishotcity = $("#ishotcity").val();
    var issearchrecommend = $("#issearchrecommend").val();
    
    var senddata = {
        provinceid: provinceid,
        cityname: cityname,
        isrecommend: isrecommend,
        ishotcity: ishotcity,
        issearchrecommend: issearchrecommend,
        pageindex:page
    };

    $.ajax({
        url: '/HotelManage/CityInfoSearchResult',
        data: senddata,
        type: 'post',
        cache: false,
        dataType: 'html',
        success: function (rep) {
            
            $("#queryresult").html(rep);
            bindingcityeditaction();

            // binding
            $('#sample-table-1 th input:checkbox').on('click', function () {
                var that = this;
                $(this).closest('table').find('tr > td:first-child input:checkbox')
                .each(function () {
                    this.checked = that.checked;
                    $(this).closest('tr').toggleClass('selected');
                });

            });
            //
        },
        error: function (error) {
            alert('error!');
        }

    });
    
}


function hotelcityinfostateaction(type,action) {
    var ids = "";
    $("#sample-table-1 tr td input[type='checkbox']").each(function () {
        if ($(this).is(":checked")) {
            ids += $(this).val()+",";
        }

    });

    if (ids == "") {
        bootbox.dialog({
            message: "<span class='bigger-110'>请选择相关城市信息</span>",
            buttons:
            {
                
                "danger":
                {
                    "label": "Danger!",
                    "className": "btn-sm btn-danger",
                    "callback": function () {
                        //Example.show("uh oh, look out!");
                    }
                }
            }
        });
        return;
    }

    var senddata = {
        url: '/HotelManage/SetCityInfoStateAction',
        data: { "cityids": ids, "type": 1,"action":action },
        success: function (rep) {


            
            $("#successMessage").show();
            setTimeout("$('#successMessage').hide();",2000);
        },
        error: function () { }
    };

    ajaxcall(senddata);
}

function ajaxcall(senddata)
{
    $.ajax({
        url: senddata.url,
        data: senddata.data,
        type: 'post',
        cache: false,
        dataType: 'html',
        success: senddata.success,
        error: senddata.error
    });
}

function editcityinfo(cityid) {
    alert(cityid);
}

function bindingcityeditaction() {
    $("#sample-table-1 tr td button.editbtn").each(function () {
        $(this).click(function () {
            var cityid = $(this).parent("div").children("input[type='hidden']").val();
           
            $.get('/HotelManage/GetCityInfo', { "cityid": cityid }, function (rep) {
                
                bootbox.dialog({
                    title: '酒店城市编辑',
                    message: rep,
                    buttons: {
                        success: {
                            label: "保存",
                            className: "btn-success",
                            callback: function () {
                                var cityid = $("#CityID").val();
                                
                                var isrecommend = $("#IsRecommendCity").is(":checked")?1:0;
                                var recommendIndex = $("#RecommentIndex").val();
                                var isHotCity = $("#IsHotCity").is(":checked") ? 1 : 0;
                                var hotIndex = $("#HotCityIndex").val();
                                var isChoice = $("#IsChoiceCity").is(":checked") ? 1 : 0;
                                var ChoiceCityIndex = $("#ChoiceCityIndex").val();
                                var issearch = $("#IsSearch").is(":checked") ? 1 : 0;
                                var data = { "CityID": cityid, "IsRecommendCity": isrecommend, "RecommentIndex": recommendIndex, "IsHotCity": isHotCity, "HotCityIndex": hotIndex, "IsChoiceCity": isChoice, "ChoiceCityIndex": ChoiceCityIndex, "IsSearch": issearch,"Rand":Math.random() };
                                $.ajax({
                                    url: '/HotelManage/CityInfoEdit',
                                    data: data,
                                    type: 'post',
                                    dataType: 'json',
                                    success: function () {
                                        $("#successMessage").show();
                                        setTimeout("$('#successMessage').hide();", 2000);
                                    },
                                    error: function () { }
                                });
                               
                            }
                        },
                        cance: {
                            label:'取消'
                        }
                     }
                    });
            });
            
        });
    });
}



function HotelBrandInfoSearch(page) {
    var brandType = $("#HotelBrandType").val();
    var brandName = $("#hotelbrandname").val();
    var ishot = $("#ishotbrand").val();
    var issearchrecommend = $("#issearchrecommend").val();

    var senddata = {
        brandtype: brandType,
        brandName: brandName,
        isHot: ishot,
        isSearchRecommend: issearchrecommend,
        pageindex: page
    };

    $.ajax({
        url: '/HotelManage/BrandInfoSearchResult',
        data: senddata,
        type: 'post',
        cache: false,
        dataType: 'html',
        success: function (rep) {

            $("#queryresult").html(rep);
            bindinghotelbrandinfoedit();
        },
        error: function (error) {
            alert('error!');
        }

    });
}


function bindinghotelbrandinfoedit() {
    //hotelbrandinfotable
    $("#hotelbrandinfotable tr td button.editbtn").each(function () {
        $(this).click(function () {
            var hiddenBrandID = $(this).parent("div").children("input[type='hidden']").val();

            $.get('/HotelManage/GetHotelBrandInfo', { "brandId": hiddenBrandID }, function (rep) {

                bootbox.dialog({
                    title: '酒店品牌编辑',
                    message: rep,
                    
                    buttons: {
                        success: {
                            label: "保存",
                            className: "btn-success",
                            callback: function () {
                                
                                var brandId = $("#BrandID").val();
                                var brandType = $("#HotelBrandTypeList").val();
                                var brandImg = $("#HiddenHotelBrandImg").val();
                                var brandTel = $("#brandTel").val();
                                var brandDesc = $("#brandDesc").val();
                                var isHotRecommend = $("#isHotRecommend").is(":checked") ? 1 : 0;
                                var isSearchRecommend = $("#isSearchRecommend").is(":checked") ? 1 : 0;
                                var orderIndex = $("#orderIndex").val();
                               
                                var data = {
                                    "BrandID": brandId,
                                    "Description": brandDesc,
                                    "BrandImg": brandImg,
                                    "BrandTel": brandTel,
                                    "BrandType": brandType,
                                    "IsSearchRecommend": isSearchRecommend,
                                    "IsHotBrand": isHotRecommend,
                                    "OrderIndex": orderIndex
                                };

                                $.ajax({
                                    url: '/HotelManage/BrandInfoEdit',
                                    data: data,
                                    type: 'post',
                                    dataType: 'json',
                                    success: function () {
                                        $("#successMessage").show();
                                        setTimeout("$('#successMessage').hide();", 2000);
                                    },
                                    error: function () { }
                                });

                            }
                        },
                        cance: {
                            label: '取消'
                        }
                    }
                });
            });

        });
    });
}

function uploadbrandimg() {
    $.ajaxFileUpload
		(
			{
			    url: '/HotelManage/UploadBrandImg',
			    secureuri: false,
			    fileElementId: 'brandImg',
			    dataType: 'json',
			    data: { brandid: 1 },
			    success: function (data) {
			        //alert(data);
			        //var brand = JSON.parse(data);
			        //alert(brand.TempFile);
			        ////eval("brand='" + data+"'");
			        $("#hotelBrandImg").attr("src", data.TempFile);
			        $("#HiddenHotelBrandImg").val(data.FileName);
			    },
			    error: function (data) {
			        var brand = JSON.parse(data);
			        alert(brand.TempFile);
			    }
			}
		)
}

function hotelordersearch(page) {
    var inRoomDate = $("#inRoomDate").val();
    var offRoomDate = $("#offRoomDate").val();
    var ContractPerson = $("#ContractPerson").val();
    var ContractTel = $("#ContractTel").val();
    var HotelOrderFlag = $("#HotelOrderFlag").val();
    
    var senddata = { pageindex: page, InRoomDate: inRoomDate, OffRoomDate: offRoomDate, ContractPerson: ContractPerson, ContractTel: ContractTel, HotelOrderFlag: HotelOrderFlag };
    $.ajax({
        url: '/HotelManage/OrderInfoSearchResult',
        data: senddata,
        type: 'post',
        cache: false,
        dataType: 'html',
        success: function (rep) {

            $("#queryresult").html(rep);
            
        },
        error: function (error) {
            alert('error!');
        }

    });
}


function hotelordercancel(serial) {
    bootbox.confirm("确定要取消吗?", function (result) {
        if (result) {
            //
            $.post('/HotelManage/HotelOrderCancel', { orderno: serial }, function () {
                alert('success');
            });
        }
    });
    return false;
}