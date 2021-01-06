<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="AssignUserRoles.aspx.cs" Inherits="EnAbleIndiaAssets.Admin.AssignUserRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Cancel" />
</asp:Content>
