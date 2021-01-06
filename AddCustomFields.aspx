<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomFields.aspx.cs" Inherits="EnAbleIndiaAssets.AddCustomFields" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Add Custom Fields</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Custom Field Name: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Data Type: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="decimal(18,2)">Currency</asp:ListItem>
                <asp:ListItem Value="date">Date</asp:ListItem>
                <asp:ListItem Value="datetime">Date and Time</asp:ListItem>
                <asp:ListItem Value="nvarchar(max)">Email</asp:ListItem>
                <asp:ListItem Value="varchar(255)">GPS Coordinates</asp:ListItem>
                <asp:ListItem Value="varchar(max)">Memo</asp:ListItem>
                <asp:ListItem Value="int">Numeric</asp:ListItem>
                <asp:ListItem Value="bigint">Numeric Auto Increment</asp:ListItem>
                <asp:ListItem Value="varchar(max)">Text</asp:ListItem>
                <asp:ListItem Value="nvarchar(max)">URL</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Data Required"></asp:Label>
            <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="DataReq" Text="Yes"/>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="DataReq" Text="Optional"/>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Selected Categories"></asp:Label>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Categories" text="All Categories" Checked="True" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged"/>
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Categories" text="Listed Categories" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged"/>
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="False">
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </div>
    </form>
</body>
</html>
