<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qiniueditor.aspx.cs" Inherits="qiniudemo.qiniueditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/template" src="Scripts/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="ueditor/ueditor.all.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script id="container" name="content" type="text/plain">
        这里写你的初始化内容
    </script>
        <script type="text/javascript">
        var ue = UE.getEditor('container');
    </script>
    </div>
    </form>
</body>
</html>
