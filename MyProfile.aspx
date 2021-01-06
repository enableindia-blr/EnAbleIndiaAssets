<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="EnAbleIndiaAssets.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>My Profile</h1>
    <p>The My Profile page allows you to make changes to your personal profile.
        For now, all you can do is change your password below.</p>
    <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangedPassword="ChangePassword1_ChangedPassword" ChangePasswordFailureText=""></asp:ChangePassword>
</asp:Content>
