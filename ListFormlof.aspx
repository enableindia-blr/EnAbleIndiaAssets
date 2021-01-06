<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListFormlof.aspx.cs" Inherits="EnAbleIndiaAssets.ListFormlof" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Form</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" >
     <div id="mydiv" runat="server" class="align-content-end">
        <div runat="server" id="chkbox" >
            <asp:CheckBoxList ID="checkboxlist1" runat="server" AutoPostBack="false"  RepeatColumns="2" Enabled="true" CssClass="mx-4 px-4 my-4 py-4" CellPadding="4" CellSpacing="4">                
            </asp:CheckBoxList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Ok" onClick ="Button1_Click" CssClass="btn btn-info mx-4 py-1 px-4"/>
        <asp:Button ID="Button2" runat="server" Text="Cancel" onClick ="Button2_Click" CssClass="btn btn-info mx-4 py-1"/>
        <asp:label id="Message" runat="server" AssociatedControlID="checkboxlist1"/>
    </div>
   </form>
</body>
</html>
