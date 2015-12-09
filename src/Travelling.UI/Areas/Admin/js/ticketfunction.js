/// <reference path="../assets/js/jquery-2.0.3.min.js" />


function ticketprovinceinfosearch(page) {
    //alert(page);
    var areaType = $("#areaType").val();
    var provinceId = $("#ddlProvinces").val();
    var senddata = { pageindex: page, areaType: areaType, provinceId: provinceId };
    $.ajax({
        url: '/TicketManage/ProvinceInfoSearchResult',
        data: senddata,
        type: 'post',
        cache: false,
        dataType: 'html',
        success: function (rep) {

            $("#queryresult").html(rep);
            //bindingcityeditaction();
        },
        error: function (error) {
            alert('error!');
        }

    });

}


function provinceinfoedit(pid) {
    var postUrl = "/TicketManage/ProvinceInfoEdit";
    var postData = { pid: pid };
   
    $.get(postUrl, postData, function (rep) {
        bootbox.dialog({
            title: '添加任务',
            message: rep,
            buttons: {
                success: {
                    label: "保存",
                    className: "btn-success",
                    callback: function () {
                        var id = $("#ID").val();
                        var isRecommend = $("#IsRecommend").is(":checked")?1:0;
                        var orderNum = $("#OrderNum").val();

                        var senddata = { ID: id, IsRecommend: isRecommend, OrderNum: orderNum };
                        $.post(postUrl, senddata, function (rep) {
                            alert('send success!!!');
                        });
                    }
                },
                cance: {
                    label: '取消'
                }
            }
        });
    });

}

function sceneryordersearch(page) {
    var inRoomDate = $("#inRoomDate").val();
    var offRoomDate = $("#offRoomDate").val();
    var ContractPerson = $("#ContractPerson").val();
    var ContractTel = $("#ContractTel").val();
    var HotelOrderFlag = $("#HotelOrderFlag").val();

    var senddata = { pageindex: page, InRoomDate: inRoomDate, OffRoomDate: offRoomDate, ContractPerson: ContractPerson, ContractTel: ContractTel, HotelOrderFlag: HotelOrderFlag };
    $.ajax({
        url: '/TicketManage/OrderSearchResult',
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