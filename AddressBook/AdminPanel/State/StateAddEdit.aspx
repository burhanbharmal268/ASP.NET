<%@ Page Title="State Add Edit" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>State Add / Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    Country
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control">

                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                    State Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                    State Code :
                 </div>
                 <div class="col-md-8">
                    <asp:TextBox ID="txtStateCode" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
            </div><br /><br />
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" id="btnSave" Text="Save" OnClick="btnSave_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

