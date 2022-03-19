<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Day3.aspx.cs" Inherits="Day3" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Control</title>

    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 align="center">LIST CONTROL</h1><hr />
                <div>
                     <asp:Label ID="lblError" runat="server" Text="" ToolTip="Error Message or Success Message"></asp:Label>
                     <br /><br />
                </div>
            <div>
                <asp:Label ID="lblNewValue" runat="server" Text="New Value" ToolTip="Data of Country"></asp:Label>
                <br />
                <div>
                    <asp:Label ID="lblNewCountryName" runat="server" Text="Country Name :" ToolTip="Enter a name of country"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtCountryName" runat="server" ></asp:TextBox>
                    <br /><br />
                    <asp:Label ID="lblNewCountryCode" runat="server" Text="Country Code :" ToolTip="Enter a greater than zero number and it's maximum limit is 3 digit"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCountryCode" runat="server" MaxLength="3" TextMode="Number" ></asp:TextBox><br /><br />
                    
                </div>
            </div>
            
            <div id="divOldValue" runat="server" visible="false">
                <asp:Label ID="lblOldValue" runat="server" Text="Old Value" ToolTip="Data of Country for change request"></asp:Label>
                <div>
                    <asp:Label ID="lblOldCountryName" runat="server" Text="Country Name :" ToolTip="Enter a name of country"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txt1CountryName" runat="server"></asp:TextBox>
                    <br /><br />
                    <asp:Label ID="lblOldCountryCode" runat="server" Text="Country Code :" ToolTip="Enter a greater than zero number and it's maximum limit is 3 digit"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt1CountryCode" runat="server" MaxLength="3" TextMode="Number"></asp:TextBox>
                    <br /><br />
                </div>
            </div>
            
            <div>
                <asp:Button ID="btnAdd" runat="server" Text="Add Item" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRemove" runat="server" Text="Remove Item" OnClick="btnRemove_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnChange" runat="server" Text="Change Item" OnClick="btnChange_Click" visible="true"/>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" visible="false" />&nbsp;&nbsp;&nbsp;&nbsp;
                <br /><br />
            </div>
            <hr />
            <div >
                <asp:ListBox ID="lstbOriginalList" runat="server" ViewStateMode="Enabled" ></asp:ListBox><br /><br />
                <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" /><br />
                <br />
                <asp:Label ID="lblDisplay" runat="server" ToolTip="Display all Record" ViewStateMode="Disabled"></asp:Label>
            </div>
            <div ">
                    <asp:Button ID="btnSingleLeftToRight" runat="server" Text=">" OnClick="btnSingleLeftToRight_Click" Width="40px" />
                    <br />
                    <asp:Button ID="btnMultiLeftToRight" runat="server" Text=">>" OnClick="btnMultiLeftToRight_Click" Width="40px" />
                    <br />
                    <asp:Button ID="btnSingleRightToLeft" runat="server" Text="<" OnClick="btnSingleRightToLeft_Click" Width="40px" />
                    <br />
                    <asp:Button ID="btnMultiRightToLeft" runat="server" Text="<<" OnClick="btnMultiRightToLeft_Click" Width="40px" />
            </div>
            <div ">
                <asp:ListBox ID="lstbCopyList" runat="server" ></asp:ListBox>
            </div>
            </div>
        </div>
    </form>
    

</body>
</html>
