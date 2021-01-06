<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="EnAbleIndiaAssets.GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
   
   <div runat="server" style="text-align:left;" CssClass="container-fluid">
            <asp:Button ID="Button1" runat="server" Text="Select Columns" onClick="Button1_Click" CssClass="btn btn-light p-2 m-2" />
            <asp:DropDownList ID="DropDownList1" runat="server" autopostback="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="btn btn-light p-2 m-2">
                
            </asp:DropDownList>
       <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-light p-2 m-2"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" CssClass="btn btn-light p-2 m-2" /> <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server" CssClass="table text-light columnscss" OnRowDataBound="OnRowDataBound" >
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <Columns>
                    <asp:TemplateField HeaderText="ASSET PHOTO">
                        <ItemTemplate>
                             <asp:Image ID="AssetsPhoto" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        </div>

    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
