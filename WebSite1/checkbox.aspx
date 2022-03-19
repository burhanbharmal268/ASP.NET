<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkbox.aspx.cs" Inherits="checkbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkbox</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div runat="server" title="Select Your College">
    Select Your College :
        <asp:Checkbox ID="chkDiet" runat="server" GroupName="college" Text="DIET"/>
        <asp:Checkbox ID="chkDietDS" runat="server" GroupName="college" Text="DIETDS"/><br /><br />
        <asp:Button ID="btnClickMe" runat="server" Text="Click Me" OnClick="btnClickMe_Click" /><br /><br /><hr />
        </div>
        <asp:Label ID="lblSelectDiet" runat="server" Text="On Selection Of DIET :" ToolTip="On selection of DIET" Visible="false"></asp:Label><br />
        <asp:Checkbox ID="chkce" runat="server" Text="Computer Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />
        <asp:Checkbox ID="chkme" runat="server" Text="Mechanical Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />
        <asp:Checkbox ID="chkee" runat="server" Text="Electrical Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />
        <asp:Checkbox ID="chkci" runat="server" Text="Civil Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />

        <asp:Label ID="lblSelectDIETDS" runat="server" Text="On Selection Of DIETDS :"  ToolTip="On selection of Diploma" Visible="false"></asp:Label><br />
        <asp:Checkbox ID="chkdce" runat="server" Text="Diploma in Computer Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:Checkbox ID="chkdme" runat="server" Text="Diploma in Mechanical Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:Checkbox ID="chkdee" runat="server" Text="Diploma in Electrical Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:Checkbox ID="chkdci" runat="server" Text="Diploma in Civil Engineering" GroupName="dipeng" Visible="false"/><br /><hr />
        <asp:Checkbox ID="chkselectall" runat="server" Text="Select All" Visible="false"/><br />
        <asp:Checkbox ID="chkresetall" runat="server" Text="Reset All" Visible="false"/><br />
        <asp:CheckBox ID="chkinverse" runat="server" Text="Inverse Selection" Visible="false"/><hr />
 
        <asp:Button ID="btnClickMe1" runat="server" Text="Click Me" Visible="false" OnClick="btnClickMe1_Click"/><br /><br /><hr />
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
    </div>
    </form>
</body>
</html>