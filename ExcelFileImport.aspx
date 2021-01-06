<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="ExcelFileImport.aspx.cs" Inherits="EnAbleIndiaAssets.ExcelFileImport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />

<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
<br />
<asp:Label ID="Label1" runat="server" Text="Has Header ?" />
<asp:RadioButtonList ID="rbHDR" runat="server">

    <asp:ListItem Text = "Yes" Value = "Yes" Selected = "True" >
    </asp:ListItem>
    <asp:ListItem Text = "No" Value = "No"></asp:ListItem>

</asp:RadioButtonList>
<asp:GridView ID="GridView1"  CssClass="table text-light" runat="server" OnPageIndexChanging = "PageIndexChanging" AllowPaging = "true">
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#FFF1D4" />
    <SortedAscendingHeaderStyle BackColor="#B95C30" />
    <SortedDescendingCellStyle BackColor="#F1E5CE" />
    <SortedDescendingHeaderStyle BackColor="#93451F" />
</asp:GridView>
</asp:Content>
