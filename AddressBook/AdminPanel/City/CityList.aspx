<%@ Page Title="City List" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div> 
                <asp:HyperLink runat="server" ID="hplAddCity" Text="Add New City" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvCity" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CityID" HeaderText="ID" />
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                    <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                    <asp:BoundField DataField="PINCode" HeaderText="PIN Code" />
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

