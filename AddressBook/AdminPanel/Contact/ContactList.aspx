<%@ Page Title="Contact List" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact List</h2>
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
                <asp:HyperLink runat="server" ID="hplAddContact" Text="Add New Contact" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField DataField="ContactID" HeaderText="ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No." />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />



                    

                                                            
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

