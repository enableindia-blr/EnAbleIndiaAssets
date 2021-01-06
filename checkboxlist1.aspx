<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkboxlist1.aspx.cs" Inherits="EnAbleIndiaAssets.checkboxlist1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="AssetTagId" DataValueField="AssetTagId" Height="74px" Width="132px"></asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>" SelectCommand="SELECT [AssetTagId], [Location], [AdditionalPeripherals], [ModelNumber], [Brand], [FundedBy], [SerialNumber], [WarrantyStatus], [AssetValue], [Description], [FundingSource], [AmountDebited], [Site], [Category], [Department], [Locations], [WindowsLicense], [BatteryDetails], [MacAddress], [SoftwareDetails], [AdaptorSerialNumber], [AssetPhoto], [MonitorBrand], [MonitorModelNumber], [MonitorSerialNumber], [OfficeLicense] FROM [AddAssets]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
