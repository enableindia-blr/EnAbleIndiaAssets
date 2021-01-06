<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modaltest.aspx.cs" Inherits="EnAbleIndiaAssets.Modaltest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modal Test</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</head>
<body>
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
        Launch demo modal
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div runat="server" style="background-color:aliceblue;width:450px;height:250px;text-align:center;margin-top:10%;margin-left:30%; border-radius:5px;padding-top:20px;">
                        <asp:Login ID="Login1" runat="server" CreateUserText="Sign Up for a New Account at EnAble India" CreateUserUrl="~/Register.aspx" DestinationPageUrl="~/Dashboard.aspx"  Height="159px" Width="400px" CssClass="input-group p-3" TitleText="" OnLoggedIn="OnLoggedIn" style="padding-top:50px; mt-3">
                        <CheckBoxStyle CssClass="pdd-2" />
                        <InstructionTextStyle CssClass="pt-2 mt-5" />
                        <LabelStyle BorderColor="Red" CssClass="pt-3 mt-3 text-right" />
                        <TextBoxStyle CssClass="p-2 m-3" />
                        <TitleTextStyle CssClass="p-2 m-3" />
                        </asp:Login>
                        <!--<asp:LoginStatus ID="LoginStatus1" runat="server" />-->
                    </div>
                </div>
                <div class="modal-footer">
                    <!--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="login_asset();">Save changes</button>-->
                </div>
            </div>
        </div>
    </div>
</body>
</html>
