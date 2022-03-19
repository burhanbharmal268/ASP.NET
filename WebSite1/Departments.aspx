<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Departments.aspx.cs" Inherits="Departments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Radio</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div title="Select Your College" runat="server">
    Select Your College :
        <asp:RadioButton ID="rdbtnDiet" runat="server" GroupName="college" Text="DIET"/>
        <asp:RadioButton ID="rdbtnDietDS" runat="server" GroupName="college" Text="DIETDS"/><br /><br />
        <asp:Button ID="btnClickMe" runat="server" Text="Click Me" OnClick="btnClickMe_Click" /><br /><br /><hr />
            </div>
        <asp:Label ID="lblSelectDiet" runat="server" Text="On Selection Of DIET :" Visible="false" ToolTip="On selection of Diet"></asp:Label><br />
        <asp:RadioButton ID="rdbtnce" runat="server" Text="Computer Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />
        <asp:RadioButton ID="rdbtnme" runat="server" Text="Mechanical Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />
        <asp:RadioButton ID="rdbtnee" runat="server" Text="Electrical Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />
        <asp:RadioButton ID="rdbtnci" runat="server" Text="Civil Engineering - Degree" Visible="false" GroupName="degreeeng"/><br />

        <asp:Label ID="lblSelectDIETDS" runat="server" Text="On Selection Of DIETDS :" Visible="false" ToolTip="On selection of Diploma"></asp:Label><br />
        <asp:RadioButton ID="rdbtndce" runat="server" Text="Diploma in Computer Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:RadioButton ID="rdbtndme" runat="server" Text="Diploma in Mechanical Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:RadioButton ID="rdbtndee" runat="server" Text="Diploma in Electrical Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:RadioButton ID="rdbtndci" runat="server" Text="Diploma in Civil Engineering" GroupName="dipeng" Visible="false"/><br />
        <asp:Button ID="btnClickMe1" runat="server" Text="Click Me" OnClick="btnClickMe1_Click" Visible="false"/><br /><br /><hr />
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
    </div>
    </form>
</body>
</html>
