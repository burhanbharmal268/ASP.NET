<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadDemo.aspx.cs" Inherits="FileUpload_FileUploadDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>Select a File to Upload:<br />
        <asp:FileUpload ID="fuFile" runat="server" /><br />
        <asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click" />
         <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" /><br />
        <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
     </div>
    </form>
</body>
</html>
