<%@ Page Title="Country List" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class="col-md-12">
            <h2>Country List</h2>
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
                <asp:HyperLink runat="server" ID="hplAddCountry" Text="Add New Country" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
                <asp:GridView ID="gvCountry" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CountryID" HeaderText="ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Code" />
                </Columns>
            </asp:GridView>
            </div>
            
        </div>
    </div>
</asp:Content>

