<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="ExcelToSQL.aspx.cs" Inherits="EnAbleIndiaAssets.ExcelToSQL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="text-dark" />
    <asp:Button ID="btnUpload" runat="server" Text="Button"  OnClick="btnUpload_Click"/>
    <asp:DropDownList DataSourceID="SqlDataSource1" DataTextField="TABLE_NAME" RepeatColumns="3" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='PlanetWrox'" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>">
    </asp:SqlDataSource>
    <asp:Label ID="lblMessage" runat="server" />
    <asp:GridView ID="GridView1" HeaderStyle-CssClass="bg-primary text-white" ShowHeaderWhenEmpty="true" runat="server" CssClass="table table-bordered``">  
        <EmptyDataTemplate>  
            <div class="text-center">No record found</div>  
        </EmptyDataTemplate>  
        <Columns>           
                        
        </Columns>  
    </asp:GridView>
</asp:Content>
