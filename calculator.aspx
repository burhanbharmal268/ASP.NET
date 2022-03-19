<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calculator.aspx.cs" Inherits="calculator"  Title="Calculator"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Hello, Welcome to the Calculator!!<br />
        <br />
        Number 1 :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Operator :
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        Number 2 :<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
