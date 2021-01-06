<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnAbleIndiaAssets.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" style="background-color:aliceblue;width:450px;height:250px;text-align:center;margin-top:10%;margin-left:30%; border-radius:5px;padding-top:20px;">
        <asp:Login ID="Login1" runat="server"  DestinationPageUrl="~/Dashboard.aspx"  Height="159px" Width="400px" CssClass="form-group p-3" TitleText="" OnLoggedIn="OnLoggedIn" style="padding-top:50px; mt-3" CheckBoxStyle-CssClass="input-group p-3" CheckBoxStyle-HorizontalAlign="Center" CheckBoxStyle-VerticalAlign="Bottom" RememberMeText="   Remember me next time." PasswordRecoveryText="Forgot Password">
        <CheckBoxStyle CssClass="mr-5" HorizontalAlign="Center" VerticalAlign="Bottom" />
        <InstructionTextStyle CssClass="pt-2 mt-5" />
        <LabelStyle BorderColor="Red" CssClass="pt-3 mt-3 text-right" />
        <TextBoxStyle CssClass="p-2 m-3" />
        <TitleTextStyle CssClass="p-2 m-3" />
        </asp:Login>
        <!--<asp:LoginStatus ID="LoginStatus1" runat="server" />-->
    </div>
   
</asp:Content>
