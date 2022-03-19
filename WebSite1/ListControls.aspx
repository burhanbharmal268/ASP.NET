<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListControls.aspx.cs" Inherits="ListControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" enableviewstate="True">
    <title>Dummy List</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlCountry" runat="server">
            <asp:ListItem Value="91">India</asp:ListItem>
            <asp:ListItem Value="92">China</asp:ListItem>
            <asp:ListItem Value="93">Sri Lanka</asp:ListItem>
            <asp:ListItem Value="94">United Kingdom</asp:ListItem>
            <asp:ListItem Value="95">South Korea</asp:ListItem>
            <asp:ListItem Value="96">USA</asp:ListItem>

        </asp:DropDownList><br />
        <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" /><br />
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
    </div>
    </form> 
</body>
</html>
