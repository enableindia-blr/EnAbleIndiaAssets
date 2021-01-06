<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EnAbleIndiaAssets.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart runat="server" ID="Chart1" Height="280px" Width="414px">
        <Series>
            <asp:Series Name="Series1" ChartType="Column"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Asset Tag ID"></AxisX>
                <AxisY Title="Asset Value"></AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>" SelectCommand="SELECT * FROM [AddAssets]"></asp:SqlDataSource>
</asp:Content>
