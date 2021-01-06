<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEIAssets.aspx.cs" Inherits="EnAbleIndiaAssets.AddEIAssets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <title>Add TextBoxes and Labels Dynamically</title>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-control ">
        <div id="form1div" runat="server">           
            
        </div>
        <div class="input-group m-2 p-2">
            <div>
                <asp:Label ID="Site" runat="server" Text="Site: "></asp:Label><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:Label ID="Category" runat="server" Text="Category: "></asp:Label><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="Department" runat="server" Text="Department: "></asp:Label><asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                <asp:Label ID="Locations" runat="server" Text="Locations: "></asp:Label><asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="input-group m-2 p-2">
            <asp:FileUpload ID="AssetPhoto" runat="server" />
        </div>
        <asp:Label ID="Message" runat="server" Text="Status"></asp:Label>   
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Cancel"/>
    </form>
    
</body>
</html>
