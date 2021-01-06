<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="ListofAssets.aspx.cs" Inherits="EnAbleIndiaAssets.ListofAssets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
   
   <div runat="server" CssClass="p-2 m-4">
            <asp:Button ID="Button1" runat="server" Text="Select Columns" onClick="Button1_Click" CssClass="btn m-2" />
            <asp:DropDownList ID="DropDownList1" runat="server" autopostback="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="btn btn-light m-2">
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-light p-2 m-2"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" CssClass="btn btn-light p-2 m-2" /> <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server" CssClass="table text-light columnscss" OnRowDataBound="OnRowDataBound" HorizontalAlign="Center" CellPadding="10" ForeColor="#333333" GridLines="None" >
                
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                
                <Columns>
                    <asp:TemplateField HeaderText="ASSET PHOTO">
                        <ItemTemplate>
                             <asp:Image ID="AssetsPhoto" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>

    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
