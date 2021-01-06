<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sites.aspx.cs" Inherits="EnAbleIndiaAssets.Sites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Site</title>
    <link href="CSS/asset.css" rel="stylesheet" runat="server" />
    <link href="CSS/bootstrap.css" rel="stylesheet" runat="server"/>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" class="form-group" style="background-color:aliceblue;width:450px;height:250px;text-align:center;margin-top:10%;margin-left:30%; border-radius:5px;">
            <div runat="server" class="pt-5 mt-3">
                <asp:Label CssClass="input-group-sm mx-2" ID="Label1" runat="server" Text="Site Name: "></asp:Label>
                <asp:TextBox CssClass="input-group-sm mx-2 p-1" ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div runat="server" class="p-4 m-4">
                <asp:Button CssClass="btn btn-primary w-25 mr-4" ID="Ok" runat="server" Text="Ok" OnClick="Ok_Click" />
                <asp:Button CssClass="btn btn-primary w-25 ml-4" ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
            </div>            
        </div>
    </form>
</body>
</html>
