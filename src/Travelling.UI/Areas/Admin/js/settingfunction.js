/// <reference path="E:\bitbucket\travelling\src\Travelling.UI\Scripts/jquery-1.9.0.min.js" />

function friendlinkedit(fid) {
    var postUrl = "/Setting/FriendLinkEdit";
    fid = Number(fid);
    var postData = { fid: fid };
    var title = fid > 0 ? "编辑友情链接" : "添加友情链接";
    $.get(postUrl, postData, function (rep) {
        bootbox.dialog({
            title: title,
            message: rep,
            buttons: {
                success: {
                    label: "保存",
                    className: "btn-success",
                    callback: function () {
                        var siteName = $("#siteName").val();
                        var siteLink = $("#siteLink").val();
                        var siteLinkMan = $("#siteLinkMan").val();
                        var siteOrderNo = $("#siteOrderNo").val();
                        var siteIsValid = $("#siteIsValid").is(":checked") ? 1 : 0;
                        var ID = $("#ID").val();

                        var sendData = {
                            Name: siteName,
                            LinkUrl: siteLink,
                            State: siteIsValid,
                            LinkMan: siteLinkMan,
                            OrderIndex: siteOrderNo,
                            ID: ID
                        };

                        $.post(postUrl, sendData, function (xhr) {
                            alert('ok!');
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


function friendlinksearch(page) {
    var senddata = { pageindex: page };
    $.ajax({
        url: '/Setting/FriendLinkSearchResult',
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

function friendlinkdelete(fid) {
    bootbox.confirm("确定要删除吗?", function (result) {
        if (result) {
            //
            $.post('/Setting/FriendLinkDelete', { fid: fid }, function () {
                alert('success');
            });
        }
    });
    return false;
}

function cachesetting(key) {
    alert(key);
    $.post('/Setting/CacheReset', { key: key }, function (rep) {
        alert('ok!!!');
    });
}

function articlesearch(page) {
    var senddata = { pageindex: page };
    $.ajax({
        url: '/Article/ArticleList',
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

function deletearticle(articleid) {
    window.location.href = "ArticleDelete?articleid=" + articleid;
}

function editarticle(articleid) {
    window.location.href = "ArticleEdit?articleid="+articleid;
}