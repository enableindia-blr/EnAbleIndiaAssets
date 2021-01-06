<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fields.aspx.cs" Inherits="EnAbleIndiaAssets.Fields" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" target="_self">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Field Name"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" Text="All Category" GroupName="Categorys" Checked="true" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
            <asp:RadioButton ID="RadioButton2" runat="server" Text ="Listed Category" GroupName="Categorys" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="true"></asp:CheckBoxList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </div>
    </form>
</body>
</html>
