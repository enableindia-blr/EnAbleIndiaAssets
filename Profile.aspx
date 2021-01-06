<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EnAbleIndiaAssets.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow CssClass="mb-5 p-2">
            <asp:TableCell CssClass="text-right p-2 m-2" >
                <asp:Label runat="server" Text="UserName: " CssClass="p-0"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="m-2">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="p-0"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="m-5 p-2">
            <asp:TableCell CssClass="text-right p-2 m-2">
                <asp:Label runat="server" Text="E-Mail ID: " CssClass="p-0"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="m-2">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="p-0"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>       
    </asp:Table>
</asp:Content>
