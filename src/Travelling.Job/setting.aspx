<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="Travelling.Job.setting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="styles/jobtask.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="float:right;">
            <a href="/default.aspx">首页</a>
            <a href="/setting.aspx">管理</a>
        </div>
    <div>
        <asp:Label runat="server" ID="lblPwd" Text="密码"></asp:Label>
        <asp:TextBox ID="txtAdminPwd" runat="server" TextMode="Password"></asp:TextBox>
        
        <asp:Button ID="btnReset" runat="server" Text="重启任务" BorderColor="#003366" BorderStyle="Solid" OnClick="btnReset_Click" Width="103px" />
        <br />
        <asp:Label runat="server" ID="lblMsg"></asp:Label>
    </div>
    </form>
</body>
</html>
