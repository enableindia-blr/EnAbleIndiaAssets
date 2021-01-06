<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="GridViewSLCOL.aspx.cs" Inherits="EnAbleIndiaAssets.GridViewSLCOL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--<asp:Button ID="Button1" runat="server" Text="Select Columns" onClick="Button1_Click" CssClass="btn" />-->
    <asp:DropDownList ID="DropDownList1" runat="server" autopostback="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="btn btn-light p-1 my-2">        
    </asp:DropDownList>
    
    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="OnRowDataBound" CssClass="table text-light columnscss" DataKeyNames="SL_NO" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSorting="GridView1_Sorting" HorizontalAlign="Center">
        <Columns>
            <asp:CommandField ShowEditButton="true" HeaderText="EDIT"/>  
            <asp:CommandField ShowDeleteButton="true" HeaderText="DELETE" />
            <asp:TemplateField HeaderText="ASSET PHOTO">
                <ItemTemplate>
                     <asp:Image ID="AssetsPhoto" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns> 
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
