<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="ListAssets.aspx.cs" Inherits="EnAbleIndiaAssets.ListAssets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="AddAssetsId" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="OnRowDataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="table list_asset" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:BoundField DataField="AssetTagId" HeaderText="Asset Tag Id" SortExpression="AssetTagId" />
            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
            <asp:BoundField DataField="AdditionalPeripherals" HeaderText="Additional Peripherals" SortExpression="AdditionalPeripherals" />
            <asp:BoundField DataField="ModelNumber" HeaderText="Model Number" SortExpression="ModelNumber" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
            <asp:BoundField DataField="FundedBy" HeaderText="Funded By" SortExpression="FundedBy" />
            <asp:BoundField DataField="SerialNumber" HeaderText="Serial Number" SortExpression="SerialNumber" />
            <asp:BoundField DataField="WarrantyStatus" HeaderText="Warranty Status" SortExpression="WarrantyStatus" />
            <asp:BoundField DataField="AssetValue" HeaderText="Asset Value" SortExpression="AssetValue" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="FundingSource" HeaderText="Funding Source" SortExpression="FundingSource" />
            <asp:BoundField DataField="AmountDebited" HeaderText="Amount Debited" SortExpression="AmountDebited" />
            <asp:BoundField DataField="Site" HeaderText="Site" SortExpression="Site" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
            <asp:BoundField DataField="Locations" HeaderText="Locations" SortExpression="Locations" />
            <asp:BoundField DataField="WindowsLicense" HeaderText="Windows License" SortExpression="WindowsLicense" />
            <asp:BoundField DataField="BatteryDetails" HeaderText="Battery Details" SortExpression="BatteryDetails" />
            <asp:BoundField DataField="MacAddress" HeaderText="Mac Address" SortExpression="MacAddress" />
            <asp:BoundField DataField="SoftwareDetails" HeaderText="Software Details" SortExpression="SoftwareDetails" />
            <asp:BoundField DataField="AdaptorSerialNumber" HeaderText="Adaptor Serial Number" SortExpression="AdaptorSerialNumber" />
            <asp:BoundField DataField="MonitorBrand" HeaderText="Monitor Brand" SortExpression="MonitorBrand" />
            <asp:BoundField DataField="MonitorModelNumber" HeaderText="Monitor Model Number" SortExpression="MonitorModelNumber" />
            <asp:BoundField DataField="MonitorSerialNumber" HeaderText="Monitor Serial Number" SortExpression="MonitorSerialNumber" />
            <asp:BoundField DataField="OfficeLicense" HeaderText="Office License" SortExpression="OfficeLicense" />
            
            <asp:TemplateField HeaderText="Asset Photo">
                <ItemTemplate>
                    <asp:Image ID="AssetsPhoto" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />  
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>" SelectCommand="SELECT [AssetTagId], [Location], [AdditionalPeripherals], [ModelNumber], [Brand], [FundedBy], [SerailNumber], [WarrantyStatus], [AssetValue], [Description], [FundingSource], [AmountDebited], [Site], [Category], [Department], [Locations], [WindowsLicense], [BatteryDetails], [MacAddress], [SoftwareDetails], [AdaptorSerialNumber], [AssetPhoto] FROM [AddAssets]"></asp:SqlDataSource>

</asp:Content>
