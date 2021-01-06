<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPwd.aspx.cs" Inherits="EnAbleIndiaAssets.ForgotPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email Address:
            <asp:TextBox ID="txtEmail" runat="server" Width="250" />
            <br />
            <asp:Label ID="lblMessage" runat="server" />
            <br />
            <asp:Button Text="Send" runat="server" OnClick="SendEmail" />
        </div>
    </form>
</body>
</html>
