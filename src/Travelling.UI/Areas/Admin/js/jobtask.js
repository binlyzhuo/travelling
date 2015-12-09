/// <reference path="../assets/js/jquery-1.10.2.min.js" />


function jobtasksearch(page) {
    //alert(page);
    var senddata = { pageindex: page, jobName: $("#jobName").val(),jobState:$("#jobState").val() };
    $.ajax({
        url: '/JobTask/JobTaskSearchResult',
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

function jobtaskedit(jobid) {
    var postUrl = "";
    var postData = {};
    if (jobid == 0)
    {
        postUrl = "/JobTask/JobTaskAdd";
    }
    else
    {
        postUrl = "/JobTask/JobTaskEdit";
        postData = { jobid: jobid };
    }
    $.get(postUrl, postData, function (rep) {
        bootbox.dialog({
            title: '添加任务',
            message: rep,
            buttons: {
                success: {
                    label: "保存",
                    className: "btn-success",
                    callback: function () {
                        
                        var jobName = $("#jobTaskName").val();
                        var jobMethodName = $("#jobMethodName").val();
                        var projectID = $("#ProjectId").val();
                        var cronExpr = $("#cronExpr").val();
                        var jobState = $("#jobStateCheckBox").is(":checked") ? 1 : 0;
                        
                        var groupName = $("#groupName").val();
                        var remark = $("#remark").val();
                        var jobID = $("#ID").val();
                        var data = {
                            ID:jobID,
                            JobName: jobName,
                            JobMethodName: jobMethodName,
                            CronExpr: cronExpr,
                            State: jobState,
                            GroupName: groupName,
                            ProjectId: projectID,
                            Remark: remark
                        };

                        $.post(postUrl, data, function (rep) {
                            
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

function deletejobtask(id) {

    bootbox.confirm("确定要删除吗?", function (result) {
        if (result) {
            //
            $.post('/JobTask/JobTaskDelete', { id: id }, function () {
                alert('success');
            });
        }
    });
    return false;
    
}

function hotelroompricejobedit(jobid) {
    var postUrl = "";
    var postData = {};
    if (jobid == 0) {
        postUrl = "/JobTask/HotelPriceScheduleAdd";
    }
    else {
        postUrl = "/JobTask/HotelPriceScheduleEdit";
        postData = { jobid: jobid };
    }

    $.get(postUrl, postData, function (rep) {
        
        bootbox.dialog({
            title: '添加酒店价格同步任务',
            message: rep,
            buttons: {
                success: {
                    label: "保存",
                    className: "btn-success",
                    callback: function () {
                        var id = $("#ID").val();
                        var startDate = $("#startDate").val();
                        var endDate = $("#endDate").val();
                        var jobState = $("#jobStateCheckBox").is(":checked") ? 1 : 0;
                        
                        var data = {
                            StartDate: startDate,
                            EndDate: endDate,
                            State: jobState,
                            ID:id
                        };
                        $.post(postUrl, data, function (rep) {

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

function hotelroompricejobsearch(page) {
    var data = { pageindex: page };
    $.ajax({
        url: '/JobTask/HotelPriceScheduleSearchResult',
        data: data,
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

function hotelroompricejobdelete(id) {
    bootbox.confirm("确定要删除吗?", function (result) {
        if (result) {
            //
            $.post('/JobTask/HotelRoomPriceJobDelete', { jobId: id }, function () {
                alert('success');
            });
        }
    });
    return false;
}