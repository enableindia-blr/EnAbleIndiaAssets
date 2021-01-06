<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="GridViewTest.aspx.cs" Inherits="EnAbleIndiaAssets.GridViewTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>  
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">  
            <Columns>  
                <asp:BoundField DataField="Id" HeaderText="S.No." />  
                <asp:BoundField DataField="Name" HeaderText="Name" />  
                <asp:BoundField DataField="Address" HeaderText="Address" />  
                <asp:BoundField DataField="Country" HeaderText="Country" />  
                <asp:CommandField ShowEditButton="true" />  
                <asp:CommandField ShowDeleteButton="true" /> </Columns>  
        </asp:GridView>  
    </div>  
    <div>  
        <asp:Label ID="lblresult" runat="server"></asp:Label>  
    </div>
</asp:Content>
