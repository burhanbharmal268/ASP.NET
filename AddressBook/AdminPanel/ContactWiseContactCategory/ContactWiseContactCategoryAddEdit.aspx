<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactWiseContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactWiseContactCategory_ContactWiseContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
    <div class="col-md-8">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Wise Add / Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-4">
            Contact Name :
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="txtContactWiseName" runat="server" CssClass="form-control" placeholder="Enter Contact Name"></asp:TextBox>
        </div>
    </div><br /><br />

    <div class="row">
        <div class="col-md-4">
            Upload File :
        </div>
        <div class="col-md-8">
            <asp:FileUpload runat="server" ID="fuContactWisePhotoPath"/>
        </div>
    </div><br /><br />
    </div>

    <div class="col-md-4">
        <div class="row">
            <div class="col-md-12">
                <h5>Contact Category:</h5>
                <asp:CheckBoxList runat="server" ID="cblContactWiseContactCategoryID" />
            </div>
        </div>
    </div>

    </div>

    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave"  Text="Save" OnClick="btnSave_Click"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel"  CssClass="btn btn-danger btn-sm" />
        </div>
    </div>
</asp:Content>

