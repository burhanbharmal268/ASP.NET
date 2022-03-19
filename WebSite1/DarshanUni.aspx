<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DarshanUni.aspx.cs" Inherits="DarshanUni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Select Gender:
        <asp:RadioButton ID="rdbtnMale" runat="server"  GroupName="gender" Text="Male" OnCheckedChanged="rdbtnMale_CheckedChanged"/>
        <asp:RadioButton ID="rdbtnFemale" runat="server" GroupName="gender" Text="Female" OnCheckedChanged="rdbtnFemale_CheckedChanged"/>  <br />
        <asp:Button ID="btnGender" runat="server" Text="Click Here" OnClick="btnGender_Click" /><br /><br />
        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
        <hr /><br />
        <asp:LinkButton ID="lbtnClickMe" runat="server" OnClick="lbtnClickMe_Click">Click Me</asp:LinkButton><br />
        <asp:ImageButton ID="imgbtnClickMe" runat="server" AlternateText="Darshan University logo" ToolTip="Darshan" ImageUrl="~/Images/DU1.jfif" OnClick="imgbtnClickMe_Click"/><br/>
        <asp:Button ID="btnClickMe" runat="server" Text="Click Me" OnClick="btnClickMe_Click" /><br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
        <asp:HyperLink ID="hlDarshanCollege" runat="server"></asp:HyperLink><br />
        <asp:Image ID="imgDarshanUniversity" runat="server" ToolTip="Darshan University" AlternateText="Darshan University" Width="300px"/><br />
        <asp:HyperLink ID="hlHomePage" runat="server" NavigateUrl="~/DarshanHomePage.aspx" Target="_blank" ToolTip="Darshan University Homepage">Darshan Homepage</asp:HyperLink>
    </div>
    </form>
</body>
</html>
