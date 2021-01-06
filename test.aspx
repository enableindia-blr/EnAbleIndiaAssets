<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="EnAbleIndiaAssets.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    public void Page_Load(Object sender, EventArgs e)
    {
        // Define the name and type of the client script on the page.
        String csName = "ButtonClickScript";
        Type csType = this.GetType();

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        // Check to see if the client script is already registered.
        if (!cs.IsClientScriptBlockRegistered(csType, csName))
        {
            StringBuilder csText = new StringBuilder();
            string message = "<input type=\"text\"" + "/" + ">" +";";
            csText.Append("<script type=\"text/javascript\"> function DoClick() {");
            csText.Append("alert('");
            csText.Append(message);
            csText.Append("')};</");
            csText.Append("script>");
            cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
        }
    }
</script>
<html  >
  <head>
    <title>RegisterClientScriptBlock Example</title>
  </head>
  <body>
     <form id="Form1"
         runat="server">
        <input type="text" id="Message" /> <input type="button" value="ClickMe" onclick="DoClick()" />
     </form>
  </body>
</html>