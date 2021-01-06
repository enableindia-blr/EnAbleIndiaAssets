<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check_In.aspx.cs" Inherits="EnAbleIndiaAssets.Check_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check In Assets</title>
    <!--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">-->
    <link href="~/CSS/bootstrap.css" rel="stylesheet" runat="server"/>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-group align-items-center" >
        <div runat="server" >
            
        <div class="text-center">
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-group m-2 p-1"></asp:TextBox><asp:Button ID="Button1" CssClass="btn m-2 p-2" runat="server" Text="Search" OnClick="Button1_Click"/>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div runat="server" class="container-fluid align-items-center p-2 m-2">  
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="SELECT DATA" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" CssClass="text-right"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Id" HeaderText="Sl No" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION" />
                    <asp:BoundField DataField="ASSET_NAME" HeaderText="ASSET_NAME" SortExpression="ASSET_NAME" />
                    <asp:BoundField DataField="ASSIGNED_TO" HeaderText="ASSIGNED TO" SortExpression="ASSIGNED_TO" NullDisplayText=" " />
                    <asp:BoundField DataField="ASSIGNED_DATE" HeaderText="ASSIGNED DATE" SortExpression="ASSIGNED_DATE" NullDisplayText=" " />
                    <asp:BoundField DataField="RETURN_DATE" HeaderText="RETURN_DATE" SortExpression="RETURN_DATE" NullDisplayText=" " />
                    <asp:BoundField DataField="RETURNED_BY" HeaderText="RETURNED_BY" SortExpression="RETURNED_BY" NullDisplayText=" " />
                    <asp:BoundField DataField="RETURNED_DATE" HeaderText="RETURNED_DATE" SortExpression="RETURNED_DATE" NullDisplayText=" "/>
                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" NullDisplayText=" "/>                    
                    <asp:BoundField DataField="CATEGORY" HeaderText="CATEGORY" SortExpression="CATEGORY" NullDisplayText=" " />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="SELECT DATA" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" CssClass="text-right"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="Sl No" InsertVisible="False" ReadOnly="False" SortExpression="Id" />
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION" />
                    <asp:BoundField DataField="ASSET_NAME" HeaderText="ASSET_NAME" SortExpression="ASSET_NAME" />
                    <asp:BoundField DataField="ASSIGNED_TO" HeaderText="ASSIGNED_TO" SortExpression="ASSIGNED_TO" NullDisplayText=" "/>
                    <asp:BoundField DataField="ASSIGNED_DATE" HeaderText="ASSIGNED_DATE" SortExpression="ASSIGNED_DATE" NullDisplayText=" "/>
                    <asp:BoundField DataField="RETURN_DATE" HeaderText="RETURN_DATE" SortExpression="RETURN_DATE" NullDisplayText=" " />
                    <asp:BoundField DataField="RETURNED_BY" HeaderText="RETURNED_BY" SortExpression="RETURNED_BY" NullDisplayText=" "/>
                    <asp:BoundField DataField="RETURNED_DATE" HeaderText="RETURNED_DATE" SortExpression="RETURNED_DATE" NullDisplayText=" "/>
                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" NullDisplayText=" "/>                    
                    <asp:BoundField DataField="CATEGORY" HeaderText="CATEGORY" SortExpression="CATEGORY" NullDisplayText=" " />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>" SelectCommand="SELECT * FROM [Check_In_Out]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AssetConnectionString1 %>" SelectCommand="SELECT * FROM [Check_Out_In]"></asp:SqlDataSource>
        <div id="tablediv" runat="server" visible="false">
            <asp:Table ID="Table1" runat="server" CssClass="table">                
                <asp:TableRow>
                    <asp:TableCell>
                        <div runat="server" class="text-right p-1">
                        <asp:Label ID="ReturnedBy" runat="server" Text="Returned By:" CssClass="input-control text-right"></asp:Label>
                    </div>
                            </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox2" runat="server" Text="" Enabled="false" CssClass="input-control text-left p-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow>
                    <asp:TableCell>
                        <div runat="server" class="text-right p-1">
                        <asp:Label ID="ReturnedDate" runat="server" Text="Returned Date:" CssClass="input-control text-right"></asp:Label>
                            </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="input-control text-left p-1" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox3" ></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div runat="server" class="text-right p-1">
                        <asp:Label ID="Status" runat="server" Text="Status:" CssClass="input-control text-right"></asp:Label>
                            </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox4" runat="server" Text="Checked-In" Enabled="false" CssClass="input-control text-left p-1"> </asp:TextBox>
                    </asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div runat="server" class="text-right p-1">
                        <asp:Label ID="Label2" runat="server" Text="Description: " CssClass="input-control text-right"></asp:Label>
                            </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox5" runat="server" Text="" Enabled="false" CssClass="input-control text-left p-1"> </asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div runat="server" class="text-right p-1">
                        <asp:Label ID="Label3" runat="server" Text="Email-Id: " CssClass="input-control text-right"></asp:Label>
                            </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox7" runat="server" Text="" Enabled="true" CssClass="input-control text-left p-1"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>  
            </asp:Table>
                </div>
            <div runat="server" class="text-center">
                <span runat="server" style="margin-right:150px">
            <asp:Button type="Button" runat="server" Text="Submit" id="Submit" OnClick="Submit_Click" CssClass="btn btn-light" Visible="false"/>
                    </span>
                <span runat="server">
                    <asp:Button  runat="server" Text="Add Assets" CssClass="btn mx-5" ID="AddAssets" OnClick="GetSelectedRecords"/>
            <asp:Button type="Button" runat="server" Text="Cancel" id="Cancel" OnClick="Cancel_Click" CssClass="btn btn-light"/>
                </span>
                </div>
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </div>
        </div>
    </form>
</body>
</html>
