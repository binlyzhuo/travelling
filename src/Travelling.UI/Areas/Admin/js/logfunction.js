/// <reference path="E:\bitbucket\travelling\src\Travelling.UI\Scripts/jquery-1.9.0.min.js" />


function operationLogSearch(page) {
    var senddata = { pageindex: page};
    $.ajax({
        url: '/LogManage/OperactingLogSearchResult',
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