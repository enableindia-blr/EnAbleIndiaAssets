<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="Assets.aspx.cs" Inherits="EnAbleIndiaAssets.Assets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="AddAssetsFrm" runat="server" CssClass="form-group align-items-center">
    <h4 class="p-3">Asset Details</h4>
        <table class="table nav-justified">
            <tr>
                <td style="height: 22px">
    <asp:Label ID="Description" runat="server" Text="Description" CssClass="pull-right" style="position: relative"></asp:Label>
    
                </td>
                <td colspan="3" style="height: 22px">
    
    <asp:TextBox ID="TextBox1" runat="server" Width="409px" CssClass="form-control input-sm"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator3"
        ControlToValidate="TextBox1"
        ErrorMessage="Required"
        runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="AssetTagId" runat="server" Text="Asset Tag Id:" CssClass="pull-right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
    <asp:RequiredFieldValidator id="RequiredFieldValidator2"
        ControlToValidate="TextBox2"
        ErrorMessage="Required"
        runat="server"/>
                </td>
                <td>
    <asp:Label ID="WarrantyStatus" runat="server" Text="Warranty Status:" CssClass="pull-right" style="position: relative"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="Location" runat="server" Text="Location:" CssClass="has-feedback" style="float: right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
    <asp:RequiredFieldValidator id="RequiredFieldValidator4"
        ControlToValidate="TextBox3"
        ErrorMessage="Required"
        runat="server"/>
                </td>
                <td>
    <asp:Label ID="AssetValue" runat="server" Text="Asset Value:" CssClass="pull-right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
    <asp:Label ID="AdditionalPeripherals" runat="server" Text="Additional Peripherals:" CssClass="pull-right"></asp:Label>
    
                </td>
                <td style="height: 22px">
    
    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
                <td style="height: 22px">
    <asp:Label ID="WindowsLicense" runat="server" Text="Windows License:" CssClass="pull-right"></asp:Label>
                </td>
                <td style="height: 22px">
    <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="ModelNumber" runat="server" Text="Model Number:" CssClass="pull-right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
                <td>
    <asp:Label ID="BatteryDetails" runat="server" Text="Battery Details:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
    <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="Brand" runat="server" Text="Brand:" CssClass="pull-right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
                <td>
    <asp:Label ID="MacAddress" runat="server" Text="Mac Address:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
    <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="FundedBy" runat="server" Text="Funded By:" required="true" CssClass="pull-right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1"
        ControlToValidate="TextBox7"
        ErrorMessage="Required"
        runat="server"/>
                </td>
                <td>
    <asp:Label ID="SoftwareDetails" runat="server" Text="Software Details:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
    <asp:TextBox ID="TextBox16" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="SerialNumber" runat="server" Text="Serial Number:" CssClass="pull-right"></asp:Label>
    
                </td>
                <td>
    
    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
                <td>
    <asp:Label ID="AdaptorSerialNumber" runat="server" Text="Adaptor Serial Number:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
    <asp:TextBox ID="TextBox17" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MonitorBrand" runat="server" CssClass="pull-right" Text="Monitor Brand:"></asp:Label>
    
                </td>
                <td>
    
                    <asp:TextBox ID="TextBox18" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="OfficeLicense" runat="server" CssClass="pull-right" Text="Office License:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox20" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MonitorModelNumber" runat="server" CssClass="pull-right" Text="Monitor Model Number:"></asp:Label>
    
                </td>
                <td>
    
                    <asp:TextBox ID="TextBox19" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="MonitorSerailNumber" runat="server" CssClass="pull-right" Text="Monitor Serial Number:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox21" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
        </table>
        
    <div>
    <h4 class="p-3">Funding Source</h4>
        <table class="table nav-justified">
            <tr>
                <td class="modal-sm" style="width: 121px">
        <asp:Label ID="FundingSource" runat="server" Text="Funding Source: "></asp:Label>
                </td>
                <td style="width: 151px">
        <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                </td>
                <td>

        <asp:Label ID="AmountDebited" runat="server" Text="Amount Debited:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>
        </table>
    
    </div>
    <hr />
    <h4 class="p-3">Site Location, Category and Department</h4>
    <div>

        <table class="table nav-justified">
            <tr>
                <td>

        <asp:Label ID="Site" runat="server" Text="Site:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="Siteddl" runat="server" Width="190px" CssClass="form-control input-sm">
            
        </asp:DropDownList>
        <asp:Button ID="Sitebtn" Type="Button" runat="server" Text="+ New" OnClick="Sitebtn_Click" />
                </td>
                <td>
        <asp:Label ID="Locationlbl" runat="server" Text="Location:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="Locationddl" runat="server" Width="190px" CssClass="form-control input-sm">
            
        </asp:DropDownList>
        <asp:Button ID="Locationbtn" runat="server" Text="+ New" OnClick="Locationbtn_Click" />
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Categorylbl" runat="server" Text="Category:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="Categoryddl" runat="server" Width="190px" AutoPostBack = "true" CssClass="form-control input-sm" OnSelectedIndexChanged="OnSelectedIndexChanged">
            
        </asp:DropDownList>
        <asp:Button ID="Categorybtn" runat="server" Text="+ New" Width="56px" OnClick="Categorybtn_Click" />
                </td>
                <td>
        <asp:Label ID="Departmentlbl" runat="server" Text="Department:" CssClass="pull-right"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="Departmentddl" runat="server" Width="190px" CssClass="form-control input-sm">
            
        </asp:DropDownList>
        <asp:Button ID="Departmentbtn" runat="server" Text="+ New" OnClick="Departmentbtn_Click" />

                </td>
            </tr>
        </table>
        <br />
        <br />

    </div>
    <hr />
    <h4 class="p-3">Asset Photo</h4>
    <div>
        <asp:FileUpload ID="AssetPhoto" runat="server" CssClass="form-control input-sm p-5" />
    </div>
    <hr />
    <div>

        <table class="table nav-justified">
            <tr>
                <td>

        <asp:Button ID="Submitbtn" runat="server" Text="Submit" OnClick="Submitbtn_Click" style="position: relative" CssClass="pull-right" />
                </td>
                <td>
        <asp:Button ID="Cancelbtn" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        
</div>
</asp:Content>
