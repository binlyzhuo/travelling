<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="qiniudemo.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传" Width="105px" />
        <br />
        <br />
        <asp:Button ID="btnGetFile" runat="server" OnClick="btnGetFile_Click" Text="获取文件" Width="104px" />
    
    </div>
    </form>
</body>
</html>
