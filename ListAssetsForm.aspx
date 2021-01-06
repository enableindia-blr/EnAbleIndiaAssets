<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="ListAssetsForm.aspx.cs" Inherits="EnAbleIndiaAssets.ListAssetsForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource1">
        
        <RowStyle BackColor="#EFF3FB" />
        <EditItemTemplate>
            AssetTagId:
            <asp:TextBox ID="AssetTagIdTextBox" runat="server" Text='<%# Bind("AssetTagId") %>' />
            <br />
            Location:
            <asp:TextBox ID="LocationTextBox" runat="server" Text='<%# Bind("Location") %>' />
            <br />
            AdditionalPeripherals:
            <asp:TextBox ID="AdditionalPeripheralsTextBox" runat="server" Text='<%# Bind("AdditionalPeripherals") %>' />
            <br />
            ModelNumber:
            <asp:TextBox ID="ModelNumberTextBox" runat="server" Text='<%# Bind("ModelNumber") %>' />
            <br />
            Brand:
            <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>' />
            <br />
            FundedBy:
            <asp:TextBox ID="FundedByTextBox" runat="server" Text='<%# Bind("FundedBy") %>' />
            <br />
            SerialNumber:
            <asp:TextBox ID="SerialNumberTextBox" runat="server" Text='<%# Bind("SerialNumber") %>' />
            <br />
            WarrantyStatus:
            <asp:TextBox ID="WarrantyStatusTextBox" runat="server" Text='<%# Bind("WarrantyStatus") %>' />
            <br />
            AssetValue:
            <asp:TextBox ID="AssetValueTextBox" runat="server" Text='<%# Bind("AssetValue") %>' />
            <br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
            <br />
            FundingSource:
            <asp:TextBox ID="FundingSourceTextBox" runat="server" Text='<%# Bind("FundingSource") %>' />
            <br />
            AmountDebited:
            <asp:TextBox ID="AmountDebitedTextBox" runat="server" Text='<%# Bind("AmountDebited") %>' />
            <br />
            Site:
            <asp:TextBox ID="SiteTextBox" runat="server" Text='<%# Bind("Site") %>' />
            <br />
            Department:
            <asp:TextBox ID="DepartmentTextBox" runat="server" Text='<%# Bind("Department") %>' />
            <br />
            Category:
            <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%# Bind("Category") %>' />
            <br />
            Locations:
            <asp:TextBox ID="LocationsTextBox" runat="server" Text='<%# Bind("Locations") %>' />
            <br />
            WindowsLicense:
            <asp:TextBox ID="WindowsLicenseTextBox" runat="server" Text='<%# Bind("WindowsLicense") %>' />
            <br />
            BatteryDetails:
            <asp:TextBox ID="BatteryDetailsTextBox" runat="server" Text='<%# Bind("BatteryDetails") %>' />
            <br />
            MacAddress:
            <asp:TextBox ID="MacAddressTextBox" runat="server" Text='<%# Bind("MacAddress") %>' />
            <br />
            SoftwareDetails:
            <asp:TextBox ID="SoftwareDetailsTextBox" runat="server" Text='<%# Bind("SoftwareDetails") %>' />
            <br />
            AdaptorSerialNumber:
            <asp:TextBox ID="AdaptorSerialNumberTextBox" runat="server" Text='<%# Bind("AdaptorSerialNumber") %>' />
            <br />
            OfficeLicense:
            <asp:TextBox ID="OfficeLicenseTextBox" runat="server" Text='<%# Bind("OfficeLicense") %>' />
            <br />
            MonitorSerialNumber:
            <asp:TextBox ID="MonitorSerialNumberTextBox" runat="server" Text='<%# Bind("MonitorSerialNumber") %>' />
            <br />
            MonitorModelNumber:
            <asp:TextBox ID="MonitorModelNumberTextBox" runat="server" Text='<%# Bind("MonitorModelNumber") %>' />
            <br />
            MonitorBrand:
            <asp:TextBox ID="MonitorBrandTextBox" runat="server" Text='<%# Bind("MonitorBrand") %>' />
            <br />
            AssetPhoto:
            <asp:TextBox ID="AssetPhotoTextBox" runat="server" Text='<%# Bind("AssetPhoto") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            AssetTagId:
            <asp:TextBox ID="AssetTagIdTextBox" runat="server" Text='<%# Bind("AssetTagId") %>' />
            <br />
            Location:
            <asp:TextBox ID="LocationTextBox" runat="server" Text='<%# Bind("Location") %>' />
            <br />
            AdditionalPeripherals:
            <asp:TextBox ID="AdditionalPeripheralsTextBox" runat="server" Text='<%# Bind("AdditionalPeripherals") %>' />
            <br />
            ModelNumber:
            <asp:TextBox ID="ModelNumberTextBox" runat="server" Text='<%# Bind("ModelNumber") %>' />
            <br />
            Brand:
            <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>' />
            <br />
            FundedBy:
            <asp:TextBox ID="FundedByTextBox" runat="server" Text='<%# Bind("FundedBy") %>' />
            <br />
            SerialNumber:
            <asp:TextBox ID="SerialNumberTextBox" runat="server" Text='<%# Bind("SerialNumber") %>' />
            <br />
            WarrantyStatus:
            <asp:TextBox ID="WarrantyStatusTextBox" runat="server" Text='<%# Bind("WarrantyStatus") %>' />
            <br />
            AssetValue:
            <asp:TextBox ID="AssetValueTextBox" runat="server" Text='<%# Bind("AssetValue") %>' />
            <br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
            <br />
            FundingSource:
            <asp:TextBox ID="FundingSourceTextBox" runat="server" Text='<%# Bind("FundingSource") %>' />
            <br />
            AmountDebited:
            <asp:TextBox ID="AmountDebitedTextBox" runat="server" Text='<%# Bind("AmountDebited") %>' />
            <br />
            Site:
            <asp:TextBox ID="SiteTextBox" runat="server" Text='<%# Bind("Site") %>' />
            <br />
            Department:
            <asp:TextBox ID="DepartmentTextBox" runat="server" Text='<%# Bind("Department") %>' />
            <br />
            Category:
            <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%# Bind("Category") %>' />
            <br />
            Locations:
            <asp:TextBox ID="LocationsTextBox" runat="server" Text='<%# Bind("Locations") %>' />
            <br />
            WindowsLicense:
            <asp:TextBox ID="WindowsLicenseTextBox" runat="server" Text='<%# Bind("WindowsLicense") %>' />
            <br />
            BatteryDetails:
            <asp:TextBox ID="BatteryDetailsTextBox" runat="server" Text='<%# Bind("BatteryDetails") %>' />
            <br />
            MacAddress:
            <asp:TextBox ID="MacAddressTextBox" runat="server" Text='<%# Bind("MacAddress") %>' />
            <br />
            SoftwareDetails:
            <asp:TextBox ID="SoftwareDetailsTextBox" runat="server" Text='<%# Bind("SoftwareDetails") %>' />
            <br />
            AdaptorSerialNumber:
            <asp:TextBox ID="AdaptorSerialNumberTextBox" runat="server" Text='<%# Bind("AdaptorSerialNumber") %>' />
            <br />
            OfficeLicense:
            <asp:TextBox ID="OfficeLicenseTextBox" runat="server" Text='<%# Bind("OfficeLicense") %>' />
            <br />
            MonitorSerialNumber:
            <asp:TextBox ID="MonitorSerialNumberTextBox" runat="server" Text='<%# Bind("MonitorSerialNumber") %>' />
            <br />
            MonitorModelNumber:
            <asp:TextBox ID="MonitorModelNumberTextBox" runat="server" Text='<%# Bind("MonitorModelNumber") %>' />
            <br />
            MonitorBrand:
            <asp:TextBox ID="MonitorBrandTextBox" runat="server" Text='<%# Bind("MonitorBrand") %>' />
            <br />
            AssetPhoto:
            <asp:TextBox ID="AssetPhotoTextBox" runat="server" Text='<%# Bind("AssetPhoto") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            AssetTagId:
            <asp:Label ID="AssetTagIdLabel" runat="server" Text='<%# Bind("AssetTagId") %>' />
            <br />
            Location:
            <asp:Label ID="LocationLabel" runat="server" Text='<%# Bind("Location") %>' />
            <br />
            AdditionalPeripherals:
            <asp:Label ID="AdditionalPeripheralsLabel" runat="server" Text='<%# Bind("AdditionalPeripherals") %>' />
            <br />
            ModelNumber:
            <asp:Label ID="ModelNumberLabel" runat="server" Text='<%# Bind("ModelNumber") %>' />
            <br />
            Brand:
            <asp:Label ID="BrandLabel" runat="server" Text='<%# Bind("Brand") %>' />
            <br />
            FundedBy:
            <asp:Label ID="FundedByLabel" runat="server" Text='<%# Bind("FundedBy") %>' />
            <br />
            SerialNumber:
            <asp:Label ID="SerialNumberLabel" runat="server" Text='<%# Bind("SerialNumber") %>' />
            <br />
            WarrantyStatus:
            <asp:Label ID="WarrantyStatusLabel" runat="server" Text='<%# Bind("WarrantyStatus") %>' />
            <br />
            AssetValue:
            <asp:Label ID="AssetValueLabel" runat="server" Text='<%# Bind("AssetValue") %>' />
            <br />
            Description:
            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>' />
            <br />
            FundingSource:
            <asp:Label ID="FundingSourceLabel" runat="server" Text='<%# Bind("FundingSource") %>' />
            <br />
            AmountDebited:
            <asp:Label ID="AmountDebitedLabel" runat="server" Text='<%# Bind("AmountDebited") %>' />
            <br />
            Site:
            <asp:Label ID="SiteLabel" runat="server" Text='<%# Bind("Site") %>' />
            <br />
            Department:
            <asp:Label ID="DepartmentLabel" runat="server" Text='<%# Bind("Department") %>' />
            <br />
            Category:
            <asp:Label ID="CategoryLabel" runat="server" Text='<%# Bind("Category") %>' />
            <br />

            Locations:
            <asp:Label ID="LocationsLabel" runat="server" Text='<%# Bind("Locations") %>' />
            <br />
            WindowsLicense:
            <asp:Label ID="WindowsLicenseLabel" runat="server" Text='<%# Bind("WindowsLicense") %>' />
            <br />
            BatteryDetails:
            <asp:Label ID="BatteryDetailsLabel" runat="server" Text='<%# Bind("BatteryDetails") %>' />
            <br />
            MacAddress:
            <asp:Label ID="MacAddressLabel" runat="server" Text='<%# Bind("MacAddress") %>' />
            <br />
            SoftwareDetails:
            <asp:Label ID="SoftwareDetailsLabel" runat="server" Text='<%# Bind("SoftwareDetails") %>' />
            <br />
            AdaptorSerialNumber:
            <asp:Label ID="AdaptorSerialNumberLabel" runat="server" Text='<%# Bind("AdaptorSerialNumber") %>' />
            <br />
            OfficeLicense:
            <asp:Label ID="OfficeLicenseLabel" runat="server" Text='<%# Bind("OfficeLicense") %>' />
            <br />
            MonitorSerialNumber:
            <asp:Label ID="MonitorSerialNumberLabel" runat="server" Text='<%# Bind("MonitorSerialNumber") %>' />
            <br />
            MonitorModelNumber:
            <asp:Label ID="MonitorModelNumberLabel" runat="server" Text='<%# Bind("MonitorModelNumber") %>' />
            <br />
            MonitorBrand:
            <asp:Label ID="MonitorBrandLabel" runat="server" Text='<%# Bind("MonitorBrand") %>' />
            <br />
            AssetPhoto:
            <asp:Label ID="AssetPhotoLabel" runat="server" Text='<%# Bind("AssetPhoto") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>" SelectCommand="SELECT [AssetTagId], [Location], [AdditionalPeripherals], [ModelNumber], [Brand], [FundedBy], [SerialNumber], [WarrantyStatus], [AssetValue], [Description], [FundingSource], [AmountDebited], [Site], [Department], [Category], [Locations], [WindowsLicense], [BatteryDetails], [MacAddress], [SoftwareDetails], [AdaptorSerialNumber], [OfficeLicense], [MonitorSerialNumber], [MonitorModelNumber], [MonitorBrand], [AssetPhoto] FROM [AddAssets]"></asp:SqlDataSource>
</asp:Content>
