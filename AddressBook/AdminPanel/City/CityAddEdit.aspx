<%@ Page Title="City Add Edit" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add / Edit Page</h2>
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
                    State
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control">

                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                    City Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                    STD Code :
                 </div>
                 <div class="col-md-8">
                    <asp:TextBox ID="txtSTDCode" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
            </div><br /><br />
            <div class="row">
                <div class="col-md-4">
                    PIN Code :
                 </div>
                 <div class="col-md-8">
                    <asp:TextBox ID="txtPINCode" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
            </div><br /><br />
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" id="btnSave" Text="Save" OnClick="btnSave_Click"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

