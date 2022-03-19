<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationForm.aspx.cs" Inherits="ValidationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form</title>
    <style type="text/css">
        .auto-style1 {
            width: 376px;
        }
        .auto-style2 {
            height: 29px;
        }
        .auto-style3 {
            width: 376px;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Student Enrollment Form</h1>
        <table>
            <tr>
                <td></td>
                <td></td>
                <td colspan="3">
                    <asp:Label runat="server" ID="lblMessage"  Text=""/>
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>*</td>
                <td>Name</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rvfName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Enrollment No.</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEnrollment"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvEnrollment" runat="server" ControlToValidate="txtEnrollment" Display="Dynamic" ErrorMessage="Enter Enrollment No." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Institute</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:DropDownList runat="server" ID="dplInstitute">
                        <asp:ListItem Value="-1" Text="Select Institute"></asp:ListItem>
                        <asp:ListItem Value="DIET" Text="Darshan Institute of Engineering & Technology"></asp:ListItem>
                        <asp:ListItem Value="DIETDS" Text="Darshan Institute of Engineering & Technology for Diploma"></asp:ListItem>
                        <asp:ListItem Value="SOE" Text="School of Engineering - Darshan University"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" ControlToValidate="dplInstitute" Display="Dynamic" ErrorMessage="Select Institute" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Department</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDepartment">
                        <asp:ListItem Value="-1" Text="Select Department"></asp:ListItem>
                        <asp:ListItem Value="CE" Text="Computer Engineering"></asp:ListItem>
                        <asp:ListItem Value="ME" Text="Mechanical Engineering"></asp:ListItem>
                        <asp:ListItem Value="EE" Text="Electrical Engineering"></asp:ListItem>
                        <asp:ListItem Value="CI" Text="Civil Engineering"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" Display="Dynamic" ErrorMessage="Select Department" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Birth Date</td>
                <td>:</td>
                <td>
                    &nbsp;</td>

                <td>
                    <asp:TextBox ID="txtBirth" runat="server"></asp:TextBox>
                </td>

                <td class="auto-style1">
                    <asp:CompareValidator ID="cvBirth" runat="server" ControlToValidate="txtBirth" Display="Dynamic" ErrorMessage="Enter Valid Date" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                </td>

            </tr>
            <tr>
                <td></td>
                <td>Semester</td>
                <td>:</td>
                <td>
                    &nbsp;</td>

                <td>
                    <asp:TextBox ID="txtSemester" runat="server"></asp:TextBox>
                </td>

                <td class="auto-style1">
                    <asp:RangeValidator ID="rvSemester" runat="server" ControlToValidate="txtSemester" Display="Dynamic" ErrorMessage="Enter Valid Semester(Between 1 to 8)" ForeColor="Red" MaximumValue="8" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </td>

            </tr>
            <tr>
                <td></td>
                <td>Email</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">*</td>
                <td class="auto-style2">Mobile No.</td>
                <td class="auto-style2">:</td>
                <td class="auto-style2">
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Enter Mobile No." ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvMobilenUmber" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" MaximumValue="9999999999" MinimumValue="6000000000"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Password</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Passowrd" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td> Re-type Password</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtReTypePass" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvReType" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Re - enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvReTypePassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtReTypePass" Display="Dynamic" ErrorMessage="Re Type Password" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td colspan="3">
                    <asp:Checkbox runat="server" ID="chkAgree"  Text="Agree Terms & Condition" OnCheckedChanged="chkAgree_CheckedChanged"/>
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td colspan="3">
                    <asp:Button runat="server" ID="btnSave"  Text="Save" OnClick="btnSave_Click"/>
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
